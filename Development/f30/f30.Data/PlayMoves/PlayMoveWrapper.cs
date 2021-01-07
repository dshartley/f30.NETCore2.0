using f30.Core;
using Smart.Platform.Net.Serialization.JSON;
using System;

namespace f30.Data.PlayMoves
{
    /// <summary>
    /// A wrapper for a PlayMove item.
    /// </summary>
    public class PlayMoveWrapper: DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayMoveWrapper"/> class.
        /// </summary>
        public PlayMoveWrapper()
        {
        }

        #endregion

        #region Public Override Methods

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public override string DataType
        {
            get
            {
                return "PlayMove";
            }
        }

        #endregion

        #region Public Methods

        private string _playReferenceData;

        public string PlayReferenceData
        {
            get { return _playReferenceData; }
            set { _playReferenceData = value; }
        }

        private PlayReferenceActionTypes _playReferenceActionType;

        public PlayReferenceActionTypes PlayReferenceActionType
        {
            get { return _playReferenceActionType; }
            set { _playReferenceActionType = value; }
        }

        private string _contentData;

        public string ContentData
        {
            get { return _contentData; }
            set { _contentData = value; }
        }

        private string _onCompleteData;

        public string OnCompleteData
        {
            get { return _onCompleteData; }
            set { _onCompleteData = value; }
        }

        #endregion

        #region Public Methods; PlayReferenceData

        protected DataJSONWrapper _playReferenceDataWrapper = null;

        public DataJSONWrapper PlayReferenceDataWrapper
        {
            get { return _playReferenceDataWrapper; }
            set { _playReferenceDataWrapper = value; }
        }

        /// <summary>
        /// Deserializes the PlayReferenceData.
        /// </summary>
        public void DeserializePlayReferenceData()
        {
            _playReferenceDataWrapper = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playReferenceData))
            {
                _playReferenceDataWrapper = JSONHelper.DeserializeToJSON(_playReferenceData);
            }
        }

        /// <summary>
        /// Serializes the PlayReferenceData.
        /// </summary>
        public void SerializePlayReferenceData()
        {
            if (_playReferenceDataWrapper == null)
            {
                _playReferenceData = string.Empty;
                return;
            }

            _playReferenceData = JSONHelper.SerializeFromJSON(_playReferenceDataWrapper);
        }

        private string _playReferenceTypeKey = $"{DesignDataItemDataJSONWrapperKeys.PlayReferenceType}";

        /// <summary>
        /// Gets or sets the PlayReferenceType.
        /// </summary>
        /// <value>
        /// The PlayReferenceType.
        /// </value>
        public PlayReferenceTypes PlayReferenceType
        {
            get
            {
                PlayReferenceTypes result = PlayReferenceTypes.None;

                if (_playReferenceDataWrapper == null) { return result; }

                result = (PlayReferenceTypes)Enum.Parse(typeof(PlayReferenceTypes), _playReferenceDataWrapper.GetParameterValue(_playReferenceTypeKey));

                return result;
            }
            set
            {
                if (_playReferenceDataWrapper == null) { return; }

                _playReferenceDataWrapper.SetParameterValue(_playReferenceTypeKey, $"{(int)value}");

                this.SerializePlayReferenceData();
            }
        }

        private string _playReferenceIDKey = $"{DesignDataItemDataJSONWrapperKeys.PlayReferenceID}";

        /// <summary>
        /// Gets or sets the PlayReferenceID.
        /// </summary>
        /// <value>
        /// The PlayReferenceID.
        /// </value>
        public int PlayReferenceID
        {
            get
            {
                int result = 0;

                if (_playReferenceDataWrapper == null) { return result; }

                result = Int32.Parse(_playReferenceDataWrapper.GetParameterValue(_playReferenceIDKey));

                return result;
            }
            set
            {
                if (_playReferenceDataWrapper == null) { return; }

                _playReferenceDataWrapper.SetParameterValue(_playReferenceIDKey, $"{value}");

                this.SerializePlayReferenceData();
            }
        }

        private string _playReferenceDataItemTypeKey = $"{DesignDataItemDataJSONWrapperKeys.PlayReferenceDataItemType}";

        /// <summary>
        /// Gets or sets the PlayReferenceDataItemType.
        /// </summary>
        /// <value>
        /// The PlayReferenceDataItemType.
        /// </value>
        public PlayReferenceDataItemTypes PlayReferenceDataItemType
        {
            get
            {
                PlayReferenceDataItemTypes result = PlayReferenceDataItemTypes.None;

                if (_playReferenceDataWrapper == null) { return result; }

                 Enum.TryParse(_playReferenceDataWrapper.GetParameterValue(_playReferenceDataItemTypeKey), out result);

                return result;
            }
            set
            {
                if (_playReferenceDataWrapper == null) { return; }

                _playReferenceDataWrapper.SetParameterValue(_playReferenceDataItemTypeKey, $"{(int)value}");

                this.SerializePlayReferenceData();
            }
        }

        private string _playReferenceDataItemIDKey = $"{DesignDataItemDataJSONWrapperKeys.PlayReferenceDataItemID}";

        /// <summary>
        /// Gets or sets the PlayReferenceDataItemID.
        /// </summary>
        /// <value>
        /// The PlayReferenceDataItemID.
        /// </value>
        public int PlayReferenceDataItemID
        {
            get
            {
                int result = 0;

                if (_playReferenceDataWrapper == null) { return result; }

                result = Int32.Parse(_playReferenceDataWrapper.GetParameterValue(_playReferenceDataItemIDKey));

                return result;
            }
            set
            {
                if (_playReferenceDataWrapper == null) { return; }

                _playReferenceDataWrapper.SetParameterValue(_playReferenceDataItemIDKey, $"{value}");

                this.SerializePlayReferenceData();
            }
        }

        #endregion
    }
}
