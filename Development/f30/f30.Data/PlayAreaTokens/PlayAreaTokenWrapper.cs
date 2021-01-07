using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayAreaTokens
{
    /// <summary>
    /// A wrapper for a PlayAreaToken item.
    /// </summary>
    public class PlayAreaTokenWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaTokenWrapper"/> class.
        /// </summary>
        public PlayAreaTokenWrapper()
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

        private int _column;

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        private int _row;

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        private string _imageName;

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        private string _tokenAttributesString;

        public string TokenAttributesString
        {
            get { return _tokenAttributesString; }
            set { _tokenAttributesString = value; }
        }

        #endregion
    }
}
