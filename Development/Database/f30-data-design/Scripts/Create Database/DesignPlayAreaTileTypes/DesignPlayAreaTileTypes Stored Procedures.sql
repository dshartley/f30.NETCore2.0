USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayAreaTileTypes]
	WHERE ID = @ID

	-- Delete DesignPlayAreaTileTypePlayMoveLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayAreaTileTypePlayMoveLinks]
	WHERE [DesignPlayAreaTileTypeID] = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@Name [nvarchar](250),
	@IsSpecialYN [bit],
	@DeckWeighting [int],
	@ImageName [nvarchar](250),
	@ExportedImageName [nvarchar](250),
	@WidthPixels [int],
	@HeightPixels [int],
	@Position [int],
	@PositionFixToCellRotationYN [bit],
	@TileAttributesString [nvarchar](max),
	@TileSideAttributesString [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data-design].[dbo].[DesignPlayAreaTileTypes]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [Name],
			[IsSpecialYN],
			[DeckWeighting],
			[ImageName],
			[ExportedImageName],
			[WidthPixels],
			[HeightPixels],
			[Position],
			[PositionFixToCellRotationYN],
			[TileAttributesString],
			[TileSideAttributesString],
			[IndexDefinitionData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
			@DesignPlaySubsetID,
			@ExportedPlaySubsetID,
		    @Name,
			@IsSpecialYN,
			@DeckWeighting,
			@ImageName,
			@ExportedImageName,
			@WidthPixels,
			@HeightPixels,
			@Position,
			@PositionFixToCellRotationYN,
			@TileAttributesString,
			@TileSideAttributesString,
			@IndexDefinitionData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID,
			@CanExportYN,
			@ExportStatus
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	-- Create a table variable for the DesignPlayAreaTileTypes
	DECLARE @DPATT TABLE(
		ID int,
		ExportedID [int],
		DesignPlaySubsetID [int],
		ExportedPlaySubsetID [int],
		Name [nvarchar](250),
		IsSpecialYN [bit],
		DeckWeighting [int],
		ImageName [nvarchar](250),
		ExportedImageName [nvarchar](250),
		WidthPixels [int],
		HeightPixels [int],
		Position [int],
		PositionFixToCellRotationYN [bit],
		TileAttributesString [nvarchar](max),
		TileSideAttributesString [nvarchar](max),
		IndexDefinitionData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int],
		CanExportYN [bit],
		ExportStatus [int])

	INSERT INTO @DPATT
	SELECT	dpatt.[ID],
			dpatt.[ExportedID],
			dpatt.[DesignPlaySubsetID],
			dpatt.[ExportedPlaySubsetID],
			dpatt.[Name],
			dpatt.[IsSpecialYN],
			dpatt.[DeckWeighting],
			dpatt.[ImageName],
			dpatt.[ExportedImageName],
			dpatt.[WidthPixels],
			dpatt.[HeightPixels],
			dpatt.[Position],
			dpatt.[PositionFixToCellRotationYN],
			dpatt.[TileAttributesString],
			dpatt.[TileSideAttributesString],
			dpatt.[IndexDefinitionData],
			dpatt.[VersionID],
			dpatt.[VersionDate],
			dpatt.[VersionOwnerID],
			dpatt.[CanExportYN],
			dpatt.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypes] dpatt
	ORDER BY dpatt.[ID] DESC

	-- Select DesignPlayAreaTileTypes
	SELECT * FROM @DPATT dpatt
	ORDER BY dpatt.[ID] DESC

	-- Select DesignPlayAreaTileTypePlayMoveLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayAreaTileTypeID],
			l.[ExportedPlayAreaTileTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypePlayMoveLinks] l
	WHERE	l.[DesignPlayAreaTileTypeID] IN (SELECT dpatt.[ID] FROM @DPATT dpatt)	

