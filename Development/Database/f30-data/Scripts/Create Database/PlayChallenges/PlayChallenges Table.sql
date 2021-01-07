USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayChallenges]') AND type in (N'U'))
DROP TABLE [dbo].[PlayChallenges]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayChallenges](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RelativeMemberID] [nvarchar](30) NOT NULL,
	[PlayGameID] [int] NOT NULL,
	[PlayMoveID] [int] NOT NULL,
	[PlayChallengeTypeID] [int] NOT NULL,
	[IsActiveYN] [bit] NOT NULL,
	[IsCompleteYN] [bit] NOT NULL,
	[DateActive] [datetime] NOT NULL
 CONSTRAINT [PK_PlayChallenges] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


