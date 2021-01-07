using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayResults
{
    public enum PlayResultDataParameterKeys
    {
        ID,
        RelativeMemberID,
        PlayGamesJSON,
        PlayGameDataJSON,
        PlayAreaTilesJSON,
        PlayAreaTileDataJSON,
        PlayExperienceStepResultsJSON
    }

    /// <summary>
    /// Encapsulates an PlayResult data item.
    /// </summary>
    public class PlayResult : DataItemBase
    {
        #region Constructors

        private PlayResult() : base() { }

        public PlayResult(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayResult(  XmlNode             dataNode,
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

        protected const string _playgamesjsonKey = "PlayGamesJSON";

        /// <summary>
        /// Gets or sets the PlayGamesJSON.
        /// </summary>
        /// <value>The PlayGamesJSON.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayGamesJSON
        {
            get
            {
                return _node.Attributes[_playgamesjsonKey].Value;
            }
            set
            {
                this.SetProperty(_playgamesjsonKey, value, false);
            }
        }

        protected const string _playgamedatajsonKey = "PlayGameDataJSON";

        /// <summary>
        /// Gets or sets the PlayGameDataJSON.
        /// </summary>
        /// <value>The PlayGameDataJSON.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayGameDataJSON
        {
            get
            {
                return _node.Attributes[_playgamedatajsonKey].Value;
            }
            set
            {
                this.SetProperty(_playgamedatajsonKey, value, false);
            }
        }

        protected const string _playareatilesjsonKey = "PlayAreaTilesJSON";

        /// <summary>
        /// Gets or sets the PlayAreaTilesJSON.
        /// </summary>
        /// <value>The PlayAreaTilesJSON.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayAreaTilesJSON
        {
            get
            {
                return _node.Attributes[_playareatilesjsonKey].Value;
            }
            set
            {
                this.SetProperty(_playareatilesjsonKey, value, false);
            }
        }

        protected const string _playareatiledatajsonKey = "PlayAreaTileDataJSON";

        /// <summary>
        /// Gets or sets the PlayAreaTileDataJSON.
        /// </summary>
        /// <value>The PlayAreaTileDataJSON.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayAreaTileDataJSON
        {
            get
            {
                return _node.Attributes[_playareatiledatajsonKey].Value;
            }
            set
            {
                this.SetProperty(_playareatiledatajsonKey, value, false);
            }
        }

        protected const string _playexperiencestepresultsjsonKey = "PlayExperienceStepResultsJSON";

        /// <summary>
        /// Gets or sets the PlayExperienceStepResultsJSON.
        /// </summary>
        /// <value>The PlayExperienceStepResultsJSON.</value>
        [System.ComponentModel.Browsable(false)]
        public string PlayExperienceStepResultsJSON
        {
            get
            {
                return _node.Attributes[_playexperiencestepresultsjsonKey].Value;
            }
            set
            {
                this.SetProperty(_playexperiencestepresultsjsonKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayResultWrapper ToWrapper()
        {
            PlayResultWrapper result = new PlayResultWrapper();

            result.ID                               = this.ID;
            result.RelativeMemberID                 = this.RelativeMemberID;
            result.PlayGamesJSON                    = this.PlayGamesJSON;
            result.PlayGameDataJSON                 = this.PlayGameDataJSON;
            result.PlayAreaTilesJSON                = this.PlayAreaTilesJSON;
            result.PlayAreaTileDataJSON             = this.PlayAreaTileDataJSON;
            result.PlayExperienceStepResultsJSON    = this.PlayExperienceStepResultsJSON;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayResultWrapper fromWrapper)
        {
            this.ID                             = fromWrapper.ID;
            this.RelativeMemberID               = fromWrapper.RelativeMemberID;
            this.PlayGamesJSON                  = fromWrapper.PlayGamesJSON;
            this.PlayGameDataJSON               = fromWrapper.PlayGameDataJSON;
            this.PlayAreaTilesJSON              = fromWrapper.PlayAreaTilesJSON;
            this.PlayAreaTileDataJSON           = fromWrapper.PlayAreaTileDataJSON;
            this.PlayExperienceStepResultsJSON  = fromWrapper.PlayExperienceStepResultsJSON;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playgamesjsonKey, "");
            this.SetAttribute(_playgamedatajsonKey, "");
            this.SetAttribute(_playareatilesjsonKey, "");
            this.SetAttribute(_playareatiledatajsonKey, "");
            this.SetAttribute(_playexperiencestepresultsjsonKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayResults_ID;
            _endEnumIndex   = (int)DataProperties.PlayResults_PlayExperienceStepResultsJSON;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                               (int)DataProperties.PlayResults_ID);
            _keys.Add(_relativememberidKey,                 (int)DataProperties.PlayResults_RelativeMemberID);
            _keys.Add(_playgamesjsonKey,                    (int)DataProperties.PlayResults_PlayGamesJSON);
            _keys.Add(_playgamedatajsonKey,                 (int)DataProperties.PlayResults_PlayGameDataJSON);
            _keys.Add(_playareatilesjsonKey,                (int)DataProperties.PlayResults_PlayAreaTilesJSON);
            _keys.Add(_playareatiledatajsonKey,             (int)DataProperties.PlayResults_PlayAreaTileDataJSON);
            _keys.Add(_playexperiencestepresultsjsonKey,    (int)DataProperties.PlayResults_PlayExperienceStepResultsJSON);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayResult"; }
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

            this.ID                             = ((PlayResult)copy).ID;
            this.RelativeMemberID               = ((PlayResult)copy).RelativeMemberID;
            this.PlayGamesJSON                  = ((PlayResult)copy).PlayGamesJSON;
            this.PlayGameDataJSON               = ((PlayResult)copy).PlayGameDataJSON;
            this.PlayAreaTilesJSON              = ((PlayResult)copy).PlayAreaTilesJSON;
            this.PlayAreaTileDataJSON           = ((PlayResult)copy).PlayAreaTileDataJSON;
            this.PlayExperienceStepResultsJSON  = ((PlayResult)copy).PlayExperienceStepResultsJSON;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayResultDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayResultDataParameterKeys.PlayGamesJSON.ToString(), this.PlayGamesJSON);
            dataWrapper.SetParameterValue(PlayResultDataParameterKeys.PlayGameDataJSON.ToString(), this.PlayGameDataJSON);
            dataWrapper.SetParameterValue(PlayResultDataParameterKeys.PlayAreaTilesJSON.ToString(), this.PlayAreaTilesJSON);
            dataWrapper.SetParameterValue(PlayResultDataParameterKeys.PlayAreaTileDataJSON.ToString(), this.PlayAreaTileDataJSON);
            dataWrapper.SetParameterValue(PlayResultDataParameterKeys.PlayExperienceStepResultsJSON.ToString(), this.PlayExperienceStepResultsJSON);

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
            this.RelativeMemberID               = Int32.Parse(dataWrapper.GetParameterValue(PlayResultDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayGamesJSON                  = dataWrapper.GetParameterValue(PlayResultDataParameterKeys.PlayGamesJSON.ToString());
            this.PlayGameDataJSON               = dataWrapper.GetParameterValue(PlayResultDataParameterKeys.PlayGameDataJSON.ToString());
            this.PlayAreaTilesJSON              = dataWrapper.GetParameterValue(PlayResultDataParameterKeys.PlayAreaTilesJSON.ToString());
            this.PlayAreaTileDataJSON           = dataWrapper.GetParameterValue(PlayResultDataParameterKeys.PlayAreaTileDataJSON.ToString());
            this.PlayExperienceStepResultsJSON  = dataWrapper.GetParameterValue(PlayResultDataParameterKeys.PlayExperienceStepResultsJSON.ToString());

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
