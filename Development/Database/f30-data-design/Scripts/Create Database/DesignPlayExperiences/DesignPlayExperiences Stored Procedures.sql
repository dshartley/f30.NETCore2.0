USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperiences]
	WHERE ID = @ID

	-- Delete DesignPlayExperiencePlayExperienceStepLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks]
	WHERE [DesignPlayExperienceID] = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@PlayExperienceType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
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

	INSERT INTO [f30-data-design].[dbo].[DesignPlayExperiences]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [PlayExperienceType],
			[Name],
			[ContentData],
			[OnCompleteData],
			[PlayChallengeObjectiveDefinitionData],
			[IndexDefinitionData],
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
		    @PlayExperienceType,
			@Name,
			@ContentData,
			@OnCompleteData,
			@PlayChallengeObjectiveDefinitionData,
			@IndexDefinitionData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	-- Create a table variable for the DesignPlayExperiences
	DECLARE @DPE TABLE(
		ID int,
		ExportedID int,
		DesignPlaySubsetID int,
		ExportedPlaySubsetID int,
		PlayExperienceType int,
		Name [nvarchar](250),
		ContentData nvarchar(max),
		OnCompleteData nvarchar(max),
		PlayChallengeObjectiveDefinitionData nvarchar(max),
		IndexDefinitionData nvarchar(max),
		ExportedThumbnailImageName nvarchar(250),
		VersionID int,
		VersionDate datetime,
		VersionOwnerID int,
		CanExportYN bit,
		ExportStatus int)

	INSERT INTO @DPE
	SELECT	dpe.[ID],
			dpe.[ExportedID],
			dpe.[DesignPlaySubsetID],
			dpe.[ExportedPlaySubsetID],
			dpe.[PlayExperienceType],
			dpe.[Name],
			dpe.[ContentData],
			dpe.[OnCompleteData],
			dpe.[PlayChallengeObjectiveDefinitionData],
			dpe.[IndexDefinitionData],
			dpe.[ExportedThumbnailImageName],
			dpe.[VersionID],
			dpe.[VersionDate],
			dpe.[VersionOwnerID],
			dpe.[CanExportYN],
			dpe.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiences] dpe

	-- Select DesignPlayExperiences
	SELECT * FROM @DPE dpe
	ORDER BY dpe.[ID] DESC

	-- Select DesignPlayExperiencePlayExperienceStepLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceID],
			l.[ExportedPlayExperienceID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks] l
	WHERE	l.[DesignPlayExperienceID] IN (SELECT dpe.[ID] FROM @DPE dpe)	

END


GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpe.[ID],
			dpe.[ExportedID],
			dpe.[DesignPlaySubsetID],
			dpe.[ExportedPlaySubsetID],
			dpe.[PlayExperienceType],
			dpe.[Name],
			dpe.[ContentData],
			dpe.[OnCompleteData],
			dpe.[PlayChallengeObjectiveDefinitionData],
			dpe.[IndexDefinitionData],
			dpe.[ExportedThumbnailImageName],
			dpe.[VersionID],
			dpe.[VersionDate],
			dpe.[VersionOwnerID],
			dpe.[CanExportYN],
			dpe.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiences] dpe
	WHERE	dpe.[ID] = @ID
	ORDER BY dpe.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the DesignPlayExperiences
	DECLARE @DPE TABLE(
		ID int,
		ExportedID int,
		DesignPlaySubsetID int,
		ExportedPlaySubsetID int,
		PlayExperienceType int,
		Name [nvarchar](250),
		ContentData nvarchar(max),
		OnCompleteData nvarchar(max),
		PlayChallengeObjectiveDefinitionData nvarchar(max),
		IndexDefinitionData nvarchar(max),
		ExportedThumbnailImageName nvarchar(250),
		VersionID int,
		VersionDate datetime,
		VersionOwnerID int,
		CanExportYN bit,
		ExportStatus int)

	INSERT INTO @DPE
	SELECT	dpe.[ID],
			dpe.[ExportedID],
			dpe.[DesignPlaySubsetID],
			dpe.[ExportedPlaySubsetID],
			dpe.[PlayExperienceType],
			dpe.[Name],
			dpe.[ContentData],
			dpe.[OnCompleteData],
			dpe.[PlayChallengeObjectiveDefinitionData],
			dpe.[IndexDefinitionData],
			dpe.[ExportedThumbnailImageName],
			dpe.[VersionID],
			dpe.[VersionDate],
			dpe.[VersionOwnerID],
			dpe.[CanExportYN],
			dpe.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiences] dpe
	WHERE	dpe.[DesignPlaySubsetID] = @DesignPlaySubsetID

	-- Select DesignPlayExperiences
	SELECT * FROM @DPE dpe
	ORDER BY dpe.[ID] DESC

	-- Select DesignPlayExperiencePlayExperienceStepLinks
	SELECT	l.[ID],
			l.[ExportedID],
			l.[DesignPlayExperienceID],
			l.[ExportedPlayExperienceID],
			l.[DesignPlayExperienceStepID],
			l.[ExportedPlayExperienceStepID],
			l.[Index],
			l.[VersionID],
			l.[VersionDate],
			l.[VersionOwnerID],
			l.[CanExportYN],
			l.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiencePlayExperienceStepLinks] l
	WHERE	l.[DesignPlayExperienceID] IN (SELECT dpe.[ID] FROM @DPE dpe)	
					
END


GO



USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@PlayExperienceType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@PlayChallengeObjectiveDefinitionData [nvarchar](max),
	@IndexDefinitionData [nvarchar](max),
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

	UPDATE	[f30-data-design].[dbo].[DesignPlayExperiences]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[PlayExperienceType] = @PlayExperienceType,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[PlayChallengeObjectiveDefinitionData] = @PlayChallengeObjectiveDefinitionData,
			[IndexDefinitionData] = @IndexDefinitionData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperiencesSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperiencesSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperiencesSelectByFullText]
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

	SELECT	pe.[ID],
			pe.[ExportedID],
			pe.[DesignPlaySubsetID],
			pe.[ExportedPlaySubsetID],
			pe.[PlayExperienceType],
			pe.[Name],
			pe.[ContentData],
			pe.[OnCompleteData],
			pe.[PlayChallengeObjectiveDefinitionData],
			pe.[IndexDefinitionData],
			pe.[ExportedThumbnailImageName],
			pe.[VersionID],
			pe.[VersionDate],
			pe.[VersionOwnerID],
			pe.[CanExportYN],
			pe.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayExperiences] pe
			INNER JOIN CONTAINSTABLE(DesignPlayExperiences, (Name, ContentData), @ContainsSearchTerm) fulltextSearch
			ON pe.[ID] = fulltextSearch.[KEY]
	WHERE	pe.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO