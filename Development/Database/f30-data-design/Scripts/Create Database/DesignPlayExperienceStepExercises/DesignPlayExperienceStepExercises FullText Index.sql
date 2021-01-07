GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayExperienceStepExercises]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperienceStepExercises] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayExperienceStepExercises]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayExperienceStepExercises]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayExperienceStepExercisesFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayExperienceStepExercisesFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayExperienceStepExercisesFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayExperienceStepExercises]
	(
		Name Language 1033,
		ContentData Language 1033
	) 
	KEY INDEX PK_DesignPlayExperienceStepExercises ON designPlayExperienceStepExercisesFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperienceStepExercises] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperienceStepExercises] SET CHANGE_TRACKING AUTO;
GO