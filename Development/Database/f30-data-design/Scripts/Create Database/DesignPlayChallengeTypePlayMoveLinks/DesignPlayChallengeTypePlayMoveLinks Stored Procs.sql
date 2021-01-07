USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayMoveLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayMoveLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayChallengeTypeID [int],
	@ExportedPlayChallengeTypeID [int],
	@DesignPlayMoveID [int],
	@ExportedPlayMoveID [int],
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks]
           ([ExportedID],
			[DesignPlayChallengeTypeID],
			[ExportedPlayChallengeTypeID],
			[DesignPlayMoveID],
			[ExportedPlayMoveID],
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
			@DesignPlayMoveID,
			@ExportedPlayMoveID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks] l
	ORDER BY l.[ID] DESC

END




GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelectByID]
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
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelectByDesignPlayChallengeTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelectByDesignPlayChallengeTypeID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksSelectByDesignPlayChallengeTypeID]
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
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks] l
	WHERE	l.[DesignPlayChallengeTypeID] = @DesignPlayChallengeTypeID
			ORDER BY l.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypePlayMoveLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypePlayMoveLinksUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayChallengeTypeID [int],
	@ExportedPlayChallengeTypeID [int],
	@DesignPlayMoveID [int],
	@ExportedPlayMoveID [int],
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks]
	SET		[ExportedID] = @ExportedID,
			[DesignPlayChallengeTypeID] = @DesignPlayChallengeTypeID,
			[ExportedPlayChallengeTypeID] = @ExportedPlayChallengeTypeID,
			[DesignPlayMoveID] = @DesignPlayMoveID,
			[ExportedPlayMoveID] = @ExportedPlayMoveID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO
