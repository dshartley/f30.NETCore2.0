USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayAreaCellTypePlayMoveLinks]') AND type in (N'U'))
DROP TABLE [dbo].[PlayAreaCellTypePlayMoveLinks]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayAreaCellTypePlayMoveLinks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayAreaCellTypeID] [int] NOT NULL,
	[PlayMoveID] [int] NOT NULL,
	[Index] int NOT NULL,
	[VersionID] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[VersionOwnerID] [int] NOT NULL
 CONSTRAINT [PK_PlayAreaCellTypePlayMoveLinks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


