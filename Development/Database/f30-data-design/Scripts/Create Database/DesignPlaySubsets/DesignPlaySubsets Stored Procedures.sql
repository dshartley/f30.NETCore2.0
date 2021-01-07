USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlaySubsetsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlaySubsetsDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlaySubsetsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlaySubsets]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlaySubsetsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlaySubsetsInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlaySubsetsInsert]
(
	@ID int output,
	@ExportedID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlaySubsets]
           ([ExportedID],
		    [Name],
			[ContentData],
			[ExportedThumbnailImageName],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
		    @Name,
			@ContentData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlaySubsetsSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlaySubsetsSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlaySubsetsSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	ps.[ID],
			ps.[ExportedID],
			ps.[Name],
			ps.[ContentData],
			ps.[ExportedThumbnailImageName],
			ps.[VersionID],
			ps.[VersionDate],
			ps.[VersionOwnerID],
			ps.[CanExportYN],
			ps.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlaySubsets] ps
			ORDER BY ps.[ID] DESC

END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlaySubsetsSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlaySubsetsSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlaySubsetsSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	ps.[ID],
			ps.[ExportedID],
			ps.[Name],
			ps.[ContentData],
			ps.[ExportedThumbnailImageName],
			ps.[VersionID],
			ps.[VersionDate],
			ps.[VersionOwnerID],
			ps.[CanExportYN],
			ps.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlaySubsets] ps
	WHERE	ps.[ID] = @ID
	ORDER BY ps.[ID] DESC
	
							
END


GO
USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlaySubsetsUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlaySubsetsUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlaySubsetsUpdate]
(
	@ID int output,
	@ExportedID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
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

	UPDATE	[f30-data-design].[dbo].[DesignPlaySubsets]
	SET		[ExportedID] = @ExportedID,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[ExportedThumbnailImageName] = @ExportedThumbnailImageName,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO

