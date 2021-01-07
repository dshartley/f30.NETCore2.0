using Smart.Platform.Core;
using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;
using f30.Core;

namespace f30.Data.PlayAreaTileTypes
{
    public enum PlayAreaTileTypeDataParameterKeys
    {
        ID,
        PlaySubsetID,
        Name,
        IsSpecialYN,
        DeckWeighting,
        ImageName,
        WidthPixels,
        HeightPixels,
        Position,
        PositionFixToCellRotationYN,
        TileAttributesString,
        TileSideAttributesString,
        IndexDefinitionData,
        VersionID,
        VersionDate,
        VersionOwnerID
    }

    /// <summary>
    /// Encapsulates an PlayAreaTileType data item.
    /// </summary>
    public class PlayAreaTileType : DataItemBase
    {
        #region Constructors

        private PlayAreaTileType() : base() { }

        public PlayAreaTileType(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaTileType(  XmlNode             dataNode,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataNode, collection, defaultCultureInfoName)
        { }

        #endregion

        #region Public Methods

        protected const string _playsubsetidKey = "PlaySubsetID";

        /// <summary>
        /// Gets or sets the PlaySubsetID.
        /// </summary>
        /// <value>The PlaySubsetID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlaySubsetID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playsubsetidKey].Value);
            }
            set
            {
                this.SetProperty(_playsubsetidKey, value.ToString(), false);
            }
        }

        protected const string _nameKey = "Name";

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        [System.ComponentModel.Browsable(false)]
        public string Name
        {
            get
            {
                return _node.Attributes[_nameKey].Value;
            }
            set
            {
                this.SetProperty(_nameKey, value, false);
            }
        }

        protected const string _isspecialynKey = "IsSpecialYN";

        /// <summary>
        /// Gets or sets the IsSpecialYN.
        /// </summary>
        /// <value>The IsSpecialYN</value>
        [System.ComponentModel.Browsable(false)]
        public bool IsSpecialYN
        {
            get
            {
                return BoolHelper.ToBool(_node.Attributes[_isspecialynKey].Value);
            }
            set
            {
                this.SetProperty(_isspecialynKey, Convert.ToInt32(value).ToString(), false);
            }
        }

        protected const string _deckweightingKey = "DeckWeighting";

