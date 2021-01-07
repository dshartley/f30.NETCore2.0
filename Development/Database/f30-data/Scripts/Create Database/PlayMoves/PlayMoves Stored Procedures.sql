USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayMovesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayMoves]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesInsert]
(
	@ID int output,
	@PlaySubsetID int,
	@PlayReferenceData [nvarchar](max),
	@PlayReferenceActionType int,
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayMoves]
           ([PlaySubsetID],
			[PlayReferenceData],
			[PlayReferenceActionType],
			[Name],
			[ContentData],
			[OnCompleteData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@PlayReferenceData,
			@PlayReferenceActionType,
			@Name,
			@ContentData,
			@OnCompleteData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayMovesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
			ORDER BY pm.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
	WHERE	pm.[ID] = @ID
	ORDER BY pm.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
	WHERE	pm.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pm.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByPlayAreaCellTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByPlayAreaCellTypeID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByPlayAreaCellTypeID]
(
	@PlayAreaCellTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
	INNER JOIN [f30-data].[dbo].[PlayAreaCellTypePlayMoveLinks] l ON l.PlayMoveID = pm.[ID]
	WHERE	l.[PlayAreaCellTypeID] = @PlayAreaCellTypeID
	ORDER BY pm.[ID] DESC
	
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByPlayAreaTileTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByPlayAreaTileTypeID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByPlayAreaTileTypeID]
(
	@PlayAreaTileTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
	INNER JOIN [f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l ON l.PlayMoveID = pm.[ID]
	WHERE	l.[PlayAreaTileTypeID] = @PlayAreaTileTypeID
	ORDER BY pm.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByPlayAreaTileID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByPlayAreaTileID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByPlayAreaTileID]
(
	@PlayAreaTileID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	DECLARE @PlayAreaTileTypeID int
	SET @PlayAreaTileTypeID = ISNULL(	(SELECT TOP(1) pat.[TileTypeID] 
										FROM [f30-data].[dbo].[PlayAreaTiles] pat 
										WHERE pat.[ID] = @PlayAreaTileID), 0)

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
	INNER JOIN [f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l ON l.PlayMoveID = pm.[ID]
	WHERE	l.[PlayAreaTileTypeID] = @PlayAreaTileTypeID
	ORDER BY pm.[ID] DESC
	
							
END


GO





USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByPlayChallengeTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByPlayChallengeTypeID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByPlayChallengeTypeID]
(
	@PlayChallengeTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pm.[ID],
			pm.[PlaySubsetID],
			pm.[PlayReferenceData],
			pm.[PlayReferenceActionType],
			pm.[Name],
			pm.[ContentData],
			pm.[OnCompleteData],
			pm.[VersionID],
			pm.[VersionDate],
			pm.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayMoves] pm
	INNER JOIN [f30-data].[dbo].[PlayChallengeTypePlayMoveLinks] l ON l.PlayMoveID = pm.[ID]
	WHERE	l.[PlayChallengeTypeID] = @PlayChallengeTypeID
	ORDER BY pm.[ID] DESC
	
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesSelectByPlayGameIDCellCoord]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesSelectByPlayGameIDCellCoord]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayMovesSelectByPlayGameIDCellCoord]
(
	@PlayGameID int,
	@Column int,
	@Row int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayMoves
	DECLARE @PM TABLE(
		ID int,
		PlaySubsetID int,
		PlayReferenceData [nvarchar](max),
		PlayReferenceActionType int,
		Name [nvarchar](250),
		ContentData [nvarchar](max),
		OnCompleteData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int])

	DECLARE @PlayAreaCellTypeID int
	SET @PlayAreaCellTypeID = ISNULL(	(SELECT TOP(1) pac.[CellTypeID] 
										FROM [f30-data].[dbo].[PlayAreaCells] pac
										WHERE	pac.[PlayGameID] = @PlayGameID 
												AND pac.[Column] = @Column 
												AND pac.[Row] = @Row), 0)

	IF (@PlayAreaCellTypeID > 0)
	BEGIN

		-- Create a table variable for the PlayAreaTileTypes
		DECLARE @PATT TABLE(
			ID int)

		INSERT INTO @PATT
		SELECT	pat.[TileTypeID]
		FROM	[f30-data].[dbo].[PlayAreaTiles] pat
		WHERE	pat.[PlayGameID] = @PlayGameID 
				AND pat.[Column] = @Column 
				AND pat.[Row] = @Row

		-- Create PlayReferenceDataJSON
		DECLARE @PlayReferenceDataJSON nvarchar(max)
		SET @PlayReferenceDataJSON = '{"ID":"","Items":[],"Params":[{"Key":"PlayReferenceDataItemType","Value":"%s"},{"Key":"PlayReferenceDataItemID","Value":"%s"}]}'

		-- Insert PlayMoves for PlayAreaTileTypes
		INSERT INTO @PM
		SELECT	pm.[ID],
				pm.[PlaySubsetID],
				FORMATMESSAGE(@PlayReferenceDataJSON, '2', CONVERT(nvarchar(6), l.[PlayAreaTileTypeID])) AS 'PlayReferenceData',
				pm.[PlayReferenceActionType],
				pm.[Name],
				pm.[ContentData],
				pm.[OnCompleteData],
				pm.[VersionID],
				pm.[VersionDate],
				pm.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayMoves] pm
		INNER JOIN [f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l ON l.PlayMoveID = pm.[ID]
		WHERE	l.[PlayAreaTileTypeID] IN (SELECT patt.[ID] FROM @PATT patt)

		-- Insert PlayMoves for PlayAreaCellType
		INSERT INTO @PM
		SELECT	pm.[ID],
				pm.[PlaySubsetID],
				FORMATMESSAGE(@PlayReferenceDataJSON, '1', l.[PlayAreaCellTypeID]) AS 'PlayReferenceData',
				pm.[PlayReferenceActionType],
				pm.[Name],
				pm.[ContentData],
				pm.[OnCompleteData],
				pm.[VersionID],
				pm.[VersionDate],
				pm.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayMoves] pm
		INNER JOIN [f30-data].[dbo].[PlayAreaCellTypePlayMoveLinks] l ON l.PlayMoveID = pm.[ID]
		WHERE	l.[PlayAreaCellTypeID] = @PlayAreaCellTypeID

		-- Select PlayMoves
		SELECT	pm.[ID],
				pm.[PlaySubsetID],
				pm.[PlayReferenceData],
				pm.[PlayReferenceActionType],
				pm.[Name],
				pm.[ContentData],
				pm.[OnCompleteData],
				pm.[VersionID],
				pm.[VersionDate],
				pm.[VersionOwnerID]
		FROM	@PM pm

	END
	ELSE
	BEGIN

		-- Select no items
		SELECT * FROM @PM pm WHERE pm.[ID] <> pm.[ID] 

	END

							
END


GO





USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayMovesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayMovesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayMovesUpdate]
(
	@ID int output,
	@PlaySubsetID int,
	@PlayReferenceData [nvarchar](max),
	@PlayReferenceActionType int,
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayMoves]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[PlayReferenceData] = @PlayReferenceData,
			[PlayReferenceActionType] = @PlayReferenceActionType,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
