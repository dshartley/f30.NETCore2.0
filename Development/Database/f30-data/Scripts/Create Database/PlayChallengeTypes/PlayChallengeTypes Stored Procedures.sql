USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayChallengeTypes]
	WHERE ID = @ID

	-- Delete PlayChallengeTypePlayChallengeObjectiveTypeLinks
	DELETE FROM [f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks]
	WHERE [PlayChallengeTypeID] = @ID

	-- Delete PlayChallengeTypePlayMoveLinks
	DELETE FROM [f30-data].[dbo].[PlayChallengeTypePlayMoveLinks]
	WHERE [PlayChallengeTypeID] = @ID

	-- Delete PlayChallengeTypeKeywordIndex
	DELETE FROM [f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex]
	WHERE [PlayChallengeTypeID] = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayChallengeTypes]
           ([PlaySubsetID],
			[Name],
			[ContentData],
			[OnCompleteData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@PlaySubsetID,
			@Name,
			@ContentData,
			@OnCompleteData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pct.[ID],
			pct.[PlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
			ORDER BY pct.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pct.[ID],
			pct.[PlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
	WHERE	pct.[ID] = @ID
	ORDER BY pct.[ID] DESC
	
							
END


GO





GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesSelectByIDLoadRelationalTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByIDLoadRelationalTables]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByIDLoadRelationalTables]
(
	@ID int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayChallengeTypes
	DECLARE @PCT TABLE(
		ID int,
		PlaySubsetID [int],
		Name [nvarchar](250),
		ContentData [nvarchar](max),
		OnCompleteData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int])

	INSERT INTO @PCT
	SELECT	pct.[ID],
			pct.[PlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
	WHERE	pct.[ID] = @ID											

	-- Select PlayChallengeTypes
	SELECT * FROM @PCT pct
	ORDER BY pct.[ID] DESC

	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayChallengeObjectiveTypes, PlayChallengeTypePlayChallengeObjectiveTypeLinks

		-- Create a table variable for the PlayChallengeTypePlayChallengeObjectiveTypeLinks
		DECLARE @L TABLE(
			ID int,
			PlayChallengeTypeID [int],
			PlayChallengeObjectiveTypeID [int],
			[Index] [int],
			VersionID [int],
			VersionDate [datetime],
			VersionOwnerID [int])

		INSERT INTO @L
		SELECT	l.[ID],
				l.[PlayChallengeTypeID],
				l.[PlayChallengeObjectiveTypeID],
				l.[Index],
				l.[VersionID],
				l.[VersionDate],
				l.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks] l
		WHERE	l.[PlayChallengeTypeID] IN (SELECT pct.[ID] FROM @PCT pct)

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
				INNER JOIN @L l ON l.[PlayChallengeObjectiveTypeID] = pcot.[ID]
		WHERE	pcot.[ID] IN (SELECT l.[PlayChallengeObjectiveTypeID] FROM @L l)
		ORDER BY pcot.[ID] DESC

		-- Select PlayChallengeTypePlayChallengeObjectiveTypeLinks
		SELECT * FROM @L l
		ORDER BY l.[ID] DESC

	END
		
						
END


GO






USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesSelectByPlayChallengeObjectiveCodeIndex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByPlayChallengeObjectiveCodeIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByPlayChallengeObjectiveCodeIndex]
(
	@PlaySubsetID int,
	@PlayChallengeObjectiveCodes nvarchar(max),
	@LoadWholePlayChallengeTypesOnlyYN bit,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;


    --// Use PlayChallengeTypesPlayChallengeObjectiveCodeIndex; 
	--//	(i) Load index items by PlayChallengeObjectiveCode
	--//	(ii) Get list of unique playChallengeTypeIDs
	--//	(iii) Load index items where playChallengeTypeID in list of playChallengeTypeIDs
	--//	(iv) Get number of items for each playChallengeTypeID and compare against number of items for each playChallengeTypeID 
	--//		where all codes are in playChallengeObjectiveCodes


	-- (i) Load index items by PlayChallengeObjectiveCode

	-- Create a table variable for the codes
	DECLARE @Codes TABLE(
		PlayChallengeObjectiveCode [nvarchar](10))

	INSERT INTO @Codes
	SELECT	LOWER(Item)
	FROM	[dbo].Split(@PlayChallengeObjectiveCodes, ',')


	-- Create a table variable for the PlayChallengeTypesPlayChallengeObjectiveCodeIndex
	DECLARE @I1 TABLE(
		ID [int],
		PlaySubsetID [int],
		PlayChallengeTypeID [int],
		PlayChallengeObjectiveCode [nvarchar](100))

	INSERT INTO @I1
	SELECT	i.[ID],
			i.[PlaySubsetID],
			i.[PlayChallengeTypeID],
			i.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex] i
	WHERE	LOWER(i.[PlayChallengeObjectiveCode]) IN (SELECT c.[PlayChallengeObjectiveCode] FROM @Codes c)


	-- (ii) Get list of unique playChallengeTypeIDs

	-- Create a table variable for the PlayChallengeTypeIDs
	DECLARE @PlayChallengeTypeIDs TABLE(
		PlayChallengeTypeID [int],
		ActualItems [int],
		TotalItems [int])

	INSERT INTO @PlayChallengeTypeIDs
	SELECT	DISTINCT i1.[PlayChallengeTypeID],
			0, 0 
	FROM	@I1 i1


	-- (iii) Load index items where playChallengeTypeID in list of playChallengeTypeIDs

	-- Create a table variable for the PlayChallengeTypesPlayChallengeObjectiveCodeIndex
	DECLARE @I2 TABLE(
		ID [int],
		PlaySubsetID [int],
		PlayChallengeTypeID [int],
		PlayChallengeObjectiveCode [nvarchar](100))

	INSERT INTO @I2
	SELECT	i.[ID],
			i.[PlaySubsetID],
			i.[PlayChallengeTypeID],
			i.[PlayChallengeObjectiveCode]
	FROM	[f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex] i
	WHERE	i.[PlayChallengeTypeID] IN (SELECT p.[PlayChallengeTypeID] FROM @PlayChallengeTypeIDs p)


	-- (iv) Get number of items for each playChallengeTypeID and compare against number of items for each playChallengeTypeID 
	--		where all codes are in playChallengeObjectiveCodes

	UPDATE	pcti
	SET		pcti.[TotalItems] = (SELECT COUNT(*) FROM @I2 i2 WHERE i2.[PlayChallengeTypeID] = pcti.[PlayChallengeTypeID]),
			pcti.[ActualItems] = (SELECT COUNT(*) FROM @I1 i1 WHERE i1.[PlayChallengeTypeID] = pcti.[PlayChallengeTypeID])
	FROM	@PlayChallengeTypeIDs pcti


	-- Create a table variable for the PlayChallengeTypes
	DECLARE @PCT TABLE(
		ID int,
		PlaySubsetID [int],
		Name [nvarchar](250),
		ContentData [nvarchar](max),
		OnCompleteData [nvarchar](max),
		VersionID [int],
		VersionDate [datetime],
		VersionOwnerID [int])

	INSERT INTO @PCT
	SELECT	pct.[ID],
			pct.[PlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
	WHERE	pct.[ID] IN (SELECT	p.[PlayChallengeTypeID]
						FROM	@PlayChallengeTypeIDs p
						WHERE	p.[ActualItems] =	CASE @LoadWholePlayChallengeTypesOnlyYN 
													WHEN 1 THEN p.[TotalItems] 
													ELSE p.[ActualItems]
													END)												
	ORDER BY pct.[ID] DESC
	
	-- Select PlayChallengeTypes
	SELECT * FROM @PCT pct
	ORDER BY pct.[ID] DESC

	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayChallengeObjectiveTypes, PlayChallengeTypePlayChallengeObjectiveTypeLinks, PlayMoves, PlayChallengeTypePlayMoveLinks

		-- Create a table variable for the PlayChallengeTypePlayChallengeObjectiveTypeLinks
		DECLARE @L TABLE(
			ID int,
			PlayChallengeTypeID [int],
			PlayChallengeObjectiveTypeID [int],
			[Index] [int],
			VersionID [int],
			VersionDate [datetime],
			VersionOwnerID [int])

		INSERT INTO @L
		SELECT	l.[ID],
				l.[PlayChallengeTypeID],
				l.[PlayChallengeObjectiveTypeID],
				l.[Index],
				l.[VersionID],
				l.[VersionDate],
				l.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayChallengeTypePlayChallengeObjectiveTypeLinks] l
		WHERE	l.[PlayChallengeTypeID] IN (SELECT pct.[ID] FROM @PCT pct)

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
				INNER JOIN @L l ON l.[PlayChallengeObjectiveTypeID] = pcot.[ID]
		WHERE	pcot.[ID] IN (SELECT l.[PlayChallengeObjectiveTypeID] FROM @L l)
		ORDER BY pcot.[ID] DESC

		-- Select PlayChallengeTypePlayChallengeObjectiveTypeLinks
		SELECT * FROM @L l
		ORDER BY l.[ID] DESC

		-- Create a table variable for the PlayChallengeTypePlayMoveLinks
		DECLARE @PCTPML TABLE(
			ID int,
			PlayChallengeTypeID [int],
			PlayMoveID [int],
			[Index] [int],
			VersionID [int],
			VersionDate [datetime],
			VersionOwnerID [int])

		INSERT INTO @PCTPML
		SELECT	l.[ID],
				l.[PlayChallengeTypeID],
				l.[PlayMoveID],
				l.[Index],
				l.[VersionID],
				l.[VersionDate],
				l.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayChallengeTypePlayMoveLinks] l
		WHERE	l.[PlayChallengeTypeID] IN (SELECT pct.[ID] FROM @PCT pct)

		-- Select PlayMoves
		SELECT	pm.[ID],
				pm.[PlaySubsetID],
				pm.[PlayReferenceData],
				pm.[PlayReferenceActionType],
				pm.[Name],
				pm.[ContentData],
				pm.[OnCompleteData],
				pm.[VersionID],
				pm.[VersionDate],
				pm.[VersionOwnerID]
		FROM	[f30-data].[dbo].[PlayMoves] pm
				INNER JOIN @PCTPML l ON l.[PlayMoveID] = pm.[ID]
		WHERE	pm.[ID] IN (SELECT l.[PlayMoveID] FROM @PCTPML l)
		ORDER BY pm.[ID] DESC

		-- Select PlayChallengeTypePlayMoveLinks
		SELECT * FROM @PCTPML l
		ORDER BY l.[ID] DESC

	END
							
