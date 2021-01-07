using System;
using System.Collections.Generic;
using System.Text;
using Smart.Platform.Net.Serialization.JSON;

namespace f30.Data.PlayResults
{
    /// <summary>
    /// A wrapper for a PlayResult item.
    /// </summary>
    public class PlayResultWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayResultWrapper"/> class.
        /// </summary>
        public PlayResultWrapper()
        {
        }

        #endregion

        #region Public Methods

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _relativeMemberID;

        public int RelativeMemberID
        {
            get { return _relativeMemberID; }
            set { _relativeMemberID = value; }
        }

        private string _playGamesJSON;

        public string PlayGamesJSON
        {
            get { return _playGamesJSON; }
            set { _playGamesJSON = value; }
        }

        private string _playGameDataJSON;

        public string PlayGameDataJSON
        {
            get { return _playGameDataJSON; }
            set { _playGameDataJSON = value; }
        }

        private string _playAreaTilesJSON;

        public string PlayAreaTilesJSON
        {
            get { return _playAreaTilesJSON; }
            set { _playAreaTilesJSON = value; }
        }

        private string _playAreaTileDataJSON;

        public string PlayAreaTileDataJSON
        {
            get { return _playAreaTileDataJSON; }
            set { _playAreaTileDataJSON = value; }
        }

        private string _playExperienceStepResultsJSON;

        public string PlayExperienceStepResultsJSON
        {
            get { return _playExperienceStepResultsJSON; }
            set { _playExperienceStepResultsJSON = value; }
        }

        #endregion

        #region Public Methods; PlayGames

        private DataJSONWrapper _playGamesWrapper = null;

        public DataJSONWrapper PlayGamesWrapper
        {
            get { return _playGamesWrapper; }
            set { _playGamesWrapper = value; }

        }
        /// <summary>
        /// Deserializes the PlayGames.
        /// </summary>
        public void DeserializePlayGames()
        {
            _playGamesWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playGamesJSON))
            {
                _playGamesWrapper = JSONHelper.DeserializeToJSON(_playGamesJSON);
            }
        }

        /// <summary>
        /// Serializes the PlayGames.
        /// </summary>
        public void SerializePlayGames()
        {
            if (_playGamesWrapper == null)
            {
                _playGamesJSON = string.Empty;
                return;
            }

            _playGamesJSON = JSONHelper.SerializeFromJSON(_playGamesWrapper);
        }

        #endregion

        #region Public Methods; PlayGameData

        private DataJSONWrapper _playGameDataWrapper = null;

        public DataJSONWrapper PlayGameDataWrapper
        {
            get { return _playGameDataWrapper; }
            set { _playGameDataWrapper = value; }

        }
        /// <summary>
        /// Deserializes the PlayGameData.
        /// </summary>
        public void DeserializePlayGameData()
        {
            _playGameDataWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playGameDataJSON))
            {
                _playGameDataWrapper = JSONHelper.DeserializeToJSON(_playGameDataJSON);
            }
        }

        /// <summary>
        /// Serializes the PlayGameData.
        /// </summary>
        public void SerializePlayGameData()
        {
            if (_playGameDataWrapper == null)
            {
                _playGameDataJSON = string.Empty;
                return;
            }

            _playGameDataJSON = JSONHelper.SerializeFromJSON(_playGameDataWrapper);
        }

        #endregion

        #region Public Methods; PlayAreaTiles

        private DataJSONWrapper _playAreaTilesWrapper = null;

        public DataJSONWrapper PlayAreaTilesWrapper
        {
            get { return _playAreaTilesWrapper; }
            set { _playAreaTilesWrapper = value; }

        }
        /// <summary>
        /// Deserializes the PlayAreaTiles.
        /// </summary>
        public void DeserializePlayAreaTiles()
        {
            _playAreaTilesWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playAreaTilesJSON))
            {
                _playAreaTilesWrapper = JSONHelper.DeserializeToJSON(_playAreaTilesJSON);
            }
        }

        /// <summary>
        /// Serializes the PlayAreaTiles.
        /// </summary>
        public void SerializePlayAreaTiles()
        {
            if (_playAreaTilesWrapper == null)
            {
                _playAreaTilesJSON = string.Empty;
                return;
            }

            _playAreaTilesJSON = JSONHelper.SerializeFromJSON(_playAreaTilesWrapper);
        }

        #endregion

        #region Public Methods; PlayAreaTileData

        private DataJSONWrapper _playAreaTileDataWrapper = null;

        public DataJSONWrapper PlayAreaTileDataWrapper
        {
            get { return _playAreaTileDataWrapper; }
            set { _playAreaTileDataWrapper = value; }

        }
        /// <summary>
        /// Deserializes the PlayAreaTileData.
        /// </summary>
        public void DeserializePlayAreaTileData()
        {
            _playAreaTileDataWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playAreaTileDataJSON))
            {
                _playAreaTileDataWrapper = JSONHelper.DeserializeToJSON(_playAreaTileDataJSON);
            }
        }

        /// <summary>
        /// Serializes the PlayAreaTileData.
        /// </summary>
        public void SerializePlayAreaTileData()
        {
            if (_playAreaTileDataWrapper == null)
            {
                _playAreaTileDataJSON = string.Empty;
                return;
            }

            _playAreaTileDataJSON = JSONHelper.SerializeFromJSON(_playAreaTileDataWrapper);
        }

        #endregion

        #region Public Methods; PlayExperienceStepResults

        private DataJSONWrapper _playExperienceStepResultsWrapper = null;

        public DataJSONWrapper PlayExperienceStepResultsWrapper
        {
            get { return _playExperienceStepResultsWrapper; }
            set { _playExperienceStepResultsWrapper = value; }

        }
        /// <summary>
        /// Deserializes the PlayExperienceStepResults.
        /// </summary>
        public void DeserializePlayExperienceStepResults()
        {
            _playExperienceStepResultsWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playExperienceStepResultsJSON))
            {
                _playExperienceStepResultsWrapper = JSONHelper.DeserializeToJSON(_playExperienceStepResultsJSON);
            }
        }

        /// <summary>
        /// Serializes the PlayExperienceStepResults.
        /// </summary>
        public void SerializePlayExperienceStepResults()
        {
            if (_playExperienceStepResultsWrapper == null)
            {
                _playExperienceStepResultsJSON = string.Empty;
                return;
            }

            _playExperienceStepResultsJSON = JSONHelper.SerializeFromJSON(_playExperienceStepResultsWrapper);
        }

        #endregion
    }
}
