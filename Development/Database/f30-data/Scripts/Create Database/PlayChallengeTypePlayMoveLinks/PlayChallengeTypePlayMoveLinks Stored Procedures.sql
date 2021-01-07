USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallengeTypePlayMoveLinks]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksInsert]
(
	@ID int output,
	@PlayChallengeTypeID [int],
	@PlayMoveID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallengeTypePlayMoveLinks]
           ([PlayChallengeTypeID],
			[PlayMoveID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlayChallengeTypeID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayMoveLinks] l
	ORDER BY l.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayMoveLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByPlayChallengeTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByPlayChallengeTypeID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByPlayChallengeTypeID]
(
	@PlayChallengeTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayMoveLinks] l
	WHERE	l.[PlayChallengeTypeID] = @PlayChallengeTypeID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayMoveLinks] l
			JOIN [f30-data].[dbo].[PlayChallengeTypes] pct ON pct.[ID] = l.[PlayChallengeTypeID]
	WHERE	pct.[PlaySubsetID] = @PlaySubsetID
	ORDER BY l.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayMoveLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayMoveLinksUpdate]
(
	@ID int output,
	@PlayChallengeTypeID [int],
	@PlayMoveID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallengeTypePlayMoveLinks]
	SET		[PlayChallengeTypeID] = @PlayChallengeTypeID,
			[PlayMoveID] = @PlayMoveID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
