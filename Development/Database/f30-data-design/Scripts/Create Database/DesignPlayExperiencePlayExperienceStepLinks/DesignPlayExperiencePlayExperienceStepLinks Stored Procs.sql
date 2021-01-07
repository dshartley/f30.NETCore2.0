USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayExperienceID [int],
	@ExportedPlayExperienceID [int],
	@DesignPlayExperienceStepID [int],
	@ExportedPlayExperienceStepID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks]
           ([ExportedID],
			[DesignPlayExperienceID],
			[ExportedPlayExperienceID],
			[DesignPlayExperienceStepID],
			[ExportedPlayExperienceStepID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
		    @DesignPlayExperienceID,
		    @ExportedPlayExperienceID,
			@DesignPlayExperienceStepID,
			@ExportedPlayExperienceStepID,
			@Index,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceID],
			l.[ExportedPlayExperienceID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks] l
			ORDER BY l.[ID] DESC

END




GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceID],
			l.[ExportedPlayExperienceID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelectByDesignPlayExperienceID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelectByDesignPlayExperienceID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksSelectByDesignPlayExperienceID]
(
	@DesignPlayExperienceID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceID],
			l.[ExportedPlayExperienceID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks] l
	WHERE	l.[DesignPlayExperienceID] = @DesignPlayExperienceID
			ORDER BY l.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencePlayExperienceStepLinksUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayExperienceID [int],
	@ExportedPlayExperienceID [int],
	@DesignPlayExperienceStepID [int],
	@ExportedPlayExperienceStepID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks]
	SET		[ExportedID] = @ExportedID,
			[DesignPlayExperienceID] = @DesignPlayExperienceID,
			[ExportedPlayExperienceID] = @ExportedPlayExperienceID,
			[DesignPlayExperienceStepID] = @DesignPlayExperienceStepID,
			[ExportedPlayExperienceStepID] = @ExportedPlayExperienceStepID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO
