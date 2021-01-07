USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayAreaCellTypes]
	WHERE ID = @ID

	-- Delete DesignPlayAreaCellTypePlayMoveLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayAreaCellTypePlayMoveLinks]
	WHERE [DesignPlayAreaCellTypeID] = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesInsert]
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
	@BlockedContentPositionsString [nvarchar](50),
	@CellAttributesString [nvarchar](max),
	@CellSideAttributesString [nvarchar](max),
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayAreaCellTypes]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [Name],
			[IsSpecialYN],
			[DeckWeighting],
			[ImageName],
			[ExportedImageName],
			[BlockedContentPositionsString],
			[CellAttributesString],
			[CellSideAttributesString],
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
			@BlockedContentPositionsString,
			@CellAttributesString,
			@CellSideAttributesString,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	-- Create a table variable for the DesignPlayAreaCellTypes
	DECLARE @DPACT TABLE(
		ID int,
		ExportedID [int],
		DesignPlaySubsetID [int],
		ExportedPlaySubsetID [int],
		Name [nvarchar](250),
		IsSpecialYN [bit],
		DeckWeighting [int],
		ImageName [nvarchar](250),
		ExportedImageName [nvarchar](250),
		BlockedContentPositionsString [nvarchar](50),
		CellAttributesString [nvarchar](max),
		CellSideAttributesString [nvarchar](max),
		IndexDefinitionData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int],
		CanExportYN [bit],
		ExportStatus [int])

	INSERT INTO @DPACT
	SELECT	dpact.[ID],
			dpact.[ExportedID],
			dpact.[DesignPlaySubsetID],
			dpact.[ExportedPlaySubsetID],
			dpact.[Name],
			dpact.[IsSpecialYN],
			dpact.[DeckWeighting],
			dpact.[ImageName],
			dpact.[ExportedImageName],
			dpact.[BlockedContentPositionsString],
			dpact.[CellAttributesString],
			dpact.[CellSideAttributesString],
			dpact.[IndexDefinitionData],
			dpact.[VersionID],
			dpact.[VersionDate],
			dpact.[VersionOwnerID],
			dpact.[CanExportYN],
			dpact.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypes] dpact
	ORDER BY dpact.[ID] DESC

	-- Select DesignPlayAreaCellTypes
	SELECT * FROM @DPACT dpact
	ORDER BY dpact.[ID] DESC

	-- Select DesignPlayAreaCellTypePlayMoveLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayAreaCellTypeID],
			l.[ExportedPlayAreaCellTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypePlayMoveLinks] l
	WHERE	l.[DesignPlayAreaCellTypeID] IN (SELECT dpact.[ID] FROM @DPACT dpact)	


END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpact.[ID],
			dpact.[ExportedID],
			dpact.[DesignPlaySubsetID],
			dpact.[ExportedPlaySubsetID],
			dpact.[Name],
			dpact.[IsSpecialYN],
			dpact.[DeckWeighting],
			dpact.[ImageName],
			dpact.[ExportedImageName],
			dpact.[BlockedContentPositionsString],
			dpact.[CellAttributesString],
			dpact.[CellSideAttributesString],
			dpact.[IndexDefinitionData],
			dpact.[VersionID],
			dpact.[VersionDate],
			dpact.[VersionOwnerID],
			dpact.[CanExportYN],
			dpact.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypes] dpact
	WHERE	dpact.[ID] = @ID
	ORDER BY dpact.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the DesignPlayAreaCellTypes
	DECLARE @DPACT TABLE(
		ID int,
		ExportedID [int],
		DesignPlaySubsetID [int],
		ExportedPlaySubsetID [int],
		Name [nvarchar](250),
		IsSpecialYN [bit],
		DeckWeighting [int],
		ImageName [nvarchar](250),
		ExportedImageName [nvarchar](250),
		BlockedContentPositionsString [nvarchar](50),
		CellAttributesString [nvarchar](max),
		CellSideAttributesString [nvarchar](max),
		IndexDefinitionData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int],
		CanExportYN [bit],
		ExportStatus [int])

	INSERT INTO @DPACT
	SELECT	dpact.[ID],
			dpact.[ExportedID],
			dpact.[DesignPlaySubsetID],
			dpact.[ExportedPlaySubsetID],
			dpact.[Name],
			dpact.[IsSpecialYN],
			dpact.[DeckWeighting],
			dpact.[ImageName],
			dpact.[ExportedImageName],
			dpact.[BlockedContentPositionsString],
			dpact.[CellAttributesString],
			dpact.[CellSideAttributesString],
			dpact.[IndexDefinitionData],
			dpact.[VersionID],
			dpact.[VersionDate],
			dpact.[VersionOwnerID],
			dpact.[CanExportYN],
			dpact.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypes] dpact
	WHERE	dpact.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY dpact.[ID] DESC

	-- Select DesignPlayAreaCellTypes
	SELECT * FROM @DPACT dpact
	ORDER BY dpact.[ID] DESC

	-- Select DesignPlayAreaCellTypePlayMoveLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayAreaCellTypeID],
			l.[ExportedPlayAreaCellTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypePlayMoveLinks] l
	WHERE	l.[DesignPlayAreaCellTypeID] IN (SELECT dpact.[ID] FROM @DPACT dpact)	

				
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesUpdate]
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
	@BlockedContentPositionsString [nvarchar](50),
	@CellAttributesString [nvarchar](max),
	@CellSideAttributesString [nvarchar](max),
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayAreaCellTypes]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[Name] = @Name,
			[IsSpecialYN] = @IsSpecialYN,
			[DeckWeighting] = @DeckWeighting,
			[ImageName] = @ImageName,
			[ExportedImageName] = @ExportedImageName,
			[BlockedContentPositionsString] = @BlockedContentPositionsString,
			[CellAttributesString] = @CellAttributesString,
			[CellSideAttributesString] = @CellSideAttributesString,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaCellTypesSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaCellTypesSelectByFullText]
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

	SELECT	pact.[ID],
			pact.[ExportedID],
			pact.[DesignPlaySubsetID],
			pact.[ExportedPlaySubsetID],
			pact.[Name],
			pact.[IsSpecialYN],
			pact.[DeckWeighting],
			pact.[ImageName],
			pact.[ExportedImageName],
			pact.[BlockedContentPositionsString],
			pact.[CellAttributesString],
			pact.[CellSideAttributesString],
			pact.[IndexDefinitionData],
			pact.[VersionID],
			pact.[VersionDate],
			pact.[VersionOwnerID],
			pact.[CanExportYN],
			pact.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypes] pact
			INNER JOIN CONTAINSTABLE(DesignPlayAreaCellTypes, (Name), @ContainsSearchTerm) fulltextSearch
			ON pact.[ID] = fulltextSearch.[KEY]
	WHERE	pact.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO