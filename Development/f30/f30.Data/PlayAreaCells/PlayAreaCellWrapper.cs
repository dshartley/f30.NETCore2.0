using f30.Core;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;

namespace f30.Data.PlayAreaCells
{
    /// <summary>
    /// A wrapper for a PlayAreaCell item.
    /// </summary>
    public class PlayAreaCellWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaCellWrapper"/> class.
        /// </summary>
        public PlayAreaCellWrapper()
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

        private int _cellTypeID;

        public int CellTypeID
        {
            get { return _cellTypeID; }
            set { _cellTypeID = value; }
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
            _cellSideAttributesWrapper      = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_cellSideAttributesString))
            {
                _cellSideAttributesWrapper  = JSONHelper.DeserializeToJSON(_cellSideAttributesString);
            }
        }

        /// <summary>
        /// Serializes the cell side attributes.
        /// </summary>
        public void SerializeCellSideAttributes()
        {
            if (_cellSideAttributesWrapper == null)
            {
                _cellSideAttributesString   = string.Empty;
                return;
            }

            _cellSideAttributesString       = JSONHelper.SerializeFromJSON(_cellSideAttributesWrapper);
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
