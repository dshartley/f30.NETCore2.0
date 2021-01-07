USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayGamesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayGames]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGamesInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlaySubsetID [int],
	@DateCreated [datetime],
	@Name [nvarchar](250)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayGames]
           ([RelativeMemberID],
			[PlaySubsetID],
			[DateCreated],			
			[Name])
     VALUES
           (@RelativeMemberID,
			@PlaySubsetID,
			@DateCreated,
			@Name)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayGamesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pg.[ID],
			pg.[RelativeMemberID],
			pg.[PlaySubsetID],
			pg.[DateCreated],
			pg.[Name]
	FROM	[f30-data].[dbo].[PlayGames] pg
			ORDER BY pg.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGamesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pg.[ID],
			pg.[RelativeMemberID],
			pg.[PlaySubsetID],
			pg.[DateCreated],
			pg.[Name]
	FROM	[f30-data].[dbo].[PlayGames] pg
	WHERE	pg.[ID] = @ID
	ORDER BY pg.[ID] DESC
	
							
END


GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesSelectByIDLoadRelationalTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesSelectByIDLoadRelationalTables]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGamesSelectByIDLoadRelationalTables]
(
	@ID int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;
				
	-- Create a table variable for the PlayGames
	DECLARE @PG TABLE(
		ID int,
		RelativeMemberID int,
		PlaySubsetID int,
		DateCreated datetime,
		Name nvarchar(250))
			
	INSERT INTO @PG
	SELECT	pg.[ID],
			pg.[RelativeMemberID],
			pg.[PlaySubsetID],
			pg.[DateCreated],
			pg.[Name]
	FROM	[f30-data].[dbo].[PlayGames] pg
	WHERE	pg.[ID] = @ID
	ORDER BY pg.[ID] DESC

	-- Select PlayGames
	SELECT * FROM @PG pg
	ORDER BY pg.[ID] DESC
			
	DECLARE @PlaySubsetID int
	SET @PlaySubsetID = (SELECT TOP(1) pg.[PlaySubsetID] FROM @PG pg WHERE pg.[ID] = @ID)

	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayGameData, PlayAreaTokens, PlayAreaCells, PlayAreaCellTypes, PlayAreaTileTypes

		-- Select PlayGameData
		SELECT	pgd.[ID],
				pgd.[RelativeMemberID],
				pgd.[PlayGameID],
				pgd.[DateLastPlayed],
				pgd.[OnCompleteData],
				pgd.[AttributeData]
		FROM	[f30-data].[dbo].[PlayGameData] pgd
				INNER JOIN @PG pg ON pgd.[PlayGameID] = pg.[ID]
		ORDER BY pgd.[ID] DESC

		-- Select PlayAreaTokens
		SELECT	pat.[ID],
				pat.[RelativeMemberID],
				pat.[PlayGameID],
				pat.[Column],
				pat.[Row],
				pat.[ImageName],
				pat.[TokenAttributesString]
		FROM	[f30-data].[dbo].[PlayAreaTokens] pat
				INNER JOIN @PG pg ON pat.[PlayGameID] = pg.[ID]
		ORDER BY pat.[ID] DESC

		-- Select PlayAreaCells byIsSpecialYN
		SELECT	pac.[ID],
				pac.[RelativeMemberID],
				pac.[PlayGameID],
				pac.[CellTypeID],
				pac.[Column],
				pac.[Row],
				pac.[RotationDegrees],
				pac.[ImageName],
				pac.[CellAttributesString],
				pac.[CellSideAttributesString]
		FROM	[f30-data].[dbo].[PlayAreaCells] pac
				INNER JOIN [f30-data].[dbo].[PlayAreaCellTypes] pact ON pact.[ID] = pac.[CellTypeID]
		WHERE	pac.[PlayGameID] IN (SELECT pg.[ID] FROM @PG pg)
				AND pact.[IsSpecialYN] = 1
		ORDER BY pac.[ID] DESC

		-- Select PlayAreaCellTypes
		SELECT	pact.[ID],
				pact.[PlaySubsetID],
				pact.[Name],
				pact.[IsSpecialYN],
				pact.[DeckWeighting],
				pact.[ImageName],
				pact.[BlockedContentPositionsString],
				pact.[CellAttributesString],
				pact.[CellSideAttributesString],
				pact.[IndexDefinitionData],
				pact.[VersionID],
				pact.[VersionDate],
				pact.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayAreaCellTypes] pact
		WHERE	pact.[PlaySubsetID] = @PlaySubsetID
		ORDER BY pact.[ID] DESC

		-- Select PlayAreaTileTypes
		SELECT	patt.[ID],
				patt.[PlaySubsetID],
				patt.[Name],
				patt.[IsSpecialYN],
				patt.[DeckWeighting],
				patt.[ImageName],
				patt.[WidthPixels],
				patt.[HeightPixels],
				patt.[Position],
				patt.[PositionFixToCellRotationYN],
				patt.[TileAttributesString],
				patt.[TileSideAttributesString],
				patt.[IndexDefinitionData],
				patt.[VersionID],
				patt.[VersionDate],
				patt.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayAreaTileTypes] patt
		WHERE	patt.[PlaySubsetID] = @PlaySubsetID
		ORDER BY patt.[ID] DESC

	END

