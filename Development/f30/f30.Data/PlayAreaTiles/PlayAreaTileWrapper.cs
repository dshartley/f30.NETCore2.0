using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayAreaTiles
{
    /// <summary>
    /// A wrapper for a PlayAreaTile item.
    /// </summary>
    public class PlayAreaTileWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaTileWrapper"/> class.
        /// </summary>
        public PlayAreaTileWrapper()
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

        private int _tileTypeID;

        public int TileTypeID
        {
            get { return _tileTypeID; }
            set { _tileTypeID = value; }
        }

        private int _columnID;

        public int Column
        {
            get { return _columnID; }
            set { _columnID = value; }
        }

        private int _rowID;

        public int Row
        {
            get { return _rowID; }
            set { _rowID = value; }
        }

        private int _rotationDegrees;

        public int RotationDegrees
        {
            get { return _rotationDegrees; }
            set { _rotationDegrees = value; }
        }

        private string _imageName;

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        private int _widthPixels;

        public int WidthPixels
        {
            get { return _widthPixels; }
            set { _widthPixels = value; }
        }

        private int _heightPixels;

        public int HeightPixels
        {
            get { return _heightPixels; }
            set { _heightPixels = value; }
        }

        private int _position;

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private bool _positionFixToCellRotationYN;

        public bool PositionFixToCellRotationYN
        {
            get { return _positionFixToCellRotationYN; }
            set { _positionFixToCellRotationYN = value; }
        }

        private string _tileAttributesString;

        public string TileAttributesString
        {
            get { return _tileAttributesString; }
            set { _tileAttributesString = value; }
        }

        private string _tileSideAttributesString;

        public string TileSideAttributesString
        {
            get { return _tileSideAttributesString; }
            set { _tileSideAttributesString = value; }
        }

        #endregion
    }
}
