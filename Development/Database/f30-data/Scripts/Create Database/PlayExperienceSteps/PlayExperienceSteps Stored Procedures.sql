USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperienceSteps]
	WHERE ID = @ID

	-- Delete PlayExperiencePlayExperienceStepLinks
	DELETE FROM [f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks]
	WHERE [PlayExperienceStepID] = @ID

	-- Delete PlayExperienceStepPlayExperienceStepExerciseLinks
	DELETE FROM [f30-data].[dbo].[PlayExperienceStepPlayExperienceStepExerciseLinks]
	WHERE [PlayExperienceStepID] = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceStepType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperienceSteps]
           ([PlaySubsetID],
			[PlayExperienceStepType],
			[Name],
			[ContentData],
			[OnCompleteData],
			[PlayChallengeObjectiveDefinitionData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@PlayExperienceStepType,
			@Name,
			@ContentData,
			@OnCompleteData,
			@PlayChallengeObjectiveDefinitionData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pes.[ID],
			pes.[PlaySubsetID],
			pes.[PlayExperienceStepType],
			pes.[Name],
			pes.[ContentData],
			pes.[OnCompleteData],
			pes.[PlayChallengeObjectiveDefinitionData],
			pes.[VersionID],
			pes.[VersionDate],
			pes.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceSteps] pes
			ORDER BY pes.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pes.[ID],
			pes.[PlaySubsetID],
			pes.[PlayExperienceStepType],
			pes.[Name],
			pes.[ContentData],
			pes.[OnCompleteData],
			pes.[PlayChallengeObjectiveDefinitionData],
			pes.[VersionID],
			pes.[VersionDate],
			pes.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceSteps] pes
	WHERE	pes.[ID] = @ID
	ORDER BY pes.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsSelectByIDLoadRelationalTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsSelectByIDLoadRelationalTables]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsSelectByIDLoadRelationalTables]
(
	@ID int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pes.[ID],
			pes.[PlaySubsetID],
			pes.[PlayExperienceStepType],
			pes.[Name],
			pes.[ContentData],
			pes.[OnCompleteData],
			pes.[PlayChallengeObjectiveDefinitionData],
			pes.[VersionID],
			pes.[VersionDate],
			pes.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceSteps] pes
	ORDER BY pes.[ID] DESC
	
	IF (@LoadRelationalTablesYN = 1)
	BEGIN
	
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
						
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pes.[ID],
			pes.[PlaySubsetID],
			pes.[PlayExperienceStepType],
			pes.[Name],
			pes.[ContentData],
			pes.[OnCompleteData],
			pes.[PlayChallengeObjectiveDefinitionData],
			pes.[VersionID],
			pes.[VersionDate],
			pes.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperienceSteps] pes
	WHERE	pes.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pes.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperienceStepsUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperienceStepsUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperienceStepsUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceStepType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperienceSteps]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[PlayExperienceStepType] = @PlayExperienceStepType,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[PlayChallengeObjectiveDefinitionData] = @PlayChallengeObjectiveDefinitionData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
