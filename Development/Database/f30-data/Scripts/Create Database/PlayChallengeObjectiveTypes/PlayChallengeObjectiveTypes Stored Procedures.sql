USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectiveTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallengeObjectiveTypes]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectiveTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@Code [nvarchar](10),
	@DefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallengeObjectiveTypes]
           ([PlaySubsetID],
			[Name],
			[ContentData],
			[OnCompleteData],
			[Code],
			[DefinitionData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@Name,
			@ContentData,
			@OnCompleteData,
			@Code,
			@DefinitionData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectiveTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pcot.[ID],
			pcot.[PlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeObjectiveTypes] pcot
			ORDER BY pcot.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectiveTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pcot.[ID],
			pcot.[PlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeObjectiveTypes] pcot
	WHERE	pcot.[ID] = @ID
	ORDER BY pcot.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectiveTypesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pcot.[ID],
			pcot.[PlaySubsetID],
			pcot.[Name],
			pcot.[ContentData],
			pcot.[OnCompleteData],
			pcot.[Code],
			pcot.[DefinitionData],
			pcot.[VersionID],
			pcot.[VersionDate],
			pcot.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeObjectiveTypes] pcot
	WHERE	pcot.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pcot.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeObjectiveTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeObjectiveTypesUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@Code [nvarchar](10),
	@DefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallengeObjectiveTypes]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[Code] = @Code,
			[DefinitionData] = @DefinitionData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
