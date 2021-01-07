USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayChallengeTypeID [int],
	@ExportedPlayChallengeTypeID [int],
	@DesignPlayChallengeObjectiveTypeID [int],
	@ExportedPlayChallengeObjectiveTypeID [int],
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks]
           ([ExportedID],
			[DesignPlayChallengeTypeID],
			[ExportedPlayChallengeTypeID],
			[DesignPlayChallengeObjectiveTypeID],
			[ExportedPlayChallengeObjectiveTypeID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
		    @DesignPlayChallengeTypeID,
		    @ExportedPlayChallengeTypeID,
			@DesignPlayChallengeObjectiveTypeID,
			@ExportedPlayChallengeObjectiveTypeID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayChallengeObjectiveTypeID],
			l.[ExportedPlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks] l
			ORDER BY l.[ID] DESC

END




GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayChallengeObjectiveTypeID],
			l.[ExportedPlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByDesignPlayChallengeTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByDesignPlayChallengeTypeID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByDesignPlayChallengeTypeID]
(
	@DesignPlayChallengeTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayChallengeObjectiveTypeID],
			l.[ExportedPlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks] l
	WHERE	l.[DesignPlayChallengeTypeID] = @DesignPlayChallengeTypeID
			ORDER BY l.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinksUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayChallengeTypeID [int],
	@ExportedPlayChallengeTypeID [int],
	@DesignPlayChallengeObjectiveTypeID [int],
	@ExportedPlayChallengeObjectiveTypeID [int],
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks]
	SET		[ExportedID] = @ExportedID,
			[DesignPlayChallengeTypeID] = @DesignPlayChallengeTypeID,
			[ExportedPlayChallengeTypeID] = @ExportedPlayChallengeTypeID,
			[DesignPlayChallengeObjectiveTypeID] = @DesignPlayChallengeObjectiveTypeID,
			[ExportedPlayChallengeObjectiveTypeID] = @ExportedPlayChallengeObjectiveTypeID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO
