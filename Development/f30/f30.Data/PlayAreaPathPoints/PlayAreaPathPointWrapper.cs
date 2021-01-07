using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayAreaPathPoints
{
    /// <summary>
    /// A wrapper for a PlayAreaPathPoint item.
    /// </summary>
    public class PlayAreaPathPointWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaPathPointWrapper"/> class.
        /// </summary>
        public PlayAreaPathPointWrapper()
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

        private int _playAreaPathID;

        public int PlayAreaPathID
        {
            get { return _playAreaPathID; }
            set { _playAreaPathID = value; }
        }

        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
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

        #endregion
    }
}
