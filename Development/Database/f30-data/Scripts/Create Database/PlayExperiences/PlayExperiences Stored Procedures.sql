USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperiences]
	WHERE ID = @ID

	-- Delete PlayExperiencePlayExperienceStepLinks
	DELETE FROM [f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks]
	WHERE [PlayExperienceID] = @ID

	-- Delete PlayExperiencesKeywordIndex
	DELETE FROM [f30-data].[dbo].[PlayExperiencesKeywordIndex]
	WHERE [PlayExperienceID] = @ID

	-- Delete PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex
	DELETE FROM [f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
	WHERE [PlayExperienceID] = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperiences]
           ([PlaySubsetID],
			[PlayExperienceType],
			[Name],
			[ContentData],
			[OnCompleteData],
			[PlayChallengeObjectiveDefinitionData],
			[IndexDefinitionData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@PlayExperienceType,
			@Name,
			@ContentData,
			@OnCompleteData,
			@PlayChallengeObjectiveDefinitionData,
			@IndexDefinitionData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pe.[ID],
			pe.[PlaySubsetID],
			pe.[PlayExperienceType],
			pe.[Name],
			pe.[ContentData],
			pe.[OnCompleteData],
			pe.[PlayChallengeObjectiveDefinitionData],
			pe.[IndexDefinitionData],
			pe.[VersionID],
			pe.[VersionDate],
			pe.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiences] pe
			ORDER BY pe.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pe.[ID],
			pe.[PlaySubsetID],
			pe.[PlayExperienceType],
			pe.[Name],
			pe.[ContentData],
			pe.[OnCompleteData],
			pe.[PlayChallengeObjectiveDefinitionData],
			pe.[IndexDefinitionData],
			pe.[VersionID],
			pe.[VersionDate],
			pe.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiences] pe
	WHERE	pe.[ID] = @ID
	ORDER BY pe.[ID] DESC
	
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesSelectByKeywordIndex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesSelectByKeywordIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesSelectByKeywordIndex]
(
	@PlaySubsetID int,
	@PlayExperienceKeyWords nvarchar(500),
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayExperiences
	DECLARE @PE TABLE(
		ID int,
		PlaySubsetID [int],
		PlayExperienceType [int],
		Name [nvarchar](250),
		ContentData [nvarchar](max),
		OnCompleteData [nvarchar](max),
		PlayChallengeObjectiveDefinitionData [nvarchar](max),
		IndexDefinitionData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int])

	INSERT INTO @PE
	SELECT	pe.[ID],
			pe.[PlaySubsetID],
			pe.[PlayExperienceType],
			pe.[Name],
			pe.[ContentData],
			pe.[OnCompleteData],
			pe.[PlayChallengeObjectiveDefinitionData],
			pe.[IndexDefinitionData],
			pe.[VersionID],
			pe.[VersionDate],
			pe.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiences] pe
	WHERE	pe.[ID] IN (SELECT	peki.[PlayExperienceID]
						FROM	[f30-data].[dbo].[PlayExperiencesKeywordIndex] peki
						WHERE	peki.[PlaySubsetID] = @PlaySubsetID
								AND peki.[Keyword] IN (SELECT * FROM [dbo].Split(@PlayExperienceKeyWords, ',')))													
	ORDER BY pe.[ID] DESC
	
	-- Select PlayExperiences
	SELECT * FROM @PE pe
	ORDER BY pe.[ID] DESC

	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayExperienceSteps, PlayExperiencePlayExperienceStepLinks

		-- Create a table variable for the PlayExperiencePlayExperienceStepLinks
		DECLARE @L TABLE(
			ID int,
			PlayExperienceID [int],
			PlayExperienceStepID [int],
			[Index] [int],
			VersionID [int],
			VersionDate [datetime],
			VersionOwnerID [int])

		INSERT INTO @L
		SELECT	l.[ID],
				l.[PlayExperienceID],
				l.[PlayExperienceStepID],
				l.[Index],
				l.[VersionID],
				l.[VersionDate],
				l.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayExperiencePlayExperienceStepLinks] l
		WHERE	l.[PlayExperienceID] IN (SELECT pe.[ID] FROM @PE pe)

		-- Select PlayExperienceSteps
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
				INNER JOIN @L l ON l.[PlayExperienceStepID] = pes.[ID]
		WHERE	pes.[ID] IN (SELECT l.[PlayExperienceStepID] FROM @L l)
		ORDER BY pes.[ID] DESC

		-- Select PlayExperiencePlayExperienceStepLinks
		SELECT * FROM @L l
		ORDER BY l.[ID] DESC

	END
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pe.[ID],
			pe.[PlaySubsetID],
			pe.[PlayExperienceType],
			pe.[Name],
			pe.[ContentData],
			pe.[OnCompleteData],
			pe.[PlayChallengeObjectiveDefinitionData],
			pe.[IndexDefinitionData],
			pe.[VersionID],
			pe.[VersionDate],
			pe.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayExperiences] pe
	WHERE	pe.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pe.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperiences]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[PlayExperienceType] = @PlayExperienceType,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[PlayChallengeObjectiveDefinitionData] = @PlayChallengeObjectiveDefinitionData,
			[IndexDefinitionData] = @IndexDefinitionData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO





USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesPopulateKeywordIndex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesPopulateKeywordIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesPopulateKeywordIndex]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceKeywords [nvarchar](4000)
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayExperienceKeyWords
	DECLARE @K TABLE(
		Keyword [nvarchar](100))

	INSERT INTO @K
	SELECT * FROM [dbo].Split(@PlayExperienceKeyWords, ',')

	-- Delete index items for PlayExperience
	DELETE FROM [f30-data].[dbo].[PlayExperiencesKeywordIndex]
	WHERE [PlayExperienceID] = @ID

	-- Insert index items for PlayExperience
	INSERT INTO [f30-data].[dbo].[PlayExperiencesKeywordIndex]
	SELECT	@PlaySubsetID,
			@ID,
			k.[Keyword]
	FROM	@K k


END

GO






USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesPopulateKeywordPlayChallengeObjectiveCodeIndex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesPopulateKeywordPlayChallengeObjectiveCodeIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesPopulateKeywordPlayChallengeObjectiveCodeIndex]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceKeywords [nvarchar](4000),
	@PlayChallengeObjectiveCodes [nvarchar](4000)
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayExperienceKeyWords
	DECLARE @K TABLE(
		Keyword [nvarchar](100))

	INSERT INTO @K
	SELECT * FROM [dbo].Split(@PlayExperienceKeyWords, ',')

	-- Create a table variable for the PlayChallengeObjectiveCodes
	DECLARE @C TABLE(
		Code [nvarchar](10))

	INSERT INTO @C
	SELECT * FROM [dbo].Split(@PlayChallengeObjectiveCodes, ',')


	-- Delete index items for PlayExperience
	DELETE FROM [f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
	WHERE [PlayExperienceID] = @ID



	DECLARE @Keyword nvarchar(100)

	-- Create cursor
	DECLARE keywordsCursor CURSOR FOR 
	SELECT	k.[Keyword]
	FROM	@K k

	OPEN keywordsCursor

	FETCH NEXT FROM keywordsCursor 
	INTO @Keyword
	
	WHILE @@FETCH_STATUS = 0
	BEGIN

		-- Insert index items for PlayExperienceKeyword
		INSERT INTO [f30-data].[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
		SELECT	@PlaySubsetID,
				@ID,
				@Keyword,
				c.[Code]
		FROM	@C c
		
		FETCH NEXT FROM keywordsCursor 
		INTO @Keyword
	END 

	CLOSE keywordsCursor
	DEALLOCATE keywordsCursor	


END

GO
