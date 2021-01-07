USE [f30-data-design]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DesignSearchItemsSelectBySearchString]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DesignSearchItemsSelectBySearchString]
GO

USE [f30-data-design]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_DesignSearchItemsSelectBySearchString]
(
	@SearchString nvarchar(100),
	@DesignPlaySubsetID int,
	@SearchDesignPlayAreaCellTypesYN bit,
	@SearchDesignPlayAreaTileTypesYN bit,
	@SearchDesignPlayChallengeObjectiveTypesYN bit,
	@SearchDesignPlayChallengeTypesYN bit,
	@SearchDesignPlayExperiencesYN bit,
	@SearchDesignPlayExperienceStepsYN bit,
	@SearchDesignPlayExperienceStepExercisesYN bit

)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- PlayAreaCellTypes
	IF (@SearchDesignPlayAreaCellTypesYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayAreaCellTypesSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayAreaCellTypes] pact
	END
	
	-- PlayAreaTileTypes
	IF (@SearchDesignPlayAreaTileTypesYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayAreaTileTypesSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayAreaTileTypes] patt
	END

	-- PlayChallengeObjectiveTypes
	IF (@SearchDesignPlayChallengeObjectiveTypesYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayChallengeObjectiveTypesSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayChallengeObjectiveTypes] pcot
	END
		
	-- PlayChallengeTypes
	IF (@SearchDesignPlayChallengeTypesYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayChallengeTypesSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayChallengeTypes] pct
	END
			
	-- PlayExperiences
	IF (@SearchDesignPlayExperiencesYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayExperiencesSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayExperiences] pe
	END
	
	-- PlayExperienceSteps
	IF (@SearchDesignPlayExperienceStepsYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayExperienceStepsSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayExperienceSteps] pes
	END
	
	-- PlayExperienceStepExercises
	IF (@SearchDesignPlayExperienceStepExercisesYN = 1)
	BEGIN
		EXECUTE [f30-data-design].[dbo].[sp_DesignPlayExperienceStepExercisesSelectByFullText] @SearchString, @DesignPlaySubsetID
	END
	ELSE
	BEGIN
		-- Empty dataset
		SELECT	TOP(0) *
		FROM	[f30-data-design].[dbo].[DesignPlayExperienceStepExercises] pese
	END						
END