END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpatt.[ID],
			dpatt.[ExportedID],
			dpatt.[DesignPlaySubsetID],
			dpatt.[ExportedPlaySubsetID],
			dpatt.[Name],
			dpatt.[IsSpecialYN],
			dpatt.[DeckWeighting],
			dpatt.[ImageName],
			dpatt.[ExportedImageName],
			dpatt.[WidthPixels],
			dpatt.[HeightPixels],
			dpatt.[Position],
			dpatt.[PositionFixToCellRotationYN],
			dpatt.[TileAttributesString],
			dpatt.[TileSideAttributesString],
			dpatt.[IndexDefinitionData],
			dpatt.[VersionID],
			dpatt.[VersionDate],
			dpatt.[VersionOwnerID],
			dpatt.[CanExportYN],
			dpatt.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypes] dpatt
	WHERE	dpatt.[ID] = @ID
	ORDER BY dpatt.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the DesignPlayAreaTileTypes
	DECLARE @DPATT TABLE(
		ID int,
		ExportedID [int],
		DesignPlaySubsetID [int],
		ExportedPlaySubsetID [int],
		Name [nvarchar](250),
		IsSpecialYN [bit],
		DeckWeighting [int],
		ImageName [nvarchar](250),
		ExportedImageName [nvarchar](250),
		WidthPixels [int],
		HeightPixels [int],
		Position [int],
		PositionFixToCellRotationYN [bit],
		TileAttributesString [nvarchar](max),
		TileSideAttributesString [nvarchar](max),
		IndexDefinitionData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int],
		CanExportYN [bit],
		ExportStatus [int])

	INSERT INTO @DPATT
	SELECT	dpatt.[ID],
			dpatt.[ExportedID],
			dpatt.[DesignPlaySubsetID],
			dpatt.[ExportedPlaySubsetID],
			dpatt.[Name],
			dpatt.[IsSpecialYN],
			dpatt.[DeckWeighting],
			dpatt.[ImageName],
			dpatt.[ExportedImageName],
			dpatt.[WidthPixels],
			dpatt.[HeightPixels],
			dpatt.[Position],
			dpatt.[PositionFixToCellRotationYN],
			dpatt.[TileAttributesString],
			dpatt.[TileSideAttributesString],
			dpatt.[IndexDefinitionData],
			dpatt.[VersionID],
			dpatt.[VersionDate],
			dpatt.[VersionOwnerID],
			dpatt.[CanExportYN],
			dpatt.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypes] dpatt
	WHERE	dpatt.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY dpatt.[ID] DESC

	-- Select DesignPlayAreaTileTypes
	SELECT * FROM @DPATT dpatt
	ORDER BY dpatt.[ID] DESC

	-- Select DesignPlayAreaTileTypePlayMoveLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayAreaTileTypeID],
			l.[ExportedPlayAreaTileTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypePlayMoveLinks] l
	WHERE	l.[DesignPlayAreaTileTypeID] IN (SELECT dpatt.[ID] FROM @DPATT dpatt)	
					
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@Name [nvarchar](250),
	@IsSpecialYN [bit],
	@DeckWeighting [int],
	@ImageName [nvarchar](250),
	@ExportedImageName [nvarchar](250),
	@WidthPixels [int],
	@HeightPixels [int],
	@Position [int],
	@PositionFixToCellRotationYN [bit],
	@TileAttributesString [nvarchar](max),
	@TileSideAttributesString [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data-design].[dbo].[DesignPlayAreaTileTypes]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[Name] = @Name,
			[IsSpecialYN] = @IsSpecialYN,
			[DeckWeighting] = @DeckWeighting,
			[ImageName] = @ImageName,
			[ExportedImageName] = @ExportedImageName,
			[WidthPixels] = @WidthPixels,
			[HeightPixels] = @HeightPixels,
			[Position] = @Position,
			[PositionFixToCellRotationYN] = @PositionFixToCellRotationYN,
			[TileAttributesString] = @TileAttributesString,
			[TileSideAttributesString] = @TileSideAttributesString,
			[IndexDefinitionData] = @IndexDefinitionData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypesSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypesSelectByFullText]
(
	@SearchString nvarchar(100),
	@DesignPlaySubsetID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	DECLARE @ContainsSearchTerm AS nvarchar(110)
	SET @ContainsSearchTerm = '"*' + @SearchString + '*"'

	SELECT	dpatt.[ID],
			dpatt.[ExportedID],
			dpatt.[DesignPlaySubsetID],
			dpatt.[ExportedPlaySubsetID],
			dpatt.[Name],
			dpatt.[IsSpecialYN],
			dpatt.[DeckWeighting],
			dpatt.[ImageName],
			dpatt.[ExportedImageName],
			dpatt.[WidthPixels],
			dpatt.[HeightPixels],
			dpatt.[Position],
			dpatt.[PositionFixToCellRotationYN],
			dpatt.[TileAttributesString],
			dpatt.[TileSideAttributesString],
			dpatt.[IndexDefinitionData],
			dpatt.[VersionID],
			dpatt.[VersionDate],
			dpatt.[VersionOwnerID],
			dpatt.[CanExportYN],
			dpatt.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypes] dpatt
			INNER JOIN CONTAINSTABLE(DesignPlayAreaTileTypes, (Name), @ContainsSearchTerm) fulltextSearch
			ON dpatt.[ID] = fulltextSearch.[KEY]
	WHERE	dpatt.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO