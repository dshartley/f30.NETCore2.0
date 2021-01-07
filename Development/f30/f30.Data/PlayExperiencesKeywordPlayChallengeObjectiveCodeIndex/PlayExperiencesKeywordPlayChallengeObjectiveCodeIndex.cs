using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex
{
    public enum PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys
    {
        ID,
        PlaySubsetID,
        PlayExperienceID,
        PlayExperienceKeyword,
        PlayChallengeObjectiveCode
    }

    /// <summary>
    /// Encapsulates an PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex data item.
    /// </summary>
    public class PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex : DataItemBase
    {
        #region Constructors

        private PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex() : base() { }

        public PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex(  XmlNode             dataNode,
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

        protected const string _playexperienceidKey = "PlayExperienceID";

        /// <summary>
        /// Gets or sets the PlayExperienceID.
        /// </summary>
        /// <value>The PlayExperienceID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayExperienceID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playexperienceidKey].Value);
            }
            set
            {
                this.SetProperty(_playexperienceidKey, value.ToString(), false);
            }
        }

        protected const string _playexperiencekeywordKey = "PlayExperienceKeyword";

        /// <summary>
        /// Gets or sets the PlayExperienceKeyword.
        /// </summary>
        /// <value>The Name.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayExperienceKeyword
        {
            get
            {
                return _node.Attributes[_playexperiencekeywordKey].Value;
            }
            set
            {
                this.SetProperty(_playexperiencekeywordKey, value, false);
            }
        }

        protected const string _playchallengeobjectivecodeKey = "PlayChallengeObjectiveCode";

        /// <summary>
        /// Gets or sets the PlayChallengeObjectiveCode.
        /// </summary>
        /// <value>The Name.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayChallengeObjectiveCode
        {
            get
            {
                return _node.Attributes[_playchallengeobjectivecodeKey].Value;
            }
            set
            {
                this.SetProperty(_playchallengeobjectivecodeKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper ToWrapper()
        {
            PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper result = new PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper();

            result.ID                           = this.ID;
            result.PlaySubsetID                 = this.PlaySubsetID;
            result.PlayExperienceID             = this.PlayExperienceID;
            result.PlayExperienceKeyword        = this.PlayExperienceKeyword;
            result.PlayChallengeObjectiveCode   = this.PlayChallengeObjectiveCode;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.PlaySubsetID                   = fromWrapper.PlaySubsetID;
            this.PlayExperienceID               = fromWrapper.PlayExperienceID;
            this.PlayExperienceKeyword          = fromWrapper.PlayExperienceKeyword;
            this.PlayChallengeObjectiveCode     = fromWrapper.PlayChallengeObjectiveCode;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playsubsetidKey, "0");
            this.SetAttribute(_playexperienceidKey, "0");
            this.SetAttribute(_playexperiencekeywordKey, "");
            this.SetAttribute(_playchallengeobjectivecodeKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_ID;
            _endEnumIndex   = (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayChallengeObjectiveCode;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                           (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_ID);
            _keys.Add(_playsubsetidKey,                 (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlaySubsetID);
            _keys.Add(_playexperienceidKey,             (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayExperienceID);
            _keys.Add(_playexperiencekeywordKey,        (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayExperienceKeyword);
            _keys.Add(_playchallengeobjectivecodeKey,   (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_PlayChallengeObjectiveCode);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex"; }
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

            this.ID                             = ((PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex)copy).ID;
            this.PlaySubsetID                   = ((PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex)copy).PlaySubsetID;
            this.PlayExperienceID               = ((PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex)copy).PlayExperienceID;
            this.PlayExperienceKeyword          = ((PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex)copy).PlayExperienceKeyword;
            this.PlayChallengeObjectiveCode     = ((PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex)copy).PlayChallengeObjectiveCode;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlaySubsetID.ToString(), this.PlaySubsetID.ToString());
            dataWrapper.SetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlayExperienceID.ToString(), this.PlayExperienceID.ToString());
            dataWrapper.SetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlayExperienceKeyword.ToString(), this.PlayExperienceKeyword);
            dataWrapper.SetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlayChallengeObjectiveCode.ToString(), this.PlayChallengeObjectiveCode);

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
            this.PlaySubsetID                   = Int32.Parse(dataWrapper.GetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlaySubsetID.ToString()));
            this.PlayExperienceID               = Int32.Parse(dataWrapper.GetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlayExperienceID.ToString()));
            this.PlayExperienceKeyword          = dataWrapper.GetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlayExperienceKeyword.ToString());
            this.PlayChallengeObjectiveCode     = dataWrapper.GetParameterValue(PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataParameterKeys.PlayChallengeObjectiveCode.ToString());

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
                //case (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_VersionDate:
                //    s = this.VersionDate.ToString("g", toCultureInfo); // MM/dd/yyyy HH:mm
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
                //case (int)DataProperties.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex_VersionDate:
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
