using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaCells
{
    public enum PlayAreaCellDataParameterKeys
    {
        ID,
        RelativeMemberID,
        PlayGameID,
        CellTypeID,
        Column,
        Row,
        RotationDegrees,
        ImageName,
        CellAttributesString,
        CellSideAttributesString
    }

    /// <summary>
    /// Encapsulates an PlayAreaCell data item.
    /// </summary>
    public class PlayAreaCell : DataItemBase
    {
        #region Constructors

        private PlayAreaCell() : base() { }

        public PlayAreaCell(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaCell(  XmlNode             dataNode,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataNode, collection, defaultCultureInfoName)
        { }

        #endregion

        #region Public Methods

        protected const string _relativememberidKey = "RelativeMemberID";

        /// <summary>
        /// Gets or sets the RelativeMemberID.
        /// </summary>
        /// <value>The RelativeMemberID.</value>
        [System.ComponentModel.Browsable(false)]
        public int RelativeMemberID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_relativememberidKey].Value);
            }
            set
            {
                this.SetProperty(_relativememberidKey, value.ToString(), false);
            }
        }

        protected const string _playgameidKey = "PlayGameID";

        /// <summary>
        /// Gets or sets the PlayGameID.
        /// </summary>
        /// <value>The PlayGameID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayGameID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playgameidKey].Value);
            }
            set
            {
                this.SetProperty(_playgameidKey, value.ToString(), false);
            }
        }

        protected const string _celltypeidKey = "CellTypeID";

        /// <summary>
        /// Gets or sets the CellTypeID.
        /// </summary>
        /// <value>The CellTypeID.</value>
        [System.ComponentModel.Browsable(false)]
        public int CellTypeID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_celltypeidKey].Value);
            }
            set
            {
                this.SetProperty(_celltypeidKey, value.ToString(), false);
            }
        }

        protected const string _columnKey = "Column";

        /// <summary>
        /// Gets or sets the Column.
        /// </summary>
        /// <value>The Column.</value>
        [System.ComponentModel.Browsable(false)]
        public int Column
        {
            get
            {
                return Int32.Parse(_node.Attributes[_columnKey].Value);
            }
            set
            {
                this.SetProperty(_columnKey, value.ToString(), false);
            }
        }

        protected const string _rowKey = "Row";

        /// <summary>
        /// Gets or sets the Row.
        /// </summary>
        /// <value>The Row.</value>
        [System.ComponentModel.Browsable(false)]
        public int Row
        {
            get
            {
                return Int32.Parse(_node.Attributes[_rowKey].Value);
            }
            set
            {
                this.SetProperty(_rowKey, value.ToString(), false);
            }
        }

        protected const string _rotationdegreesKey = "RotationDegrees";

        /// <summary>
        /// Gets or sets the RotationDegrees.
        /// </summary>
        /// <value>The RotationDegrees.</value>
        [System.ComponentModel.Browsable(false)]
        public int RotationDegrees
        {
            get
            {
                return Int32.Parse(_node.Attributes[_rotationdegreesKey].Value);
            }
            set
            {
                this.SetProperty(_rotationdegreesKey, value.ToString(), false);
            }
        }

        protected const string _imagenameKey = "ImageName";

        /// <summary>
        /// Gets or sets the ImageName.
        /// </summary>
        /// <value>The ImageName.</value>
        [System.ComponentModel.Browsable(false)]
        public string ImageName
        {
            get
            {
                return _node.Attributes[_imagenameKey].Value;
            }
            set
            {
                this.SetProperty(_imagenameKey, value, false);
            }
        }

        protected const string _cellattributesstringKey = "CellAttributesString";

        /// <summary>
        /// Gets or sets the CellAttributesString.
        /// </summary>
        /// <value>The CellAttributesString.</value>
        [System.ComponentModel.Browsable(false)]
        public string CellAttributesString
        {
            get
            {
                return _node.Attributes[_cellattributesstringKey].Value;
            }
            set
            {
                this.SetProperty(_cellattributesstringKey, value, false);
            }
        }

        protected const string _cellsideattributesstringKey = "CellSideAttributesString";

        /// <summary>
        /// Gets or sets the CellSideAttributesString.
        /// </summary>
        /// <value>The CellSideAttributesString.</value>
        [System.ComponentModel.Browsable(false)]
        public string CellSideAttributesString
        {
            get
            {
                return _node.Attributes[_cellsideattributesstringKey].Value;
            }
            set
            {
                this.SetProperty(_cellsideattributesstringKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaCellWrapper ToWrapper()
        {
            PlayAreaCellWrapper result = new PlayAreaCellWrapper();

            result.ID                           = this.ID;
            result.RelativeMemberID             = this.RelativeMemberID;
            result.PlayGameID                   = this.PlayGameID;
            result.CellTypeID                   = this.CellTypeID;
            result.Column                       = this.Column;
            result.Row                          = this.Row;
            result.RotationDegrees              = this.RotationDegrees;
            result.ImageName                    = this.ImageName;
            result.CellAttributesString         = this.CellAttributesString;
            result.CellSideAttributesString     = this.CellSideAttributesString;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaCellWrapper fromWrapper)
        {
            this.ID                         = fromWrapper.ID;
            this.RelativeMemberID           = fromWrapper.RelativeMemberID;
            this.PlayGameID                 = fromWrapper.PlayGameID;
            this.CellTypeID                 = fromWrapper.CellTypeID;
            this.Column                     = fromWrapper.Column;
            this.Row                        = fromWrapper.Row;
            this.RotationDegrees            = fromWrapper.RotationDegrees;
            this.ImageName                  = fromWrapper.ImageName;
            this.CellAttributesString       = fromWrapper.CellAttributesString;
            this.CellSideAttributesString   = fromWrapper.CellSideAttributesString;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "");
            this.SetAttribute(_playgameidKey, "0");
            this.SetAttribute(_celltypeidKey, "0");
            this.SetAttribute(_columnKey, "0");
            this.SetAttribute(_rowKey, "0");
            this.SetAttribute(_rotationdegreesKey, "0");
            this.SetAttribute(_imagenameKey, "");
            this.SetAttribute(_cellattributesstringKey, "");
            this.SetAttribute(_cellsideattributesstringKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaCells_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaCells_CellSideAttributesString;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                           (int)DataProperties.PlayAreaCells_ID);
            _keys.Add(_relativememberidKey,             (int)DataProperties.PlayAreaCells_RelativeMemberID);
            _keys.Add(_playgameidKey,                   (int)DataProperties.PlayAreaCells_PlayGameID);
            _keys.Add(_celltypeidKey,                   (int)DataProperties.PlayAreaCells_CellTypeID);
            _keys.Add(_columnKey,                       (int)DataProperties.PlayAreaCells_Column);
            _keys.Add(_rowKey,                          (int)DataProperties.PlayAreaCells_Row);
            _keys.Add(_rotationdegreesKey,              (int)DataProperties.PlayAreaCells_RotationDegrees);
            _keys.Add(_imagenameKey,                    (int)DataProperties.PlayAreaCells_ImageName);
            _keys.Add(_cellattributesstringKey,         (int)DataProperties.PlayAreaCells_CellAttributesString);
            _keys.Add(_cellsideattributesstringKey,     (int)DataProperties.PlayAreaCells_CellSideAttributesString);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaCell"; }
        }

        public override void Copy(IDataItem copy)
        {
            #region Check Parameters

            if (copy == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "copy is nothing"));

            #endregion

            // Validations should not be performed when copying the item
            bool doValidations = this.DoValidations;
            this.DoValidations = false;

            // Copy all properties from the copy data item to this data item:

            this.ID                         = ((PlayAreaCell)copy).ID;
            this.RelativeMemberID           = ((PlayAreaCell)copy).RelativeMemberID;
            this.PlayGameID                 = ((PlayAreaCell)copy).PlayGameID;
            this.CellTypeID                 = ((PlayAreaCell)copy).CellTypeID;
            this.Column                     = ((PlayAreaCell)copy).Column;
            this.Row                        = ((PlayAreaCell)copy).Row;
            this.RotationDegrees            = ((PlayAreaCell)copy).RotationDegrees;
            this.ImageName                  = ((PlayAreaCell)copy).ImageName;
            this.CellAttributesString       = ((PlayAreaCell)copy).CellAttributesString;
            this.CellSideAttributesString   = ((PlayAreaCell)copy).CellSideAttributesString;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.RelativeMemberID.ToString(), ((int)this.RelativeMemberID).ToString());
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.PlayGameID.ToString(), this.PlayGameID.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.CellTypeID.ToString(), this.CellTypeID.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.Column.ToString(), this.Column.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.Row.ToString(), this.Row.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.RotationDegrees.ToString(), this.RotationDegrees.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.ImageName.ToString(), this.ImageName);
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.CellAttributesString.ToString(), this.CellAttributesString);
            dataWrapper.SetParameterValue(PlayAreaCellDataParameterKeys.CellSideAttributesString.ToString(), this.CellSideAttributesString);

            return dataWrapper;
        }

        public override void CopyFromWrapper(DataJSONWrapper dataWrapper, CultureInfo fromCultureInfo)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));
            if (fromCultureInfo == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "fromCultureInfo is nothing"));

            #endregion

            // Validations should not be performed when copying the item
            bool doValidations = this.DoValidations;
            this.DoValidations = false;

            // Copy all properties from the copy data item to this data item:

            this.ID                         = Int32.Parse(dataWrapper.ID);
            this.RelativeMemberID           = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayGameID                 = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.PlayGameID.ToString()));
            this.CellTypeID                 = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.CellTypeID.ToString()));
            this.Column                     = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.Column.ToString()));
            this.Row                        = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.Row.ToString()));
            this.RotationDegrees            = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.RotationDegrees.ToString()));
            this.ImageName                  = dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.ImageName.ToString());
            this.CellAttributesString       = dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.CellAttributesString.ToString());
            this.CellSideAttributesString   = dataWrapper.GetParameterValue(PlayAreaCellDataParameterKeys.CellSideAttributesString.ToString());


            this.DoValidations       = doValidations;
        }

        public override ValidationResultTypes IsValid(int propertyEnum, string value)
        {
            #region Check Parameters

            if (value == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "value is nothing"));

            #endregion

            ValidationResultTypes result = ValidationResultTypes.Passed;

            // Perform validations for the specified property
            switch (ToProperty(propertyEnum))
            {
                default:
                    break;
            }

            return result;
        }

        // Note: This method is overridden to implement culture specific formatting
        public override string GetProperty(int propertyEnum, CultureInfo toCultureInfo)
        {
            #region Check Parameters

            if (toCultureInfo == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "toCultureInfo is nothing"));

            #endregion

            string s = string.Empty;

            switch (propertyEnum)
            {
                //case (int)DataProperties.Volumes_DatePublished:
                //    s = this.DatePublished.ToString("g", toCultureInfo); // MM/dd/yyyy HH:mm
                //    break;
                default:
                    s = this.GetProperty(propertyEnum);
                    break;
            }

            return s;
        }

        // Note: This method is overridden to implement culture specific formatting
        public override void SetProperty(string key, string value, bool setWhenInvalid, CultureInfo fromCultureInfo)
        {
            #region Check Parameters

            if (key == string.Empty) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "key is nothing"));
            if (fromCultureInfo == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "fromCultureInfo is nothing"));

            #endregion

            string  s = string.Empty;
            int     propertyEnum = this.ToEnum(key);

            switch (propertyEnum)
            {
                //case (int)DataProperties.Volumes_DatePublished:

                //    // Parse the value using fromCultureInfo
                //    s = this.DoParseToStorageDateString(value, fromCultureInfo);

                //    break;
                default:
                    s = value;
                    break;
            }


            this.SetProperty(key, s, setWhenInvalid);

        }

        #endregion

        #region Private Methods

        private DataProperties ToProperty(int propertyEnum)
        {
            return (DataProperties)propertyEnum;
        }

        #endregion

        #region Validations

        #endregion
    }
}
