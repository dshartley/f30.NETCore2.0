using f30.Data.PlaySubsets;
using f30.Data.PlayAreaCells;
using f30.Data.PlayAreaCellTypes;
using f30.Data.PlayAreaPathPoints;
using f30.Data.PlayAreaPaths;
using f30.Data.PlayAreaTileData;
using f30.Data.PlayAreaTiles;
using f30.Data.PlayAreaTileTypeChallengeObjectives;
using f30.Data.PlayAreaTileTypes;
using f30.Data.PlayAreaTokens;
using f30.Data.PlayChallengeObjectives;
using f30.Data.PlayChallengeObjectiveTypes;
using f30.Data.PlayChallenges;
using f30.Data.PlayChallengeTypes;
using f30.Data.PlayExperiences;
using f30.Data.PlayExperienceStepExercises;
using f30.Data.PlayExperienceSteps;
using f30.Data.PlayExperienceStepResults;
using f30.Data.PlayExperienceStepPlayExperienceStepExerciseLinks;
using f30.Data.PlayExperiencePlayExperienceStepLinks;
using f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks;
using f30.Data.PlayGameData;
using f30.Data.PlayGames;
using f30.Data.PlayMoves;
using f30.Data.PlayAreaCellTypePlayMoveLinks;
using f30.Data.PlayAreaTileTypePlayMoveLinks;
using f30.Data.PlayChallengeTypePlayMoveLinks;
using f30.Data.PlayResults;
using f30.Data.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex;
using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data
{
    public enum DataManagerKeys
    {
        Live,
        Local
    }

    /// <summary>
    /// Manages the data layer and provides access to the data administrators.
    /// </summary>
    public class DataManager : IDataAdministratorProvider
    {
        private string _defaultCultureInfoName;
        private Dictionary<string, IDataAdministrator> _dataAdministrators;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        private DataManager() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        /// <param name="defaultCultureInfoName">Default name of the culture info.</param>
        public DataManager(string defaultCultureInfoName)
        {
            #region Check Parameters

            if (defaultCultureInfoName == String.Empty) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "defaultCultureInfoName is nothing"));

            #endregion

            _defaultCultureInfoName = defaultCultureInfoName;
            _dataAdministrators = new Dictionary<string, IDataAdministrator>();
        }

        #endregion

        #region Public Methods

        private DataManagerKeys _key;

        public DataManagerKeys Key
        {
            get { return _key; }
            set { _key = value; }
        }

        #region PlaySubsets

        private PlaySubsetDataAdministrator     _playSubsetsDA;
        private IDataManagementPolicy           _playSubsetsDMP;
        private IDataAccessStrategy             _playSubsetsDAS;

        /// <summary>
        /// Setups the PlaySubset data administrator.
        /// </summary>
        /// <param name="playSubsetsDMP">The playSubsets DMP.</param>
        /// <param name="playSubsetsDAS">The playSubsets DAS.</param>
        public void SetupPlaySubsetDataAdministrator(IDataManagementPolicy playSubsetsDMP, IDataAccessStrategy playSubsetsDAS)
        {
            #region Check Parameters

            if (playSubsetsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playSubsetsDMP is nothing"));
            if (playSubsetsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playSubsetsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlaySubsets")) _dataAdministrators.Remove("PlaySubsets");

            _playSubsetsDMP     = playSubsetsDMP;
            _playSubsetsDAS     = playSubsetsDAS;
            _playSubsetsDA      = new PlaySubsetDataAdministrator(_playSubsetsDMP, _playSubsetsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlaySubsets"] = _playSubsetsDA;
        }

        /// <summary>
        /// Gets the PlaySubset data administrator.
        /// </summary>
        /// <value>The PlaySubset data administrator.</value>
        public PlaySubsetDataAdministrator PlaySubsetDataAdministrator
        {
            get { return _playSubsetsDA; }
        }

        #endregion

        #region PlayResults

        private PlayResultDataAdministrator _playResultsDA;
        private IDataManagementPolicy       _playResultsDMP;
        private IDataAccessStrategy         _playResultsDAS;

        /// <summary>
        /// Setups the PlayResult data administrator.
        /// </summary>
        /// <param name="playResultsDMP">The playResults DMP.</param>
        /// <param name="playResultsDAS">The playResults DAS.</param>
        public void SetupPlayResultDataAdministrator(IDataManagementPolicy playResultsDMP, IDataAccessStrategy playResultsDAS)
        {
            #region Check Parameters

            if (playResultsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playResultsDMP is nothing"));
            if (playResultsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playResultsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayResults")) _dataAdministrators.Remove("PlayResults");

            _playResultsDMP = playResultsDMP;
            _playResultsDAS = playResultsDAS;
            _playResultsDA  = new PlayResultDataAdministrator(_playResultsDMP, _playResultsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayResults"] = _playResultsDA;
        }

        /// <summary>
        /// Gets the PlayResult data administrator.
        /// </summary>
        /// <value>The PlayResult data administrator.</value>
        public PlayResultDataAdministrator PlayResultDataAdministrator
        {
            get { return _playResultsDA; }
        }

        #endregion

        #region PlayGames

        private PlayGameDataAdministrator _playGamesDA;
        private IDataManagementPolicy _playGamesDMP;
        private IDataAccessStrategy _playGamesDAS;

        /// <summary>
        /// Setups the PlayGame data administrator.
        /// </summary>
        /// <param name="playGamesDMP">The playGames DMP.</param>
        /// <param name="playGamesDAS">The playGames DAS.</param>
        public void SetupPlayGameDataAdministrator(IDataManagementPolicy playGamesDMP, IDataAccessStrategy playGamesDAS)
        {
            #region Check Parameters

            if (playGamesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playGamesDMP is nothing"));
            if (playGamesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playGamesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayGames")) _dataAdministrators.Remove("PlayGames");

            _playGamesDMP = playGamesDMP;
            _playGamesDAS = playGamesDAS;
            _playGamesDA = new PlayGameDataAdministrator(_playGamesDMP, _playGamesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayGames"] = _playGamesDA;
        }

        /// <summary>
        /// Gets the PlayGame data administrator.
        /// </summary>
        /// <value>The PlayGame data administrator.</value>
        public PlayGameDataAdministrator PlayGameDataAdministrator
        {
            get { return _playGamesDA; }
        }

        #endregion

        #region PlayGameData

        private PlayGameDataDataAdministrator   _playGameDataDA;
        private IDataManagementPolicy           _playGameDataDMP;
        private IDataAccessStrategy             _playGameDataDAS;

        /// <summary>
        /// Setups the PlayGameData data administrator.
        /// </summary>
        /// <param name="playGameDataDMP">The playGameData DMP.</param>
        /// <param name="playGameDataDAS">The playGameData DAS.</param>
        public void SetupPlayGameDataDataAdministrator(IDataManagementPolicy playGameDataDMP, IDataAccessStrategy playGameDataDAS)
        {
            #region Check Parameters

            if (playGameDataDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playGameDataDMP is nothing"));
            if (playGameDataDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playGameDataDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayGameData")) _dataAdministrators.Remove("PlayGameData");

            _playGameDataDMP   = playGameDataDMP;
            _playGameDataDAS   = playGameDataDAS;
            _playGameDataDA    = new PlayGameDataDataAdministrator(_playGameDataDMP, _playGameDataDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayGameData"] = _playGameDataDA;
        }

        /// <summary>
        /// Gets the PlayGameData data administrator.
        /// </summary>
        /// <value>The PlayGameData data administrator.</value>
        public PlayGameDataDataAdministrator PlayGameDataDataAdministrator
        {
            get { return _playGameDataDA; }
        }

        #endregion

        #region PlayAreaTokens

        private PlayAreaTokenDataAdministrator _playAreaTokensDA;
        private IDataManagementPolicy _playAreaTokensDMP;
        private IDataAccessStrategy _playAreaTokensDAS;

        /// <summary>
        /// Setups the PlayAreaToken data administrator.
        /// </summary>
        /// <param name="playAreaTokensDMP">The playAreaTokens DMP.</param>
        /// <param name="playAreaTokensDAS">The playAreaTokens DAS.</param>
        public void SetupPlayAreaTokenDataAdministrator(IDataManagementPolicy playAreaTokensDMP, IDataAccessStrategy playAreaTokensDAS)
        {
            #region Check Parameters

            if (playAreaTokensDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTokensDMP is nothing"));
            if (playAreaTokensDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTokensDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaTokens")) _dataAdministrators.Remove("PlayAreaTokens");

            _playAreaTokensDMP = playAreaTokensDMP;
            _playAreaTokensDAS = playAreaTokensDAS;
            _playAreaTokensDA = new PlayAreaTokenDataAdministrator(_playAreaTokensDMP, _playAreaTokensDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaTokens"] = _playAreaTokensDA;
        }

        /// <summary>
        /// Gets the PlayAreaToken data administrator.
        /// </summary>
        /// <value>The PlayAreaToken data administrator.</value>
        public PlayAreaTokenDataAdministrator PlayAreaTokenDataAdministrator
        {
            get { return _playAreaTokensDA; }
        }

        #endregion

        #region PlayAreaTiles

        private PlayAreaTileDataAdministrator _playAreaTilesDA;
        private IDataManagementPolicy _playAreaTilesDMP;
        private IDataAccessStrategy _playAreaTilesDAS;

        /// <summary>
        /// Setups the PlayAreaTile data administrator.
        /// </summary>
        /// <param name="playAreaTilesDMP">The playAreaTiles DMP.</param>
        /// <param name="playAreaTilesDAS">The playAreaTiles DAS.</param>
        public void SetupPlayAreaTileDataAdministrator(IDataManagementPolicy playAreaTilesDMP, IDataAccessStrategy playAreaTilesDAS)
        {
            #region Check Parameters

            if (playAreaTilesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTilesDMP is nothing"));
            if (playAreaTilesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTilesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaTiles")) _dataAdministrators.Remove("PlayAreaTiles");

            _playAreaTilesDMP = playAreaTilesDMP;
            _playAreaTilesDAS = playAreaTilesDAS;
            _playAreaTilesDA = new PlayAreaTileDataAdministrator(_playAreaTilesDMP, _playAreaTilesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaTiles"] = _playAreaTilesDA;
        }

        /// <summary>
        /// Gets the PlayAreaTile data administrator.
        /// </summary>
        /// <value>The PlayAreaTile data administrator.</value>
        public PlayAreaTileDataAdministrator PlayAreaTileDataAdministrator
        {
            get { return _playAreaTilesDA; }
        }

        #endregion

        #region PlayAreaTileTypes

        private PlayAreaTileTypeDataAdministrator _playAreaTileTypesDA;
        private IDataManagementPolicy _playAreaTileTypesDMP;
        private IDataAccessStrategy _playAreaTileTypesDAS;

        /// <summary>
        /// Setups the PlayAreaTileType data administrator.
        /// </summary>
        /// <param name="playAreaTileTypesDMP">The playAreaTileTypes DMP.</param>
        /// <param name="playAreaTileTypesDAS">The playAreaTileTypes DAS.</param>
        public void SetupPlayAreaTileTypeDataAdministrator(IDataManagementPolicy playAreaTileTypesDMP, IDataAccessStrategy playAreaTileTypesDAS)
        {
            #region Check Parameters

            if (playAreaTileTypesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileTypesDMP is nothing"));
            if (playAreaTileTypesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileTypesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaTileTypes")) _dataAdministrators.Remove("PlayAreaTileTypes");

            _playAreaTileTypesDMP = playAreaTileTypesDMP;
            _playAreaTileTypesDAS = playAreaTileTypesDAS;
            _playAreaTileTypesDA = new PlayAreaTileTypeDataAdministrator(_playAreaTileTypesDMP, _playAreaTileTypesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaTileTypes"] = _playAreaTileTypesDA;
        }

        /// <summary>
        /// Gets the PlayAreaTileType data administrator.
        /// </summary>
        /// <value>The PlayAreaTileType data administrator.</value>
        public PlayAreaTileTypeDataAdministrator PlayAreaTileTypeDataAdministrator
        {
            get { return _playAreaTileTypesDA; }
        }

        #endregion

        #region PlayAreaTileData

        private PlayAreaTileDataDataAdministrator   _playAreaTileDataDA;
        private IDataManagementPolicy               _playAreaTileDataDMP;
        private IDataAccessStrategy                 _playAreaTileDataDAS;

        /// <summary>
        /// Setups the PlayAreaTileData data administrator.
        /// </summary>
        /// <param name="playAreaTileDataDMP">The playAreaTileData DMP.</param>
        /// <param name="playAreaTileDataDAS">The playAreaTileData DAS.</param>
        public void SetupPlayAreaTileDataDataAdministrator(IDataManagementPolicy playAreaTileDataDMP, IDataAccessStrategy playAreaTileDataDAS)
        {
            #region Check Parameters

            if (playAreaTileDataDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileDataDMP is nothing"));
            if (playAreaTileDataDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileDataDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaTileData")) _dataAdministrators.Remove("PlayAreaTileData");

            _playAreaTileDataDMP    = playAreaTileDataDMP;
            _playAreaTileDataDAS    = playAreaTileDataDAS;
            _playAreaTileDataDA     = new PlayAreaTileDataDataAdministrator(_playAreaTileDataDMP, _playAreaTileDataDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaTileData"] = _playAreaTileDataDA;
        }

        /// <summary>
        /// Gets the PlayAreaTileData data administrator.
        /// </summary>
        /// <value>The PlayAreaTileData data administrator.</value>
        public PlayAreaTileDataDataAdministrator PlayAreaTileDataDataAdministrator
        {
            get { return _playAreaTileDataDA; }
        }

        #endregion

        #region PlayAreaCells

        private PlayAreaCellDataAdministrator _playAreaCellsDA;
        private IDataManagementPolicy _playAreaCellsDMP;
        private IDataAccessStrategy _playAreaCellsDAS;

        /// <summary>
        /// Setups the PlayAreaCell data administrator.
        /// </summary>
        /// <param name="playAreaCellsDMP">The playAreaCells DMP.</param>
        /// <param name="playAreaCellsDAS">The playAreaCells DAS.</param>
        public void SetupPlayAreaCellDataAdministrator(IDataManagementPolicy playAreaCellsDMP, IDataAccessStrategy playAreaCellsDAS)
        {
            #region Check Parameters

            if (playAreaCellsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaCellsDMP is nothing"));
            if (playAreaCellsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaCellsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaCells")) _dataAdministrators.Remove("PlayAreaCells");

            _playAreaCellsDMP = playAreaCellsDMP;
            _playAreaCellsDAS = playAreaCellsDAS;
            _playAreaCellsDA = new PlayAreaCellDataAdministrator(_playAreaCellsDMP, _playAreaCellsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaCells"] = _playAreaCellsDA;
        }

        /// <summary>
        /// Gets the PlayAreaCell data administrator.
        /// </summary>
        /// <value>The PlayAreaCell data administrator.</value>
        public PlayAreaCellDataAdministrator PlayAreaCellDataAdministrator
        {
            get { return _playAreaCellsDA; }
        }

        #endregion

        #region PlayAreaCellTypes

        private PlayAreaCellTypeDataAdministrator _playAreaCellTypesDA;
        private IDataManagementPolicy _playAreaCellTypesDMP;
        private IDataAccessStrategy _playAreaCellTypesDAS;

        /// <summary>
        /// Setups the PlayAreaCellType data administrator.
        /// </summary>
        /// <param name="playAreaCellTypesDMP">The playAreaCellTypes DMP.</param>
        /// <param name="playAreaCellTypesDAS">The playAreaCellTypes DAS.</param>
        public void SetupPlayAreaCellTypeDataAdministrator(IDataManagementPolicy playAreaCellTypesDMP, IDataAccessStrategy playAreaCellTypesDAS)
        {
            #region Check Parameters

            if (playAreaCellTypesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaCellTypesDMP is nothing"));
            if (playAreaCellTypesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaCellTypesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaCellTypes")) _dataAdministrators.Remove("PlayAreaCellTypes");

            _playAreaCellTypesDMP = playAreaCellTypesDMP;
            _playAreaCellTypesDAS = playAreaCellTypesDAS;
            _playAreaCellTypesDA = new PlayAreaCellTypeDataAdministrator(_playAreaCellTypesDMP, _playAreaCellTypesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaCellTypes"] = _playAreaCellTypesDA;
        }

        /// <summary>
        /// Gets the PlayAreaCellType data administrator.
        /// </summary>
        /// <value>The PlayAreaCellType data administrator.</value>
        public PlayAreaCellTypeDataAdministrator PlayAreaCellTypeDataAdministrator
        {
            get { return _playAreaCellTypesDA; }
        }

        #endregion

        #region PlayExperiences

        private PlayExperienceDataAdministrator _playExperiencesDA;
        private IDataManagementPolicy _playExperiencesDMP;
        private IDataAccessStrategy _playExperiencesDAS;

        /// <summary>
        /// Setups the PlayExperience data administrator.
        /// </summary>
        /// <param name="playExperiencesDMP">The playExperiences DMP.</param>
        /// <param name="playExperiencesDAS">The playExperiences DAS.</param>
        public void SetupPlayExperienceDataAdministrator(IDataManagementPolicy playExperiencesDMP, IDataAccessStrategy playExperiencesDAS)
        {
            #region Check Parameters

            if (playExperiencesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperiencesDMP is nothing"));
            if (playExperiencesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperiencesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperiences")) _dataAdministrators.Remove("PlayExperiences");

            _playExperiencesDMP = playExperiencesDMP;
            _playExperiencesDAS = playExperiencesDAS;
            _playExperiencesDA = new PlayExperienceDataAdministrator(_playExperiencesDMP, _playExperiencesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperiences"] = _playExperiencesDA;
        }

        /// <summary>
        /// Gets the PlayExperience data administrator.
        /// </summary>
        /// <value>The PlayExperience data administrator.</value>
        public PlayExperienceDataAdministrator PlayExperienceDataAdministrator
        {
            get { return _playExperiencesDA; }
        }

        #endregion

        #region PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex

        private PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator      _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDA;
        private IDataManagementPolicy                                                       _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP;
        private IDataAccessStrategy                                                         _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS;

        /// <summary>
        /// Setups the PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex data administrator.
        /// </summary>
        /// <param name="playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP">The playExperiencesKeywordPlayChallengeObjectiveCodeIndex DMP.</param>
        /// <param name="playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS">The playExperiencesKeywordPlayChallengeObjectiveCodeIndex DAS.</param>
        public void SetupPlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator(IDataManagementPolicy playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP, IDataAccessStrategy playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS)
        {
            #region Check Parameters

            if (playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP is nothing"));
            if (playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex")) _dataAdministrators.Remove("PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex");

            _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP                       = playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP;
            _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS                       = playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS;
            _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDA                        = new PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator(_playExperiencesKeywordPlayChallengeObjectiveCodeIndexDMP, _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex"]    = _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDA;
        }

        /// <summary>
        /// Gets the PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex data administrator.
        /// </summary>
        /// <value>The PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex data administrator.</value>
        public PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator
        {
            get { return _playExperiencesKeywordPlayChallengeObjectiveCodeIndexDA; }
        }

        #endregion

        #region PlayExperienceSteps

        private PlayExperienceStepDataAdministrator _playExperienceStepsDA;
        private IDataManagementPolicy _playExperienceStepsDMP;
        private IDataAccessStrategy _playExperienceStepsDAS;

        /// <summary>
        /// Setups the PlayExperienceStep data administrator.
        /// </summary>
        /// <param name="playExperienceStepsDMP">The playExperienceSteps DMP.</param>
        /// <param name="playExperienceStepsDAS">The playExperienceSteps DAS.</param>
        public void SetupPlayExperienceStepDataAdministrator(IDataManagementPolicy playExperienceStepsDMP, IDataAccessStrategy playExperienceStepsDAS)
        {
            #region Check Parameters

            if (playExperienceStepsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepsDMP is nothing"));
            if (playExperienceStepsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperienceSteps")) _dataAdministrators.Remove("PlayExperienceSteps");

            _playExperienceStepsDMP = playExperienceStepsDMP;
            _playExperienceStepsDAS = playExperienceStepsDAS;
            _playExperienceStepsDA = new PlayExperienceStepDataAdministrator(_playExperienceStepsDMP, _playExperienceStepsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperienceSteps"] = _playExperienceStepsDA;
        }

        /// <summary>
        /// Gets the PlayExperienceStep data administrator.
        /// </summary>
        /// <value>The PlayExperienceStep data administrator.</value>
        public PlayExperienceStepDataAdministrator PlayExperienceStepDataAdministrator
        {
            get { return _playExperienceStepsDA; }
        }

        #endregion

        #region PlayExperienceStepResults

        private PlayExperienceStepResultDataAdministrator   _playExperienceStepResultsDA;
        private IDataManagementPolicy                       _playExperienceStepResultsDMP;
        private IDataAccessStrategy                         _playExperienceStepResultsDAS;

        /// <summary>
        /// Setups the PlayExperienceStepResult data administrator.
        /// </summary>
        /// <param name="playExperienceStepResultsDMP">The playExperienceStepResults DMP.</param>
        /// <param name="playExperienceStepResultsDAS">The playExperienceStepResults DAS.</param>
        public void SetupPlayExperienceStepResultDataAdministrator(IDataManagementPolicy playExperienceStepResultsDMP, IDataAccessStrategy playExperienceStepResultsDAS)
        {
            #region Check Parameters

            if (playExperienceStepResultsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepResultsDMP is nothing"));
            if (playExperienceStepResultsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepResultsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperienceStepResults")) _dataAdministrators.Remove("PlayExperienceStepResults");

            _playExperienceStepResultsDMP                       = playExperienceStepResultsDMP;
            _playExperienceStepResultsDAS                       = playExperienceStepResultsDAS;
            _playExperienceStepResultsDA                        = new PlayExperienceStepResultDataAdministrator(_playExperienceStepResultsDMP, _playExperienceStepResultsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperienceStepResults"]    = _playExperienceStepResultsDA;
        }

        /// <summary>
        /// Gets the PlayExperienceStepResult data administrator.
        /// </summary>
        /// <value>The PlayExperienceStepResult data administrator.</value>
        public PlayExperienceStepResultDataAdministrator PlayExperienceStepResultDataAdministrator
        {
            get { return _playExperienceStepResultsDA; }
        }

        #endregion

        #region PlayExperienceStepExercises

        private PlayExperienceStepExerciseDataAdministrator _playExperienceStepExercisesDA;
        private IDataManagementPolicy _playExperienceStepExercisesDMP;
        private IDataAccessStrategy _playExperienceStepExercisesDAS;

        /// <summary>
        /// Setups the PlayExperienceStepExercise data administrator.
        /// </summary>
        /// <param name="playExperienceStepExercisesDMP">The playExperienceStepExercises DMP.</param>
        /// <param name="playExperienceStepExercisesDAS">The playExperienceStepExercises DAS.</param>
        public void SetupPlayExperienceStepExerciseDataAdministrator(IDataManagementPolicy playExperienceStepExercisesDMP, IDataAccessStrategy playExperienceStepExercisesDAS)
        {
            #region Check Parameters

            if (playExperienceStepExercisesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepExercisesDMP is nothing"));
            if (playExperienceStepExercisesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepExercisesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperienceStepExercises")) _dataAdministrators.Remove("PlayExperienceStepExercises");

            _playExperienceStepExercisesDMP = playExperienceStepExercisesDMP;
            _playExperienceStepExercisesDAS = playExperienceStepExercisesDAS;
            _playExperienceStepExercisesDA = new PlayExperienceStepExerciseDataAdministrator(_playExperienceStepExercisesDMP, _playExperienceStepExercisesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperienceStepExercises"] = _playExperienceStepExercisesDA;
        }

        /// <summary>
        /// Gets the PlayExperienceStepExercise data administrator.
        /// </summary>
        /// <value>The PlayExperienceStepExercise data administrator.</value>
        public PlayExperienceStepExerciseDataAdministrator PlayExperienceStepExerciseDataAdministrator
        {
            get { return _playExperienceStepExercisesDA; }
        }

        #endregion

        #region PlayExperienceStepPlayExperienceStepExerciseLinks

        private PlayExperienceStepPlayExperienceStepExerciseLinkDataAdministrator   _playExperienceStepPlayExperienceStepExerciseLinksDA;
        private IDataManagementPolicy                                               _playExperienceStepPlayExperienceStepExerciseLinksDMP;
        private IDataAccessStrategy                                                 _playExperienceStepPlayExperienceStepExerciseLinksDAS;

        /// <summary>
        /// Setups the PlayExperienceStepPlayExperienceStepExerciseLink data administrator.
        /// </summary>
        /// <param name="playExperienceStepPlayExperienceStepExerciseLinksDMP">The playExperienceStepPlayExperienceStepExerciseLinks DMP.</param>
        /// <param name="playExperienceStepPlayExperienceStepExerciseLinksDAS">The playExperienceStepPlayExperienceStepExerciseLinks DAS.</param>
        public void SetupPlayExperienceStepPlayExperienceStepExerciseLinkDataAdministrator(IDataManagementPolicy playExperienceStepPlayExperienceStepExerciseLinksDMP, IDataAccessStrategy playExperienceStepPlayExperienceStepExerciseLinksDAS)
        {
            #region Check Parameters

            if (playExperienceStepPlayExperienceStepExerciseLinksDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepPlayExperienceStepExerciseLinksDMP is nothing"));
            if (playExperienceStepPlayExperienceStepExerciseLinksDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepPlayExperienceStepExerciseLinksDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperienceStepPlayExperienceStepExerciseLinks")) _dataAdministrators.Remove("PlayExperienceStepPlayExperienceStepExerciseLinks");

            _playExperienceStepPlayExperienceStepExerciseLinksDMP   = playExperienceStepPlayExperienceStepExerciseLinksDMP;
            _playExperienceStepPlayExperienceStepExerciseLinksDAS   = playExperienceStepPlayExperienceStepExerciseLinksDAS;
            _playExperienceStepPlayExperienceStepExerciseLinksDA    = new PlayExperienceStepPlayExperienceStepExerciseLinkDataAdministrator(_playExperienceStepPlayExperienceStepExerciseLinksDMP, _playExperienceStepPlayExperienceStepExerciseLinksDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperienceStepPlayExperienceStepExerciseLinks"] = _playExperienceStepPlayExperienceStepExerciseLinksDA;
        }

        /// <summary>
        /// Gets the PlayExperienceStepPlayExperienceStepExerciseLink data administrator.
        /// </summary>
        /// <value>The PlayExperienceStepPlayExperienceStepExerciseLink data administrator.</value>
        public PlayExperienceStepPlayExperienceStepExerciseLinkDataAdministrator PlayExperienceStepPlayExperienceStepExerciseLinkDataAdministrator
        {
            get { return _playExperienceStepPlayExperienceStepExerciseLinksDA; }
        }

        #endregion

        #region PlayExperiencePlayExperienceStepLinks

        private PlayExperiencePlayExperienceStepLinkDataAdministrator   _playExperiencePlayExperienceStepLinksDA;
        private IDataManagementPolicy                                   _playExperiencePlayExperienceStepLinksDMP;
        private IDataAccessStrategy                                     _playExperiencePlayExperienceStepLinksDAS;

        /// <summary>
        /// Setups the PlayExperiencePlayExperienceStepLink data administrator.
        /// </summary>
        /// <param name="playExperiencePlayExperienceStepLinksDMP">The playExperiencePlayExperienceStepLinks DMP.</param>
        /// <param name="playExperiencePlayExperienceStepLinksDAS">The playExperiencePlayExperienceStepLinks DAS.</param>
        public void SetupPlayExperiencePlayExperienceStepLinkDataAdministrator(IDataManagementPolicy playExperiencePlayExperienceStepLinksDMP, IDataAccessStrategy playExperiencePlayExperienceStepLinksDAS)
        {
            #region Check Parameters

            if (playExperiencePlayExperienceStepLinksDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperiencePlayExperienceStepLinksDMP is nothing"));
            if (playExperiencePlayExperienceStepLinksDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperiencePlayExperienceStepLinksDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayExperiencePlayExperienceStepLinks")) _dataAdministrators.Remove("PlayExperiencePlayExperienceStepLinks");

            _playExperiencePlayExperienceStepLinksDMP   = playExperiencePlayExperienceStepLinksDMP;
            _playExperiencePlayExperienceStepLinksDAS   = playExperiencePlayExperienceStepLinksDAS;
            _playExperiencePlayExperienceStepLinksDA    = new PlayExperiencePlayExperienceStepLinkDataAdministrator(_playExperiencePlayExperienceStepLinksDMP, _playExperiencePlayExperienceStepLinksDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayExperiencePlayExperienceStepLinks"] = _playExperiencePlayExperienceStepLinksDA;
        }

        /// <summary>
        /// Gets the PlayExperiencePlayExperienceStepLink data administrator.
        /// </summary>
        /// <value>The PlayExperiencePlayExperienceStepLink data administrator.</value>
        public PlayExperiencePlayExperienceStepLinkDataAdministrator PlayExperiencePlayExperienceStepLinkDataAdministrator
        {
            get { return _playExperiencePlayExperienceStepLinksDA; }
        }

        #endregion

        #region PlayChallenges

        private PlayChallengeDataAdministrator _playChallengesDA;
        private IDataManagementPolicy _playChallengesDMP;
        private IDataAccessStrategy _playChallengesDAS;

        /// <summary>
        /// Setups the PlayChallenge data administrator.
        /// </summary>
        /// <param name="playChallengesDMP">The playChallenges DMP.</param>
        /// <param name="playChallengesDAS">The playChallenges DAS.</param>
        public void SetupPlayChallengeDataAdministrator(IDataManagementPolicy playChallengesDMP, IDataAccessStrategy playChallengesDAS)
        {
            #region Check Parameters

            if (playChallengesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengesDMP is nothing"));
            if (playChallengesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayChallenges")) _dataAdministrators.Remove("PlayChallenges");

            _playChallengesDMP = playChallengesDMP;
            _playChallengesDAS = playChallengesDAS;
            _playChallengesDA = new PlayChallengeDataAdministrator(_playChallengesDMP, _playChallengesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayChallenges"] = _playChallengesDA;
        }

        /// <summary>
        /// Gets the PlayChallenge data administrator.
        /// </summary>
        /// <value>The PlayChallenge data administrator.</value>
        public PlayChallengeDataAdministrator PlayChallengeDataAdministrator
        {
            get { return _playChallengesDA; }
        }

        #endregion

        #region PlayChallengeTypes

        private PlayChallengeTypeDataAdministrator  _playChallengeTypesDA;
        private IDataManagementPolicy               _playChallengeTypesDMP;
        private IDataAccessStrategy                 _playChallengeTypesDAS;

        /// <summary>
        /// Setups the PlayChallengeType data administrator.
        /// </summary>
        /// <param name="playChallengeTypesDMP">The playChallengeTypes DMP.</param>
        /// <param name="playChallengeTypesDAS">The playChallengeTypes DAS.</param>
        public void SetupPlayChallengeTypeDataAdministrator(IDataManagementPolicy playChallengeTypesDMP, IDataAccessStrategy playChallengeTypesDAS)
        {
            #region Check Parameters

            if (playChallengeTypesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypesDMP is nothing"));
            if (playChallengeTypesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayChallengeTypes")) _dataAdministrators.Remove("PlayChallengeTypes");

            _playChallengeTypesDMP  = playChallengeTypesDMP;
            _playChallengeTypesDAS  = playChallengeTypesDAS;
            _playChallengeTypesDA   = new PlayChallengeTypeDataAdministrator(_playChallengeTypesDMP, _playChallengeTypesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayChallengeTypes"] = _playChallengeTypesDA;
        }

        /// <summary>
        /// Gets the PlayChallengeType data administrator.
        /// </summary>
        /// <value>The PlayChallengeType data administrator.</value>
        public PlayChallengeTypeDataAdministrator PlayChallengeTypeDataAdministrator
        {
            get { return _playChallengeTypesDA; }
        }

        #endregion

        #region PlayChallengeObjectives

        private PlayChallengeObjectiveDataAdministrator _playChallengeObjectivesDA;
        private IDataManagementPolicy _playChallengeObjectivesDMP;
        private IDataAccessStrategy _playChallengeObjectivesDAS;

        /// <summary>
        /// Setups the PlayChallengeObjective data administrator.
        /// </summary>
        /// <param name="playChallengeObjectivesDMP">The playChallengeObjectives DMP.</param>
        /// <param name="playChallengeObjectivesDAS">The playChallengeObjectives DAS.</param>
        public void SetupPlayChallengeObjectiveDataAdministrator(IDataManagementPolicy playChallengeObjectivesDMP, IDataAccessStrategy playChallengeObjectivesDAS)
        {
            #region Check Parameters

            if (playChallengeObjectivesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectivesDMP is nothing"));
            if (playChallengeObjectivesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectivesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayChallengeObjectives")) _dataAdministrators.Remove("PlayChallengeObjectives");

            _playChallengeObjectivesDMP = playChallengeObjectivesDMP;
            _playChallengeObjectivesDAS = playChallengeObjectivesDAS;
            _playChallengeObjectivesDA = new PlayChallengeObjectiveDataAdministrator(_playChallengeObjectivesDMP, _playChallengeObjectivesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayChallengeObjectives"] = _playChallengeObjectivesDA;
        }

        /// <summary>
        /// Gets the PlayChallengeObjective data administrator.
        /// </summary>
        /// <value>The PlayChallengeObjective data administrator.</value>
        public PlayChallengeObjectiveDataAdministrator PlayChallengeObjectiveDataAdministrator
        {
            get { return _playChallengeObjectivesDA; }
        }

        #endregion

        #region PlayChallengeObjectiveTypes

        private PlayChallengeObjectiveTypeDataAdministrator _playChallengeObjectiveTypesDA;
        private IDataManagementPolicy                       _playChallengeObjectiveTypesDMP;
        private IDataAccessStrategy                         _playChallengeObjectiveTypesDAS;

        /// <summary>
        /// Setups the PlayChallengeObjectiveType data administrator.
        /// </summary>
        /// <param name="playChallengeObjectiveTypesDMP">The playChallengeObjectiveTypes DMP.</param>
        /// <param name="playChallengeObjectiveTypesDAS">The playChallengeObjectiveTypes DAS.</param>
        public void SetupPlayChallengeObjectiveTypeDataAdministrator(IDataManagementPolicy playChallengeObjectiveTypesDMP, IDataAccessStrategy playChallengeObjectiveTypesDAS)
        {
            #region Check Parameters

            if (playChallengeObjectiveTypesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectiveTypesDMP is nothing"));
            if (playChallengeObjectiveTypesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectiveTypesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayChallengeObjectiveTypes")) _dataAdministrators.Remove("PlayChallengeObjectiveTypes");

            _playChallengeObjectiveTypesDMP = playChallengeObjectiveTypesDMP;
            _playChallengeObjectiveTypesDAS = playChallengeObjectiveTypesDAS;
            _playChallengeObjectiveTypesDA  = new PlayChallengeObjectiveTypeDataAdministrator(_playChallengeObjectiveTypesDMP, _playChallengeObjectiveTypesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayChallengeObjectiveTypes"] = _playChallengeObjectiveTypesDA;
        }

        /// <summary>
        /// Gets the PlayChallengeObjectiveType data administrator.
        /// </summary>
        /// <value>The PlayChallengeObjectiveType data administrator.</value>
        public PlayChallengeObjectiveTypeDataAdministrator PlayChallengeObjectiveTypeDataAdministrator
        {
            get { return _playChallengeObjectiveTypesDA; }
        }

        #endregion

        #region PlayChallengeTypePlayChallengeObjectiveTypeLinks

        private PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator _playChallengeTypePlayChallengeObjectiveTypeLinksDA;
        private IDataManagementPolicy _playChallengeTypePlayChallengeObjectiveTypeLinksDMP;
        private IDataAccessStrategy _playChallengeTypePlayChallengeObjectiveTypeLinksDAS;

        /// <summary>
        /// Setups the PlayChallengeTypePlayChallengeObjectiveTypeLink data administrator.
        /// </summary>
        /// <param name="playChallengeTypePlayChallengeObjectiveTypeLinksDMP">The playChallengeTypePlayChallengeObjectiveTypeLinks DMP.</param>
        /// <param name="playChallengeTypePlayChallengeObjectiveTypeLinksDAS">The playChallengeTypePlayChallengeObjectiveTypeLinks DAS.</param>
        public void SetupPlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator(IDataManagementPolicy playChallengeTypePlayChallengeObjectiveTypeLinksDMP, IDataAccessStrategy playChallengeTypePlayChallengeObjectiveTypeLinksDAS)
        {
            #region Check Parameters

            if (playChallengeTypePlayChallengeObjectiveTypeLinksDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypePlayChallengeObjectiveTypeLinksDMP is nothing"));
            if (playChallengeTypePlayChallengeObjectiveTypeLinksDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypePlayChallengeObjectiveTypeLinksDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayChallengeTypePlayChallengeObjectiveTypeLinks")) _dataAdministrators.Remove("PlayChallengeTypePlayChallengeObjectiveTypeLinks");

            _playChallengeTypePlayChallengeObjectiveTypeLinksDMP = playChallengeTypePlayChallengeObjectiveTypeLinksDMP;
            _playChallengeTypePlayChallengeObjectiveTypeLinksDAS = playChallengeTypePlayChallengeObjectiveTypeLinksDAS;
            _playChallengeTypePlayChallengeObjectiveTypeLinksDA = new PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator(_playChallengeTypePlayChallengeObjectiveTypeLinksDMP, _playChallengeTypePlayChallengeObjectiveTypeLinksDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayChallengeTypePlayChallengeObjectiveTypeLinks"] = _playChallengeTypePlayChallengeObjectiveTypeLinksDA;
        }

        /// <summary>
        /// Gets the PlayChallengeTypePlayChallengeObjectiveTypeLink data administrator.
        /// </summary>
        /// <value>The PlayChallengeTypePlayChallengeObjectiveTypeLink data administrator.</value>
        public PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator
        {
            get { return _playChallengeTypePlayChallengeObjectiveTypeLinksDA; }
        }

        #endregion

        #region PlayAreaTileTypeChallengeObjectives

        private PlayAreaTileTypeChallengeObjectiveDataAdministrator _playAreaTileTypeChallengeObjectivesDA;
        private IDataManagementPolicy                               _playAreaTileTypeChallengeObjectivesDMP;
        private IDataAccessStrategy                                 _playAreaTileTypeChallengeObjectivesDAS;

        /// <summary>
        /// Setups the PlayAreaTileTypeChallengeObjective data administrator.
        /// </summary>
        /// <param name="playAreaTileTypeChallengeObjectivesDMP">The playAreaTileTypeChallengeObjectives DMP.</param>
        /// <param name="playAreaTileTypeChallengeObjectivesDAS">The playAreaTileTypeChallengeObjectives DAS.</param>
        public void SetupPlayAreaTileTypeChallengeObjectiveDataAdministrator(IDataManagementPolicy playAreaTileTypeChallengeObjectivesDMP, IDataAccessStrategy playAreaTileTypeChallengeObjectivesDAS)
        {
            #region Check Parameters

            if (playAreaTileTypeChallengeObjectivesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileTypeChallengeObjectivesDMP is nothing"));
            if (playAreaTileTypeChallengeObjectivesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileTypeChallengeObjectivesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaTileTypeChallengeObjectives")) _dataAdministrators.Remove("PlayAreaTileTypeChallengeObjectives");

            _playAreaTileTypeChallengeObjectivesDMP = playAreaTileTypeChallengeObjectivesDMP;
            _playAreaTileTypeChallengeObjectivesDAS = playAreaTileTypeChallengeObjectivesDAS;
            _playAreaTileTypeChallengeObjectivesDA  = new PlayAreaTileTypeChallengeObjectiveDataAdministrator(_playAreaTileTypeChallengeObjectivesDMP, _playAreaTileTypeChallengeObjectivesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaTileTypeChallengeObjectives"] = _playAreaTileTypeChallengeObjectivesDA;
        }

        /// <summary>
        /// Gets the PlayAreaTileTypeChallengeObjective data administrator.
        /// </summary>
        /// <value>The PlayAreaTileTypeChallengeObjective data administrator.</value>
        public PlayAreaTileTypeChallengeObjectiveDataAdministrator PlayAreaTileTypeChallengeObjectiveDataAdministrator
        {
            get { return _playAreaTileTypeChallengeObjectivesDA; }
        }

        #endregion

        #region PlayAreaPaths

        private PlayAreaPathDataAdministrator _playAreaPathsDA;
        private IDataManagementPolicy _playAreaPathsDMP;
        private IDataAccessStrategy _playAreaPathsDAS;

        /// <summary>
        /// Setups the PlayAreaPath data administrator.
        /// </summary>
        /// <param name="playAreaPathsDMP">The playAreaPaths DMP.</param>
        /// <param name="playAreaPathsDAS">The playAreaPaths DAS.</param>
        public void SetupPlayAreaPathDataAdministrator(IDataManagementPolicy playAreaPathsDMP, IDataAccessStrategy playAreaPathsDAS)
        {
            #region Check Parameters

            if (playAreaPathsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaPathsDMP is nothing"));
            if (playAreaPathsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaPathsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaPaths")) _dataAdministrators.Remove("PlayAreaPaths");

            _playAreaPathsDMP = playAreaPathsDMP;
            _playAreaPathsDAS = playAreaPathsDAS;
            _playAreaPathsDA = new PlayAreaPathDataAdministrator(_playAreaPathsDMP, _playAreaPathsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaPaths"] = _playAreaPathsDA;
        }

        /// <summary>
        /// Gets the PlayAreaPath data administrator.
        /// </summary>
        /// <value>The PlayAreaPath data administrator.</value>
        public PlayAreaPathDataAdministrator PlayAreaPathDataAdministrator
        {
            get { return _playAreaPathsDA; }
        }

        #endregion

        #region PlayAreaPathPoints

        private PlayAreaPathPointDataAdministrator  _playAreaPathPointsDA;
        private IDataManagementPolicy               _playAreaPathPointsDMP;
        private IDataAccessStrategy                 _playAreaPathPointsDAS;

        /// <summary>
        /// Setups the PlayAreaPathPoint data administrator.
        /// </summary>
        /// <param name="playAreaPathPointsDMP">The playAreaPathPoints DMP.</param>
        /// <param name="playAreaPathPointsDAS">The playAreaPathPoints DAS.</param>
        public void SetupPlayAreaPathPointDataAdministrator(IDataManagementPolicy playAreaPathPointsDMP, IDataAccessStrategy playAreaPathPointsDAS)
        {
            #region Check Parameters

            if (playAreaPathPointsDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaPathPointsDMP is nothing"));
            if (playAreaPathPointsDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaPathPointsDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaPathPoints")) _dataAdministrators.Remove("PlayAreaPathPoints");

            _playAreaPathPointsDMP  = playAreaPathPointsDMP;
            _playAreaPathPointsDAS  = playAreaPathPointsDAS;
            _playAreaPathPointsDA   = new PlayAreaPathPointDataAdministrator(_playAreaPathPointsDMP, _playAreaPathPointsDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaPathPoints"] = _playAreaPathPointsDA;
        }

        /// <summary>
        /// Gets the PlayAreaPathPoint data administrator.
        /// </summary>
        /// <value>The PlayAreaPathPoint data administrator.</value>
        public PlayAreaPathPointDataAdministrator PlayAreaPathPointDataAdministrator
        {
            get { return _playAreaPathPointsDA; }
        }

        #endregion

        #region PlayMoves

        private PlayMoveDataAdministrator _playMovesDA;
        private IDataManagementPolicy _playMovesDMP;
        private IDataAccessStrategy _playMovesDAS;

        /// <summary>
        /// Setups the PlayMove data administrator.
        /// </summary>
        /// <param name="playMovesDMP">The playMoves DMP.</param>
        /// <param name="playMovesDAS">The playMoves DAS.</param>
        public void SetupPlayMoveDataAdministrator(IDataManagementPolicy playMovesDMP, IDataAccessStrategy playMovesDAS)
        {
            #region Check Parameters

            if (playMovesDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playMovesDMP is nothing"));
            if (playMovesDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playMovesDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayMoves")) _dataAdministrators.Remove("PlayMoves");

            _playMovesDMP = playMovesDMP;
            _playMovesDAS = playMovesDAS;
            _playMovesDA = new PlayMoveDataAdministrator(_playMovesDMP, _playMovesDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayMoves"] = _playMovesDA;
        }

        /// <summary>
        /// Gets the PlayMove data administrator.
        /// </summary>
        /// <value>The PlayMove data administrator.</value>
        public PlayMoveDataAdministrator PlayMoveDataAdministrator
        {
            get { return _playMovesDA; }
        }

        #endregion

        #region PlayAreaCellTypePlayMoveLinks

        private PlayAreaCellTypePlayMoveLinkDataAdministrator   _playAreaCellTypePlayMoveLinksDA;
        private IDataManagementPolicy                           _playAreaCellTypePlayMoveLinksDMP;
        private IDataAccessStrategy                             _playAreaCellTypePlayMoveLinksDAS;

        /// <summary>
        /// Setups the PlayAreaCellTypePlayMoveLink data administrator.
        /// </summary>
        /// <param name="playAreaCellTypePlayMoveLinksDMP">The playAreaCellTypePlayMoveLinks DMP.</param>
        /// <param name="playAreaCellTypePlayMoveLinksDAS">The playAreaCellTypePlayMoveLinks DAS.</param>
        public void SetupPlayAreaCellTypePlayMoveLinkDataAdministrator(IDataManagementPolicy playAreaCellTypePlayMoveLinksDMP, IDataAccessStrategy playAreaCellTypePlayMoveLinksDAS)
        {
            #region Check Parameters

            if (playAreaCellTypePlayMoveLinksDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaCellTypePlayMoveLinksDMP is nothing"));
            if (playAreaCellTypePlayMoveLinksDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaCellTypePlayMoveLinksDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaCellTypePlayMoveLinks")) _dataAdministrators.Remove("PlayAreaCellTypePlayMoveLinks");

            _playAreaCellTypePlayMoveLinksDMP   = playAreaCellTypePlayMoveLinksDMP;
            _playAreaCellTypePlayMoveLinksDAS   = playAreaCellTypePlayMoveLinksDAS;
            _playAreaCellTypePlayMoveLinksDA    = new PlayAreaCellTypePlayMoveLinkDataAdministrator(_playAreaCellTypePlayMoveLinksDMP, _playAreaCellTypePlayMoveLinksDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaCellTypePlayMoveLinks"] = _playAreaCellTypePlayMoveLinksDA;
        }

        /// <summary>
        /// Gets the PlayAreaCellTypePlayMoveLink data administrator.
        /// </summary>
        /// <value>The PlayAreaCellTypePlayMoveLink data administrator.</value>
        public PlayAreaCellTypePlayMoveLinkDataAdministrator PlayAreaCellTypePlayMoveLinkDataAdministrator
        {
            get { return _playAreaCellTypePlayMoveLinksDA; }
        }

        #endregion

        #region PlayAreaTileTypePlayMoveLinks

        private PlayAreaTileTypePlayMoveLinkDataAdministrator   _playAreaTileTypePlayMoveLinksDA;
        private IDataManagementPolicy                           _playAreaTileTypePlayMoveLinksDMP;
        private IDataAccessStrategy                             _playAreaTileTypePlayMoveLinksDAS;

        /// <summary>
        /// Setups the PlayAreaTileTypePlayMoveLink data administrator.
        /// </summary>
        /// <param name="playAreaTileTypePlayMoveLinksDMP">The playAreaTileTypePlayMoveLinks DMP.</param>
        /// <param name="playAreaTileTypePlayMoveLinksDAS">The playAreaTileTypePlayMoveLinks DAS.</param>
        public void SetupPlayAreaTileTypePlayMoveLinkDataAdministrator(IDataManagementPolicy playAreaTileTypePlayMoveLinksDMP, IDataAccessStrategy playAreaTileTypePlayMoveLinksDAS)
        {
            #region Check Parameters

            if (playAreaTileTypePlayMoveLinksDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileTypePlayMoveLinksDMP is nothing"));
            if (playAreaTileTypePlayMoveLinksDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playAreaTileTypePlayMoveLinksDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayAreaTileTypePlayMoveLinks")) _dataAdministrators.Remove("PlayAreaTileTypePlayMoveLinks");

            _playAreaTileTypePlayMoveLinksDMP   = playAreaTileTypePlayMoveLinksDMP;
            _playAreaTileTypePlayMoveLinksDAS   = playAreaTileTypePlayMoveLinksDAS;
            _playAreaTileTypePlayMoveLinksDA    = new PlayAreaTileTypePlayMoveLinkDataAdministrator(_playAreaTileTypePlayMoveLinksDMP, _playAreaTileTypePlayMoveLinksDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayAreaTileTypePlayMoveLinks"] = _playAreaTileTypePlayMoveLinksDA;
        }

        /// <summary>
        /// Gets the PlayAreaTileTypePlayMoveLink data administrator.
        /// </summary>
        /// <value>The PlayAreaTileTypePlayMoveLink data administrator.</value>
        public PlayAreaTileTypePlayMoveLinkDataAdministrator PlayAreaTileTypePlayMoveLinkDataAdministrator
        {
            get { return _playAreaTileTypePlayMoveLinksDA; }
        }

        #endregion

        #region PlayChallengeTypePlayMoveLinks

        private PlayChallengeTypePlayMoveLinkDataAdministrator  _playChallengeTypePlayMoveLinksDA;
        private IDataManagementPolicy                           _playChallengeTypePlayMoveLinksDMP;
        private IDataAccessStrategy                             _playChallengeTypePlayMoveLinksDAS;

        /// <summary>
        /// Setups the PlayChallengeTypePlayMoveLink data administrator.
        /// </summary>
        /// <param name="playChallengeTypePlayMoveLinksDMP">The playChallengeTypePlayMoveLinks DMP.</param>
        /// <param name="playChallengeTypePlayMoveLinksDAS">The playChallengeTypePlayMoveLinks DAS.</param>
        public void SetupPlayChallengeTypePlayMoveLinkDataAdministrator(IDataManagementPolicy playChallengeTypePlayMoveLinksDMP, IDataAccessStrategy playChallengeTypePlayMoveLinksDAS)
        {
            #region Check Parameters

            if (playChallengeTypePlayMoveLinksDMP == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypePlayMoveLinksDMP is nothing"));
            if (playChallengeTypePlayMoveLinksDAS == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypePlayMoveLinksDAS is nothing"));

            #endregion

            if (_dataAdministrators.ContainsKey("PlayChallengeTypePlayMoveLinks")) _dataAdministrators.Remove("PlayChallengeTypePlayMoveLinks");

            _playChallengeTypePlayMoveLinksDMP                      = playChallengeTypePlayMoveLinksDMP;
            _playChallengeTypePlayMoveLinksDAS                      = playChallengeTypePlayMoveLinksDAS;
            _playChallengeTypePlayMoveLinksDA                       = new PlayChallengeTypePlayMoveLinkDataAdministrator(_playChallengeTypePlayMoveLinksDMP, _playChallengeTypePlayMoveLinksDAS, _defaultCultureInfoName, this);

            _dataAdministrators["PlayChallengeTypePlayMoveLinks"]   = _playChallengeTypePlayMoveLinksDA;
        }

        /// <summary>
        /// Gets the PlayChallengeTypePlayMoveLink data administrator.
        /// </summary>
        /// <value>The PlayChallengeTypePlayMoveLink data administrator.</value>
        public PlayChallengeTypePlayMoveLinkDataAdministrator PlayChallengeTypePlayMoveLinkDataAdministrator
        {
            get { return _playChallengeTypePlayMoveLinksDA; }
        }

        #endregion

        #endregion

        #region IDataAdministratorProvider Members

        /// <summary>
        /// Gets the data administrator with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public IDataAdministrator GetDataAdministrator(string key)
        {
            #region Check Parameters

            if (String.IsNullOrEmpty(key)) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "key is nothing"));
            if (!_dataAdministrators.ContainsKey(key)) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "key is invalid"));

            #endregion

            if (_dataAdministrators.ContainsKey(key)) return _dataAdministrators[key];
            return null;
        }

        #endregion
    }
}
