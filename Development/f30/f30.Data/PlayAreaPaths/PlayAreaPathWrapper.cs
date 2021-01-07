using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayAreaPaths
{
    /// <summary>
    /// A wrapper for a PlayAreaPath item.
    /// </summary>
    public class PlayAreaPathWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaPathWrapper"/> class.
        /// </summary>
        public PlayAreaPathWrapper()
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

        private int _playGameID;

        public int PlayGameID
        {
            get { return _playGameID; }
            set { _playGameID = value; }
        }

        private string _pathAttributesString;

        public string PathAttributesString
        {
            get { return _pathAttributesString; }
            set { _pathAttributesString = value; }
        }

        private string _pathLogString;

        public string PathLogString
        {
            get { return _pathLogString; }
            set { _pathLogString = value; }
        }

        #endregion
    }
}
