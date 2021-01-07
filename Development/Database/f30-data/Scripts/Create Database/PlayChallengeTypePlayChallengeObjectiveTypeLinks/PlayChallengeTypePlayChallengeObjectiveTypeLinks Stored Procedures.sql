USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksInsert]
(
	@ID int output,
	@PlayChallengeTypeID [int],
	@PlayChallengeObjectiveTypeID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks]
           ([PlayChallengeTypeID],
			[PlayChallengeObjectiveTypeID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlayChallengeTypeID,
			@PlayChallengeObjectiveTypeID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks] l
			ORDER BY l.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByPlayChallengeTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByPlayChallengeTypeID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByPlayChallengeTypeID]
(
	@PlayChallengeTypeID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks] l
	WHERE	l.[PlayChallengeTypeID] = @PlayChallengeTypeID
			ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayChallengeTypeID],
			l.[PlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks] l
			JOIN [f30-data].[dbo].[PlayChallengeTypes] pct ON pct.[ID] = l.[PlayChallengeTypeID]
	WHERE	pct.[PlaySubsetID] = @PlaySubsetID
	ORDER BY l.[ID] DESC
	
							
END


GO
	



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypePlayChallengeObjectiveTypeLinksUpdate]
(
	@ID int output,
	@PlayChallengeTypeID [int],
	@PlayChallengeObjectiveTypeID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks]
	SET		[PlayChallengeTypeID] = @PlayChallengeTypeID,
			[PlayChallengeObjectiveTypeID] = @PlayChallengeObjectiveTypeID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