END


GO





USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesSelectByIDForPlayAreaPathBuilder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesSelectByIDForPlayAreaPathBuilder]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGamesSelectByIDForPlayAreaPathBuilder]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;
				
	-- Create a table variable for the PlayGames
	DECLARE @PG TABLE(
		ID int,
		RelativeMemberID int,
		PlaySubsetID int,
		DateCreated datetime,
		Name nvarchar(250))
			
	INSERT INTO @PG
	SELECT	pg.[ID],
			pg.[RelativeMemberID],
			pg.[PlaySubsetID],
			pg.[DateCreated],
			pg.[Name]
	FROM	[f30-data].[dbo].[PlayGames] pg
	WHERE	pg.[ID] = @ID
	ORDER BY pg.[ID] DESC

	-- Select PlayGames
	SELECT * FROM @PG pg
	ORDER BY pg.[ID] DESC
			
	DECLARE @PlaySubsetID int
	SET @PlaySubsetID = (SELECT TOP(1) pg.[PlaySubsetID] FROM @PG pg WHERE pg.[ID] = @ID)

	-- Load Relational Tables:
	-- PlayAreaCells, PlayAreaCellTypes

	-- Select PlayAreaCells
	SELECT	pac.[ID],
			pac.[RelativeMemberID],
			pac.[PlayGameID],
			pac.[CellTypeID],
			pac.[Column],
			pac.[Row],
			pac.[RotationDegrees],
			pac.[ImageName],
			pac.[CellAttributesString],
			pac.[CellSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaCells] pac
	WHERE	pac.[PlayGameID] IN (SELECT pg.[ID] FROM @PG pg)
	ORDER BY pac.[ID] DESC

	-- Select PlayAreaCellTypes
	SELECT	pact.[ID],
			pact.[PlaySubsetID],
			pact.[Name],
			pact.[IsSpecialYN],
			pact.[DeckWeighting],
			pact.[ImageName],
			pact.[BlockedContentPositionsString],
			pact.[CellAttributesString],
			pact.[CellSideAttributesString],
			pact.[IndexDefinitionData],
			pact.[VersionID],
			pact.[VersionDate],
			pact.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaCellTypes] pact
	WHERE	pact.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pact.[ID] DESC


