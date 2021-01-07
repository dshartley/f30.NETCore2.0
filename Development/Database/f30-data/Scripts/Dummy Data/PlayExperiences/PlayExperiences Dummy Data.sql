USE [f30-data]
GO

DECLARE @RC int
DECLARE @ID int

DECLARE @VersionID int
SET @VersionID = 1
DECLARE @VersionDate datetime
SET @VersionDate = '1/1/1900'
DECLARE @VersionOwnerID int
SET @VersionOwnerID = 1


-- PlayExperiences

DECLARE @PlayExperienceContentData nvarchar(max)
SET @PlayExperienceContentData = '{\"ID\":\"\", \"Items\":[], \"Params\" : [{\"Key\" : \"Title\", \"Value\" : \"Experience from f30Server!\"}, {\"Key\" : \"ThumbnailImageName\", \"Value\" : \"exp01_milk\"}]}'
DECLARE @PlayExperienceOnCompleteData nvarchar(max)
SET @PlayExperienceOnCompleteData = '{\"ID\":\"\", \"Items\":[], \"Params\" : [{\"Key\" : \"NumberOfExperiencePoints\", \"Value\" : \"5\"}]}'
DECLARE @PlayExperiencePlayChallengeObjectiveDefinitionData nvarchar(max)
SET @PlayExperiencePlayChallengeObjectiveDefinitionData = '{\"ID\":\"\",\"Items\":[],\"Params\": [{\"Key\":\"Code\",\"Value\":\"1234\"}, {\"Key\":\"Code1\",\"Value\":\"1\"}]}'

EXECUTE @RC = [dbo].[sp_PlayExperiencesInsert] 
   @ID OUTPUT
  ,1 -- @PlayExperienceType
  ,'TestPlayExperience1' -- @Name
  ,@PlayExperienceContentData -- @ContentData
  ,@PlayExperienceOnCompleteData -- @OnCompleteData
  ,@PlayExperiencePlayChallengeObjectiveDefinitionData -- @PlayChallengeObjectiveDefinitionData
  ,@VersionID -- @VersionID
  ,@VersionDate -- @VersionDate
  ,@VersionOwnerID -- @VersionOwnerID


-- PlayExperienceSteps

DECLARE @PlayExperienceStepContentData nvarchar(max)
SET @PlayExperienceStepContentData = '{\"ID\":\"\", \"Items\":[], \"Params\" : [{\"Key\" : \"Title\", \"Value\" : \"Experience Step from f30Server!\"}, {\"Key\" : \"ThumbnailImageName\", \"Value\" : \"exp01_milk\"}]}'
DECLARE @PlayExperienceStepOnCompleteData nvarchar(max)
SET @PlayExperienceStepOnCompleteData = '{\"ID\":\"\", \"Items\":[], \"Params\" : [{\"Key\" : \"NumberOfPoints\", \"Value\" : \"1\"}, {\"Key\" : \"NumberOfFeathers\", \"Value\" : \"1\"}]}'
DECLARE @PlayExperienceStepPlayChallengeObjectiveDefinitionData nvarchar(max)
SET @PlayExperienceStepPlayChallengeObjectiveDefinitionData = '{\"ID\":\"\",\"Items\":[],\"Params\": [{\"Key\":\"Code\",\"Value\":\"5678\"}, {\"Key\":\"Code1\",\"Value\":\"2\"}]}'

EXECUTE @RC = [dbo].[sp_PlayExperienceStepsInsert] 
   @ID OUTPUT
  ,1 -- @PlayExperienceStepType
  ,'TesPlayExperience1' -- @Name
  ,@PlayExperienceStepContentData -- @ContentData
  ,@PlayExperienceStepOnCompleteData -- @OnCompleteData
  ,@PlayExperienceStepPlayChallengeObjectiveDefinitionData -- @PlayChallengeObjectiveDefinitionData
  ,@VersionID -- @VersionID
  ,@VersionDate -- @VersionDate
  ,@VersionOwnerID -- @VersionOwnerID


-- PlayExperienceStepExercises

DECLARE @PlayExperienceStepExerciseContentData1 nvarchar(max)
SET @PlayExperienceStepExerciseContentData1 = ' {\"ID\":\"\", \"Items\":[{\"ID\":\"ContentImages\",\"Items\": [{\"ID\":\"1\",\"Items\":[],\"Params\": [{\"Key\":\"ImageName\",\"Value\":\"shopping1\"}, {\"Key\":\"Answer\",\"Value\":\"0\"}]}, {\"ID\":\"2\",\"Items\":[],\"Params\": [{\"Key\":\"ImageName\",\"Value\":\"shopping2\"}, {\"Key\":\"Answer\",\"Value\":\"1\"}]}, {\"ID\":\"3\",\"Items\":[],\"Params\": [{\"Key\":\"ImageName\",\"Value\":\"shopping3\"}, {\"Key\":\"Answer\",\"Value\":\"0\"}]}],\"Params\":[]}], \"Params\" : [{\"Key\" : \"Text\", \"Value\" : \"text1\"}]}'

DECLARE @PlayExperienceStepExerciseContentData2 nvarchar(max)
SET @PlayExperienceStepExerciseContentData2 = ' {\"ID\":\"\", \"Items\":[{\"ID\":\"ContentImages\",\"Items\": [{\"ID\":\"1\",\"Items\":[],\"Params\": [{\"Key\":\"ImageName\",\"Value\":\"shopping4\"}, {\"Key\":\"Answer\",\"Value\":\"0\"}]}, {\"ID\":\"2\",\"Items\":[],\"Params\": [{\"Key\":\"ImageName\",\"Value\":\"shopping5\"}, {\"Key\":\"Answer\",\"Value\":\"1\"}]}, {\"ID\":\"3\",\"Items\":[],\"Params\": [{\"Key\":\"ImageName\",\"Value\":\"shopping6\"}, {\"Key\":\"Answer\",\"Value\":\"0\"}]}],\"Params\":[]}], \"Params\" : [{\"Key\" : \"Text\", \"Value\" : \"text2\"}]}'

DECLARE @PlayExperienceStepExerciseOnCompleteData nvarchar(max)
SET @PlayExperienceStepExerciseOnCompleteData = 'JSON'

EXECUTE @RC = [dbo].[sp_PlayExperienceStepExercisesInsert] 
   @ID OUTPUT
  ,1 -- @PlayExperienceStepExerciseType
  ,@PlayExperienceStepExerciseContentData1 -- @ContentData
  ,@PlayExperienceStepExerciseOnCompleteData -- @OnCompleteData
  ,@VersionID -- @VersionID
  ,@VersionDate -- @VersionDate
  ,@VersionOwnerID -- @VersionOwnerID

EXECUTE @RC = [dbo].[sp_PlayExperienceStepExercisesInsert] 
   @ID OUTPUT
  ,1 -- @PlayExperienceStepExerciseType
  ,@PlayExperienceStepExerciseContentData2 -- @ContentData
  ,@PlayExperienceStepExerciseOnCompleteData -- @OnCompleteData
  ,@VersionID -- @VersionID
  ,@VersionDate -- @VersionDate
  ,@VersionOwnerID -- @VersionOwnerID

GO


