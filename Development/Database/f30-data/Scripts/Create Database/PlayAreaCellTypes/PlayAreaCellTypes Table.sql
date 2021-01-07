USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayAreaCellTypes]') AND type in (N'U'))
DROP TABLE [dbo].[PlayAreaCellTypes]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayAreaCellTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlaySubsetID] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsSpecialYN] [bit] NOT NULL,
	[DeckWeighting] [int] NOT NULL,
	[ImageName] [nvarchar](250) NOT NULL,
	[BlockedContentPositionsString] [nvarchar](50) NOT NULL,
	[CellAttributesString] [nvarchar](max) NOT NULL,
	[CellSideAttributesString] [nvarchar](max) NOT NULL,
	[IndexDefinitionData] [nvarchar](max) NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL
 CONSTRAINT [PK_PlayAreaCellTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


