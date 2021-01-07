using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaPaths
{
    public enum PlayAreaPathDataParameterKeys
    {
        ID,
        PlayGameID,
        PathAttributesString,
        PathLogString
    }

    /// <summary>
    /// Encapsulates an PlayAreaPath data item.
    /// </summary>
    public class PlayAreaPath : DataItemBase
    {
        #region Constructors

        private PlayAreaPath() : base() { }

        public PlayAreaPath(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaPath(  XmlNode             dataNode,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataNode, collection, defaultCultureInfoName)
        { }

        #endregion

        #region Public Methods

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

        protected const string _pathattributesstringKey = "PathAttributesString";

        /// <summary>
        /// Gets or sets the PathAttributesString.
        /// </summary>
        /// <value>The PathAttributesString.</value>
        [System.ComponentModel.Browsable(false)]
        public string PathAttributesString
        {
            get
            {
                return _node.Attributes[_pathattributesstringKey].Value;
            }
            set
            {
                this.SetProperty(_pathattributesstringKey, value, false);
            }
        }

        protected const string _pathlogstringKey = "PathLogString";

        /// <summary>
        /// Gets or sets the PathLogString.
        /// </summary>
        /// <value>The PathLogString.</value>
        [System.ComponentModel.Browsable(false)]
        public string PathLogString
        {
            get
            {
                return _node.Attributes[_pathlogstringKey].Value;
            }
            set
            {
                this.SetProperty(_pathlogstringKey, value, false);
            }
        }

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaPathWrapper ToWrapper()
        {
            PlayAreaPathWrapper result = new PlayAreaPathWrapper();

            result.ID                       = this.ID;
            result.PlayGameID               = this.PlayGameID;
            result.PathAttributesString     = this.PathAttributesString;
            result.PathLogString            = this.PathLogString;
           
            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaPathWrapper fromWrapper)
        {
            this.ID                     = fromWrapper.ID;
            this.PlayGameID             = fromWrapper.PlayGameID;
            this.PathAttributesString   = fromWrapper.PathAttributesString;
            this.PathLogString          = fromWrapper.PathLogString;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playgameidKey, "0");
            this.SetAttribute(_pathattributesstringKey, "");
            this.SetAttribute(_pathlogstringKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaPaths_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaPaths_PathLogString;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                   (int)DataProperties.PlayAreaPaths_ID);
            _keys.Add(_playgameidKey,           (int)DataProperties.PlayAreaPaths_PlayGameID);
            _keys.Add(_pathattributesstringKey, (int)DataProperties.PlayAreaPaths_PathAttributesString);
            _keys.Add(_pathlogstringKey,        (int)DataProperties.PlayAreaPaths_PathLogString);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaPath"; }
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

            this.ID                     = ((PlayAreaPath)copy).ID;
            this.PlayGameID             = ((PlayAreaPath)copy).PlayGameID;
            this.PathAttributesString   = ((PlayAreaPath)copy).PathAttributesString;
            this.PathLogString          = ((PlayAreaPath)copy).PathLogString;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaPathDataParameterKeys.PlayGameID.ToString(), this.PlayGameID.ToString());
            dataWrapper.SetParameterValue(PlayAreaPathDataParameterKeys.PathAttributesString.ToString(), this.PathAttributesString);
            dataWrapper.SetParameterValue(PlayAreaPathDataParameterKeys.PathLogString.ToString(), this.PathLogString);

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
            this.PlayGameID             = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaPathDataParameterKeys.PlayGameID.ToString()));
            this.PathAttributesString   = dataWrapper.GetParameterValue(PlayAreaPathDataParameterKeys.PathAttributesString.ToString());
            this.PathLogString          = dataWrapper.GetParameterValue(PlayAreaPathDataParameterKeys.PathLogString.ToString());

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
