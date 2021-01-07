GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayAreaTileTypes]'))
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayAreaTileTypes] DISABLE
GO

IF  EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[DesignPlayAreaTileTypes]'))
DROP FULLTEXT INDEX ON [dbo].[DesignPlayAreaTileTypes]

GO

IF  EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'designPlayAreaTileTypesFullTextCatalog')
DROP FULLTEXT CATALOG [designPlayAreaTileTypesFullTextCatalog]
GO

USE [f30-data-design]
GO

CREATE FULLTEXT CATALOG [designPlayAreaTileTypesFullTextCatalog]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]

GO


CREATE FULLTEXT INDEX ON [dbo].[DesignPlayAreaTileTypes]
	(
		Name Language 1033
	) 
	KEY INDEX PK_DesignPlayAreaTileTypes ON designPlayAreaTileTypesFullTextCatalog;
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayAreaTileTypes] START FULL POPULATION
GO


USE [f30-data-design]
GO
ALTER FULLTEXT INDEX ON [dbo].[DesignPlayAreaTileTypes] SET CHANGE_TRACKING AUTO;
GO