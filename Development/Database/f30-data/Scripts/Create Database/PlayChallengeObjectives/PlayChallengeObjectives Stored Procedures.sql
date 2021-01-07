USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectivesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectivesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectivesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallengeObjectives]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectivesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectivesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectivesInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayChallengeID [int],
	@PlayChallengeObjectiveTypeID [int],
	@IsAchievedYN [bit],
	@DateActive [datetime]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallengeObjectives]
           ([RelativeMemberID],
			[PlayChallengeID],
			[PlayChallengeObjectiveTypeID],
			[IsAchievedYN],
			[DateActive])
     VALUES
           (@RelativeMemberID,
			@PlayChallengeID,
			@PlayChallengeObjectiveTypeID,
			@IsAchievedYN,
			@DateActive
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectivesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectivesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectivesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pco.[ID],
			pco.[RelativeMemberID],
			pco.[PlayChallengeID],
			pco.[PlayChallengeObjectiveTypeID],
			pco.[IsAchievedYN],
			pco.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallengeObjectives] pco
			ORDER BY pco.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectivesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectivesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectivesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pco.[ID],
			pco.[RelativeMemberID],
			pco.[PlayChallengeID],
			pco.[PlayChallengeObjectiveTypeID],
			pco.[IsAchievedYN],
			pco.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallengeObjectives] pco
	WHERE	pco.[ID] = @ID
	ORDER BY pco.[ID] DESC
	
							
END


GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectivesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectivesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectivesUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayChallengeID [int],
	@PlayChallengeObjectiveTypeID [int],
	@IsAchievedYN [bit],
	@DateActive [datetime]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallengeObjectives]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayChallengeID] = @PlayChallengeID,
			[PlayChallengeObjectiveTypeID] = @PlayChallengeObjectiveTypeID,
			[IsAchievedYN] = @IsAchievedYN,
			[DateActive] = @DateActive
	WHERE ID = @ID

END

GO
