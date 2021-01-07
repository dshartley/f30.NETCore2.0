using Smart.Platform.Core;
using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;
using f30.Core;

namespace f30.Data.PlayAreaCellTypes
{
    public enum PlayAreaCellTypeDataParameterKeys
    {
        ID,
        PlaySubsetID,
        Name,
        IsSpecialYN,
        DeckWeighting,
        ImageName,
        BlockedContentPositionsString,
        CellAttributesString,
        CellSideAttributesString,
        IndexDefinitionData,
        VersionID,
        VersionDate,
        VersionOwnerID
    }

    /// <summary>
    /// Encapsulates an PlayAreaCellType data item.
    /// </summary>
    public class PlayAreaCellType : DataItemBase
    {
        #region Constructors

        private PlayAreaCellType() : base() { }

        public PlayAreaCellType(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaCellType(  XmlNode             dataNode,
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

        protected const string _blockedcontentpositionsstringKey = "BlockedContentPositionsString";

        /// <summary>
        /// Gets or sets the BlockedContentPositionsString.
        /// </summary>
        /// <value>The BlockedContentPositionsString.</value>
        [System.ComponentModel.Browsable(false)]
        public string BlockedContentPositionsString
        {
            get
            {
                return _node.Attributes[_blockedcontentpositionsstringKey].Value;
            }
            set
            {
                this.SetProperty(_blockedcontentpositionsstringKey, value, false);
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
        public PlayAreaCellTypeWrapper ToWrapper()
        {
            PlayAreaCellTypeWrapper result = new PlayAreaCellTypeWrapper();

            result.ID                               = this.ID;
            result.PlaySubsetID                     = this.PlaySubsetID;
            result.Name                             = this.Name;
            result.IsSpecialYN                      = this.IsSpecialYN;
            result.DeckWeighting                    = this.DeckWeighting;
            result.ImageName                        = this.ImageName;
            result.BlockedContentPositionsString    = this.BlockedContentPositionsString;
            result.CellAttributesString             = this.CellAttributesString;
            result.CellSideAttributesString         = this.CellSideAttributesString;
            result.IndexDefinitionData              = this.IndexDefinitionData;
            result.VersionID                        = this.VersionID;
            result.VersionDate                      = this.VersionDate;
            result.VersionOwnerID                   = this.VersionOwnerID;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaCellTypeWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.PlaySubsetID                   = fromWrapper.PlaySubsetID;
            this.Name                           = fromWrapper.Name;
            this.IsSpecialYN                    = fromWrapper.IsSpecialYN;
            this.DeckWeighting                  = fromWrapper.DeckWeighting;
            this.ImageName                      = fromWrapper.ImageName;
            this.BlockedContentPositionsString  = fromWrapper.BlockedContentPositionsString;
            this.CellAttributesString           = fromWrapper.CellAttributesString;
            this.CellSideAttributesString       = fromWrapper.CellSideAttributesString;
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
            this.SetAttribute(_blockedcontentpositionsstringKey, "");
            this.SetAttribute(_cellattributesstringKey, "");
            this.SetAttribute(_cellsideattributesstringKey, "");
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

            _startEnumIndex = (int)DataProperties.PlayAreaCellTypes_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaCellTypes_VersionOwnerID;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                               (int)DataProperties.PlayAreaCellTypes_ID);
            _keys.Add(_playsubsetidKey,                     (int)DataProperties.PlayAreaCellTypes_PlaySubsetID);
            _keys.Add(_nameKey,                             (int)DataProperties.PlayAreaCellTypes_Name);
            _keys.Add(_isspecialynKey,                      (int)DataProperties.PlayAreaCellTypes_IsSpecialYN);
            _keys.Add(_deckweightingKey,                    (int)DataProperties.PlayAreaCellTypes_DeckWeighting);
            _keys.Add(_imagenameKey,                        (int)DataProperties.PlayAreaCellTypes_ImageName);
            _keys.Add(_blockedcontentpositionsstringKey,    (int)DataProperties.PlayAreaCellTypes_BlockedContentPositionsString);
            _keys.Add(_cellattributesstringKey,             (int)DataProperties.PlayAreaCellTypes_CellAttributesString);
            _keys.Add(_cellsideattributesstringKey,         (int)DataProperties.PlayAreaCellTypes_CellSideAttributesString);
            _keys.Add(_indexdefinitiondataKey,              (int)DataProperties.PlayAreaCellTypes_IndexDefinitionData);
            _keys.Add(_versionidKey,                        (int)DataProperties.PlayAreaCellTypes_VersionID);
            _keys.Add(_versiondateKey,                      (int)DataProperties.PlayAreaCellTypes_VersionDate);
            _keys.Add(_versionowneridKey,                   (int)DataProperties.PlayAreaCellTypes_VersionOwnerID);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaCellType"; }
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

            this.ID                             = ((PlayAreaCellType)copy).ID;
            this.PlaySubsetID                   = ((PlayAreaCellType)copy).PlaySubsetID;
            this.Name                           = ((PlayAreaCellType)copy).Name;
            this.IsSpecialYN                    = ((PlayAreaCellType)copy).IsSpecialYN;
            this.DeckWeighting                  = ((PlayAreaCellType)copy).DeckWeighting;
            this.ImageName                      = ((PlayAreaCellType)copy).ImageName;
            this.BlockedContentPositionsString  = ((PlayAreaCellType)copy).BlockedContentPositionsString;
            this.CellAttributesString           = ((PlayAreaCellType)copy).CellAttributesString;
            this.CellSideAttributesString       = ((PlayAreaCellType)copy).CellSideAttributesString;
            this.IndexDefinitionData            = ((PlayAreaCellType)copy).IndexDefinitionData;
            this.VersionID                      = ((PlayAreaCellType)copy).VersionID;
            this.VersionDate                    = ((PlayAreaCellType)copy).VersionDate;
            this.VersionOwnerID                 = ((PlayAreaCellType)copy).VersionOwnerID;

            this.DoValidations                  = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.PlaySubsetID.ToString(), this.PlaySubsetID.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.Name.ToString(), this.Name.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.IsSpecialYN.ToString(), Convert.ToInt32(this.IsSpecialYN).ToString());
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.DeckWeighting.ToString(), this.DeckWeighting.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.ImageName.ToString(), this.ImageName);
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.BlockedContentPositionsString.ToString(), this.BlockedContentPositionsString);
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.CellAttributesString.ToString(), this.CellAttributesString);
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.CellSideAttributesString.ToString(), this.CellSideAttributesString);
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.IndexDefinitionData.ToString(), this.IndexDefinitionData);
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.VersionID.ToString(), this.VersionID.ToString());
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.VersionDate.ToString(), this.VersionDate.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayAreaCellTypeDataParameterKeys.VersionOwnerID.ToString(), this.VersionOwnerID.ToString());

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
            this.PlaySubsetID                   = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.PlaySubsetID.ToString()));
            this.Name                           = dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.Name.ToString());
            this.IsSpecialYN                    = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.IsSpecialYN.ToString()));
            this.DeckWeighting                  = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.DeckWeighting.ToString()));
            this.ImageName                      = dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.ImageName.ToString());
            this.BlockedContentPositionsString  = dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.BlockedContentPositionsString.ToString());
            this.CellAttributesString           = dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.CellAttributesString.ToString());
            this.CellSideAttributesString       = dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.CellSideAttributesString.ToString());
            this.IndexDefinitionData            = dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.IndexDefinitionData.ToString());
            this.VersionID                      = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.VersionID.ToString()));
            this.VersionDate                    = DateTime.Parse(dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.VersionDate.ToString()));
            this.VersionOwnerID                 = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaCellTypeDataParameterKeys.VersionOwnerID.ToString()));

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
                case (int)DataProperties.PlayAreaCellTypes_VersionDate:
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
                case (int)DataProperties.PlayAreaCellTypes_VersionDate:
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
