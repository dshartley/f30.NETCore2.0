USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayChallengeObjectives]') AND type in (N'U'))
DROP TABLE [dbo].[PlayChallengeObjectives]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayChallengeObjectives](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RelativeMemberID] [nvarchar](30) NOT NULL,
	[PlayChallengeID] [int] NOT NULL,
	[PlayChallengeObjectiveTypeID] [int] NOT NULL,
	[IsAchievedYN] [bit] NOT NULL,
	[DateActive] [datetime] NOT NULL
 CONSTRAINT [PK_PlayChallengeObjectives] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


