USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksInsert]
(
	@ID int output,
	@PlayExperienceID [int],
	@PlayExperienceStepID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks]
           ([PlayExperienceID],
			[PlayExperienceStepID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlayExperienceID,
			@PlayExperienceStepID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[PlayExperienceID],
			l.[PlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks] l
			ORDER BY l.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayExperienceID],
			l.[PlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByPlayExperienceID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByPlayExperienceID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByPlayExperienceID]
(
	@PlayExperienceID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayExperienceID],
			l.[PlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks] l
	WHERE	l.[PlayExperienceID] = @PlayExperienceID
			ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayExperienceID],
			l.[PlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks] l
			JOIN [f30-data].[dbo].[PlayExperiences] pe ON pe.[ID] = l.[PlayExperienceID]
	WHERE	pe.[PlaySubsetID] = @PlaySubsetID
	ORDER BY l.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencePlayExperienceStepLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencePlayExperienceStepLinksUpdate]
(
	@ID int output,
	@PlayExperienceID [int],
	@PlayExperienceStepID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks]
	SET		[PlayExperienceID] = @PlayExperienceID,
			[PlayExperienceStepID] = @PlayExperienceStepID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
