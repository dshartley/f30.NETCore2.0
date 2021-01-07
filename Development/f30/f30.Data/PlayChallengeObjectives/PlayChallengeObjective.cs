using Smart.Platform.Core;
using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayChallengeObjectives
{
    public enum PlayChallengeObjectiveDataParameterKeys
    {
        ID,
	    RelativeMemberID,
        PlayChallengeID,
        PlayChallengeObjectiveTypeID,
        IsAchievedYN,
        DateActive
    }

    /// <summary>
    /// Encapsulates an PlayChallengeObjective data item.
    /// </summary>
    public class PlayChallengeObjective : DataItemBase
    {
        #region Constructors

        private PlayChallengeObjective() : base() { }

        public PlayChallengeObjective(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayChallengeObjective(  XmlNode             dataNode,
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

        protected const string _playchallengeidKey = "PlayChallengeID";

        /// <summary>
        /// Gets or sets the PlayChallengeID.
        /// </summary>
        /// <value>The PlayChallengeID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayChallengeID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playchallengeidKey].Value);
            }
            set
            {
                this.SetProperty(_playchallengeidKey, value.ToString(), false);
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

        protected const string _isachievedynKey = "IsAchievedYN";

        /// <summary>
        /// Gets or sets the IsAchievedYN.
        /// </summary>
        /// <value>The IsAchievedYN</value>
        [System.ComponentModel.Browsable(false)]
        public bool IsAchievedYN
        {
            get
            {
                return BoolHelper.ToBool(_node.Attributes[_isachievedynKey].Value);
            }
            set
            {
                this.SetProperty(_isachievedynKey, Convert.ToInt32(value).ToString(), false);
            }
        }

        protected const string _dateactiveKey = "DateActive";

        /// <summary>
        /// Gets or sets the DateActive.
        /// </summary>
        /// <value>The DateActive.</value>
        [System.ComponentModel.Browsable(false)]
        public DateTime DateActive
        {
            get
            {
                return DateTime.Parse(_node.Attributes[_dateactiveKey].Value);
            }
            set
            {
                this.SetProperty(_dateactiveKey, value.ToString(), false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayChallengeObjectiveWrapper ToWrapper()
        {
            PlayChallengeObjectiveWrapper result = new PlayChallengeObjectiveWrapper();

            result.ID                               = this.ID;
            result.RelativeMemberID                 = this.RelativeMemberID;
            result.PlayChallengeID                  = this.PlayChallengeID;
            result.PlayChallengeObjectiveTypeID     = this.PlayChallengeObjectiveTypeID;
            result.IsAchievedYN                     = this.IsAchievedYN;
            result.DateActive                       = this.DateActive;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayChallengeObjectiveWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.RelativeMemberID               = fromWrapper.RelativeMemberID;
            this.PlayChallengeID                = fromWrapper.PlayChallengeID;
            this.PlayChallengeObjectiveTypeID   = fromWrapper.PlayChallengeObjectiveTypeID;
            this.IsAchievedYN                   = fromWrapper.IsAchievedYN;
            this.DateActive                     = fromWrapper.DateActive;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playchallengeidKey, "0");
            this.SetAttribute(_playchallengeobjectivetypeidKey, "0");
            this.SetAttribute(_isachievedynKey, "0");
            this.SetAttribute(_dateactiveKey, "1/1/1900");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayChallengeObjectives_ID;
            _endEnumIndex   = (int)DataProperties.PlayChallengeObjectives_DateActive;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                               (int)DataProperties.PlayChallengeObjectives_ID);
            _keys.Add(_relativememberidKey,                 (int)DataProperties.PlayChallengeObjectives_RelativeMemberID);
            _keys.Add(_playchallengeidKey,                  (int)DataProperties.PlayChallengeObjectives_PlayChallengeID);
            _keys.Add(_playchallengeobjectivetypeidKey,     (int)DataProperties.PlayChallengeObjectives_PlayChallengeObjectiveTypeID);
            _keys.Add(_isachievedynKey,                     (int)DataProperties.PlayChallengeObjectives_IsAchievedYN);
            _keys.Add(_dateactiveKey,                       (int)DataProperties.PlayChallengeObjectives_DateActive);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayChallengeObjective"; }
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

            this.ID                             = ((PlayChallengeObjective)copy).ID;
            this.RelativeMemberID               = ((PlayChallengeObjective)copy).RelativeMemberID;
            this.PlayChallengeID                = ((PlayChallengeObjective)copy).PlayChallengeID;
            this.PlayChallengeObjectiveTypeID   = ((PlayChallengeObjective)copy).PlayChallengeObjectiveTypeID;
            this.IsAchievedYN                   = ((PlayChallengeObjective)copy).IsAchievedYN;
            this.DateActive                     = ((PlayChallengeObjective)copy).DateActive;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayChallengeObjectiveDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeObjectiveDataParameterKeys.PlayChallengeID.ToString(), this.PlayChallengeID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeObjectiveDataParameterKeys.PlayChallengeObjectiveTypeID.ToString(), this.PlayChallengeObjectiveTypeID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeObjectiveDataParameterKeys.IsAchievedYN.ToString(), Convert.ToInt32(this.IsAchievedYN).ToString());
            dataWrapper.SetParameterValue(PlayChallengeObjectiveDataParameterKeys.DateActive.ToString(), this.DateActive.ToString("g", this._outputCultureInfo));

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
            this.RelativeMemberID               = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeObjectiveDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayChallengeID                = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeObjectiveDataParameterKeys.PlayChallengeID.ToString()));
            this.PlayChallengeObjectiveTypeID   = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeObjectiveDataParameterKeys.PlayChallengeObjectiveTypeID.ToString()));
            this.IsAchievedYN                   = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayChallengeObjectiveDataParameterKeys.IsAchievedYN.ToString()));
            this.DateActive                     = DateTime.Parse(dataWrapper.GetParameterValue(PlayChallengeObjectiveDataParameterKeys.DateActive.ToString()));

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
                case (int)DataProperties.PlayChallengeObjectives_DateActive:
                    s = this.DateActive.ToString("g", toCultureInfo); // MM/dd/yyyy HH:mm
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
                case (int)DataProperties.PlayChallengeObjectives_DateActive:
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
