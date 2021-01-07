USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallenges]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengesInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@PlayMoveID [int],
	@PlayChallengeTypeID [int],
	@IsActiveYN [bit],
	@IsCompleteYN [bit],
	@DateActive [datetime]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallenges]
           ([RelativeMemberID],
			[PlayGameID],
			[PlayMoveID],
			[PlayChallengeTypeID],
			[IsActiveYN],
			[IsCompleteYN],
			[DateActive])
     VALUES
           (@RelativeMemberID,
			@PlayGameID,
			@PlayMoveID,
			@PlayChallengeTypeID,
			@IsActiveYN,
			@IsCompleteYN,
			@DateActive
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pc.[ID],
			pc.[RelativeMemberID],
			pc.[PlayGameID],
			pc.[PlayMoveID],
			pc.[PlayChallengeTypeID],
			pc.[IsActiveYN],
			pc.[IsCompleteYN],
			pc.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallenges] pc
			ORDER BY pc.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pc.[ID],
			pc.[RelativeMemberID],
			pc.[PlayGameID],
			pc.[PlayMoveID],
			pc.[PlayChallengeTypeID],
			pc.[IsActiveYN],
			pc.[IsCompleteYN],
			pc.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallenges] pc
	WHERE	pc.[ID] = @ID
	ORDER BY pc.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesSelectByPlayGameIDIsActiveYN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesSelectByPlayGameIDIsActiveYN]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengesSelectByPlayGameIDIsActiveYN]
(
	@RelativeMemberID int,
	@PlayGameID int,
	@IsActiveYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayChallenges
	DECLARE @PC TABLE(
		ID int,
		RelativeMemberID nvarchar(30),
		PlayGameID int,
		PlayMoveID int,
		PlayChallengeTypeID int,
		IsActiveYN bit,
		IsCompleteYN bit,
		DateActive datetime)

	INSERT INTO @PC
	SELECT	pc.[ID],
			pc.[RelativeMemberID],
			pc.[PlayGameID],
			pc.[PlayMoveID],
			pc.[PlayChallengeTypeID],
			pc.[IsActiveYN],
			pc.[IsCompleteYN],
			pc.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallenges] pc
	WHERE	pc.[PlayGameID] = @PlayGameID
			AND pc.[IsActiveYN] = 1
	ORDER BY pc.[ID] DESC
	
	-- Select PlayChallenges
	SELECT * FROM @PC pc
	ORDER BY pc.[ID] DESC
			

	-- Load Relational Tables:
	-- PlayChallengeTypes, PlayChallengeObjectives, PlayChallengeObjectiveTypes

	-- Select PlayChallengeTypes
	SELECT	pct.[ID],
			pct.[PlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
	WHERE	pct.[ID] IN (SELECT pc.[PlayChallengeTypeID] FROM @PC pc)
	ORDER BY pct.[ID] DESC

	-- Create a table variable for the PlayChallengeObjectives
	DECLARE @PCO TABLE(
		ID int,
		RelativeMemberID nvarchar(30),
		PlayChallengeID int,
		PlayChallengeObjectiveTypeID int,
		IsAchievedYN bit,
		DateActive datetime)

	-- Select PlayChallengeObjectives
	INSERT INTO @PCO
	SELECT	pco.[ID],
			pco.[RelativeMemberID],
			pco.[PlayChallengeID],
			pco.[PlayChallengeObjectiveTypeID],
			pco.[IsAchievedYN],
			pco.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallengeObjectives] pco
	WHERE	pco.[PlayChallengeID] IN (SELECT pc.[ID] FROM @PC pc)
	ORDER BY pco.[ID] DESC

	-- Select PlayChallengeObjectives
	SELECT * FROM @PCO pco
	ORDER BY pco.[ID] DESC

	-- Select PlayChallengeObjectiveTypes
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
	WHERE	pcot.[ID] IN (SELECT pco.[PlayChallengeObjectiveTypeID] FROM @PCO pco)
	ORDER BY pcot.[ID] DESC
				
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesSelectByIDLoadRelationalTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesSelectByIDLoadRelationalTables]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengesSelectByIDLoadRelationalTables]
(
	@ID int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayChallenges
	DECLARE @PC TABLE(
		ID int,
		RelativeMemberID nvarchar(30),
		PlayGameID int,
		PlayMoveID int,
		PlayChallengeTypeID int,
		IsActiveYN bit,
		IsCompleteYN bit,
		DateActive datetime)

	INSERT INTO @PC
	SELECT	pc.[ID],
			pc.[RelativeMemberID],
			pc.[PlayGameID],
			pc.[PlayMoveID],
			pc.[PlayChallengeTypeID],
			pc.[IsActiveYN],
			pc.[IsCompleteYN],
			pc.[DateActive]
	FROM	[f30-data].[dbo].[PlayChallenges] pc
	WHERE	pc.[ID] = @ID
	ORDER BY pc.[ID] DESC
	
	-- Select PlayChallenges
	SELECT * FROM @PC pc
	ORDER BY pc.[ID] DESC
	
	IF (@LoadRelationalTablesYN = 1)
	BEGIN
	
		-- Load Relational Tables:
		-- PlayChallengeTypes, PlayChallengeObjectives, PlayChallengeObjectiveTypes

		-- Select PlayChallengeTypes
		SELECT	pct.[ID],
				pct.[PlaySubsetID],
				pct.[Name],
				pct.[ContentData],
				pct.[OnCompleteData],
				pct.[VersionID],
				pct.[VersionDate],
				pct.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
		WHERE	pct.[ID] IN (SELECT pc.[PlayChallengeTypeID] FROM @PC pc)
		ORDER BY pct.[ID] DESC

		-- Create a table variable for the PlayChallengeObjectives
		DECLARE @PCO TABLE(
			ID int,
			RelativeMemberID nvarchar(30),
			PlayChallengeID int,
			PlayChallengeObjectiveTypeID int,
			IsAchievedYN bit,
			DateActive datetime)

		-- Select PlayChallengeObjectives
		INSERT INTO @PCO
		SELECT	pco.[ID],
				pco.[RelativeMemberID],
				pco.[PlayChallengeID],
				pco.[PlayChallengeObjectiveTypeID],
				pco.[IsAchievedYN],
				pco.[DateActive]
		FROM	[f30-data].[dbo].[PlayChallengeObjectives] pco
		WHERE	pco.[PlayChallengeID] IN (SELECT pc.[ID] FROM @PC pc)
		ORDER BY pco.[ID] DESC

		-- Select PlayChallengeObjectives
		SELECT * FROM @PCO pco
		ORDER BY pco.[ID] DESC

		-- Select PlayChallengeObjectiveTypes
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
		WHERE	pcot.[ID] IN (SELECT pco.[PlayChallengeObjectiveTypeID] FROM @PCO pco)
		ORDER BY pcot.[ID] DESC

	END
						
END


GO





USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengesUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@PlayMoveID [int],
	@PlayChallengeTypeID [int],
	@IsActiveYN [bit],
	@IsCompleteYN [bit],
	@DateActive [datetime]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallenges]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayGameID] = @PlayGameID,
			[PlayMoveID] = @PlayMoveID,
			[PlayChallengeTypeID] = @PlayChallengeTypeID,
			[IsActiveYN] = @IsActiveYN,
			[IsCompleteYN] = @IsCompleteYN,
			[DateActive] = @DateActive
	WHERE ID = @ID

END

GO
