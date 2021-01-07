GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayChallengeObjectiveTypes]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayChallengeObjectiveTypes] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayChallengeObjectiveTypes]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayChallengeObjectiveTypes]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayChallengeObjectiveTypesFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayChallengeObjectiveTypesFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayChallengeObjectiveTypesFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayChallengeObjectiveTypes]
	(
		Name Language 1033,
		ContentData Language 1033
	) 
	KEY INDEX PK_DesignPlayChallengeObjectiveTypes ON designPlayChallengeObjectiveTypesFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayChallengeObjectiveTypes] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayChallengeObjectiveTypes] SET CHANGE_TRACKING AUTO;
GO