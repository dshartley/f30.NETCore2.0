USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayAreaTileData]') AND type in (N'U'))
DROP TABLE [dbo].[PlayAreaTileData]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayAreaTileData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RelativeMemberID] [nvarchar](30) NOT NULL,
	[PlayAreaTileID] [int] NOT NULL,
	[OnCompleteData] [nvarchar](max) NOT NULL,
	[AttributeData] [nvarchar](max) NOT NULL
 CONSTRAINT [PK_PlayAreaTileData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


