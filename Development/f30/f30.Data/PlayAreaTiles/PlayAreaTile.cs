using Smart.Platform.Core;
using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaTiles
{
    public enum PlayAreaTileDataParameterKeys
    {
        ID,
	    RelativeMemberID,
        PlayGameID,
        TileTypeID,
        Column,
        Row,
        RotationDegrees,
        ImageName,
        WidthPixels,
        HeightPixels,
        Position,
        PositionFixToCellRotationYN,
        TileAttributesString,
        TileSideAttributesString
    }

    /// <summary>
    /// Encapsulates an PlayAreaTile data item.
    /// </summary>
    public class PlayAreaTile : DataItemBase
    {
        #region Constructors

        private PlayAreaTile() : base() { }

        public PlayAreaTile(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaTile(  XmlNode             dataNode,
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

        protected const string _tiletypeidKey = "TileTypeID";

        /// <summary>
        /// Gets or sets the TileTypeID.
        /// </summary>
        /// <value>The TileTypeID.</value>
        [System.ComponentModel.Browsable(false)]
        public int TileTypeID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_tiletypeidKey].Value);
            }
            set
            {
                this.SetProperty(_tiletypeidKey, value.ToString(), false);
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

        protected const string _widthpixelsKey = "WidthPixels";

        /// <summary>
        /// Gets or sets the WidthPixels.
        /// </summary>
        /// <value>The WidthPixels.</value>
        [System.ComponentModel.Browsable(false)]
        public int WidthPixels
        {
            get
            {
                return Int32.Parse(_node.Attributes[_widthpixelsKey].Value);
            }
            set
            {
                this.SetProperty(_widthpixelsKey, value.ToString(), false);
            }
        }

        protected const string _heightpixelsKey = "HeightPixels";

        /// <summary>
        /// Gets or sets the HeightPixels.
        /// </summary>
        /// <value>The HeightPixels.</value>
        [System.ComponentModel.Browsable(false)]
        public int HeightPixels
        {
            get
            {
                return Int32.Parse(_node.Attributes[_heightpixelsKey].Value);
            }
            set
            {
                this.SetProperty(_heightpixelsKey, value.ToString(), false);
            }
        }

        protected const string _positionKey = "Position";

        /// <summary>
        /// Gets or sets the Position.
        /// </summary>
        /// <value>The Position.</value>
        [System.ComponentModel.Browsable(false)]
        public int Position
        {
            get
            {
                return Int32.Parse(_node.Attributes[_positionKey].Value);
            }
            set
            {
                this.SetProperty(_positionKey, value.ToString(), false);
            }
        }

        //PositionFixToCellRotationYN
        protected const string _positionfixtocellrotationynKey = "PositionFixToCellRotationYN";

        /// <summary>
        /// Gets or sets the PositionFixToCellRotationYN.
        /// </summary>
        /// <value>The PositionFixToCellRotationYN.</value>
        [System.ComponentModel.Browsable(false)]
        public bool PositionFixToCellRotationYN
        {
            get
            {
                return BoolHelper.ToBool(_node.Attributes[_positionfixtocellrotationynKey].Value);
            }
            set
            {
                this.SetProperty(_positionfixtocellrotationynKey, Convert.ToInt32(value).ToString(), false);
            }
        }

        protected const string _tileattributesstringKey = "TileAttributesString";

        /// <summary>
        /// Gets or sets the TileAttributesString.
        /// </summary>
        /// <value>The TileAttributesString.</value>
        [System.ComponentModel.Browsable(false)]
        public string TileAttributesString
        {
            get
            {
                return _node.Attributes[_tileattributesstringKey].Value;
            }
            set
            {
                this.SetProperty(_tileattributesstringKey, value, false);
            }
        }

        protected const string _tilesideattributesstringKey = "TileSideAttributesString";

        /// <summary>
        /// Gets or sets the TileSideAttributesString.
        /// </summary>
        /// <value>The TileSideAttributesString.</value>
        [System.ComponentModel.Browsable(false)]
        public string TileSideAttributesString
        {
            get
            {
                return _node.Attributes[_tilesideattributesstringKey].Value;
            }
            set
            {
                this.SetProperty(_tilesideattributesstringKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaTileWrapper ToWrapper()
        {
            PlayAreaTileWrapper result = new PlayAreaTileWrapper();

            result.ID                           = this.ID;
            result.RelativeMemberID             = this.RelativeMemberID;
            result.PlayGameID                   = this.PlayGameID;
            result.TileTypeID                   = this.TileTypeID;
            result.Column                       = this.Column;
            result.Row                          = this.Row;
            result.RotationDegrees              = this.RotationDegrees;
            result.ImageName                    = this.ImageName;
            result.WidthPixels                  = this.WidthPixels;
            result.HeightPixels                 = this.HeightPixels;
            result.Position                     = this.Position;
            result.PositionFixToCellRotationYN  = this.PositionFixToCellRotationYN;
            result.TileAttributesString         = this.TileAttributesString;
            result.TileSideAttributesString     = this.TileSideAttributesString;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaTileWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.RelativeMemberID               = fromWrapper.RelativeMemberID;
            this.PlayGameID                     = fromWrapper.PlayGameID;
            this.TileTypeID                     = fromWrapper.TileTypeID;
            this.Column                         = fromWrapper.Column;
            this.Row                            = fromWrapper.Row;
            this.RotationDegrees                = fromWrapper.RotationDegrees;
            this.ImageName                      = fromWrapper.ImageName;
            this.WidthPixels                    = fromWrapper.WidthPixels;
            this.HeightPixels                   = fromWrapper.HeightPixels;
            this.Position                       = fromWrapper.Position;
            this.PositionFixToCellRotationYN    = fromWrapper.PositionFixToCellRotationYN;
            this.TileAttributesString           = fromWrapper.TileAttributesString;
            this.TileSideAttributesString       = fromWrapper.TileSideAttributesString;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playgameidKey, "0");
            this.SetAttribute(_tiletypeidKey, "0");
            this.SetAttribute(_columnKey, "0");
            this.SetAttribute(_rowKey, "0");
            this.SetAttribute(_rotationdegreesKey, "0");
            this.SetAttribute(_imagenameKey, "");
            this.SetAttribute(_widthpixelsKey, "0");
            this.SetAttribute(_heightpixelsKey, "0");
            this.SetAttribute(_positionKey, "0");
            this.SetAttribute(_positionfixtocellrotationynKey, "0");
            this.SetAttribute(_tileattributesstringKey, "");
            this.SetAttribute(_tilesideattributesstringKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaTiles_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaTiles_TileSideAttributesString;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                           (int)DataProperties.PlayAreaTiles_ID);
            _keys.Add(_relativememberidKey,             (int)DataProperties.PlayAreaTiles_RelativeMemberID);
            _keys.Add(_playgameidKey,                   (int)DataProperties.PlayAreaTiles_PlayGameID);
            _keys.Add(_tiletypeidKey,                   (int)DataProperties.PlayAreaTiles_TileTypeID);
            _keys.Add(_columnKey,                       (int)DataProperties.PlayAreaTiles_Column);
            _keys.Add(_rowKey,                          (int)DataProperties.PlayAreaTiles_Row);
            _keys.Add(_rotationdegreesKey,              (int)DataProperties.PlayAreaTiles_RotationDegrees);
            _keys.Add(_imagenameKey,                    (int)DataProperties.PlayAreaTiles_ImageName);
            _keys.Add(_widthpixelsKey,                  (int)DataProperties.PlayAreaTiles_WidthPixels);
            _keys.Add(_heightpixelsKey,                 (int)DataProperties.PlayAreaTiles_HeightPixels);
            _keys.Add(_positionKey,                     (int)DataProperties.PlayAreaTiles_Position);
            _keys.Add(_positionfixtocellrotationynKey,  (int)DataProperties.PlayAreaTiles_PositionFixToCellRotationYN);
            _keys.Add(_tileattributesstringKey,         (int)DataProperties.PlayAreaTiles_TileAttributesString);
            _keys.Add(_tilesideattributesstringKey,     (int)DataProperties.PlayAreaTiles_TileSideAttributesString);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaTile"; }
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

            this.ID                             = ((PlayAreaTile)copy).ID;
            this.RelativeMemberID               = ((PlayAreaTile)copy).RelativeMemberID;
            this.PlayGameID                     = ((PlayAreaTile)copy).PlayGameID;
            this.TileTypeID                     = ((PlayAreaTile)copy).TileTypeID;
            this.Column                         = ((PlayAreaTile)copy).Column;
            this.Row                            = ((PlayAreaTile)copy).Row;
            this.RotationDegrees                = ((PlayAreaTile)copy).RotationDegrees;
            this.ImageName                      = ((PlayAreaTile)copy).ImageName;
            this.WidthPixels                    = ((PlayAreaTile)copy).WidthPixels;
            this.HeightPixels                   = ((PlayAreaTile)copy).HeightPixels;
            this.Position                       = ((PlayAreaTile)copy).Position;
            this.PositionFixToCellRotationYN    = ((PlayAreaTile)copy).PositionFixToCellRotationYN;
            this.TileAttributesString           = ((PlayAreaTile)copy).TileAttributesString;
            this.TileSideAttributesString       = ((PlayAreaTile)copy).TileSideAttributesString;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.PlayGameID.ToString(), this.PlayGameID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.TileTypeID.ToString(), this.TileTypeID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.Column.ToString(), this.Column.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.Row.ToString(), this.Row.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.RotationDegrees.ToString(), this.RotationDegrees.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.ImageName.ToString(), this.ImageName);
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.WidthPixels.ToString(), this.WidthPixels.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.HeightPixels.ToString(), this.HeightPixels.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.Position.ToString(), this.Position.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.PositionFixToCellRotationYN.ToString(), Convert.ToInt32(this.PositionFixToCellRotationYN).ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.TileAttributesString.ToString(), this.TileAttributesString);
            dataWrapper.SetParameterValue(PlayAreaTileDataParameterKeys.TileSideAttributesString.ToString(), this.TileSideAttributesString);

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

            this.ID                             = Int32.Parse(dataWrapper.ID);
            this.RelativeMemberID               = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayGameID                     = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.PlayGameID.ToString()));
            this.TileTypeID                     = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.TileTypeID.ToString()));
            this.Column                         = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.Column.ToString()));
            this.Row                            = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.Row.ToString()));
            this.RotationDegrees                = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.RotationDegrees.ToString()));
            this.ImageName                      = dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.ImageName.ToString());
            this.WidthPixels                    = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.WidthPixels.ToString()));
            this.HeightPixels                   = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.HeightPixels.ToString()));
            this.Position                       = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.Position.ToString()));
            this.PositionFixToCellRotationYN    = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.PositionFixToCellRotationYN.ToString()));
            this.TileAttributesString           = dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.TileAttributesString.ToString());
            this.TileSideAttributesString       = dataWrapper.GetParameterValue(PlayAreaTileDataParameterKeys.TileSideAttributesString.ToString());

            this.DoValidations                  = doValidations;
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
