USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]') AND type in (N'U'))
DROP TABLE [dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExportedID] [int] NOT NULL,
	[DesignPlayExperienceStepID] [int] NOT NULL,
	[ExportedPlayExperienceStepID] [int] NOT NULL,
	[DesignPlayExperienceStepExerciseID] [int] NOT NULL,
	[ExportedPlayExperienceStepExerciseID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL,
	[CanExportYN] [bit] NOT NULL,
	[ExportStatus] [int] NOT NULL
 CONSTRAINT [PK_DesignPlayExperienceStepPlayExperienceStepExerciseLinks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


