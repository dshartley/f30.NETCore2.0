USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayChallengeTypes]
	WHERE ID = @ID

	-- Delete DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks]
	WHERE [DesignPlayChallengeTypeID] = @ID

	-- Delete DesignPlayChallengeTypePlayMoveLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks]
	WHERE [DesignPlayChallengeTypeID] = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@ExportedThumbnailImageName [nvarchar](250),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data-design].[dbo].[DesignPlayChallengeTypes]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [Name],
			[ContentData],
			[OnCompleteData],
			[ExportedThumbnailImageName],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
			@DesignPlaySubsetID,
			@ExportedPlaySubsetID,
		    @Name,
			@ContentData,
			@OnCompleteData,
			@ExportedThumbnailImageName,
			@VersionID,
			@VersionDate,
			@VersionOwnerID,
			@CanExportYN,
			@ExportStatus
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	-- Create a table variable for the DesignPlayChallengeTypes
	DECLARE @DPCT TABLE(
		ID int,
		ExportedID int,
		DesignPlaySubsetID int,
		ExportedPlaySubsetID int,
		Name nvarchar(max),
		ContentData nvarchar(max),
		OnCompleteData nvarchar(max),
		ExportedThumbnailImageName nvarchar(250),
		VersionID int,
		VersionDate datetime,
		VersionOwnerID int,
		CanExportYN bit,
		ExportStatus int)

	INSERT INTO @DPCT
	SELECT	dpct.[ID],
			dpct.[ExportedID],
			dpct.[DesignPlaySubsetID],
			dpct.[ExportedPlaySubsetID],
			dpct.[Name],
			dpct.[ContentData],
			dpct.[OnCompleteData],
			dpct.[ExportedThumbnailImageName],
			dpct.[VersionID],
			dpct.[VersionDate],
			dpct.[VersionOwnerID],
			dpct.[CanExportYN],
			dpct.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypes] dpct

	-- Select DesignPlayChallengeTypes
	SELECT * FROM @DPCT dpct
	ORDER BY dpct.[ID] DESC

	-- Select DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayChallengeObjectiveTypeID],
			l.[ExportedPlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks] l
	WHERE	l.[DesignPlayChallengeTypeID] IN (SELECT dpct.[ID] FROM @DPCT dpct)

	-- Select DesignPlayChallengeTypePlayMoveLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks] l
	WHERE	l.[DesignPlayChallengeTypeID] IN (SELECT dpct.[ID] FROM @DPCT dpct)

END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpct.[ID],
			dpct.[ExportedID],
			dpct.[DesignPlaySubsetID],
			dpct.[ExportedPlaySubsetID],
			dpct.[Name],
			dpct.[ContentData],
			dpct.[OnCompleteData],
			dpct.[ExportedThumbnailImageName],
			dpct.[VersionID],
			dpct.[VersionDate],
			dpct.[VersionOwnerID],
			dpct.[CanExportYN],
			dpct.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypes] dpct
	WHERE	dpct.[ID] = @ID
	ORDER BY dpct.[ID] DESC
	
							
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the DesignPlayChallengeTypes
	DECLARE @DPCT TABLE(
		ID int,
		ExportedID int,
		DesignPlaySubsetID int,
		ExportedPlaySubsetID int,
		Name nvarchar(max),
		ContentData nvarchar(max),
		OnCompleteData nvarchar(max),
		ExportedThumbnailImageName nvarchar(250),
		VersionID int,
		VersionDate datetime,
		VersionOwnerID int,
		CanExportYN bit,
		ExportStatus int)

	INSERT INTO @DPCT
	SELECT	dpct.[ID],
			dpct.[ExportedID],
			dpct.[DesignPlaySubsetID],
			dpct.[ExportedPlaySubsetID],
			dpct.[Name],
			dpct.[ContentData],
			dpct.[OnCompleteData],
			dpct.[ExportedThumbnailImageName],
			dpct.[VersionID],
			dpct.[VersionDate],
			dpct.[VersionOwnerID],
			dpct.[CanExportYN],
			dpct.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypes] dpct
	WHERE	dpct.[DesignPlaySubsetID] = @DesignPlaySubsetID

	-- Select DesignPlayChallengeTypes
	SELECT * FROM @DPCT dpct
	ORDER BY dpct.[ID] DESC

	-- Select DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayChallengeObjectiveTypeID],
			l.[ExportedPlayChallengeObjectiveTypeID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayChallengeObjectiveTypeLinks] l
	WHERE	l.[DesignPlayChallengeTypeID] IN (SELECT dpct.[ID] FROM @DPCT dpct)

	-- Select DesignPlayChallengeTypePlayMoveLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayChallengeTypeID],
			l.[ExportedPlayChallengeTypeID],
			l.[DesignPlayMoveID],
			l.[ExportedPlayMoveID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypePlayMoveLinks] l
	WHERE	l.[DesignPlayChallengeTypeID] IN (SELECT dpct.[ID] FROM @DPCT dpct)
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@ExportedThumbnailImageName [nvarchar](250),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data-design].[dbo].[DesignPlayChallengeTypes]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[ExportedThumbnailImageName] = @ExportedThumbnailImageName,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID,
			[CanExportYN] = @CanExportYN,
			[ExportStatus] = @ExportStatus
	WHERE ID = @ID

END

GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayChallengeTypesSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayChallengeTypesSelectByFullText]
(
	@SearchString nvarchar(100),
	@DesignPlaySubsetID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	DECLARE @ContainsSearchTerm AS nvarchar(110)
	SET @ContainsSearchTerm = '"*' + @SearchString + '*"'

	SELECT	pct.[ID],
			pct.[ExportedID],
			pct.[DesignPlaySubsetID],
			pct.[ExportedPlaySubsetID],
			pct.[Name],
			pct.[ContentData],
			pct.[OnCompleteData],
			pct.[ExportedThumbnailImageName],
			pct.[VersionID],
			pct.[VersionDate],
			pct.[VersionOwnerID],
			pct.[CanExportYN],
			pct.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypes] pct
			INNER JOIN CONTAINSTABLE(DesignPlayChallengeTypes, (Name, ContentData), @ContainsSearchTerm) fulltextSearch
			ON pct.[ID] = fulltextSearch.[KEY]
	WHERE	pct.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO