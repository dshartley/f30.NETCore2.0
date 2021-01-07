using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayGames
{
    public enum PlayGameDataParameterKeys
    {
        ID,
	    RelativeMemberID,
        PlaySubsetID,
        DateCreated,
        Name
    }

    /// <summary>
    /// Encapsulates an PlayGame data item.
    /// </summary>
    public class PlayGame : DataItemBase
    {
        #region Constructors

        private PlayGame() : base() { }

        public PlayGame(  XmlDocument         dataDocument,
                        IDataItemCollection collection,
                        string              defaultCultureInfoName)
            : base(dataDocument, collection, defaultCultureInfoName)
        { }

        public PlayGame(  XmlNode             dataNode,
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

        protected const string _datecreatedKey = "DateCreated";

        /// <summary>
        /// Gets or sets the DateCreated.
        /// </summary>
        /// <value>The DateCreated.</value>
        [System.ComponentModel.Browsable(false)]
        public DateTime DateCreated
        {
            get
            {
                return DateTime.Parse(_node.Attributes[_datecreatedKey].Value);
            }
            set
            {
                this.SetProperty(_datecreatedKey, value.ToString(), false);
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

        /// <summary>
        /// To the wrapper.
        /// </summary>
        /// <returns></returns>
        public PlayGameWrapper ToWrapper()
        {
            PlayGameWrapper result = new PlayGameWrapper();

            result.ID                   = this.ID;
            result.RelativeMemberID     = this.RelativeMemberID;
            result.PlaySubsetID         = this.PlaySubsetID;
            result.DateCreated          = this.DateCreated;
            result.Name                 = this.Name;

            return result;
        }

        /// <summary>
        /// Copies the specified from wrapper.
        /// </summary>
        /// <param name="fromWrapper">From wrapper.</param>
        public void Copy(PlayGameWrapper fromWrapper)
        {
            this.ID                 = fromWrapper.ID;
            this.RelativeMemberID   = fromWrapper.RelativeMemberID;
            this.PlaySubsetID       = fromWrapper.PlaySubsetID;
            this.DateCreated        = fromWrapper.DateCreated;
            this.Name               = fromWrapper.Name;
        }

        #endregion

        #region Protected Override Methods

        protected override void InitialiseDataNode()
        {
            // Setup the node data:

            this.SetAttribute(_idKey, "0");
            this.SetAttribute(_relativememberidKey, "0");
            this.SetAttribute(_playsubsetidKey, "0");
            this.SetAttribute(_datecreatedKey, "1/1/1900");
            this.SetAttribute(_nameKey, "");
        }

        protected override void InitialiseDataItem()
        {
            // Setup foreign key dependency helpers:
        }

        protected override void InitialisePropertyIndexes()
        {
            // Define the range of the properties using the enum values:

            _startEnumIndex = (int)DataProperties.PlayGames_ID;
            _endEnumIndex   = (int)DataProperties.PlayGames_Name;
        }

        protected override void InitialisePropertyKeys()
        {
            // Populate the dictionary of property keys:

            _keys.Add(_idKey,                   (int)DataProperties.PlayGames_ID);
            _keys.Add(_relativememberidKey,     (int)DataProperties.PlayGames_RelativeMemberID);
            _keys.Add(_playsubsetidKey,         (int)DataProperties.PlayGames_PlaySubsetID);
            _keys.Add(_datecreatedKey,          (int)DataProperties.PlayGames_DateCreated);
            _keys.Add(_nameKey,                 (int)DataProperties.PlayGames_Name);
        }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayGame"; }
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

            this.ID                     = ((PlayGame)copy).ID;
            this.RelativeMemberID       = ((PlayGame)copy).RelativeMemberID;
            this.PlaySubsetID           = ((PlayGame)copy).PlaySubsetID;
            this.DateCreated            = ((PlayGame)copy).DateCreated;
            this.Name                   = ((PlayGame)copy).Name;          

            this.DoValidations = doValidations;
        }

        public override DataJSONWrapper CopyToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.ID = this.ID.ToString();

            dataWrapper.SetParameterValue(PlayGameDataParameterKeys.RelativeMemberID.ToString(), this.RelativeMemberID.ToString());
            dataWrapper.SetParameterValue(PlayGameDataParameterKeys.PlaySubsetID.ToString(), this.PlaySubsetID.ToString());
            dataWrapper.SetParameterValue(PlayGameDataParameterKeys.DateCreated.ToString(), this.DateCreated.ToString("g", this._outputCultureInfo));
            dataWrapper.SetParameterValue(PlayGameDataParameterKeys.Name.ToString(), this.Name);

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
            this.RelativeMemberID   = Int32.Parse(dataWrapper.GetParameterValue(PlayGameDataParameterKeys.RelativeMemberID.ToString()));
            this.PlaySubsetID       = Int32.Parse(dataWrapper.GetParameterValue(PlayGameDataParameterKeys.PlaySubsetID.ToString()));
            this.DateCreated        = DateTime.Parse(dataWrapper.GetParameterValue(PlayGameDataParameterKeys.DateCreated.ToString()));
            this.Name               = dataWrapper.GetParameterValue(PlayGameDataParameterKeys.Name.ToString());            

            this.DoValidations       = doValidations;
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
                case (int)DataProperties.PlayGames_DateCreated:
                    s = this.DateCreated.ToString("g", toCultureInfo); // MM/dd/yyyy HH:mm
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

            string s = string.Empty;
            int propertyEnum = this.ToEnum(key);

            switch (propertyEnum)
            {
                case (int)DataProperties.PlayGames_DateCreated:
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
