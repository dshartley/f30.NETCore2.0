USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTilesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaTiles]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTilesInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@TileTypeID [int],
	@Column [int],
	@Row [int],
	@RotationDegrees [int],
	@ImageName [nvarchar](250),
	@WidthPixels [int],
	@HeightPixels [int],
	@Position [int],
	@PositionFixToCellRotationYN [bit],
	@TileAttributesString [nvarchar](max),
	@TileSideAttributesString [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaTiles]
           ([RelativeMemberID],
			[PlayGameID],
			[TileTypeID],
			[Column],
			[Row],
			[RotationDegrees],
			[ImageName],
			[WidthPixels],
			[HeightPixels],
			[Position],
			[PositionFixToCellRotationYN],
			[TileAttributesString],
			[TileSideAttributesString])
     VALUES
           (@RelativeMemberID,
			@PlayGameID,
			@TileTypeID,
			@Column,
			@Row,
			@RotationDegrees,
			@ImageName,
			@WidthPixels,
			@HeightPixels,
			@Position,
			@PositionFixToCellRotationYN,
			@TileAttributesString,
			@TileSideAttributesString
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTilesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[TileTypeID],
			pat.[Column],
			pat.[Row],
			pat.[RotationDegrees],
			pat.[ImageName],
			pat.[WidthPixels],
			pat.[HeightPixels],
			pat.[Position],
			pat.[PositionFixToCellRotationYN],
			pat.[TileAttributesString],
			pat.[TileSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTiles] pat
			ORDER BY pat.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTilesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[TileTypeID],
			pat.[Column],
			pat.[Row],
			pat.[RotationDegrees],
			pat.[ImageName],
			pat.[WidthPixels],
			pat.[HeightPixels],
			pat.[Position],
			pat.[PositionFixToCellRotationYN],
			pat.[TileAttributesString],
			pat.[TileSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTiles] pat
	WHERE	pat.[ID] = @ID
	ORDER BY pat.[ID] DESC
	
							
END


GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesSelectByPlayGameID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesSelectByPlayGameID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTilesSelectByPlayGameID]
(
	@PlayGameID int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;
				
	-- Create a table variable for the PlayAreaTiles
	DECLARE @PAT TABLE(
		ID int,
		RelativeMemberID [nvarchar](30),
		PlayGameID [int],
		TileTypeID [int],
		[Column] [int],
		[Row] [int],
		RotationDegrees [int],
		ImageName [nvarchar](250),
		WidthPixels [int],
		HeightPixels [int],
		Position [int],
		PositionFixToCellRotationYN [bit],
		TileAttributesString [nvarchar](max),
		TileSideAttributesString [nvarchar](max))

	INSERT INTO @PAT
	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[TileTypeID],
			pat.[Column],
			pat.[Row],
			pat.[RotationDegrees],
			pat.[ImageName],
			pat.[WidthPixels],
			pat.[HeightPixels],
			pat.[Position],
			pat.[PositionFixToCellRotationYN],
			pat.[TileAttributesString],
			pat.[TileSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTiles] pat
	WHERE	pat.[PlayGameID] = @PlayGameID
	ORDER BY pat.[ID] DESC
			
	-- Select PlayAreaTiles
	SELECT * FROM @PAT pat
	ORDER BY pat.[ID] DESC

	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayAreaTileTypes

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
		WHERE	patt.[ID] IN (SELECT pat.[TileTypeID] FROM @PAT pat)
		ORDER BY patt.[ID] DESC

	END

END


GO





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesSelectByPlayGameIDCellCoord]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesSelectByPlayGameIDCellCoord]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTilesSelectByPlayGameIDCellCoord]
(
	@PlayGameID int,
	@Column int,
	@Row int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;
				
	-- Create a table variable for the PlayAreaTiles
	DECLARE @PAT TABLE(
		ID int,
		RelativeMemberID [nvarchar](30),
		PlayGameID [int],
		TileTypeID [int],
		[Column] [int],
		[Row] [int],
		RotationDegrees [int],
		ImageName [nvarchar](250),
		WidthPixels [int],
		HeightPixels [int],
		Position [int],
		PositionFixToCellRotationYN [bit],
		TileAttributesString [nvarchar](max),
		TileSideAttributesString [nvarchar](max))

	INSERT INTO @PAT
	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[TileTypeID],
			pat.[Column],
			pat.[Row],
			pat.[RotationDegrees],
			pat.[ImageName],
			pat.[WidthPixels],
			pat.[HeightPixels],
			pat.[Position],
			pat.[PositionFixToCellRotationYN],
			pat.[TileAttributesString],
			pat.[TileSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTiles] pat
	WHERE	pat.[PlayGameID] = @PlayGameID
			AND pat.[Column] = @Column
			AND pat.[Row] = @Row
	ORDER BY pat.[ID] DESC
			
	-- Select PlayAreaTiles
	SELECT * FROM @PAT pat
	ORDER BY pat.[ID] DESC

	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayAreaTileTypes

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
		WHERE	patt.[ID] IN (SELECT pat.[TileTypeID] FROM @PAT pat)
		ORDER BY patt.[ID] DESC

	END

END


GO






USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTilesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTilesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTilesUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@TileTypeID [int],
	@Column [int],
	@Row [int],
	@RotationDegrees [int],
	@ImageName [nvarchar](250),
	@WidthPixels [int],
	@HeightPixels [int],
	@Position [int],
	@PositionFixToCellRotationYN [bit],
	@TileAttributesString [nvarchar](max),
	@TileSideAttributesString [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaTiles]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayGameID] = @PlayGameID,
			[TileTypeID] = @TileTypeID,
			[Column] = @Column,
			[Row] = @Row,
			[RotationDegrees] = @RotationDegrees,
			[ImageName] = @ImageName,
			[WidthPixels] = @WidthPixels,
			[HeightPixels] = @HeightPixels,
			[Position] = @Position,
			[PositionFixToCellRotationYN] = @PositionFixToCellRotationYN,
			[TileAttributesString] = @TileAttributesString,
			[TileSideAttributesString] = @TileSideAttributesString
	WHERE ID = @ID

END

GO
