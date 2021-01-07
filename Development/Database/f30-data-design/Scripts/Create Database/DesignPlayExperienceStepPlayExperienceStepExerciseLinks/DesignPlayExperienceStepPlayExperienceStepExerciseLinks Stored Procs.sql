USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayExperienceStepID [int],
	@ExportedPlayExperienceStepID [int],
	@DesignPlayExperienceStepExerciseID [int],
	@ExportedPlayExperienceStepExerciseID [int],
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]
           ([ExportedID],
			[DesignPlayExperienceStepID],
			[ExportedPlayExperienceStepID],
			[DesignPlayExperienceStepExerciseID],
			[ExportedPlayExperienceStepExerciseID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
		    @DesignPlayExperienceStepID,
		    @ExportedPlayExperienceStepID,
			@DesignPlayExperienceStepExerciseID,
			@ExportedPlayExperienceStepExerciseID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[DesignPlayExperienceStepExerciseID],
			l.[ExportedPlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks] l
			ORDER BY l.[ID] DESC

END




GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[DesignPlayExperienceStepExerciseID],
			l.[ExportedPlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelectByDesignPlayExperienceStepID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelectByDesignPlayExperienceStepID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksSelectByDesignPlayExperienceStepID]
(
	@DesignPlayExperienceStepID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[DesignPlayExperienceStepExerciseID],
			l.[ExportedPlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks] l
	WHERE	l.[DesignPlayExperienceStepID] = @DesignPlayExperienceStepID
			ORDER BY l.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepPlayExperienceStepExerciseLinksUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayExperienceStepID [int],
	@ExportedPlayExperienceStepID [int],
	@DesignPlayExperienceStepExerciseID [int],
	@ExportedPlayExperienceStepExerciseID [int],
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]
	SET		[ExportedID] = @ExportedID,
			[DesignPlayExperienceStepID] = @DesignPlayExperienceStepID,
			[ExportedPlayExperienceStepID] = @ExportedPlayExperienceStepID,
			[DesignPlayExperienceStepExerciseID] = @DesignPlayExperienceStepExerciseID,
			[ExportedPlayExperienceStepExerciseID] = @ExportedPlayExperienceStepExerciseID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO
