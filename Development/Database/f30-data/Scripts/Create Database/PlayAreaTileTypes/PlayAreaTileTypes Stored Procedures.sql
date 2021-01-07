USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaTileTypes]
	WHERE ID = @ID

	-- Delete PlayAreaTileTypePlayMoveLinks
	DELETE FROM [f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks]
	WHERE [PlayAreaTileTypeID] = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypesInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@IsSpecialYN [bit],
	@DeckWeighting [int],
	@ImageName [nvarchar](250),
	@WidthPixels [int],
	@HeightPixels [int],
	@Position [int],
	@PositionFixToCellRotationYN [bit],
	@TileAttributesString [nvarchar](max),
	@TileSideAttributesString [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaTileTypes]
           ([PlaySubsetID],
			[Name],
			[IsSpecialYN],
			[DeckWeighting],
			[ImageName],
			[WidthPixels],
			[HeightPixels],
			[Position],
			[PositionFixToCellRotationYN],
			[TileAttributesString],
			[TileSideAttributesString],
			[IndexDefinitionData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@Name,
			@IsSpecialYN,
			@DeckWeighting,
			@ImageName,
			@WidthPixels,
			@HeightPixels,
			@Position,
			@PositionFixToCellRotationYN,
			@TileAttributesString,
			@TileSideAttributesString,
			@IndexDefinitionData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

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
			ORDER BY patt.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

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
	WHERE	patt.[ID] = @ID
	ORDER BY patt.[ID] DESC
	
							
END


GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

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


GO
	



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypesUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@IsSpecialYN [bit],
	@DeckWeighting [int],
	@ImageName [nvarchar](250),
	@WidthPixels [int],
	@HeightPixels [int],
	@Position [int],
	@PositionFixToCellRotationYN [bit],
	@TileAttributesString [nvarchar](max),
	@TileSideAttributesString [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaTileTypes]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[Name] = @Name,
			[IsSpecialYN] = @IsSpecialYN,
			[DeckWeighting] = @DeckWeighting,
			[ImageName] = @ImageName,
			[WidthPixels] = @WidthPixels,
			[HeightPixels] = @HeightPixels,
			[Position] = @Position,
			[PositionFixToCellRotationYN] = @PositionFixToCellRotationYN,
			[TileAttributesString] = @TileAttributesString,
			[TileSideAttributesString] = @TileSideAttributesString,
			[IndexDefinitionData] = @IndexDefinitionData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
