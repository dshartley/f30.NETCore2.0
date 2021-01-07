using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaTileData
{
    public enum PlayAreaTileDataDataParameterKeys
    {
        ID,
        RelativeMemberID,
        PlayAreaTileID,
        OnCompleteData,
        AttributeData
    }

    /// <summary>
    /// Encapsulates an PlayAreaTileData data item.
    /// </summary>
    public class PlayAreaTileData : DataItemBase
    {
        #region Constructors

        private PlayAreaTileData() : base() { }

        public PlayAreaTileData(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaTileData(  XmlNode             dataNode,
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

        protected const string _playareatileidKey = "PlayAreaTileID";

        /// <summary>
        /// Gets or sets the PlayAreaTileID.
        /// </summary>
        /// <value>The PlayAreaTileID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayAreaTileID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playareatileidKey].Value);
            }
            set
            {
                this.SetProperty(_playareatileidKey, value.ToString(), false);
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

        protected const string _attributedataKey = "AttributeData";

        /// <summary>
        /// Gets or sets the AttributeData.
        /// </summary>
        /// <value>The AttributeData.</value>
        [System.ComponentModel.Browsable(false)]
        public string AttributeData
        {
            get
            {
                return _node.Attributes[_attributedataKey].Value;
            }
            set
            {
                this.SetProperty(_attributedataKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaTileDataWrapper ToWrapper()
        {
            PlayAreaTileDataWrapper result = new PlayAreaTileDataWrapper();

            result.ID                   = this.ID;
            result.RelativeMemberID     = this.RelativeMemberID;
            result.PlayAreaTileID       = this.PlayAreaTileID;
            result.OnCompleteData       = this.OnCompleteData;
            result.AttributeData        = this.AttributeData;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaTileDataWrapper fromWrapper)
        {
            this.ID                     = fromWrapper.ID;
            this.RelativeMemberID       = fromWrapper.RelativeMemberID;
            this.PlayAreaTileID         = fromWrapper.PlayAreaTileID;
            this.OnCompleteData         = fromWrapper.OnCompleteData;
            this.AttributeData          = fromWrapper.AttributeData;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playareatileidKey, "0");
            this.SetAttribute(_oncompletedataKey, "");
            this.SetAttribute(_attributedataKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaTileData_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaTileData_AttributeData;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                   (int)DataProperties.PlayAreaTileData_ID);
            _keys.Add(_relativememberidKey,     (int)DataProperties.PlayAreaTileData_RelativeMemberID);
            _keys.Add(_playareatileidKey,       (int)DataProperties.PlayAreaTileData_PlayAreaTileID);
            _keys.Add(_oncompletedataKey,       (int)DataProperties.PlayAreaTileData_OnCompleteData);
            _keys.Add(_attributedataKey,        (int)DataProperties.PlayAreaTileData_AttributeData);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaTileData"; }
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

            this.ID                     = ((PlayAreaTileData)copy).ID;
            this.RelativeMemberID       = ((PlayAreaTileData)copy).RelativeMemberID;
            this.PlayAreaTileID         = ((PlayAreaTileData)copy).PlayAreaTileID;
            this.OnCompleteData         = ((PlayAreaTileData)copy).OnCompleteData;
            this.AttributeData          = ((PlayAreaTileData)copy).AttributeData;

            this.DoValidations          = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaTileDataDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataDataParameterKeys.PlayAreaTileID.ToString(), this.PlayAreaTileID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTileDataDataParameterKeys.OnCompleteData.ToString(), this.OnCompleteData);
            dataWrapper.SetParameterValue(PlayAreaTileDataDataParameterKeys.AttributeData.ToString(), this.AttributeData);

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
            this.RelativeMemberID       = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayAreaTileID         = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTileDataDataParameterKeys.PlayAreaTileID.ToString()));
            this.OnCompleteData         = dataWrapper.GetParameterValue(PlayAreaTileDataDataParameterKeys.OnCompleteData.ToString());
            this.AttributeData          = dataWrapper.GetParameterValue(PlayAreaTileDataDataParameterKeys.AttributeData.ToString());

            this.DoValidations          = doValidations;
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
