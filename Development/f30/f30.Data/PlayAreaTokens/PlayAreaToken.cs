using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaTokens
{
    public enum PlayAreaTokenDataParameterKeys
    {
        ID,
        RelativeMemberID,
        PlayGameID,
        Column,
        Row,
        ImageName,
        TokenAttributesString
    }

    /// <summary>
    /// Encapsulates an PlayAreaToken data item.
    /// </summary>
    public class PlayAreaToken : DataItemBase
    {
        #region Constructors

        private PlayAreaToken() : base() { }

        public PlayAreaToken(XmlDocument dataDocument,
                        IDataItemCollection collection,
                        string defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaToken(XmlNode dataNode,
                        IDataItemCollection collection,
                        string defaultCultureInfoName)
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

        protected const string _columnKey = "Column";

        /// <summary>
        /// Gets or sets the Column.
        /// </summary>
        /// <value>The Column.</value>
        [System.ComponentModel.Browsable(false)]
        public int Column
        {
            get
            {
                return Int32.Parse(_node.Attributes[_columnKey].Value);
            }
            set
            {
                this.SetProperty(_columnKey, value.ToString(), false);
            }
        }

        protected const string _rowKey = "Row";

        /// <summary>
        /// Gets or sets the Row.
        /// </summary>
        /// <value>The Row.</value>
        [System.ComponentModel.Browsable(false)]
        public int Row
        {
            get
            {
                return Int32.Parse(_node.Attributes[_rowKey].Value);
            }
            set
            {
                this.SetProperty(_rowKey, value.ToString(), false);
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

        protected const string _tokenattributesstringKey = "TokenAttributesString";

        /// <summary>
        /// Gets or sets the TokenAttributesString.
        /// </summary>
        /// <value>The TokenAttributesString.</value>
        [System.ComponentModel.Browsable(false)]
        public string TokenAttributesString
        {
            get
            {
                return _node.Attributes[_tokenattributesstringKey].Value;
            }
            set
            {
                this.SetProperty(_tokenattributesstringKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaTokenWrapper ToWrapper()
        {
            PlayAreaTokenWrapper result = new PlayAreaTokenWrapper();

            result.ID                       = this.ID;
            result.RelativeMemberID         = this.RelativeMemberID;
            result.PlayGameID               = this.PlayGameID;
            result.Column                   = this.Column;
            result.Row                      = this.Row;
            result.ImageName                = this.ImageName;
            result.TokenAttributesString    = this.TokenAttributesString;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaTokenWrapper fromWrapper)
        {
            this.ID                         = fromWrapper.ID;
            this.RelativeMemberID           = fromWrapper.RelativeMemberID;
            this.PlayGameID                 = fromWrapper.PlayGameID;
            this.Column                     = fromWrapper.Column;
            this.Row                        = fromWrapper.Row;
            this.ImageName                  = fromWrapper.ImageName;
            this.TokenAttributesString      = fromWrapper.TokenAttributesString;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playgameidKey, "0");
            this.SetAttribute(_columnKey, "0");
            this.SetAttribute(_rowKey, "0");
            this.SetAttribute(_imagenameKey, "");
            this.SetAttribute(_tokenattributesstringKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaTokens_ID;
            _endEnumIndex = (int)DataProperties.PlayAreaTokens_TokenAttributesString;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                       (int)DataProperties.PlayAreaTokens_ID);
            _keys.Add(_relativememberidKey,         (int)DataProperties.PlayAreaTokens_RelativeMemberID);
            _keys.Add(_playgameidKey,               (int)DataProperties.PlayAreaTokens_PlayGameID);
            _keys.Add(_columnKey,                   (int)DataProperties.PlayAreaTokens_Column);
            _keys.Add(_rowKey,                      (int)DataProperties.PlayAreaTokens_Row);
            _keys.Add(_imagenameKey,                (int)DataProperties.PlayAreaTokens_ImageName);
            _keys.Add(_tokenattributesstringKey,    (int)DataProperties.PlayAreaTokens_TokenAttributesString);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaToken"; }
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

            this.ID                         = ((PlayAreaToken)copy).ID;
            this.RelativeMemberID           = ((PlayAreaToken)copy).RelativeMemberID;
            this.PlayGameID                 = ((PlayAreaToken)copy).PlayGameID;
            this.Column                     = ((PlayAreaToken)copy).Column;
            this.Row                        = ((PlayAreaToken)copy).Row;
            this.ImageName                  = ((PlayAreaToken)copy).ImageName;
            this.TokenAttributesString      = ((PlayAreaToken)copy).TokenAttributesString;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaTokenDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTokenDataParameterKeys.PlayGameID.ToString(), this.PlayGameID.ToString());
            dataWrapper.SetParameterValue(PlayAreaTokenDataParameterKeys.Column.ToString(), this.Column.ToString());
            dataWrapper.SetParameterValue(PlayAreaTokenDataParameterKeys.Row.ToString(), this.Row.ToString());
            dataWrapper.SetParameterValue(PlayAreaTokenDataParameterKeys.ImageName.ToString(), this.ImageName);
            dataWrapper.SetParameterValue(PlayAreaTokenDataParameterKeys.TokenAttributesString.ToString(), this.TokenAttributesString);

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
            this.RelativeMemberID       = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTokenDataParameterKeys.RelativeMemberID.ToString()));
            this.PlayGameID             = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTokenDataParameterKeys.PlayGameID.ToString()));
            this.Column                 = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTokenDataParameterKeys.Column.ToString()));
            this.Row                    = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaTokenDataParameterKeys.Row.ToString()));
            this.ImageName              = dataWrapper.GetParameterValue(PlayAreaTokenDataParameterKeys.ImageName.ToString());
            this.TokenAttributesString  = dataWrapper.GetParameterValue(PlayAreaTokenDataParameterKeys.TokenAttributesString.ToString());

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

            string s = string.Empty;
            int propertyEnum = this.ToEnum(key);

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
