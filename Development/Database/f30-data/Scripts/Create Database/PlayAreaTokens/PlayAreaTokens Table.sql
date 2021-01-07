USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayAreaTokens]') AND type in (N'U'))
DROP TABLE [dbo].[PlayAreaTokens]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayAreaTokens](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RelativeMemberID] [nvarchar](30) NOT NULL,
	[PlayGameID] [int] NOT NULL,
	[Column] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[ImageName] [nvarchar](250) NOT NULL,
	[TokenAttributesString] [nvarchar](max) NOT NULL
 CONSTRAINT [PK_PlayAreaTokens] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