        /// <summary>
        /// Gets or sets the DeckWeighting.
        /// </summary>
        /// <value>The DeckWeighting.</value>
        [System.ComponentModel.Browsable(false)]
        public int DeckWeighting
        {
            get
            {
                return Int32.Parse(_node.Attributes[_deckweightingKey].Value);
            }
            set
            {
                this.SetProperty(_deckweightingKey, value.ToString(), false);
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

        protected const string _indexdefinitiondataKey = "IndexDefinitionData";

        /// <summary>
        /// Gets or sets the IndexDefinitionData.
        /// </summary>
        /// <value>The IndexDefinitionData.</value>
        [System.ComponentModel.Browsable(false)]
        public string IndexDefinitionData
        {
            get
            {
                return _node.Attributes[_indexdefinitiondataKey].Value;
            }
            set
            {
                this.SetProperty(_indexdefinitiondataKey, value, false);
            }
        }

        protected const string _versionidKey = "VersionID";

        /// <summary>
        /// Gets or sets the VersionID.
        /// </summary>
        /// <value>The VersionID.</value>
        [System.ComponentModel.Browsable(false)]
        public int VersionID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_versionidKey].Value);
            }
            set
            {
                this.SetProperty(_versionidKey, value.ToString(), false);
            }
        }

        protected const string _versiondateKey = "VersionDate";

        /// <summary>
        /// Gets or sets the VersionDate.
        /// </summary>
        /// <value>The VersionDate.</value>
        [System.ComponentModel.Browsable(false)]
        public DateTime VersionDate
        {
            get
            {
                return DateTime.Parse(_node.Attributes[_versiondateKey].Value);
            }
            set
            {
                this.SetProperty(_versiondateKey, value.ToString(), false);
            }
        }

        protected const string _versionowneridKey = "VersionOwnerID";

        /// <summary>
        /// Gets or sets the VersionOwnerID.
        /// </summary>
        /// <value>The VersionOwnerID.</value>
        [System.ComponentModel.Browsable(false)]
        public int VersionOwnerID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_versionowneridKey].Value);
            }
            set
            {
                this.SetProperty(_versionowneridKey, value.ToString(), false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaTileTypeWrapper ToWrapper()
        {
            PlayAreaTileTypeWrapper result = new PlayAreaTileTypeWrapper();

            result.ID                           = this.ID;
            result.PlaySubsetID                 = this.PlaySubsetID;
            result.Name                         = this.Name;
            result.IsSpecialYN                  = this.IsSpecialYN;
            result.DeckWeighting                = this.DeckWeighting;
            result.ImageName                    = this.ImageName;
            result.WidthPixels                  = this.WidthPixels;
            result.HeightPixels                 = this.HeightPixels;
            result.Position                     = (CellContentPositionTypes)Enum.Parse(typeof(CellContentPositionTypes), this.Position.ToString());
            result.PositionFixToCellRotationYN  = this.PositionFixToCellRotationYN;
            result.TileAttributesString         = this.TileAttributesString;
            result.TileSideAttributesString     = this.TileSideAttributesString;
            result.IndexDefinitionData          = this.IndexDefinitionData;
            result.VersionID                    = this.VersionID;
            result.VersionDate                  = this.VersionDate;
            result.VersionOwnerID               = this.VersionOwnerID;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaTileTypeWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.PlaySubsetID                   = fromWrapper.PlaySubsetID;
            this.Name                           = fromWrapper.Name;
            this.IsSpecialYN                    = fromWrapper.IsSpecialYN;
            this.DeckWeighting                  = fromWrapper.DeckWeighting;
            this.ImageName                      = fromWrapper.ImageName;
            this.WidthPixels                    = fromWrapper.WidthPixels;
            this.HeightPixels                   = fromWrapper.HeightPixels;
            this.Position                       = (int)fromWrapper.Position;
            this.PositionFixToCellRotationYN    = fromWrapper.PositionFixToCellRotationYN;
            this.TileAttributesString           = fromWrapper.TileAttributesString;
            this.TileSideAttributesString       = fromWrapper.TileSideAttributesString;
            this.IndexDefinitionData            = fromWrapper.IndexDefinitionData;
            this.VersionID                      = fromWrapper.VersionID;
            this.VersionDate                    = fromWrapper.VersionDate;
            this.VersionOwnerID                 = fromWrapper.VersionOwnerID;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playsubsetidKey, "0");
            this.SetAttribute(_nameKey, "");
            this.SetAttribute(_isspecialynKey, "0");
            this.SetAttribute(_deckweightingKey, "0");
            this.SetAttribute(_imagenameKey, "");
            this.SetAttribute(_widthpixelsKey, "0");
            this.SetAttribute(_heightpixelsKey, "0");
            this.SetAttribute(_positionKey, "0");
            this.SetAttribute(_positionfixtocellrotationynKey, "0");
            this.SetAttribute(_tileattributesstringKey, "");
            this.SetAttribute(_tilesideattributesstringKey, "");
            this.SetAttribute(_indexdefinitiondataKey, "");
            this.SetAttribute(_versionidKey, "0");
            this.SetAttribute(_versiondateKey, "1/1/1900");
            this.SetAttribute(_versionowneridKey, "0");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaTileTypes_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaTileTypes_VersionOwnerID;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                               (int)DataProperties.PlayAreaTileTypes_ID);
            _keys.Add(_playsubsetidKey,                     (int)DataProperties.PlayAreaTileTypes_PlaySubsetID);
            _keys.Add(_nameKey,                             (int)DataProperties.PlayAreaTileTypes_Name);
            _keys.Add(_isspecialynKey,                      (int)DataProperties.PlayAreaTileTypes_IsSpecialYN);
            _keys.Add(_deckweightingKey,                    (int)DataProperties.PlayAreaTileTypes_DeckWeighting);
            _keys.Add(_imagenameKey,                        (int)DataProperties.PlayAreaTileTypes_ImageName);
            _keys.Add(_widthpixelsKey,                      (int)DataProperties.PlayAreaTileTypes_WidthPixels);
            _keys.Add(_heightpixelsKey,                     (int)DataProperties.PlayAreaTileTypes_HeightPixels);
            _keys.Add(_positionKey,                         (int)DataProperties.PlayAreaTileTypes_Position);
            _keys.Add(_positionfixtocellrotationynKey,      (int)DataProperties.PlayAreaTileTypes_PositionFixToCellRotationYN);
            _keys.Add(_tileattributesstringKey,             (int)DataProperties.PlayAreaTileTypes_TileAttributesString);
            _keys.Add(_tilesideattributesstringKey,         (int)DataProperties.PlayAreaTileTypes_TileSideAttributesString);
            _keys.Add(_indexdefinitiondataKey,              (int)DataProperties.PlayAreaTileTypes_IndexDefinitionData);
            _keys.Add(_versionidKey,                        (int)DataProperties.PlayAreaTileTypes_VersionID);
            _keys.Add(_versiondateKey,                      (int)DataProperties.PlayAreaTileTypes_VersionDate);
            _keys.Add(_versionowneridKey,                   (int)DataProperties.PlayAreaTileTypes_VersionOwnerID);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaTileType"; }
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

            this.ID                             = ((PlayAreaTileType)copy).ID;
            this.PlaySubsetID                   = ((PlayAreaTileType)copy).PlaySubsetID;
            this.Name                           = ((PlayAreaTileType)copy).Name;
            this.IsSpecialYN                    = ((PlayAreaTileType)copy).IsSpecialYN;
            this.DeckWeighting                  = ((PlayAreaTileType)copy).DeckWeighting;
            this.ImageName                      = ((PlayAreaTileType)copy).ImageName;
            this.WidthPixels                    = ((PlayAreaTileType)copy).WidthPixels;
            this.HeightPixels                   = ((PlayAreaTileType)copy).HeightPixels;
            this.Position                       = ((PlayAreaTileType)copy).Position;
            this.PositionFixToCellRotationYN    = ((PlayAreaTileType)copy).PositionFixToCellRotationYN;
            this.TileAttributesString           = ((PlayAreaTileType)copy).TileAttributesString;
            this.TileSideAttributesString       = ((PlayAreaTileType)copy).TileSideAttributesString;
            this.IndexDefinitionData            = ((PlayAreaTileType)copy).IndexDefinitionData;
            this.VersionID                      = ((PlayAreaTileType)copy).VersionID;
            this.VersionDate                    = ((PlayAreaTileType)copy).VersionDate;
            this.VersionOwnerID                 = ((PlayAreaTileType)copy).VersionOwnerID;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.Name.ToString(), this.Name.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.PlaySubsetID.ToString(), this.PlaySubsetID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.IsSpecialYN.ToString(), Convert.ToInt32(this.IsSpecialYN).ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.DeckWeighting.ToString(), this.DeckWeighting.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.ImageName.ToString(), this.ImageName);
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.WidthPixels.ToString(), this.WidthPixels.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.HeightPixels.ToString(), this.HeightPixels.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.Position.ToString(), this.Position.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.PositionFixToCellRotationYN.ToString(), Convert.ToInt32(this.PositionFixToCellRotationYN).ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.TileAttributesString.ToString(), this.TileAttributesString);
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.TileSideAttributesString.ToString(), this.TileSideAttributesString);
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.IndexDefinitionData.ToString(), this.IndexDefinitionData);
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.VersionID.ToString(), this.VersionID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.VersionDate.ToString(), this.VersionDate.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayAreaTileTypeDataParameterKeys.VersionOwnerID.ToString(), this.VersionOwnerID.ToString());

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
            this.PlaySubsetID                   = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.PlaySubsetID.ToString()));
            this.Name                           = dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.Name.ToString());
            this.IsSpecialYN                    = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.IsSpecialYN.ToString()));
            this.DeckWeighting                  = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.DeckWeighting.ToString()));
            this.ImageName                      = dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.ImageName.ToString());
            this.WidthPixels                    = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.WidthPixels.ToString()));
            this.HeightPixels                   = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.HeightPixels.ToString()));
            this.Position                       = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.Position.ToString()));
            this.PositionFixToCellRotationYN    = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.PositionFixToCellRotationYN.ToString()));
            this.TileAttributesString           = dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.TileAttributesString.ToString());
            this.TileSideAttributesString       = dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.TileSideAttributesString.ToString());
            this.IndexDefinitionData            = dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.IndexDefinitionData.ToString());
            this.VersionID                      = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.VersionID.ToString()));
            this.VersionDate                    = DateTime.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.VersionDate.ToString()));
            this.VersionOwnerID                 = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileTypeDataParameterKeys.VersionOwnerID.ToString()));

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
                case (int)DataProperties.PlayAreaTileTypes_VersionDate:
                    s = this.VersionDate.ToString("g", toCultureInfo); // MM/dd/yyyy HH:mm
                    break;
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
                case (int)DataProperties.PlayAreaTileTypes_VersionDate:
                    // Parse the value using fromCultureInfo
                    s = this.DoParseToStorageDateString(value, fromCultureInfo);               
                    break;
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
