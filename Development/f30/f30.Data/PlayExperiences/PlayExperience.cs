using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;
using f30.Core;

namespace f30.Data.PlayExperiences
{
    public enum PlayExperienceDataParameterKeys
    {
        ID,
        PlaySubsetID,
        PlayExperienceType,
        Name,
        ContentData,
        OnCompleteData,
        PlayChallengeObjectiveDefinitionData,
        IndexDefinitionData,
        VersionID,
        VersionDate,
        VersionOwnerID
    }

    /// <summary>
    /// Encapsulates an PlayExperience data item.
    /// </summary>
    public class PlayExperience : DataItemBase
    {
        #region Constructors

        private PlayExperience() : base() { }

        public PlayExperience(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayExperience(  XmlNode             dataNode,
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

        protected const string _playexperiencetypeKey = "PlayExperienceType";

        /// <summary>
        /// Gets or sets the PlayExperienceType.
        /// </summary>
        /// <value>The PlayExperienceType.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayExperienceType
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playexperiencetypeKey].Value);
            }
            set
            {
                this.SetProperty(_playexperiencetypeKey, value.ToString(), false);
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

        protected const string _contentdataKey = "ContentData";

        /// <summary>
        /// Gets or sets the ContentData.
        /// </summary>
        /// <value>The ContentData.</value>
        [System.ComponentModel.Browsable(false)]
        public string ContentData
        {
            get
            {
                return _node.Attributes[_contentdataKey].Value;
            }
            set
            {
                this.SetProperty(_contentdataKey, value, false);
            }
        }

        protected const string _oncompletedataKey = "OnCompleteData";

        /// <summary>
        /// Gets or sets the OnCompleteData.
        /// </summary>
        /// <value>The OnCompleteData.</value>
        [System.ComponentModel.Browsable(false)]
        public string OnCompleteData
        {
            get
            {
                return _node.Attributes[_oncompletedataKey].Value;
            }
            set
            {
                this.SetProperty(_oncompletedataKey, value, false);
            }
        }

        protected const string _playchallengeobjectivedefinitiondataKey = "PlayChallengeObjectiveDefinitionData";

        /// <summary>
        /// Gets or sets the PlayChallengeObjectiveDefinitionData.
        /// </summary>
        /// <value>The PlayChallengeObjectiveDefinitionData.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayChallengeObjectiveDefinitionData
        {
            get
            {
                return _node.Attributes[_playchallengeobjectivedefinitiondataKey].Value;
            }
            set
            {
                this.SetProperty(_playchallengeobjectivedefinitiondataKey, value, false);
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
        public PlayExperienceWrapper ToWrapper()
        {
            PlayExperienceWrapper result = new PlayExperienceWrapper();

            result.ID                                       = this.ID;
            result.PlaySubsetID                             = this.PlaySubsetID;
            result.PlayExperienceType                       = (PlayExperienceTypes)Enum.Parse(typeof(PlayExperienceTypes), this.PlayExperienceType.ToString());
            result.Name                                     = this.Name;
            result.ContentData                              = this.ContentData;
            result.OnCompleteData                           = this.OnCompleteData;
            result.PlayChallengeObjectiveDefinitionData     = this.PlayChallengeObjectiveDefinitionData;
            result.IndexDefinitionData                      = this.IndexDefinitionData;
            result.VersionID                                = this.VersionID;
            result.VersionDate                              = this.VersionDate;
            result.VersionOwnerID                           = this.VersionOwnerID;

            return result;
        }
         
        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayExperienceWrapper fromWrapper)
        {
            this.ID                                     = fromWrapper.ID;
            this.PlaySubsetID                           = fromWrapper.PlaySubsetID;
            this.PlayExperienceType                     = (int)fromWrapper.PlayExperienceType;
            this.Name                                   = fromWrapper.Name;
            this.ContentData                            = fromWrapper.ContentData;
            this.OnCompleteData                         = fromWrapper.OnCompleteData;
            this.PlayChallengeObjectiveDefinitionData   = fromWrapper.PlayChallengeObjectiveDefinitionData;
            this.IndexDefinitionData                    = fromWrapper.IndexDefinitionData;
            this.VersionID                              = fromWrapper.VersionID;
            this.VersionDate                            = fromWrapper.VersionDate;
            this.VersionOwnerID                         = fromWrapper.VersionOwnerID;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playsubsetidKey, "0");
            this.SetAttribute(_playexperiencetypeKey, "0");
            this.SetAttribute(_nameKey, "");
            this.SetAttribute(_contentdataKey, "");
            this.SetAttribute(_oncompletedataKey, "");
            this.SetAttribute(_playchallengeobjectivedefinitiondataKey, "");
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

            _startEnumIndex = (int)DataProperties.PlayExperiences_ID;
            _endEnumIndex   = (int)DataProperties.PlayExperiences_VersionOwnerID;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                                       (int)DataProperties.PlayExperiences_ID);
            _keys.Add(_playsubsetidKey,                             (int)DataProperties.PlayExperiences_PlaySubsetID);
            _keys.Add(_playexperiencetypeKey,                       (int)DataProperties.PlayExperiences_PlayExperienceType);
            _keys.Add(_nameKey,                                     (int)DataProperties.PlayExperiences_Name);
            _keys.Add(_contentdataKey,                              (int)DataProperties.PlayExperiences_ContentData);
            _keys.Add(_oncompletedataKey,                           (int)DataProperties.PlayExperiences_OnCompleteData);
            _keys.Add(_playchallengeobjectivedefinitiondataKey,     (int)DataProperties.PlayExperiences_PlayChallengeObjectiveDefinitionData);
            _keys.Add(_indexdefinitiondataKey,                      (int)DataProperties.PlayExperiences_IndexDefinitionData);
            _keys.Add(_versionidKey,                                (int)DataProperties.PlayExperiences_VersionID);
            _keys.Add(_versiondateKey,                              (int)DataProperties.PlayExperiences_VersionDate);
            _keys.Add(_versionowneridKey,                           (int)DataProperties.PlayExperiences_VersionOwnerID);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayExperience"; }
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

            this.ID                                     = ((PlayExperience)copy).ID;
            this.PlaySubsetID                           = ((PlayExperience)copy).PlaySubsetID;
            this.PlayExperienceType                     = ((PlayExperience)copy).PlayExperienceType;
            this.Name                                   = ((PlayExperience)copy).Name;
            this.ContentData                            = ((PlayExperience)copy).ContentData;
            this.OnCompleteData                         = ((PlayExperience)copy).OnCompleteData;
            this.PlayChallengeObjectiveDefinitionData   = ((PlayExperience)copy).PlayChallengeObjectiveDefinitionData;
            this.IndexDefinitionData                    = ((PlayExperience)copy).IndexDefinitionData;
            this.VersionID                              = ((PlayExperience)copy).VersionID;
            this.VersionDate                            = ((PlayExperience)copy).VersionDate;
            this.VersionOwnerID                         = ((PlayExperience)copy).VersionOwnerID;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.PlaySubsetID.ToString(), this.PlaySubsetID.ToString());
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.PlayExperienceType.ToString(), this.PlayExperienceType.ToString());
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.Name.ToString(), this.Name);
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.ContentData.ToString(), this.ContentData);
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.OnCompleteData.ToString(), this.OnCompleteData);
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.PlayChallengeObjectiveDefinitionData.ToString(), this.PlayChallengeObjectiveDefinitionData);
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.IndexDefinitionData.ToString(), this.IndexDefinitionData);
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.VersionID.ToString(), this.VersionID.ToString());
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.VersionDate.ToString(), this.VersionDate.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayExperienceDataParameterKeys.VersionOwnerID.ToString(), this.VersionOwnerID.ToString());

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

            this.ID                                     = Int32.Parse(dataWrapper.ID);
            this.PlaySubsetID                           = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.PlaySubsetID.ToString()));
            this.PlayExperienceType                     = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.PlayExperienceType.ToString()));
            this.Name                                   = dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.Name.ToString());
            this.ContentData                            = dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.ContentData.ToString());
            this.OnCompleteData                         = dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.OnCompleteData.ToString());
            this.PlayChallengeObjectiveDefinitionData   = dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.PlayChallengeObjectiveDefinitionData.ToString());
            this.IndexDefinitionData                    = dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.IndexDefinitionData.ToString());
            this.VersionID                              = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.VersionID.ToString()));
            this.VersionDate                            = DateTime.Parse(dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.VersionDate.ToString()));
            this.VersionOwnerID                         = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceDataParameterKeys.VersionOwnerID.ToString()));

            this.DoValidations                          = doValidations;
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
                case (int)DataProperties.PlayExperiences_VersionDate:
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
                case (int)DataProperties.PlayExperiences_VersionDate:
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
