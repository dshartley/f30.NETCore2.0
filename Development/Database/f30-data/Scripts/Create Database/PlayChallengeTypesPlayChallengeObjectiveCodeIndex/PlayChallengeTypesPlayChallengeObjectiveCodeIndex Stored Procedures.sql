USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayChallengeTypeID [int],
	@PlayChallengeObjectiveCode [nvarchar](100)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex]
           ([PlaySubsetID],
			[PlayChallengeTypeID],
			[PlayChallengeObjectiveCode])
     VALUES
           (@PlaySubsetID,
			@PlayChallengeTypeID,
			@PlayChallengeObjectiveCode
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pctpcoci.[ID],
			pctpcoci.[PlaySubsetID],
			pctpcoci.[PlayChallengeTypeID],
			pctpcoci.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex] pctpcoci
	ORDER BY pctpcoci.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pctpcoci.[ID],
			pctpcoci.[PlaySubsetID],
			pctpcoci.[PlayChallengeTypeID],
			pctpcoci.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex] pctpcoci
	WHERE	pctpcoci.[ID] = @ID
	ORDER BY pctpcoci.[ID] DESC
	
							
END


GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesPlayChallengeObjectiveCodeIndexUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayChallengeTypeID [int],
	@PlayChallengeObjectiveCode [nvarchar](100)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[PlayChallengeTypeID] = @PlayChallengeTypeID,
			[PlayChallengeObjectiveCode] = @PlayChallengeObjectiveCode
	WHERE ID = @ID

END

GO
