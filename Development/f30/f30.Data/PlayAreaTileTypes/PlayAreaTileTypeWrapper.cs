using f30.Core;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayAreaTileTypes
{
    /// <summary>
    /// A wrapper for a PlayAreaTileType item.
    /// </summary>
    public class PlayAreaTileTypeWrapper: DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaTileTypeWrapper"/> class.
        /// </summary>
        public PlayAreaTileTypeWrapper() : base()
        {
        }

        #endregion

        #region Public Override Methods

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public override string DataType
        {
            get
            {
                return "PlayAreaTileType";
            }
        }

        #endregion

        #region Public Methods

        private bool _isSpecialYN;

        public bool IsSpecialYN
        {
            get { return _isSpecialYN; }
            set { _isSpecialYN = value; }
        }

        private int _deckWeighting;

        public int DeckWeighting
        {
            get { return _deckWeighting; }
            set { _deckWeighting = value; }
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

        private CellContentPositionTypes _position;

        public CellContentPositionTypes Position
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
