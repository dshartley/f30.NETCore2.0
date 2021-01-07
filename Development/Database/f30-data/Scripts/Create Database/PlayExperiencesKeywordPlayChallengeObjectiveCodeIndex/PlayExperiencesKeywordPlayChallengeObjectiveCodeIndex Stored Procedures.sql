USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceID [int],
	@PlayExperienceKeyword [nvarchar](100),
	@PlayChallengeObjectiveCode [nvarchar](10)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
           ([PlaySubsetID],
			[PlayExperienceID],
			[PlayExperienceKeyword],
			[PlayChallengeObjectiveCode])
     VALUES
           (@PlaySubsetID,
			@PlayExperienceID,
			@PlayExperienceKeyword,
			@PlayChallengeObjectiveCode
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pekpcoci.[ID],
			pekpcoci.[PlaySubsetID],
			pekpcoci.[PlayExperienceID],
			pekpcoci.[PlayExperienceKeyword],
			pekpcoci.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex] pekpcoci
	ORDER BY pekpcoci.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pekpcoci.[ID],
			pekpcoci.[PlaySubsetID],
			pekpcoci.[PlayExperienceID],
			pekpcoci.[PlayExperienceKeyword],
			pekpcoci.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex] pekpcoci
	WHERE	pekpcoci.[ID] = @ID
	ORDER BY pekpcoci.[ID] DESC
	
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelectByPlayExperienceKeywords]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelectByPlayExperienceKeywords]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexSelectByPlayExperienceKeywords]
(
	@PlaySubsetID int,
	@PlayExperienceKeywords nvarchar(max)
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pekpcoci.[ID],
			pekpcoci.[PlaySubsetID],
			pekpcoci.[PlayExperienceID],
			pekpcoci.[PlayExperienceKeyword],
			pekpcoci.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex] pekpcoci
	WHERE	pekpcoci.[PlaySubsetID] = @PlaySubsetID
			AND pekpcoci.[PlayExperienceKeyword] IN (SELECT * FROM [dbo].Split(@PlayExperienceKeyWords, ','))
	
							
END


GO






USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceID [int],
	@PlayExperienceKeyword [nvarchar](100),
	@PlayChallengeObjectiveCode [nvarchar](10)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[PlayExperienceID] = @PlayExperienceID,
			[PlayExperienceKeyword] = @PlayExperienceKeyword,
			[PlayChallengeObjectiveCode] = @PlayChallengeObjectiveCode
	WHERE ID = @ID

END

GO
