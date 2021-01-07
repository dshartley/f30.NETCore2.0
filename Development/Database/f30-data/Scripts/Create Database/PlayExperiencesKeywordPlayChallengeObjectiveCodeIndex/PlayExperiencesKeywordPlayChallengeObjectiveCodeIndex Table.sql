USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]') AND type in (N'U'))
DROP TABLE [dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlaySubsetID] [int] NOT NULL,
	[PlayExperienceID] [int] NOT NULL,
	[PlayExperienceKeyword] [nvarchar](100) NOT NULL,
	[PlayChallengeObjectiveCode] nvarchar(10) NOT NULL
 CONSTRAINT [PK_PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


