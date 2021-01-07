using System;
using System.Collections.Generic;
using System.Text;
using Smart.Platform.Net.Serialization.JSON;

namespace f30.Data.PlayGameData
{
    /// <summary>
    /// A wrapper for a PlayGameData item.
    /// </summary>
    public class PlayGameDataWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameDataWrapper"/> class.
        /// </summary>
        public PlayGameDataWrapper()
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

        private int _playGameID;

        public int PlayGameID
        {
            get { return _playGameID; }
            set { _playGameID = value; }
        }

        private DateTime _dateLastPlayed;

        public DateTime DateLastPlayed
        {
            get { return _dateLastPlayed; }
            set { _dateLastPlayed = value; }
        }

        private string _onCompleteData;

        public string OnCompleteData
        {
            get { return _onCompleteData; }
            set { _onCompleteData = value; }
        }

        private string _attributeData = string.Empty;

        public string AttributeData
        {
            get { return _attributeData; }
            set { _attributeData = value; }
        }

        #endregion

        #region Public Methods; OnCompleteData

        protected DataJSONWrapper _onCompleteDataWrapper = null;

        public DataJSONWrapper OnCompleteDataWrapper
        {
            get { return _onCompleteDataWrapper; }
            set { _onCompleteDataWrapper = value; }
        }

        /// <summary>
        /// Deserializes the OnCompleteData.
        /// </summary>
        public void DeserializeOnCompleteData()
        {
            _onCompleteDataWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_onCompleteData))
            {
                _onCompleteDataWrapper = JSONHelper.DeserializeToJSON(_onCompleteData);
            }
        }

        /// <summary>
        /// Serializes the OnCompleteData.
        /// </summary>
        public void SerializeOnCompleteData()
        {
            if (_onCompleteDataWrapper == null)
            {
                _onCompleteData = string.Empty;
                return;
            }

            _onCompleteData = JSONHelper.SerializeFromJSON(_onCompleteDataWrapper);
        }

        #endregion
    }
}
