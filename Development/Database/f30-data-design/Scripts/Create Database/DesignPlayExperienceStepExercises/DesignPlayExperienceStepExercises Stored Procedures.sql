USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesDelete]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperienceStepExercises]
	WHERE ID = @ID

	-- Delete DesignPlayExperienceStepPlayExperienceStepExerciseLinks
	DELETE FROM [f30-data-design].[dbo].[DesignPlayExperienceStepPlayExperienceStepExerciseLinks]
	WHERE [DesignPlayExperienceStepExerciseID] = @ID

END



GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesInsert]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesInsert]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@PlayExperienceStepExerciseType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@AssetData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data-design].[dbo].[DesignPlayExperienceStepExercises]
           ([ExportedID],
			[DesignPlaySubsetID],
			[ExportedPlaySubsetID],
		    [PlayExperienceStepExerciseType],
			[Name],
			[ContentData],
			[OnCompleteData],
			[AssetData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID],
			[CanExportYN],
			[ExportStatus])
     VALUES
           (@ExportedID,
			@DesignPlaySubsetID,
			@ExportedPlaySubsetID,
		    @PlayExperienceStepExerciseType,
			@Name,
			@ContentData,
			@OnCompleteData,
			@AssetData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelect]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	dpese.[ID],
			dpese.[ExportedID],
			dpese.[DesignPlaySubsetID],
			dpese.[ExportedPlaySubsetID],
			dpese.[PlayExperienceStepExerciseType],
			dpese.[Name],
			dpese.[ContentData],
			dpese.[OnCompleteData],
			dpese.[AssetData],
			dpese.[VersionID],
			dpese.[VersionDate],
			dpese.[VersionOwnerID],
			dpese.[CanExportYN],
			dpese.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepExercises] dpese
			ORDER BY dpese.[ID] DESC

END



GO

USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelectByID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpese.[ID],
			dpese.[ExportedID],
			dpese.[DesignPlaySubsetID],
			dpese.[ExportedPlaySubsetID],
			dpese.[PlayExperienceStepExerciseType],
			dpese.[Name],
			dpese.[ContentData],
			dpese.[OnCompleteData],
			dpese.[AssetData],
			dpese.[VersionID],
			dpese.[VersionDate],
			dpese.[VersionOwnerID],
			dpese.[CanExportYN],
			dpese.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepExercises] dpese
	WHERE	dpese.[ID] = @ID
	ORDER BY dpese.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesSelectByDesignPlaySubsetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelectByDesignPlaySubsetID]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelectByDesignPlaySubsetID]
(
	@DesignPlaySubsetID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	dpese.[ID],
			dpese.[ExportedID],
			dpese.[DesignPlaySubsetID],
			dpese.[ExportedPlaySubsetID],
			dpese.[PlayExperienceStepExerciseType],
			dpese.[Name],
			dpese.[ContentData],
			dpese.[OnCompleteData],
			dpese.[AssetData],
			dpese.[VersionID],
			dpese.[VersionDate],
			dpese.[VersionOwnerID],
			dpese.[CanExportYN],
			dpese.[ExportStatus]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepExercises] dpese
	WHERE	dpese.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY dpese.[ID] DESC
	
							
END


GO


USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesUpdate]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesUpdate]
(
	@ID int output,
	@ExportedID [int],
	@DesignPlaySubsetID [int],
	@ExportedPlaySubsetID [int],
	@PlayExperienceStepExerciseType [int],
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@OnCompleteData [nvarchar](max),
	@AssetData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int],
	@CanExportYN [bit],
	@ExportStatus [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data-design].[dbo].[DesignPlayExperienceStepExercises]
	SET		[ExportedID] = @ExportedID,
			[DesignPlaySubsetID] = @DesignPlaySubsetID,
			[ExportedPlaySubsetID] = @ExportedPlaySubsetID,
			[PlayExperienceStepExerciseType] = @PlayExperienceStepExerciseType,
			[Name] = @Name,
			[ContentData] = @ContentData,
			[OnCompleteData] = @OnCompleteData,
			[AssetData] = @AssetData,
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignPlayExperienceStepExercisesSelectByFullText]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelectByFullText]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DesignPlayExperienceStepExercisesSelectByFullText]
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

	SELECT	pese.[ID],
			pese.[ExportedID],
			pese.[DesignPlaySubsetID],
			pese.[ExportedPlaySubsetID],
			pese.[PlayExperienceStepExerciseType],
			pese.[Name],
			pese.[ContentData],
			pese.[OnCompleteData],
			pese.[AssetData],
			pese.[VersionID],
			pese.[VersionDate],
			pese.[VersionOwnerID],
			pese.[CanExportYN],
			pese.[ExportStatus],
			fulltextSearch.[Key],
			fulltextSearch.[Rank]
	FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepExercises] pese
			INNER JOIN CONTAINSTABLE(DesignPlayExperienceStepExercises, (Name, ContentData), @ContainsSearchTerm) fulltextSearch
			ON pese.[ID] = fulltextSearch.[KEY]
	WHERE	pese.[DesignPlaySubsetID] = @DesignPlaySubsetID
	ORDER BY RANK DESC

										
END

GO