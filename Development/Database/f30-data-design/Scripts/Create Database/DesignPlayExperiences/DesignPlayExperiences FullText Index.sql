GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayExperiences]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperiences] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayExperiences]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayExperiences]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayExperiencesFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayExperiencesFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayExperiencesFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayExperiences]
	(
		Name Language 1033,
		ContentData Language 1033
	) 
	KEY INDEX PK_DesignPlayExperiences ON designPlayExperiencesFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperiences] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayExperiences] SET CHANGE_TRACKING AUTO;
GO