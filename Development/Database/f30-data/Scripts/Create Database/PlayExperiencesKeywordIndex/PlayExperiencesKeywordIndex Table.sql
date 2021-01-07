USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayExperiencesKeywordIndex]') AND type in (N'U'))
DROP TABLE [dbo].[PlayExperiencesKeywordIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayExperiencesKeywordIndex](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlaySubsetID] [int] NOT NULL,
	[PlayExperienceID] [int] NOT NULL,
	[Keyword] [nvarchar](100) NOT NULL
 CONSTRAINT [PK_PlayExperiencesKeywordIndex] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


