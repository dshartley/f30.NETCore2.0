using Smart.Platform.Core;
using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayChallenges
{
    public enum PlayChallengeDataParameterKeys
    {
        ID,
        RelativeMemberID,
        PlayGameID,
        PlayMoveID,
        PlayChallengeTypeID,
        IsActiveYN,
        IsCompleteYN,
        DateActive
    }

    /// <summary>
    /// Encapsulates an PlayChallenge data item.
    /// </summary>
    public class PlayChallenge : DataItemBase
    {
        #region Constructors

        private PlayChallenge() : base() { }

        public PlayChallenge(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayChallenge(  XmlNode             dataNode,
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

        protected const string _playmoveidKey = "PlayMoveID";

        /// <summary>
        /// Gets or sets the PlayMoveID.
        /// </summary>
        /// <value>The PlayMoveID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayMoveID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playmoveidKey].Value);
            }
            set
            {
                this.SetProperty(_playmoveidKey, value.ToString(), false);
            }
        }

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

        protected const string _isactiveynKey = "IsActiveYN";

        /// <summary>
        /// Gets or sets the IsActiveYN.
        /// </summary>
        /// <value>The IsActiveYN</value>
        [System.ComponentModel.Browsable(false)]
        public bool IsActiveYN
        {
            get
            {
                return BoolHelper.ToBool(_node.Attributes[_isactiveynKey].Value);
            }
            set
            {
                this.SetProperty(_isactiveynKey, Convert.ToInt32(value).ToString(), false);
            }
        }

        protected const string _iscompleteynKey = "IsCompleteYN";

        /// <summary>
        /// Gets or sets the IsCompleteYN.
        /// </summary>
        /// <value>The IsCompleteYN</value>
        [System.ComponentModel.Browsable(false)]
        public bool IsCompleteYN
        {
            get
            {
                return BoolHelper.ToBool(_node.Attributes[_iscompleteynKey].Value);
            }
            set
            {
                this.SetProperty(_iscompleteynKey, Convert.ToInt32(value).ToString(), false);
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
        public PlayChallengeWrapper ToWrapper()
        {
            PlayChallengeWrapper result = new PlayChallengeWrapper();

            result.ID                   = this.ID;
            result.RelativeMemberID     = this.RelativeMemberID;
            result.PlayGameID           = this.PlayGameID;
            result.PlayMoveID           = this.PlayMoveID;
            result.PlayChallengeTypeID  = this.PlayChallengeTypeID;
            result.IsActiveYN           = this.IsActiveYN;
            result.IsCompleteYN         = this.IsCompleteYN;
            result.DateActive           = this.DateActive;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayChallengeWrapper fromWrapper)
        {
            this.ID                     = fromWrapper.ID;
            this.RelativeMemberID       = fromWrapper.RelativeMemberID;
            this.PlayGameID             = fromWrapper.PlayGameID;
            this.PlayMoveID             = fromWrapper.PlayMoveID;
            this.PlayChallengeTypeID    = fromWrapper.PlayChallengeTypeID;
            this.IsActiveYN             = fromWrapper.IsActiveYN;
            this.IsCompleteYN           = fromWrapper.IsCompleteYN;
            this.DateActive             = fromWrapper.DateActive;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playgameidKey, "0");
            this.SetAttribute(_playmoveidKey, "0");
            this.SetAttribute(_playchallengetypeidKey, "0");
            this.SetAttribute(_isactiveynKey, "0");
            this.SetAttribute(_iscompleteynKey, "0");
            this.SetAttribute(_dateactiveKey, "1/1/1900");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayChallenges_ID;
            _endEnumIndex   = (int)DataProperties.PlayChallenges_DateActive;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                   (int)DataProperties.PlayChallenges_ID);
            _keys.Add(_relativememberidKey,     (int)DataProperties.PlayChallenges_RelativeMemberID);
            _keys.Add(_playgameidKey,           (int)DataProperties.PlayChallenges_PlayGameID);
            _keys.Add(_playmoveidKey,           (int)DataProperties.PlayChallenges_PlayMoveID);
            _keys.Add(_playchallengetypeidKey,  (int)DataProperties.PlayChallenges_PlayChallengeTypeID);
            _keys.Add(_isactiveynKey,           (int)DataProperties.PlayChallenges_IsActiveYN);
            _keys.Add(_iscompleteynKey,         (int)DataProperties.PlayChallenges_IsCompleteYN);
            _keys.Add(_dateactiveKey,           (int)DataProperties.PlayChallenges_DateActive);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayChallenge"; }
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

            this.ID                     = ((PlayChallenge)copy).ID;
            this.RelativeMemberID       = ((PlayChallenge)copy).RelativeMemberID;
            this.PlayGameID             = ((PlayChallenge)copy).PlayGameID;
            this.PlayMoveID             = ((PlayChallenge)copy).PlayMoveID;
            this.PlayChallengeTypeID    = ((PlayChallenge)copy).PlayChallengeTypeID;
            this.IsActiveYN             = ((PlayChallenge)copy).IsActiveYN;
            this.IsCompleteYN           = ((PlayChallenge)copy).IsCompleteYN;
            this.DateActive             = ((PlayChallenge)copy).DateActive;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.PlayGameID.ToString(), this.PlayGameID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.PlayMoveID.ToString(), this.PlayMoveID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.PlayChallengeTypeID.ToString(), this.PlayChallengeTypeID.ToString());
            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.IsActiveYN.ToString(), Convert.ToInt32(this.IsActiveYN).ToString());
            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.IsCompleteYN.ToString(), Convert.ToInt32(this.IsCompleteYN).ToString());
            dataWrapper.SetParameterValue(PlayChallengeDataParameterKeys.DateActive.ToString(), this.DateActive.ToString("g", this._outputCultureInfo));

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

            this.ID                     = Int32.Parse(dataWrapper.ID);
            this.RelativeMemberID       = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayGameID             = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.PlayGameID.ToString()));
            this.PlayMoveID             = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.PlayMoveID.ToString()));
            this.PlayChallengeTypeID    = Int32.Parse(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.PlayChallengeTypeID.ToString()));
            this.IsActiveYN             = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.IsActiveYN.ToString()));
            this.IsCompleteYN           = BoolHelper.ToBool(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.IsCompleteYN.ToString()));
            this.DateActive             = DateTime.Parse(dataWrapper.GetParameterValue(PlayChallengeDataParameterKeys.DateActive.ToString()));

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
                case (int)DataProperties.PlayChallenges_DateActive:
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
                case (int)DataProperties.PlayChallenges_DateActive:
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
