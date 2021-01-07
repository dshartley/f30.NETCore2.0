using System;

namespace f30.Core
{
    public enum ExportStatusTypes
    {
        None = 0,
        UpToDate = 1,
        PendingSave = 2,
        PendingDelete = 3,
        PendingInsert = 4
    }

    public enum CellSides
    {
        Unspecified = 0,
        Top = 1,
        Right = 2,
        Bottom = 3,
        Left = 4
    }

    public enum CellContentPositionTypes
    {
        Unspecified = 0,
        Center = 1,
        TopCenter = 2,
        TopRight = 3,
        RightCenter = 4,
        BottomRight = 5,
        BottomCenter = 6,
        BottomLeft = 7,
        LeftCenter = 8,
        TopLeft = 9
    }

    public enum PlayExperienceTypes
    {
        Basic = 1,
        Advanced = 2
    }

    public enum PlayExperienceStepTypes
    {
        Basic = 1,
        Advanced = 2
    }

    public enum PlayExperienceStepExerciseTypes
    {
        Basic = 1,
        Advanced = 2,
        MultipleChoiceImages1 = 3,
        MatchingPairs1 = 4
    }

    public enum PlayAreaPathAbilityTypes
    {
        ByFoot = 1,
        ByCar = 2,
        ByBike = 3,
        ByTrain = 4,
        ByAeroplane = 5,
        ByBoat = 6,
        ByScooter = 7,
        ByBus = 8,
        ByTram = 9
    }

    public enum PlayReferenceTypes
    {
        None = 0,
        PlayAreaTile = 1,
        PlayAreaToken = 2,
        PlayAreaPath = 3,
        PlayAreaPathPoint = 4
    }

    public enum PlayReferenceDataItemTypes
    {
        None = 0,
        PlayAreaCellType = 1,
        PlayAreaTileType = 2
    }

    public enum PlayReferenceActionTypes
    {
        Unspecified = 0,
        BeforeStartMovingAlongPath = 1,
        BeforeMoveToPathPoint = 2,
        AfterMoveToPathPoint = 3,
        AfterFinishedMovingAlongPath = 4
    }

    /// <summary>
    /// DesignDataItemDataJSONWrapperKeys
    /// </summary>
    public enum DesignDataItemDataJSONWrapperKeys
    {
        None,
        Key,
        PlayReferenceType,
        PlayReferenceID,
        PlayReferenceDataItemType,
        PlayReferenceDataItemID,
        Title,
        Points,
        DefinitionSubCodes,
        DefinitionCodes,
        DefinitionParams,
        ThumbnailImageName,
        FileName,
        ExportedFileName,
        Text,
        IndexDefinitions,
        PlayExperienceIndexDefinitions,
        PlayChallengeTypeIndexDefinitions,
        ChallengeTextItems,
        Img1Items,
        P1Items
    }

    /// <summary>
    /// IndexDefinitionGroups
    /// </summary>
    public enum IndexDefinitionGroups
    {
        General = 1,
        PlayExperiences = 2,
        PlayChallengeTypes = 3
    }

    /// <summary>
    /// MatchingPairSubItemTypes
    /// </summary>
    public enum MatchingPairSubItemTypes
    {
        ImageAndText = 1,
        Image = 2,
        Text = 3
    }
}
