USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperienceSteps]
	WHERE ID = @ID

	-- Delete DesignPlayExperiencePlayExperienceStepLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks]
	WHERE [DesignPlayExperienceStepID] = @ID

	-- Delete DesignPlayExperienceStepPlayExperienceStepExerciseLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]
	WHERE [DesignPlayExperienceStepID] = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@PlayExperienceStepType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayExperienceSteps]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [PlayExperienceStepType],
			[Name],
			[ContentData],
			[OnCompleteData],
			[PlayChallengeObjectiveDefinitionData],
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
		    @PlayExperienceStepType,
			@Name,
			@ContentData,
			@OnCompleteData,
			@PlayChallengeObjectiveDefinitionData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelect]
AS
BEGIN

	SET NOCOUNT ON;

	-- Create a table variable for the DesignPlayExperienceSteps
	DECLARE @DPES TABLE(
		ID int,
		ExportedID int,
		DesignPlaySubsetID int,
		ExportedPlaySubsetID int,
		PlayExperienceStepType int,
		Name [nvarchar](250),
		ContentData nvarchar(max),
		OnCompleteData nvarchar(max),
		PlayChallengeObjectiveDefinitionData nvarchar(max),
		ExportedThumbnailImageName nvarchar(250),
		VersionID int,
		VersionDate datetime,
		VersionOwnerID int,
		CanExportYN bit,
		ExportStatus int)

	INSERT INTO @DPES
	SELECT	dpes.[ID],
			dpes.[ExportedID],
			dpes.[DesignPlaySubsetID],
			dpes.[ExportedPlaySubsetID],
			dpes.[PlayExperienceStepType],
			dpes.[Name],
			dpes.[ContentData],
			dpes.[OnCompleteData],
			dpes.[PlayChallengeObjectiveDefinitionData],
			dpes.[ExportedThumbnailImageName],
			dpes.[VersionID],
			dpes.[VersionDate],
			dpes.[VersionOwnerID],
			dpes.[CanExportYN],
			dpes.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceSteps] dpes

	-- Select DesignPlayExperienceSteps
	SELECT * FROM @DPES dpes
	ORDER BY dpes.[ID] DESC

	-- Select DesignPlayExperienceStepPlayExperienceStepExerciseLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[DesignPlayExperienceStepExerciseID],
			l.[ExportedPlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks] l
	WHERE	l.[DesignPlayExperienceStepID] IN (SELECT dpes.[ID] FROM @DPES dpes)	

END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpes.[ID],
			dpes.[ExportedID],
			dpes.[DesignPlaySubsetID],
			dpes.[ExportedPlaySubsetID],
			dpes.[PlayExperienceStepType],
			dpes.[Name],
			dpes.[ContentData],
			dpes.[OnCompleteData],
			dpes.[PlayChallengeObjectiveDefinitionData],
			dpes.[ExportedThumbnailImageName],
			dpes.[VersionID],
			dpes.[VersionDate],
			dpes.[VersionOwnerID],
			dpes.[CanExportYN],
			dpes.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceSteps] dpes
	WHERE	dpes.[ID] = @ID
	ORDER BY dpes.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the DesignPlayExperienceSteps
	DECLARE @DPES TABLE(
		ID int,
		ExportedID int,
		DesignPlaySubsetID int,
		ExportedPlaySubsetID int,
		PlayExperienceStepType int,
		Name [nvarchar](250),
		ContentData nvarchar(max),
		OnCompleteData nvarchar(max),
		PlayChallengeObjectiveDefinitionData nvarchar(max),
		ExportedThumbnailImageName nvarchar(250),
		VersionID int,
		VersionDate datetime,
		VersionOwnerID int,
		CanExportYN bit,
		ExportStatus int)

	INSERT INTO @DPES
	SELECT	dpes.[ID],
			dpes.[ExportedID],
			dpes.[DesignPlaySubsetID],
			dpes.[ExportedPlaySubsetID],
			dpes.[PlayExperienceStepType],
			dpes.[Name],
			dpes.[ContentData],
			dpes.[OnCompleteData],
			dpes.[PlayChallengeObjectiveDefinitionData],
			dpes.[ExportedThumbnailImageName],
			dpes.[VersionID],
			dpes.[VersionDate],
			dpes.[VersionOwnerID],
			dpes.[CanExportYN],
			dpes.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceSteps] dpes
	WHERE	dpes.[DesignPlaySubsetID] = @DesignPlaySubsetID

	-- Select DesignPlayExperienceSteps
	SELECT * FROM @DPES dpes
	ORDER BY dpes.[ID] DESC

	-- Select DesignPlayExperienceStepPlayExperienceStepExerciseLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[DesignPlayExperienceStepExerciseID],
			l.[ExportedPlayExperienceStepExerciseID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks] l
	WHERE	l.[DesignPlayExperienceStepID] IN (SELECT dpes.[ID] FROM @DPES dpes)	

							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@PlayExperienceStepType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayExperienceSteps]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[PlayExperienceStepType] = @PlayExperienceStepType,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[PlayChallengeObjectiveDefinitionData] = @PlayChallengeObjectiveDefinitionData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepsSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepsSelectByFullText]
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

	SELECT	pes.[ID],
			pes.[ExportedID],
			pes.[DesignPlaySubsetID],
			pes.[ExportedPlaySubsetID],
			pes.[PlayExperienceStepType],
			pes.[Name],
			pes.[ContentData],
			pes.[OnCompleteData],
			pes.[PlayChallengeObjectiveDefinitionData],
			pes.[ExportedThumbnailImageName],
			pes.[VersionID],
			pes.[VersionDate],
			pes.[VersionOwnerID],
			pes.[CanExportYN],
			pes.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceSteps] pes
			INNER JOIN CONTAINSTABLE(DesignPlayExperienceSteps, (Name, ContentData), @ContainsSearchTerm) fulltextSearch
			ON pes.[ID] = fulltextSearch.[KEY]
	WHERE	pes.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO