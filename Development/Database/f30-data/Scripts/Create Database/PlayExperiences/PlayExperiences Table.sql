USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayExperiences]') AND type in (N'U'))
DROP TABLE [dbo].[PlayExperiences]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayExperiences](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlaySubsetID] [int] NOT NULL,
	[PlayExperienceType] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ContentData] [nvarchar](max) NOT NULL,
	[OnCompleteData] [nvarchar](max) NOT NULL,
	[PlayChallengeObjectiveDefinitionData] [nvarchar](max) NOT NULL,
	[IndexDefinitionData] [nvarchar](max) NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL
 CONSTRAINT [PK_PlayExperiences] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


