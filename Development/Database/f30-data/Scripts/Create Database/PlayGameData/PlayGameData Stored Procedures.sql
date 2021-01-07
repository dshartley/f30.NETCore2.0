USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGameDataDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGameDataDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayGameDataDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayGameData]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGameDataInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGameDataInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGameDataInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@DateLastPlayed [datetime],
	@OnCompleteData [nvarchar](max),
	@AttributeData [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayGameData]
           ([RelativeMemberID],
			[PlayGameID],
			[DateLastPlayed],
			[OnCompleteData],
			[AttributeData])
     VALUES
           (@RelativeMemberID,
			@PlayGameID,
			@DateLastPlayed,
			@OnCompleteData,
			@AttributeData
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGameDataSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGameDataSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayGameDataSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pgd.[ID],
			pgd.[RelativeMemberID],
			pgd.[PlayGameID],
			pgd.[DateLastPlayed],
			pgd.[OnCompleteData],
			pgd.[AttributeData]
	FROM	[f30-data].[dbo].[PlayGameData] pgd
			ORDER BY pgd.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGameDataSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGameDataSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayGameDataSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pgd.[ID],
			pgd.[RelativeMemberID],
			pgd.[PlayGameID],
			pgd.[DateLastPlayed],
			pgd.[OnCompleteData],
			pgd.[AttributeData]
	FROM	[f30-data].[dbo].[PlayGameData] pgd
	WHERE	pgd.[ID] = @ID
	ORDER BY pgd.[ID] DESC
	
							
END


GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayGameDataUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayGameDataUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayGameDataUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@DateLastPlayed [datetime],
	@OnCompleteData [nvarchar](max),
	@AttributeData [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayGameData]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayGameID] = @PlayGameID,
			[DateLastPlayed] = @DateLastPlayed,
			[OnCompleteData] = @OnCompleteData,
			[AttributeData] = @AttributeData
	WHERE ID = @ID

END

GO
