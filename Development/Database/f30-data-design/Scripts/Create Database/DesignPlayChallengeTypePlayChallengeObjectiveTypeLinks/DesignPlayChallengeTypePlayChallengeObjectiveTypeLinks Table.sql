USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks]') AND type in (N'U'))
DROP TABLE [dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExportedID] [int] NOT NULL,
	[DesignPlayChallengeTypeID] [int] NOT NULL,
	[ExportedPlayChallengeTypeID] [int] NOT NULL,
	[DesignPlayChallengeObjectiveTypeID] [int] NOT NULL,
	[ExportedPlayChallengeObjectiveTypeID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL,
	[CanExportYN] [bit] NOT NULL,
	[ExportStatus] [int] NOT NULL
 CONSTRAINT [PK_DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


