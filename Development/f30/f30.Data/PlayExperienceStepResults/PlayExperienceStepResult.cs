using f30.Core;
using Smart.Platform.Core;
using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayExperienceStepResults
{
    public enum PlayExperienceStepResultDataParameterKeys
    {
        ID,
        PlayExperienceID,
        PlayExperienceStepID,
        DateCompleted,
        RepeatedYN
    }

    /// <summary>
    /// Encapsulates an PlayExperienceStepResult data item.
    /// </summary>
    public class PlayExperienceStepResult : DataItemBase
    {
        #region Constructors

        private PlayExperienceStepResult() : base() { }

        public PlayExperienceStepResult(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayExperienceStepResult(  XmlNode             dataNode,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataNode, collection, defaultCultureInfoName)
        { }

        #endregion

        #region Public Methods

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

        protected const string _playexperiencestepidKey = "PlayExperienceStepID";

        /// <summary>
        /// Gets or sets the PlayExperienceStepID.
        /// </summary>
        /// <value>The PlayExperienceStepID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayExperienceStepID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playexperiencestepidKey].Value);
            }
            set
            {
                this.SetProperty(_playexperiencestepidKey, value.ToString(), false);
            }
        }

        protected const string _datecompletedKey = "DateCompleted";

        /// <summary>
        /// Gets or sets the DateCompleted.
        /// </summary>
        /// <value>The DateCompleted.</value>
        [System.ComponentModel.Browsable(false)]
        public DateTime DateCompleted
        {
            get
            {
                return DateTime.Parse(_node.Attributes[_datecompletedKey].Value);
            }
            set
            {
                this.SetProperty(_datecompletedKey, value.ToString(), false);
            }
        }

        protected const string _repeatedynKey = "RepeatedYN";

        /// <summary>
        /// Gets or sets the RepeatedYN.
        /// </summary>
        /// <value>The RepeatedYN</value>
        [System.ComponentModel.Browsable(false)]
        public bool RepeatedYN
        {
            get
            {
                return BoolHelper.ToBool(_node.Attributes[_repeatedynKey].Value);
            }
            set
            {
                this.SetProperty(_repeatedynKey, Convert.ToInt32(value).ToString(), false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayExperienceStepResultWrapper ToWrapper()
        {
            PlayExperienceStepResultWrapper     result = new PlayExperienceStepResultWrapper();

            result.ID                           = this.ID;
            result.PlayExperienceID             = this.PlayExperienceID;
            result.PlayExperienceStepID         = this.PlayExperienceStepID;
            result.DateCompleted                = this.DateCompleted;
            result.RepeatedYN                   = this.RepeatedYN;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayExperienceStepResultWrapper fromWrapper)
        {
            this.ID                     = fromWrapper.ID;
            this.PlayExperienceID       = fromWrapper.PlayExperienceID;
            this.PlayExperienceStepID   = fromWrapper.PlayExperienceStepID;
            this.DateCompleted          = fromWrapper.DateCompleted;
            this.RepeatedYN             = fromWrapper.RepeatedYN;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playexperienceidKey, "0");
            this.SetAttribute(_playexperiencestepidKey, "0");
            this.SetAttribute(_datecompletedKey, "1/1/1900");
            this.SetAttribute(_repeatedynKey, "0");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayExperienceStepResults_ID;
            _endEnumIndex   = (int)DataProperties.PlayExperienceStepResults_RepeatedYN;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                       (int)DataProperties.PlayExperienceStepResults_ID);
            _keys.Add(_playexperienceidKey,         (int)DataProperties.PlayExperienceStepResults_PlayExperienceID);
            _keys.Add(_playexperiencestepidKey,     (int)DataProperties.PlayExperienceStepResults_PlayExperienceStepID);
            _keys.Add(_datecompletedKey,            (int)DataProperties.PlayExperienceStepResults_DateCompleted);
            _keys.Add(_repeatedynKey,               (int)DataProperties.PlayExperienceStepResults_RepeatedYN);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayExperienceStepResult"; }
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

            this.ID                     = ((PlayExperienceStepResult)copy).ID;
            this.PlayExperienceID       = ((PlayExperienceStepResult)copy).PlayExperienceID;
            this.PlayExperienceStepID   = ((PlayExperienceStepResult)copy).PlayExperienceStepID;
            this.DateCompleted          = ((PlayExperienceStepResult)copy).DateCompleted;
            this.RepeatedYN             = ((PlayExperienceStepResult)copy).RepeatedYN;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayExperienceStepResultDataParameterKeys.PlayExperienceID.ToString(), this.PlayExperienceID.ToString());
            dataWrapper.SetParameterValue(PlayExperienceStepResultDataParameterKeys.PlayExperienceStepID.ToString(), this.PlayExperienceStepID.ToString());
            dataWrapper.SetParameterValue(PlayExperienceStepResultDataParameterKeys.DateCompleted.ToString(), this.DateCompleted.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayExperienceStepResultDataParameterKeys.RepeatedYN.ToString(), Convert.ToInt32(this.RepeatedYN).ToString());


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

            // Check ID
            if (String.IsNullOrEmpty(dataWrapper.ID)) { dataWrapper.ID = "0"; }

            // Check DateCompleted
            if (String.IsNullOrEmpty(dataWrapper.GetParameterValue(PlayExperienceStepResultDataParameterKeys.DateCompleted.ToString()))) {
                dataWrapper.SetParameterValue(PlayExperienceStepResultDataParameterKeys.DateCompleted.ToString(), DateTime.Now.ToString());
            }

            // Copy all properties from the copy data item to this data item:

            this.ID                     = Int32.Parse(dataWrapper.ID);
            this.PlayExperienceID       = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceStepResultDataParameterKeys.PlayExperienceID.ToString()));
            this.PlayExperienceStepID   = Int32.Parse(dataWrapper.GetParameterValue(PlayExperienceStepResultDataParameterKeys.PlayExperienceStepID.ToString()));
            this.DateCompleted          = DateTime.Parse(dataWrapper.GetParameterValue(PlayExperienceStepResultDataParameterKeys.DateCompleted.ToString()));
            this.RepeatedYN             = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayExperienceStepResultDataParameterKeys.RepeatedYN.ToString()));

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
                case (int)DataProperties.PlayExperienceStepResults_DateCompleted:
                    s = this.DateCompleted.ToString("g", toCultureInfo); // MM/dd/yyyy HH:mm
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
                case (int)DataProperties.PlayExperienceStepResults_DateCompleted:
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
