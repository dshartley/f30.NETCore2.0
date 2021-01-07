USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypeChallengeObjectivesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaTileTypeChallengeObjectives]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypeChallengeObjectivesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesInsert]
(
	@ID int output,
	@PlayAreaTileTypeID [int],
	@PlayChallengeObjectiveCode [nvarchar](10),
	@PlayChallengeObjectiveData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaTileTypeChallengeObjectives]
           ([PlayAreaTileTypeID],
			[PlayChallengeObjectiveCode],
			[PlayChallengeObjectiveData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlayAreaTileTypeID,
			@PlayChallengeObjectiveCode,
			@PlayChallengeObjectiveData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypeChallengeObjectivesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pattco.[ID],
			pattco.[PlayAreaTileTypeID],
			pattco.[PlayChallengeObjectiveCode],
			pattco.[PlayChallengeObjectiveData],
			pattco.[VersionID],
			pattco.[VersionDate],
			pattco.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaTileTypeChallengeObjectives] pattco
			ORDER BY pattco.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypeChallengeObjectivesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pattco.[ID],
			pattco.[PlayAreaTileTypeID],
			pattco.[PlayChallengeObjectiveCode],
			pattco.[PlayChallengeObjectiveData],
			pattco.[VersionID],
			pattco.[VersionDate],
			pattco.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaTileTypeChallengeObjectives] pattco
	WHERE	pattco.[ID] = @ID
	ORDER BY pattco.[ID] DESC
	
							
END


GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaTileTypeChallengeObjectivesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaTileTypeChallengeObjectivesUpdate]
(
	@ID int output,
	@PlayAreaTileTypeID [int],
	@PlayChallengeObjectiveCode [nvarchar](10),
	@PlayChallengeObjectiveData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaTileTypeChallengeObjectives]
	SET		[PlayAreaTileTypeID] = @PlayAreaTileTypeID,
			[PlayChallengeObjectiveCode] = @PlayChallengeObjectiveCode,
			[PlayChallengeObjectiveData] = @PlayChallengeObjectiveData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
