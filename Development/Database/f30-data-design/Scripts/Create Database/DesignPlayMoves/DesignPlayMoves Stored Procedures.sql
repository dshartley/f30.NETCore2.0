USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayMovesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayMovesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayMovesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayMoves]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayMovesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayMovesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayMovesInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID int,
	@ExportedPlaySubsetID [int],
	@PlayReferenceData [nvarchar](max),
	@PlayReferenceActionType int,
	@ExportedThumbnailImageName [nvarchar](250),
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data-design].[dbo].[DesignPlayMoves]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
			[PlayReferenceData],
			[PlayReferenceActionType],
			[ExportedThumbnailImageName],
			[Name],
			[ContentData],
			[OnCompleteData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
			@DesignPlaySubsetID,
			@ExportedPlaySubsetID,
			@PlayReferenceData,
			@PlayReferenceActionType,
			@ExportedThumbnailImageName,
			@Name,
			@ContentData,
			@OnCompleteData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayMovesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayMovesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayMovesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	dpm.[ID],
			dpm.[ExportedID],
			dpm.[DesignPlaySubsetID],
			dpm.[ExportedPlaySubsetID],
			dpm.[PlayReferenceData],
			dpm.[PlayReferenceActionType],
			dpm.[ExportedThumbnailImageName],
			dpm.[Name],
			dpm.[ContentData],
			dpm.[OnCompleteData],
			dpm.[VersionID],
			dpm.[VersionDate],
			dpm.[VersionOwnerID],
			dpm.[CanExportYN],
			dpm.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayMoves] dpm
			ORDER BY dpm.[ID] DESC

END




GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayMovesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayMovesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayMovesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpm.[ID],
			dpm.[ExportedID],
			dpm.[DesignPlaySubsetID],
			dpm.[ExportedPlaySubsetID],
			dpm.[PlayReferenceData],
			dpm.[PlayReferenceActionType],
			dpm.[ExportedThumbnailImageName],
			dpm.[Name],
			dpm.[ContentData],
			dpm.[OnCompleteData],
			dpm.[VersionID],
			dpm.[VersionDate],
			dpm.[VersionOwnerID],
			dpm.[CanExportYN],
			dpm.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayMoves] dpm
	WHERE	dpm.[ID] = @ID
	ORDER BY dpm.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayMovesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayMovesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayMovesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpm.[ID],
			dpm.[ExportedID],
			dpm.[DesignPlaySubsetID],
			dpm.[ExportedPlaySubsetID],
			dpm.[PlayReferenceData],
			dpm.[PlayReferenceActionType],
			dpm.[ExportedThumbnailImageName],
			dpm.[Name],
			dpm.[ContentData],
			dpm.[OnCompleteData],
			dpm.[VersionID],
			dpm.[VersionDate],
			dpm.[VersionOwnerID],
			dpm.[CanExportYN],
			dpm.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayMoves] dpm
	WHERE	dpm.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY dpm.[ID] DESC

END


GO





USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayMovesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayMovesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayMovesUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID int,
	@ExportedPlaySubsetID [int],
	@PlayReferenceData [nvarchar](max),
	@PlayReferenceActionType int,
	@ExportedThumbnailImageName [nvarchar](250),
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data-design].[dbo].[DesignPlayMoves]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[PlayReferenceData] = @PlayReferenceData,
			[PlayReferenceActionType] = @PlayReferenceActionType,
			[ExportedThumbnailImageName] = @ExportedThumbnailImageName,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO
