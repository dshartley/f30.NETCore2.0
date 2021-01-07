GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayAreaCellTypes]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayAreaCellTypes] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayAreaCellTypes]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayAreaCellTypes]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayAreaCellTypesFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayAreaCellTypesFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayAreaCellTypesFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayAreaCellTypes]
	(
		Name Language 1033
	) 
	KEY INDEX PK_DesignPlayAreaCellTypes ON designPlayAreaCellTypesFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayAreaCellTypes] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayAreaCellTypes] SET CHANGE_TRACKING AUTO;
GO