END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesSelectByRelativeMemberID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesSelectByRelativeMemberID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGamesSelectByRelativeMemberID]
(
	@RelativeMemberID int,
	@LoadLatestOnlyYN bit,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayGames
	DECLARE @PG TABLE(
		ID int,
		RelativeMemberID int,
		PlaySubsetID int,
		DateCreated datetime,
		Name nvarchar(250))
			
	IF (@LoadLatestOnlyYN = 1)
	BEGIN

		INSERT INTO @PG
		SELECT	TOP(1) 
				pg.[ID],
				pg.[RelativeMemberID],
				pg.[PlaySubsetID],
				pg.[DateCreated],
				pg.[Name]
		FROM	[f30-data].[dbo].[PlayGames] pg
				INNER JOIN [f30-data].[dbo].[PlayGameData] pgd ON pg.[ID] = pgd.[PlayGameID]
		WHERE	pg.[RelativeMemberID] = @RelativeMemberID
		ORDER BY pgd.[DateLastPlayed] DESC

	END
	ELSE
	BEGIN

		INSERT INTO @PG
		SELECT	pg.[ID],
				pg.[RelativeMemberID],
				pg.[PlaySubsetID],
				pg.[DateCreated],
				pg.[Name]
		FROM	[f30-data].[dbo].[PlayGames] pg
		WHERE	pg.[RelativeMemberID] = @RelativeMemberID
		ORDER BY pg.[ID] DESC

	END

	-- Select PlayGames
	SELECT * FROM @PG pg
	ORDER BY pg.[ID] DESC
			
	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- If @LoadLatestOnlyYN; PlayGameData, PlayAreaTokens, PlayAreaCells, PlayAreaCellTypes, PlayAreaTileTypes
		-- Else if !@LoadLatestOnlyYN; PlayGameData

		-- Select PlayGameData
		SELECT	pgd.[ID],
				pgd.[RelativeMemberID],
				pgd.[PlayGameID],
				pgd.[DateLastPlayed],
				pgd.[OnCompleteData],
				pgd.[AttributeData]
		FROM	[f30-data].[dbo].[PlayGameData] pgd
				INNER JOIN @PG pg ON pgd.[PlayGameID] = pg.[ID]
		ORDER BY pgd.[ID] DESC

		-- Select PlayAreaTokens
		IF (@LoadLatestOnlyYN = 1)
		SELECT	pat.[ID],
				pat.[RelativeMemberID],
				pat.[PlayGameID],
				pat.[Column],
				pat.[Row],
				pat.[ImageName],
				pat.[TokenAttributesString]
		FROM	[f30-data].[dbo].[PlayAreaTokens] pat
				INNER JOIN @PG pg ON pat.[PlayGameID] = pg.[ID]
		ORDER BY pat.[ID] DESC

		-- Select PlayAreaCells byIsSpecialYN
		IF (@LoadLatestOnlyYN = 1)
		SELECT	pac.[ID],
				pac.[RelativeMemberID],
				pac.[PlayGameID],
				pac.[CellTypeID],
				pac.[Column],
				pac.[Row],
				pac.[RotationDegrees],
				pac.[ImageName],
				pac.[CellAttributesString],
				pac.[CellSideAttributesString]
		FROM	[f30-data].[dbo].[PlayAreaCells] pac
				INNER JOIN [f30-data].[dbo].[PlayAreaCellTypes] pact ON pact.[ID] = pac.[CellTypeID]
		WHERE	pac.[PlayGameID] IN (SELECT pg.[ID] FROM @PG pg)
				AND pact.[IsSpecialYN] = 1
		ORDER BY pac.[ID] DESC

		-- Select PlayAreaCellTypes
		IF (@LoadLatestOnlyYN = 1)
		SELECT	pact.[ID],
				pact.[PlaySubsetID],
				pact.[Name],
				pact.[IsSpecialYN],
				pact.[DeckWeighting],
				pact.[ImageName],
				pact.[BlockedContentPositionsString],
				pact.[CellAttributesString],
				pact.[CellSideAttributesString],
				pact.[IndexDefinitionData],
				pact.[VersionID],
				pact.[VersionDate],
				pact.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayAreaCellTypes] pact
		WHERE	pact.[PlaySubsetID] IN (SELECT pg.[PlaySubsetID] FROM @PG pg)
		ORDER BY pact.[ID] DESC

		-- Select PlayAreaTileTypes
		IF (@LoadLatestOnlyYN = 1)
		SELECT	patt.[ID],
				patt.[PlaySubsetID],
				patt.[Name],
				patt.[IsSpecialYN],
				patt.[DeckWeighting],
				patt.[ImageName],
				patt.[WidthPixels],
				patt.[HeightPixels],
				patt.[Position],
				patt.[PositionFixToCellRotationYN],
				patt.[TileAttributesString],
				patt.[TileSideAttributesString],
				patt.[IndexDefinitionData],
				patt.[VersionID],
				patt.[VersionDate],
				patt.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayAreaTileTypes] patt
		WHERE	patt.[PlaySubsetID] IN (SELECT pg.[PlaySubsetID] FROM @PG pg)
		ORDER BY patt.[ID] DESC

	END
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGamesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGamesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayGamesUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlaySubsetID [int],
	@DateCreated [datetime],
	@Name [nvarchar](250)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayGames]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlaySubsetID] = @PlaySubsetID,
			[DateCreated] = @DateCreated,
			[Name] = @Name
	WHERE ID = @ID

END

GO
