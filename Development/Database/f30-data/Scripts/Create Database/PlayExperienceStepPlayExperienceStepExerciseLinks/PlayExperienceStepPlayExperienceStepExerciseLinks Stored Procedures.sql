USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksInsert]
(
	@ID int output,
	@PlayExperienceStepID [int],
	@PlayExperienceStepExerciseID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks]
           ([PlayExperienceStepID],
			[PlayExperienceStepExerciseID],
			[Index],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlayExperienceStepID,
			@PlayExperienceStepExerciseID,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	l.[ID],
			l.[PlayExperienceStepID],
			l.[PlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks] l
			ORDER BY l.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayExperienceStepID],
			l.[PlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks] l
	WHERE	l.[ID] = @ID
	ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByPlayExperienceStepID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByPlayExperienceStepID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByPlayExperienceStepID]
(
	@PlayExperienceStepID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayExperienceStepID],
			l.[PlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks] l
	WHERE	l.[PlayExperienceStepID] = @PlayExperienceStepID
			ORDER BY l.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	l.[ID],
			l.[PlayExperienceStepID],
			l.[PlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks] l
			JOIN [f30-data].[dbo].[PlayExperienceSteps] pes ON pes.[ID] = l.[PlayExperienceStepID]
	WHERE	pes.[PlaySubsetID] = @PlaySubsetID
	ORDER BY l.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepPlayExperienceStepExerciseLinksUpdate]
(
	@ID int output,
	@PlayExperienceStepID [int],
	@PlayExperienceStepExerciseID [int],
	@Index [int],
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks]
	SET		[PlayExperienceStepID] = @PlayExperienceStepID,
			[PlayExperienceStepExerciseID] = @PlayExperienceStepExerciseID,
			[Index] = @Index,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
