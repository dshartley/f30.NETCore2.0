using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks
{
    public enum PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys
    {
        ID,
        PlayChallengeTypeID,
        PlayChallengeObjectiveTypeID,
        Index,
        VersionID,
        VersionDate,
        VersionOwnerID
    }

    /// <summary>
    /// Encapsulates an PlayChallengeTypePlayChallengeObjectiveTypeLink data item.
    /// </summary>
    public class PlayChallengeTypePlayChallengeObjectiveTypeLink : DataItemBase
    {
        #region Constructors

        private PlayChallengeTypePlayChallengeObjectiveTypeLink() : base() { }

        public PlayChallengeTypePlayChallengeObjectiveTypeLink(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayChallengeTypePlayChallengeObjectiveTypeLink(  XmlNode             dataNode,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataNode, collection, defaultCultureInfoName)
        { }

        #endregion

        #region Public Methods

        protected const string _playchallengetypeidKey = "PlayChallengeTypeID";

        /// <summary>
        /// Gets or sets the PlayChallengeTypeID.
        /// </summary>
        /// <value>The PlayChallengeTypeID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayChallengeTypeID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playchallengetypeidKey].Value);
            }
            set
            {
                this.SetProperty(_playchallengetypeidKey, value.ToString(), false);
            }
        }

        protected const string _playchallengeobjectivetypeidKey = "PlayChallengeObjectiveTypeID";

        /// <summary>
        /// Gets or sets the PlayChallengeObjectiveTypeID.
        /// </summary>
        /// <value>The PlayChallengeObjectiveTypeID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayChallengeObjectiveTypeID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playchallengeobjectivetypeidKey].Value);
            }
            set
            {
                this.SetProperty(_playchallengeobjectivetypeidKey, value.ToString(), false);
            }
        }

        protected const string _indexKey = "Index";

        /// <summary>
        /// Gets or sets the Index.
        /// </summary>
        /// <value>The Index.</value>
        [System.ComponentModel.Browsable(false)]
        public int Index
        {
            get
            {
                return Int32.Parse(_node.Attributes[_indexKey].Value);
            }
            set
            {
                this.SetProperty(_indexKey, value.ToString(), false);
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
        public PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper ToWrapper()
        {
            PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper result = new PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper();

            result.ID                               = this.ID;
            result.PlayChallengeTypeID              = this.PlayChallengeTypeID;
            result.PlayChallengeObjectiveTypeID     = this.PlayChallengeObjectiveTypeID;
            result.Index                            = this.Index;
            result.VersionID                        = this.VersionID;
            result.VersionDate                      = this.VersionDate;
            result.VersionOwnerID                   = this.VersionOwnerID;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.PlayChallengeTypeID            = fromWrapper.PlayChallengeTypeID;
            this.PlayChallengeObjectiveTypeID   = fromWrapper.PlayChallengeObjectiveTypeID;
            this.Index                          = fromWrapper.Index;
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
            this.SetAttribute(_playchallengetypeidKey, "0");
            this.SetAttribute(_playchallengeobjectivetypeidKey, "0");
            this.SetAttribute(_indexKey, "0");
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

            _startEnumIndex = (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_ID;
            _endEnumIndex   = (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionOwnerID;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                           (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_ID);
            _keys.Add(_playchallengetypeidKey,          (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_PlayChallengeTypeID);
            _keys.Add(_playchallengeobjectivetypeidKey, (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_PlayChallengeObjectiveTypeID);
            _keys.Add(_indexKey,                        (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_Index);
            _keys.Add(_versionidKey,                    (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionID);
            _keys.Add(_versiondateKey,                  (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionDate);
            _keys.Add(_versionowneridKey,               (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionOwnerID);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayChallengeTypePlayChallengeObjectiveTypeLink"; }
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

            this.ID                             = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).ID;
            this.PlayChallengeTypeID            = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).PlayChallengeTypeID;
            this.PlayChallengeObjectiveTypeID   = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).PlayChallengeObjectiveTypeID;
            this.Index                          = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).Index;
            this.VersionID                      = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).VersionID;
            this.VersionDate                    = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).VersionDate;
            this.VersionOwnerID                 = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)copy).VersionOwnerID;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.PlayChallengeTypeID.ToString(), this.PlayChallengeTypeID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.PlayChallengeObjectiveTypeID.ToString(), this.PlayChallengeObjectiveTypeID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.Index.ToString(), this.Index.ToString());
            dataWrapper.SetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.VersionID.ToString(), this.VersionID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.VersionDate.ToString(), this.VersionDate.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.VersionOwnerID.ToString(), this.VersionOwnerID.ToString());

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
            this.PlayChallengeTypeID            = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.PlayChallengeTypeID.ToString()));
            this.PlayChallengeObjectiveTypeID   = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.PlayChallengeObjectiveTypeID.ToString()));
            this.Index                          = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.Index.ToString()));
            this.VersionID                      = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.VersionID.ToString()));
            this.VersionDate                    = DateTime.Parse(dataWrapper.GetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.VersionDate.ToString()));
            this.VersionOwnerID                 = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeTypePlayChallengeObjectiveTypeLinkDataParameterKeys.VersionOwnerID.ToString()));

            this.DoValidations = doValidations;
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
                case (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionDate:
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
                case (int)DataProperties.PlayChallengeTypePlayChallengeObjectiveTypeLinks_VersionDate:
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
