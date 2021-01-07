USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepExercisesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepExercisesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepExercisesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperienceStepExercises]
	WHERE ID = @ID

	-- Delete PlayExperienceStepPlayExperienceStepExerciseLinks
	DELETE FROM [f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks]
	WHERE [PlayExperienceStepExerciseID] = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepExercisesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepExercisesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepExercisesInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@PlayExperienceStepExerciseType [int],
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperienceStepExercises]
           ([PlaySubsetID],
			[Name],
			[PlayExperienceStepExerciseType],
			[ContentData],
			[OnCompleteData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@Name,
			@PlayExperienceStepExerciseType,
			@ContentData,
			@OnCompleteData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepExercisesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepExercisesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepExercisesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pese.[ID],
			pese.[PlaySubsetID],
			pese.[Name],
			pese.[PlayExperienceStepExerciseType],
			pese.[ContentData],
			pese.[OnCompleteData],
			pese.[VersionID],
			pese.[VersionDate],
			pese.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepExercises] pese
			ORDER BY pese.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepExercisesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepExercisesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepExercisesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pese.[ID],
			pese.[PlaySubsetID],
			pese.[Name],
			pese.[PlayExperienceStepExerciseType],
			pese.[ContentData],
			pese.[OnCompleteData],
			pese.[VersionID],
			pese.[VersionDate],
			pese.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepExercises] pese
	WHERE	pese.[ID] = @ID
	ORDER BY pese.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepExercisesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepExercisesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepExercisesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pese.[ID],
			pese.[PlaySubsetID],
			pese.[Name],
			pese.[PlayExperienceStepExerciseType],
			pese.[ContentData],
			pese.[OnCompleteData],
			pese.[VersionID],
			pese.[VersionDate],
			pese.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceStepExercises] pese
	WHERE	pese.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pese.[ID] DESC
	
							
END


GO
	

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepExercisesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepExercisesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepExercisesUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@PlayExperienceStepExerciseType [int],
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperienceStepExercises]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[Name] = @Name,
			[PlayExperienceStepExerciseType] = @PlayExperienceStepExerciseType,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
