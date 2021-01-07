USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@Code [nvarchar](max),
	@DefinitionData [nvarchar](max),
	@ExportedThumbnailImageName [nvarchar](250),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [Name],
			[ContentData],
			[OnCompleteData],
			[Code],
			[DefinitionData],
			[ExportedThumbnailImageName],
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
			@ContentData,
			@OnCompleteData,
			@Code,
			@DefinitionData,
			@ExportedThumbnailImageName,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pcot.[ID],
			pcot.[ExportedID],
			pcot.[DesignPlaySubsetID],
			pcot.[ExportedPlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[ExportedThumbnailImageName],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID],
			pcot.[CanExportYN],
			pcot.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes] pcot
			ORDER BY pcot.[ID] DESC

END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pcot.[ID],
			pcot.[ExportedID],
			pcot.[DesignPlaySubsetID],
			pcot.[ExportedPlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[ExportedThumbnailImageName],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID],
			pcot.[CanExportYN],
			pcot.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes] pcot
	WHERE	pcot.[ID] = @ID
	ORDER BY pcot.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pcot.[ID],
			pcot.[ExportedID],
			pcot.[DesignPlaySubsetID],
			pcot.[ExportedPlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[ExportedThumbnailImageName],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID],
			pcot.[CanExportYN],
			pcot.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes] pcot
	WHERE	pcot.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY pcot.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@Code [nvarchar](max),
	@DefinitionData [nvarchar](max),
	@ExportedThumbnailImageName [nvarchar](250),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[Code] = @Code,
			[DefinitionData] = @DefinitionData,
			[ExportedThumbnailImageName] = @ExportedThumbnailImageName,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByFullText]
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

	SELECT	pcot.[ID],
			pcot.[ExportedID],
			pcot.[DesignPlaySubsetID],
			pcot.[ExportedPlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[ExportedThumbnailImageName],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID],
			pcot.[CanExportYN],
			pcot.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes] pcot
			INNER JOIN CONTAINSTABLE(DesignPlayChallengeObjectiveTypes, (Name, ContentData), @ContainsSearchTerm) fulltextSearch
			ON pcot.[ID] = fulltextSearch.[KEY]
	WHERE	pcot.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO