USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayAreaTileTypePlayMoveLinks]
	WHERE ID = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayAreaTileTypeID [int],
	@ExportedPlayAreaTileTypeID [int],
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayAreaTileTypePlayMoveLinks]
           ([ExportedID],
			[DesignPlayAreaTileTypeID],
			[ExportedPlayAreaTileTypeID],
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
		    @DesignPlayAreaTileTypeID,
		    @ExportedPlayAreaTileTypeID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

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
	ORDER BY l.[ID] DESC

END




GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

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
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelectByDesignPlayAreaTileTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelectByDesignPlayAreaTileTypeID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksSelectByDesignPlayAreaTileTypeID]
(
	@DesignPlayAreaTileTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

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
	WHERE	l.[DesignPlayAreaTileTypeID] = @DesignPlayAreaTileTypeID
			ORDER BY l.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayAreaTileTypePlayMoveLinksUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlayAreaTileTypeID [int],
	@ExportedPlayAreaTileTypeID [int],
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayAreaTileTypePlayMoveLinks]
	SET		[ExportedID] = @ExportedID,
			[DesignPlayAreaTileTypeID] = @DesignPlayAreaTileTypeID,
			[ExportedPlayAreaTileTypeID] = @ExportedPlayAreaTileTypeID,
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
