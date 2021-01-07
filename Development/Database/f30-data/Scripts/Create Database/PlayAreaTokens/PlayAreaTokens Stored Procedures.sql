USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTokensDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTokensDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTokensDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaTokens]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTokensInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTokensInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTokensInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@Column [int],
	@Row [int],
	@ImageName [nvarchar](250),
	@TokenAttributesString [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaTokens]
           ([RelativeMemberID],
			[PlayGameID],
			[Column],
			[Row],
			[ImageName],
			[TokenAttributesString])
     VALUES
           (@RelativeMemberID,
			@PlayGameID,
			@Column,
			@Row,
			@ImageName,
			@TokenAttributesString
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTokensSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTokensSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTokensSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[Column],
			pat.[Row],
			pat.[ImageName],
			pat.[TokenAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTokens] pat
			ORDER BY pat.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTokensSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTokensSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTokensSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[Column],
			pat.[Row],
			pat.[ImageName],
			pat.[TokenAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTokens] pat
	WHERE	pat.[ID] = @ID
	ORDER BY pat.[ID] DESC
	
							
END


GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTokensSelectByPlayGameID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTokensSelectByPlayGameID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTokensSelectByPlayGameID]
(
	@PlayGameID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pat.[ID],
			pat.[RelativeMemberID],
			pat.[PlayGameID],
			pat.[Column],
			pat.[Row],
			pat.[ImageName],
			pat.[TokenAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaTokens] pat
	WHERE	pat.[PlayGameID] = @PlayGameID
	ORDER BY pat.[ID] DESC
	
							
END


GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTokensUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTokensUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTokensUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@Column [int],
	@Row [int],
	@ImageName [nvarchar](250),
	@TokenAttributesString [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaTokens]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayGameID] = @PlayGameID,
			[Column] = @Column,
			[Row] = @Row,
			[ImageName] = @ImageName,
			[TokenAttributesString] = @TokenAttributesString
	WHERE ID = @ID

END

GO
