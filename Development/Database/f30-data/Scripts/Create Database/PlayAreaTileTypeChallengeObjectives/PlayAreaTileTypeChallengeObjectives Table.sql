USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayAreaTileTypeChallengeObjectives]') AND type in (N'U'))
DROP TABLE [dbo].[PlayAreaTileTypeChallengeObjectives]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayAreaTileTypeChallengeObjectives](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayAreaTileTypeID] [int] NOT NULL,
	[PlayChallengeObjectiveCode] [nvarchar](10) NOT NULL,
	[PlayChallengeObjectiveData] [nvarchar](max) NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL
 CONSTRAINT [PK_PlayAreaTileTypeChallengeObjectives] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


