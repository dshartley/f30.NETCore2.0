USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayAreaCells]') AND type in (N'U'))
DROP TABLE [dbo].[PlayAreaCells]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayAreaCells](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RelativeMemberID] [nvarchar](30) NOT NULL,
	[PlayGameID] [int] NOT NULL,
	[CellTypeID] [int] NOT NULL,
	[Column] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[RotationDegrees] [int] NOT NULL,
	[ImageName] [nvarchar](250) NOT NULL,
	[CellAttributesString] [nvarchar](max) NOT NULL,
	[CellSideAttributesString] [nvarchar](max) NOT NULL
 CONSTRAINT [PK_PlayAreaCells] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


