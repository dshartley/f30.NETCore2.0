using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data
{
    public enum DataProperties
    {
        // PlaySubsets
        PlaySubsets_ID,
        PlaySubsets_Name,
        PlaySubsets_ContentData,
        PlaySubsets_VersionID,
        PlaySubsets_VersionDate,
        PlaySubsets_VersionOwnerID,

        // PlayResults
        PlayResults_ID,
        PlayResults_RelativeMemberID,
        PlayResults_PlayGamesJSON,
        PlayResults_PlayGameDataJSON,
        PlayResults_PlayAreaTilesJSON,
        PlayResults_PlayAreaTileDataJSON,
        PlayResults_PlayExperienceStepResultsJSON,

        // PlayGames
        PlayGames_ID,
        PlayGames_RelativeMemberID,
        PlayGames_PlaySubsetID,
        PlayGames_DateCreated,
        PlayGames_Name,

        // PlayGameData
        PlayGameData_ID,
        PlayGameData_RelativeMemberID,
        PlayGameData_PlayGameID,
        PlayGameData_DateLastPlayed,
        PlayGameData_OnCompleteData,
        PlayGameData_AttributeData,

        // PlayAreaTokens
        PlayAreaTokens_ID,
        PlayAreaTokens_RelativeMemberID,
        PlayAreaTokens_PlayGameID,
        PlayAreaTokens_Column,
        PlayAreaTokens_Row,
        PlayAreaTokens_ImageName,
        PlayAreaTokens_TokenAttributesString,

        // PlayAreaTiles
        PlayAreaTiles_ID,
        PlayAreaTiles_RelativeMemberID,
        PlayAreaTiles_PlayGameID,
        PlayAreaTiles_TileTypeID,
        PlayAreaTiles_Column,
        PlayAreaTiles_Row,
        PlayAreaTiles_RotationDegrees,
        PlayAreaTiles_ImageName,
        PlayAreaTiles_WidthPixels,
        PlayAreaTiles_HeightPixels,
        PlayAreaTiles_Position,
        PlayAreaTiles_PositionFixToCellRotationYN,
        PlayAreaTiles_TileAttributesString,
        PlayAreaTiles_TileSideAttributesString,

        // PlayAreaTileTypes
        PlayAreaTileTypes_ID,
        PlayAreaTileTypes_PlaySubsetID,
        PlayAreaTileTypes_Name,
        PlayAreaTileTypes_IsSpecialYN,
        PlayAreaTileTypes_DeckWeighting,
        PlayAreaTileTypes_ImageName,
        PlayAreaTileTypes_WidthPixels,
        PlayAreaTileTypes_HeightPixels,
        PlayAreaTileTypes_Position,
        PlayAreaTileTypes_PositionFixToCellRotationYN,
        PlayAreaTileTypes_TileAttributesString,
        PlayAreaTileTypes_TileSideAttributesString,
        PlayAreaTileTypes_IndexDefinitionData,
        PlayAreaTileTypes_VersionID,
        PlayAreaTileTypes_VersionDate,
        PlayAreaTileTypes_VersionOwnerID,

        // PlayAreaTileData
        PlayAreaTileData_ID,
        PlayAreaTileData_RelativeMemberID,
        PlayAreaTileData_PlayAreaTileID,
        PlayAreaTileData_OnCompleteData,
        PlayAreaTileData_AttributeData,

        // PlayAreaCells
        PlayAreaCells_ID,
        PlayAreaCells_RelativeMemberID,
        PlayAreaCells_PlayGameID,
        PlayAreaCells_CellTypeID,
        PlayAreaCells_Column,
        PlayAreaCells_Row,
        PlayAreaCells_RotationDegrees,
        PlayAreaCells_ImageName,
        PlayAreaCells_CellAttributesString,
        PlayAreaCells_CellSideAttributesString,

        // PlayAreaCellTypes
        PlayAreaCellTypes_ID,
        PlayAreaCellTypes_PlaySubsetID,
        PlayAreaCellTypes_Name,
        PlayAreaCellTypes_IsSpecialYN,
        PlayAreaCellTypes_DeckWeighting,
        PlayAreaCellTypes_ImageName,
        PlayAreaCellTypes_BlockedContentPositionsString,
        PlayAreaCellTypes_CellAttributesString,
        PlayAreaCellTypes_CellSideAttributesString,
        PlayAreaCellTypes_IndexDefinitionData,
        PlayAreaCellTypes_VersionID,
        PlayAreaCellTypes_VersionDate,
        PlayAreaCellTypes_VersionOwnerID,

        // PlayMoves
        PlayMoves_ID,
        PlayMoves_PlaySubsetID,
        PlayMoves_PlayReferenceData,
        PlayMoves_PlayReferenceActionType,
        PlayMoves_Name,
        PlayMoves_ContentData,
        PlayMoves_OnCompleteData,
        PlayMoves_VersionID,
        PlayMoves_VersionDate,
        PlayMoves_VersionOwnerID,

        // PlayAreaTileTypePlayMoveLinks
        PlayAreaTileTypePlayMoveLinks_ID,
        PlayAreaTileTypePlayMoveLinks_PlayAreaTileTypeID,
        PlayAreaTileTypePlayMoveLinks_PlayMoveID,
        PlayAreaTileTypePlayMoveLinks_Index,
        PlayAreaTileTypePlayMoveLinks_VersionID,
        PlayAreaTileTypePlayMoveLinks_VersionDate,
        PlayAreaTileTypePlayMoveLinks_VersionOwnerID,

        // PlayAreaCellTypePlayMoveLinks
        PlayAreaCellTypePlayMoveLinks_ID,
        PlayAreaCellTypePlayMoveLinks_PlayAreaCellTypeID,
        PlayAreaCellTypePlayMoveLinks_PlayMoveID,
        PlayAreaCellTypePlayMoveLinks_Index,
        PlayAreaCellTypePlayMoveLinks_VersionID,
        PlayAreaCellTypePlayMoveLinks_VersionDate,
        PlayAreaCellTypePlayMoveLinks_VersionOwnerID,

        // PlayChallengeTypePlayMoveLinks
        PlayChallengeTypePlayMoveLinks_ID,
        PlayChallengeTypePlayMoveLinks_PlayChallengeTypeID,
        PlayChallengeTypePlayMoveLinks_PlayMoveID,
        PlayChallengeTypePlayMoveLinks_Index,
        PlayChallengeTypePlayMoveLinks_VersionID,
        PlayChallengeTypePlayMoveLinks_VersionDate,
        PlayChallengeTypePlayMoveLinks_VersionOwnerID,

        // PlayExperiences
        PlayExperiences_ID,
        PlayExperiences_PlaySubsetID,
        PlayExperiences_PlayExperienceType,
        PlayExperiences_Name,
        PlayExperiences_ContentData,
        PlayExperiences_OnCompleteData,
        PlayExperiences_PlayChallengeObjectiveDefinitionData,
        PlayExperiences_IndexDefinitionData,
        PlayExperiences_VersionID,
        PlayExperiences_VersionDate,
        PlayExperiences_VersionOwnerID,

        // PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex
        PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_ID,
        PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlaySubsetID,
        PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayExperienceID,
        PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayExperienceKeyword,
        PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayChallengeObjectiveCode,

        // PlayExperienceSteps
        PlayExperienceSteps_ID,
        PlayExperienceSteps_PlaySubsetID,
        PlayExperienceSteps_PlayExperienceStepType,
        PlayExperienceSteps_Name,
        PlayExperienceSteps_ContentData,
        PlayExperienceSteps_OnCompleteData,
        PlayExperienceSteps_PlayChallengeObjectiveDefinitionData,
        PlayExperienceSteps_VersionID,
        PlayExperienceSteps_VersionDate,
        PlayExperienceSteps_VersionOwnerID,

        // PlayExperienceStepResults
        PlayExperienceStepResults_ID,
        PlayExperienceStepResults_PlayExperienceID,
        PlayExperienceStepResults_PlayExperienceStepID,
        PlayExperienceStepResults_DateCompleted,
        PlayExperienceStepResults_RepeatedYN,

        // PlayExperienceStepExercises
        PlayExperienceStepExercises_ID,
        PlayExperienceStepExercises_PlaySubsetID,
        PlayExperienceStepExercises_Name,
        PlayExperienceStepExercises_PlayExperienceStepExerciseType,
        PlayExperienceStepExercises_ContentData,
        PlayExperienceStepExercises_OnCompleteData,
        PlayExperienceStepExercises_VersionID,
        PlayExperienceStepExercises_VersionDate,
        PlayExperienceStepExercises_VersionOwnerID,

        // PlayExperienceStepPlayExperienceStepExerciseLinks
        PlayExperienceStepPlayExperienceStepExerciseLinks_ID,
        PlayExperienceStepPlayExperienceStepExerciseLinks_PlayExperienceStepID,
        PlayExperienceStepPlayExperienceStepExerciseLinks_PlayExperienceStepExerciseID,
        PlayExperienceStepPlayExperienceStepExerciseLinks_Index,
        PlayExperienceStepPlayExperienceStepExerciseLinks_VersionID,
        PlayExperienceStepPlayExperienceStepExerciseLinks_VersionDate,
        PlayExperienceStepPlayExperienceStepExerciseLinks_VersionOwnerID,

        // PlayExperiencePlayExperienceStepLinks
        PlayExperiencePlayExperienceStepLinks_ID,
        PlayExperiencePlayExperienceStepLinks_PlayExperienceID,
        PlayExperiencePlayExperienceStepLinks_PlayExperienceStepID,
        PlayExperiencePlayExperienceStepLinks_Index,
        PlayExperiencePlayExperienceStepLinks_VersionID,
        PlayExperiencePlayExperienceStepLinks_VersionDate,
        PlayExperiencePlayExperienceStepLinks_VersionOwnerID,

        // PlayChallenges
        PlayChallenges_ID,
        PlayChallenges_RelativeMemberID,
        PlayChallenges_PlayGameID,
        PlayChallenges_PlayMoveID,
        PlayChallenges_PlayChallengeTypeID,
        PlayChallenges_IsActiveYN,
        PlayChallenges_IsCompleteYN,
        PlayChallenges_DateActive,

        // PlayChallengeTypes
        PlayChallengeTypes_ID,
        PlayChallengeTypes_PlaySubsetID,
        PlayChallengeTypes_Name,
        PlayChallengeTypes_ContentData,
        PlayChallengeTypes_OnCompleteData,
        PlayChallengeTypes_VersionID,
        PlayChallengeTypes_VersionDate,
        PlayChallengeTypes_VersionOwnerID,

        // PlayChallengeObjectives
        PlayChallengeObjectives_ID,
        PlayChallengeObjectives_RelativeMemberID,
        PlayChallengeObjectives_PlayChallengeID,
        PlayChallengeObjectives_PlayChallengeObjectiveTypeID,
        PlayChallengeObjectives_IsAchievedYN,
        PlayChallengeObjectives_DateActive,

        // PlayChallengeObjectiveTypes
        PlayChallengeObjectiveTypes_ID,
        PlayChallengeObjectiveTypes_PlaySubsetID,
        PlayChallengeObjectiveTypes_Name,
        PlayChallengeObjectiveTypes_ContentData,
        PlayChallengeObjectiveTypes_OnCompleteData,
        PlayChallengeObjectiveTypes_Code,
        PlayChallengeObjectiveTypes_DefinitionData,
        PlayChallengeObjectiveTypes_VersionID,
        PlayChallengeObjectiveTypes_VersionDate,
        PlayChallengeObjectiveTypes_VersionOwnerID,

        // PlayChallengeTypePlayChallengeObjectiveTypeLinks
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_ID,
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_PlayChallengeTypeID,
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_PlayChallengeObjectiveTypeID,
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_Index,
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionID,
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionDate,
        PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionOwnerID,

        // PlayAreaTileTypeChallengeObjectives
        PlayAreaTileTypeChallengeObjectives_ID,
        PlayAreaTileTypeChallengeObjectives_PlayAreaTileTypeID,
        PlayAreaTileTypeChallengeObjectives_PlayChallengeObjectiveCode,
        PlayAreaTileTypeChallengeObjectives_PlayChallengeObjectiveData,
        PlayAreaTileTypeChallengeObjectives_VersionID,
        PlayAreaTileTypeChallengeObjectives_VersionDate,
        PlayAreaTileTypeChallengeObjectives_VersionOwnerID,

        // PlayAreaPaths
        PlayAreaPaths_ID,
        PlayAreaPaths_PlayGameID,
        PlayAreaPaths_PathAttributesString,
        PlayAreaPaths_PathLogString,

        // PlayAreaPathPoints
        PlayAreaPathPoints_ID,
        PlayAreaPathPoints_PlayGameID,
        PlayAreaPathPoints_PlayAreaPathID,
        PlayAreaPathPoints_Index,
        PlayAreaPathPoints_Column,
        PlayAreaPathPoints_Row
        
    }

}
