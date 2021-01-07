using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;
using f30.Core;

namespace f30.Data.PlayExperienceStepExercises
{
    public enum PlayExperienceStepExerciseDataParameterKeys
    {
        ID,
        PlaySubsetID,
        Name,
        PlayExperienceStepExerciseType,
        ContentData,
        OnCompleteData,
        VersionID,
        VersionDate,
        VersionOwnerID
    }

    /// <summary>
    /// Encapsulates an PlayExperienceStepExercise data item.
    /// </summary>
    public class PlayExperienceStepExercise : DataItemBase
    {
        #region Constructors

        private PlayExperienceStepExercise() : base() { }

        public PlayExperienceStepExercise(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayExperienceStepExercise(  XmlNode             dataNode,
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

        protected const string _playexperiencestepexercisetypeKey = "PlayExperienceStepExerciseType";

        /// <summary>
        /// Gets or sets the PlayExperienceStepExerciseType.
        /// </summary>
        /// <value>The PlayExperienceStepExerciseType.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayExperienceStepExerciseType
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playexperiencestepexercisetypeKey].Value);
            }
            set
            {
                this.SetProperty(_playexperiencestepexercisetypeKey, value.ToString(), false);
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
        public PlayExperienceStepExerciseWrapper ToWrapper()
        {
            PlayExperienceStepExerciseWrapper result = new PlayExperienceStepExerciseWrapper();

            result.ID                               = this.ID;
            result.PlaySubsetID                     = this.PlaySubsetID;
            result.Name                             = this.Name;
            result.PlayExperienceStepExerciseType   = (PlayExperienceStepExerciseTypes)Enum.Parse(typeof(PlayExperienceStepExerciseTypes), this.PlayExperienceStepExerciseType.ToString());
            result.ContentData                      = this.ContentData;
            result.OnCompleteData                   = this.OnCompleteData;
            result.VersionID                        = this.VersionID;
            result.VersionDate                      = this.VersionDate;
            result.VersionOwnerID                   = this.VersionOwnerID;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayExperienceStepExerciseWrapper fromWrapper)
        {
            this.ID                                 = fromWrapper.ID;
            this.PlaySubsetID                       = fromWrapper.PlaySubsetID;
            this.Name                               = fromWrapper.Name;
            this.PlayExperienceStepExerciseType     = (int)fromWrapper.PlayExperienceStepExerciseType;
            this.ContentData                        = fromWrapper.ContentData;
            this.OnCompleteData                     = fromWrapper.OnCompleteData;
            this.VersionID                          = fromWrapper.VersionID;
            this.VersionDate                        = fromWrapper.VersionDate;
            this.VersionOwnerID                     = fromWrapper.VersionOwnerID;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playsubsetidKey, "0");
            this.SetAttribute(_nameKey, "");
            this.SetAttribute(_playexperiencestepexercisetypeKey, "0");
            this.SetAttribute(_contentdataKey, "");
            this.SetAttribute(_oncompletedataKey, "");
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

            _startEnumIndex = (int)DataProperties.PlayExperienceStepExercises_ID;
            _endEnumIndex   = (int)DataProperties.PlayExperienceStepExercises_VersionOwnerID;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                               (int)DataProperties.PlayExperienceStepExercises_ID);
            _keys.Add(_playsubsetidKey,                     (int)DataProperties.PlayExperienceStepExercises_PlaySubsetID);
            _keys.Add(_nameKey,                             (int)DataProperties.PlayExperienceStepExercises_Name);
            _keys.Add(_playexperiencestepexercisetypeKey,   (int)DataProperties.PlayExperienceStepExercises_PlayExperienceStepExerciseType);
            _keys.Add(_contentdataKey,                      (int)DataProperties.PlayExperienceStepExercises_ContentData);
            _keys.Add(_oncompletedataKey,                   (int)DataProperties.PlayExperienceStepExercises_OnCompleteData);
            _keys.Add(_versionidKey,                        (int)DataProperties.PlayExperienceStepExercises_VersionID);
            _keys.Add(_versiondateKey,                      (int)DataProperties.PlayExperienceStepExercises_VersionDate);
            _keys.Add(_versionowneridKey,                   (int)DataProperties.PlayExperienceStepExercises_VersionOwnerID);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayExperienceStepExercise"; }
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

            this.ID                                 = ((PlayExperienceStepExercise)copy).ID;
            this.PlaySubsetID                       = ((PlayExperienceStepExercise)copy).PlaySubsetID;
            this.Name                               = ((PlayExperienceStepExercise)copy).Name;
            this.PlayExperienceStepExerciseType     = ((PlayExperienceStepExercise)copy).PlayExperienceStepExerciseType;
            this.ContentData                        = ((PlayExperienceStepExercise)copy).ContentData;
            this.OnCompleteData                     = ((PlayExperienceStepExercise)copy).OnCompleteData;
            this.VersionID                          = ((PlayExperienceStepExercise)copy).VersionID;
            this.VersionDate                        = ((PlayExperienceStepExercise)copy).VersionDate;
            this.VersionOwnerID                     = ((PlayExperienceStepExercise)copy).VersionOwnerID;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.PlaySubsetID.ToString(), this.PlaySubsetID.ToString());
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.Name.ToString(), this.Name.ToString());
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.PlayExperienceStepExerciseType.ToString(), this.PlayExperienceStepExerciseType.ToString());
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.ContentData.ToString(), this.ContentData);
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.OnCompleteData.ToString(), this.OnCompleteData);
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.VersionID.ToString(), this.VersionID.ToString());
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.VersionDate.ToString(), this.VersionDate.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayExperienceStepExerciseDataParameterKeys.VersionOwnerID.ToString(), this.VersionOwnerID.ToString());

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

            this.ID                                 = Int32.Parse(dataWrapper.ID);
            this.PlaySubsetID                       = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.PlaySubsetID.ToString()));
            this.Name                               = dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.Name.ToString());
            this.PlayExperienceStepExerciseType     = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.PlayExperienceStepExerciseType.ToString()));
            this.ContentData                        = dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.ContentData.ToString());
            this.OnCompleteData                     = dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.OnCompleteData.ToString());
            this.VersionID                          = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.VersionID.ToString()));
            this.VersionDate                        = DateTime.Parse(dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.VersionDate.ToString()));
            this.VersionOwnerID                     = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceStepExerciseDataParameterKeys.VersionOwnerID.ToString()));

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
                case (int)DataProperties.PlayExperienceStepExercises_VersionDate:
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
                case (int)DataProperties.PlayExperienceStepExercises_VersionDate:
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
