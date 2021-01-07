USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileDataDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileDataDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileDataDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaTileData]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileDataInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileDataInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileDataInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](50),
	@PlayAreaTileID [int],
	@OnCompleteData [nvarchar](max),
	@AttributeData [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaTileData]
           ([RelativeMemberID],
			[PlayAreaTileID],
			[OnCompleteData],
			[AttributeData])
     VALUES
           (@RelativeMemberID,
			@PlayAreaTileID,
			@OnCompleteData,
			@AttributeData
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileDataSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileDataSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileDataSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	patd.[ID],
			patd.[RelativeMemberID],
			patd.[PlayAreaTileID],
			patd.[OnCompleteData],
			patd.[AttributeData]
	FROM	[f30-data].[dbo].[PlayAreaTileData] patd
			ORDER BY patd.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileDataSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileDataSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileDataSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	patd.[ID],
			patd.[RelativeMemberID],
			patd.[PlayAreaTileID],
			patd.[OnCompleteData],
			patd.[AttributeData]
	FROM	[f30-data].[dbo].[PlayAreaTileData] patd
	WHERE	patd.[ID] = @ID
	ORDER BY patd.[ID] DESC
	
							
END


GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileDataUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileDataUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileDataUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](50),
	@PlayAreaTileID [int],
	@OnCompleteData [nvarchar](max),
	@AttributeData [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaTileData]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayAreaTileID] = @PlayAreaTileID,
			[OnCompleteData] = @OnCompleteData,
			[AttributeData] = @AttributeData
	WHERE ID = @ID

END

GO
