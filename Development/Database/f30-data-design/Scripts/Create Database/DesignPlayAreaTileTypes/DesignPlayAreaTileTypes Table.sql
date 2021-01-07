USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DesignPlayAreaTileTypes]') AND type in (N'U'))
DROP TABLE [dbo].[DesignPlayAreaTileTypes]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DesignPlayAreaTileTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExportedID] [int] NOT NULL,
	[DesignPlaySubsetID] [int] NOT NULL,
	[ExportedPlaySubsetID] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsSpecialYN] [bit] NOT NULL,
	[DeckWeighting] [int] NOT NULL,
	[ImageName] [nvarchar](250) NOT NULL,
	[ExportedImageName] [nvarchar](250) NOT NULL,
	[WidthPixels] [int] NOT NULL,
	[HeightPixels] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[PositionFixToCellRotationYN] [bit] NOT NULL,
	[TileAttributesString] [nvarchar](max) NOT NULL,
	[TileSideAttributesString] [nvarchar](max) NOT NULL,
	[IndexDefinitionData] [nvarchar](max) NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL,
	[CanExportYN] [bit] NOT NULL,
	[ExportStatus] [int] NOT NULL
 CONSTRAINT [PK_DesignPlayAreaTileTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


