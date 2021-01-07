USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksInsert]
(
	@ID int output,
	@PlayAreaTileTypeID [int],
	@PlayMoveID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks]
           ([PlayAreaTileTypeID],
			[PlayMoveID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlayAreaTileTypeID,
			@PlayMoveID,
			@Index,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[PlayAreaTileTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l
	ORDER BY l.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayAreaTileTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByPlayAreaTileTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByPlayAreaTileTypeID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByPlayAreaTileTypeID]
(
	@PlayAreaTileTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayAreaTileTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l
	WHERE	l.[PlayAreaTileTypeID] = @PlayAreaTileTypeID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayAreaTileTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks] l
			JOIN [f30-data].[dbo].[PlayAreaTileTypes] patt ON patt.[ID] = l.[PlayAreaTileTypeID]
	WHERE	patt.[PlaySubsetID] = @PlaySubsetID
	ORDER BY l.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypePlayMoveLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypePlayMoveLinksUpdate]
(
	@ID int output,
	@PlayAreaTileTypeID [int],
	@PlayMoveID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaTileTypePlayMoveLinks]
	SET		[PlayAreaTileTypeID] = @PlayAreaTileTypeID,
			[PlayMoveID] = @PlayMoveID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
