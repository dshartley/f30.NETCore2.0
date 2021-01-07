using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaPathPoints
{
    public enum PlayAreaPathPointDataParameterKeys
    {
        ID,
        PlayGameID,
        PlayAreaPathID,
        Index,
        Column,
        Row
    }

    /// <summary>
    /// Encapsulates an PlayAreaPathPoint data item.
    /// </summary>
    public class PlayAreaPathPoint : DataItemBase
    {
        #region Constructors

        private PlayAreaPathPoint() : base() { }

        public PlayAreaPathPoint(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayAreaPathPoint(  XmlNode             dataNode,
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

        protected const string _playareapathidKey = "PlayAreaPathID";

        /// <summary>
        /// Gets or sets the PlayAreaPathID.
        /// </summary>
        /// <value>The PlayAreaPathID.</value>
        [System.ComponentModel.Browsable(false)]
        public int PlayAreaPathID
        {
            get
            {
                return Int32.Parse(_node.Attributes[_playareapathidKey].Value);
            }
            set
            {
                this.SetProperty(_playareapathidKey, value.ToString(), false);
            }
        }

        protected const string _indexKey = "Index";

        /// <summary>
        /// Gets or sets the Index.
        /// </summary>
        /// <value>The Index.</value>
        [System.ComponentModel.Browsable(false)]
        public int Index
        {
            get
            {
                return Int32.Parse(_node.Attributes[_indexKey].Value);
            }
            set
            {
                this.SetProperty(_indexKey, value.ToString(), false);
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

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayAreaPathPointWrapper ToWrapper()
        {
            PlayAreaPathPointWrapper result = new PlayAreaPathPointWrapper();

            result.ID                   = this.ID;
            result.PlayGameID           = this.PlayGameID;
            result.PlayAreaPathID       = this.PlayAreaPathID;
            result.Index                = this.Index;
            result.Column               = this.Column;
            result.Row                  = this.Row;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayAreaPathPointWrapper fromWrapper)
        {
            this.ID                 = fromWrapper.ID;
            this.PlayGameID         = fromWrapper.PlayGameID;
            this.PlayAreaPathID     = fromWrapper.PlayAreaPathID;
            this.Index              = fromWrapper.Index;
            this.Column             = fromWrapper.Column;
            this.Row                = fromWrapper.Row;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_playgameidKey, "0");
            this.SetAttribute(_playareapathidKey, "0");
            this.SetAttribute(_indexKey, "0");
            this.SetAttribute(_columnKey, "0");
            this.SetAttribute(_rowKey, "0");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayAreaPathPoints_ID;
            _endEnumIndex   = (int)DataProperties.PlayAreaPathPoints_Row;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                   (int)DataProperties.PlayAreaPathPoints_ID);
            _keys.Add(_playgameidKey,           (int)DataProperties.PlayAreaPathPoints_PlayGameID);
            _keys.Add(_playareapathidKey,       (int)DataProperties.PlayAreaPathPoints_PlayAreaPathID);
            _keys.Add(_indexKey,                (int)DataProperties.PlayAreaPathPoints_Index);
            _keys.Add(_columnKey,               (int)DataProperties.PlayAreaPathPoints_Column);
            _keys.Add(_rowKey,                  (int)DataProperties.PlayAreaPathPoints_Row);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaPathPoint"; }
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

            this.ID                 = ((PlayAreaPathPoint)copy).ID;
            this.PlayGameID         = ((PlayAreaPathPoint)copy).PlayGameID;
            this.PlayAreaPathID     = ((PlayAreaPathPoint)copy).PlayAreaPathID;
            this.Index              = ((PlayAreaPathPoint)copy).Index;
            this.Column             = ((PlayAreaPathPoint)copy).Column;
            this.Row                = ((PlayAreaPathPoint)copy).Row;

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayAreaPathPointDataParameterKeys.PlayGameID.ToString(), this.PlayGameID.ToString());
            dataWrapper.SetParameterValue(PlayAreaPathPointDataParameterKeys.PlayAreaPathID.ToString(), this.PlayAreaPathID.ToString());
            dataWrapper.SetParameterValue(PlayAreaPathPointDataParameterKeys.Index.ToString(), this.Index.ToString());
            dataWrapper.SetParameterValue(PlayAreaPathPointDataParameterKeys.Column.ToString(), this.Column.ToString());
            dataWrapper.SetParameterValue(PlayAreaPathPointDataParameterKeys.Row.ToString(), this.Row.ToString());
            
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

            this.ID                 = Int32.Parse(dataWrapper.ID);
            this.PlayGameID         = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaPathPointDataParameterKeys.PlayGameID.ToString()));
            this.PlayAreaPathID     = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaPathPointDataParameterKeys.PlayAreaPathID.ToString()));
            this.Index              = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaPathPointDataParameterKeys.Index.ToString()));
            this.Column             = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaPathPointDataParameterKeys.Column.ToString()));
            this.Row                = Int32.Parse(dataWrapper.GetParameterValue(PlayAreaPathPointDataParameterKeys.Row.ToString()));

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
