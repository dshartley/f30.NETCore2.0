using f30.Core;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayAreaCellTypes
{
    /// <summary>
    /// A wrapper for a PlayAreaCellType item.
    /// </summary>
    public class PlayAreaCellTypeWrapper: DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaCellTypeWrapper"/> class.
        /// </summary>
        public PlayAreaCellTypeWrapper() : base()
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
                return "PlayAreaCellType";
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

        private string _blockedContentPositionsString;

        public string BlockedContentPositionsString
        {
            get { return _blockedContentPositionsString; }
            set { _blockedContentPositionsString = value; }
        }

        private string _cellAttributesString;

        public string CellAttributesString
        {
            get { return _cellAttributesString; }
            set { _cellAttributesString = value; }
        }

        private string _cellSideAttributesString;

        public string CellSideAttributesString
        {
            get { return _cellSideAttributesString; }
            set { _cellSideAttributesString = value; }
        }

        #endregion

        #region Public Methods; CellSideAttributes

        private DataJSONWrapper _cellSideAttributesWrapper = null;

        public DataJSONWrapper CellSideAttributesWrapper
        {
            get { return _cellSideAttributesWrapper; }
            set { _cellSideAttributesWrapper = value; }
        }

        /// <summary>
        /// Deserializes the cell side attributes.
        /// </summary>
        public void DeserializeCellSideAttributes()
        {
            _cellSideAttributesWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_cellSideAttributesString))
            {
                _cellSideAttributesWrapper = JSONHelper.DeserializeToJSON(_cellSideAttributesString);
            }
        }

        /// <summary>
        /// Serializes the cell side attributes.
        /// </summary>
        public void SerializeCellSideAttributes()
        {
            if (_cellSideAttributesWrapper == null)
            {
                _cellSideAttributesString = string.Empty;
                return;
            }

            _cellSideAttributesString = JSONHelper.SerializeFromJSON(_cellSideAttributesWrapper);
        }

        /// <summary>
        /// Gets the cell side attribute.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string GetCellSideAttribute(CellSides side, string key)
        {
            #region Check Parameters

            if (string.IsNullOrEmpty(key)) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "key is nothing"));

            #endregion

            string              result = string.Empty;

            // Get sideWrapper
            DataJSONWrapper     sideWrapper = _cellSideAttributesWrapper.Find(DesignDataItemHelper.ToKey(side));

            if (sideWrapper == null || sideWrapper.Params.Count == 0) { return result; }

            // Get parameter value
            result              = sideWrapper.GetParameterValue(key);

            return result;
        }

        #endregion
    }
}
