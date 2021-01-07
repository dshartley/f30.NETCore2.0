using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayAreaTileData
{
    /// <summary>
    /// A wrapper for a PlayAreaTileData item.
    /// </summary>
    public class PlayAreaTileDataWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaTileDataWrapper"/> class.
        /// </summary>
        public PlayAreaTileDataWrapper()
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

        private int _playAreaTileID;

        public int PlayAreaTileID
        {
            get { return _playAreaTileID; }
            set { _playAreaTileID = value; }
        }

        private string _onCompleteData;

        public string OnCompleteData
        {
            get { return _onCompleteData; }
            set { _onCompleteData = value; }
        }

        private string _attributeData;

        public string AttributeData
        {
            get { return _attributeData; }
            set { _attributeData = value; }
        }

        #endregion
    }
}