END


GO







USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesSelectByPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByPlaySubsetID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesSelectByPlaySubsetID]
(
	@PlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pct.[ID],
			pct.[PlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlayChallengeTypes] pct
	WHERE	pct.[PlaySubsetID] = @PlaySubsetID
	ORDER BY pct.[ID] DESC
	
							
END


GO
	


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayChallengeTypes]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayChallengeTypesPopulatePlayChallengeObjectiveCodeIndex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayChallengeTypesPopulatePlayChallengeObjectiveCodeIndex]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayChallengeTypesPopulatePlayChallengeObjectiveCodeIndex]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayChallengeObjectiveCodes [nvarchar](4000)
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayChallengeObjectiveCodes
	DECLARE @K TABLE(
		PlayChallengeObjectiveCode [nvarchar](10))

	INSERT INTO @K
	SELECT * FROM [dbo].Split(@PlayChallengeObjectiveCodes, ',')

	-- Delete index items for PlayChallengeType
	DELETE FROM [f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex]
	WHERE [PlayChallengeTypeID] = @ID

	-- Insert index items for PlayChallengeType
	INSERT INTO [f30-data].[dbo].[PlayChallengeTypesPlayChallengeObjectiveCodeIndex]
	SELECT	@PlaySubsetID,
			@ID,
			k.[PlayChallengeObjectiveCode]
	FROM	@K k


END

GO
