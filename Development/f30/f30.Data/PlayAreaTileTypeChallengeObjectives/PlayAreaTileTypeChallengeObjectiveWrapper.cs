using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayAreaTileTypeChallengeObjectives
{
    /// <summary>
    /// A wrapper for a PlayAreaTileTypeChallengeObjective item.
    /// </summary>
    public class PlayAreaTileTypeChallengeObjectiveWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaTileTypeChallengeObjectiveWrapper"/> class.
        /// </summary>
        public PlayAreaTileTypeChallengeObjectiveWrapper()
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

        private int _playAreaTileTypeID;

        public int PlayAreaTileTypeID
        {
            get { return _playAreaTileTypeID; }
            set { _playAreaTileTypeID = value; }
        }

        private string _playChallengeObjectiveCode;

        public string PlayChallengeObjectiveCode
        {
            get { return _playChallengeObjectiveCode; }
            set { _playChallengeObjectiveCode = value; }
        }

        private string _playChallengeObjectiveData;

        public string PlayChallengeObjectiveData
        {
            get { return _playChallengeObjectiveData; }
            set { _playChallengeObjectiveData = value; }
        }

        private int _versionID;

        public int VersionID
        {
            get { return _versionID; }
            set { _versionID = value; }
        }

        private DateTime _versionDate;

        public DateTime VersionDate
        {
            get { return _versionDate; }
            set { _versionDate = value; }
        }

        private int _versionOwnerID;

        public int VersionOwnerID
        {
            get { return _versionOwnerID; }
            set { _versionOwnerID = value; }
        }

        #endregion
    }
}
