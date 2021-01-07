USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellTypesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaCellTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaCellTypes]
	WHERE ID = @ID

	-- Delete PlayAreaCellTypePlayMoveLinks
	DELETE FROM [f30-data].[dbo].[PlayAreaCellTypePlayMoveLinks]
	WHERE [PlayAreaCellTypeID] = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellTypesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellTypesInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@IsSpecialYN [bit],
	@DeckWeighting [int],
	@ImageName [nvarchar](250),
	@BlockedContentPositionsString [nvarchar](50),
	@CellAttributesString [nvarchar](max),
	@CellSideAttributesString [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaCellTypes]
           ([PlaySubsetID],
			[Name],
			[IsSpecialYN],
			[DeckWeighting],
			[ImageName],
			[BlockedContentPositionsString],
			[CellAttributesString],
			[CellSideAttributesString],
			[IndexDefinitionData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@Name,
			@IsSpecialYN,
			@DeckWeighting,
			@ImageName,
			@BlockedContentPositionsString,
			@CellAttributesString,
			@CellSideAttributesString,
			@IndexDefinitionData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellTypesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaCellTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pact.[ID],
			pact.[PlaySubsetID],
			pact.[Name],
			pact.[IsSpecialYN],
			pact.[DeckWeighting],
			pact.[ImageName],
			pact.[BlockedContentPositionsString],
			pact.[CellAttributesString],
			pact.[CellSideAttributesString],
			pact.[IndexDefinitionData],
			pact.[VersionID],
			pact.[VersionDate],
			pact.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaCellTypes] pact
			ORDER BY pact.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellTypesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pact.[ID],
			pact.[PlaySubsetID],
			pact.[Name],
			pact.[IsSpecialYN],
			pact.[DeckWeighting],
			pact.[ImageName],
			pact.[BlockedContentPositionsString],
			pact.[CellAttributesString],
			pact.[CellSideAttributesString],
			pact.[IndexDefinitionData],
			pact.[VersionID],
			pact.[VersionDate],
			pact.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaCellTypes] pact
	WHERE	pact.[ID] = @ID
	ORDER BY pact.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellTypesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellTypesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellTypesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pact.[ID],
			pact.[PlaySubsetID],
			pact.[Name],
			pact.[IsSpecialYN],
			pact.[DeckWeighting],
			pact.[ImageName],
			pact.[BlockedContentPositionsString],
			pact.[CellAttributesString],
			pact.[CellSideAttributesString],
			pact.[IndexDefinitionData],
			pact.[VersionID],
			pact.[VersionDate],
			pact.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayAreaCellTypes] pact
	WHERE	pact.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pact.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellTypesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaCellTypesUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@IsSpecialYN [bit],
	@DeckWeighting [int],
	@ImageName [nvarchar](250),
	@BlockedContentPositionsString [nvarchar](50),
	@CellAttributesString [nvarchar](max),
	@CellSideAttributesString [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaCellTypes]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[Name] = @Name,
			[IsSpecialYN] = @IsSpecialYN,
			[DeckWeighting] = @DeckWeighting,
			[ImageName] = @ImageName,
			[BlockedContentPositionsString] = @BlockedContentPositionsString,
			[CellAttributesString] = @CellAttributesString,
			[CellSideAttributesString] = @CellSideAttributesString,
			[IndexDefinitionData] = @IndexDefinitionData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
