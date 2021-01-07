GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayChallengeTypes]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayChallengeTypes] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayChallengeTypes]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayChallengeTypes]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayChallengeTypesFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayChallengeTypesFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayChallengeTypesFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayChallengeTypes]
	(
		Name Language 1033,
		ContentData Language 1033
	) 
	KEY INDEX PK_DesignPlayChallengeTypes ON designPlayChallengeTypesFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayChallengeTypes] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayChallengeTypes] SET CHANGE_TRACKING AUTO;
GO