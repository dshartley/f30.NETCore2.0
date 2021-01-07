USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DesignPlayMoves]') AND type in (N'U'))
DROP TABLE [dbo].[DesignPlayMoves]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DesignPlayMoves](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExportedID] [int] NOT NULL,
	[DesignPlaySubsetID] [int] NOT NULL,
	[ExportedPlaySubsetID] [int] NOT NULL,
	[PlayReferenceData] [nvarchar](max) NOT NULL,
	[PlayReferenceActionType] [int] NOT NULL,
	[ExportedThumbnailImageName] [nvarchar](250) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ContentData] [nvarchar](max) NOT NULL,
	[OnCompleteData] [nvarchar](max) NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL,
	[CanExportYN] [bit] NOT NULL,
	[ExportStatus] [int] NOT NULL
 CONSTRAINT [PK_DesignPlayMoves] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



