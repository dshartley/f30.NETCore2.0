GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayExperienceSteps]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperienceSteps] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayExperienceSteps]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayExperienceSteps]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayExperienceStepsFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayExperienceStepsFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayExperienceStepsFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayExperienceSteps]
	(
		Name Language 1033,
		ContentData Language 1033
	) 
	KEY INDEX PK_DesignPlayExperienceSteps ON designPlayExperienceStepsFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperienceSteps] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperienceSteps] SET CHANGE_TRACKING AUTO;
GO