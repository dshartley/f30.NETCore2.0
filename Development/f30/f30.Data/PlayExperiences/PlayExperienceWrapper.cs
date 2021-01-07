using f30.Core;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayExperiences
{
    /// <summary>
    /// A wrapper for a PlayExperience item.
    /// </summary>
    public class PlayExperienceWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperienceWrapper"/> class.
        /// </summary>
        public PlayExperienceWrapper() : base()
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
                return "PlayExperience";
            }
        }

        #endregion

        #region Public Methods

        private PlayExperienceTypes _playExperienceType;

        public PlayExperienceTypes PlayExperienceType
        {
            get { return _playExperienceType; }
            set { _playExperienceType = value; }
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

        private string _playChallengeObjectiveDefinitionData;

        public string PlayChallengeObjectiveDefinitionData
        {
            get { return _playChallengeObjectiveDefinitionData; }
            set { _playChallengeObjectiveDefinitionData = value; }
        }

        #endregion

        #region Public Methods; PlayChallengeObjectiveDefinitionData

        protected DataJSONWrapper _playChallengeObjectiveDefinitionDataWrapper = null;

        public DataJSONWrapper PlayChallengeObjectiveDefinitionDataWrapper
        {
            get { return _playChallengeObjectiveDefinitionDataWrapper; }
            set { _playChallengeObjectiveDefinitionDataWrapper = value; }
        }

        /// <summary>
        /// Deserializes the PlayChallengeObjectiveDefinitionData.
        /// </summary>
        public void DeserializePlayChallengeObjectiveDefinitionData()
        {
            _playChallengeObjectiveDefinitionDataWrapper        = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_playChallengeObjectiveDefinitionData))
            {
                _playChallengeObjectiveDefinitionDataWrapper    = JSONHelper.DeserializeToJSON(_playChallengeObjectiveDefinitionData);
            }

            // Deserialize PlayChallengeObjectiveDefinitionCodes
            this.DoDeserializePlayChallengeObjectiveDefinitionCodesFromWrapper();
        }

        /// <summary>
        /// Serializes the PlayChallengeObjectiveDefinitionData.
        /// </summary>
        public void SerializePlayChallengeObjectiveDefinitionData()
        {
            if (_playChallengeObjectiveDefinitionDataWrapper == null)
            {
                _playChallengeObjectiveDefinitionData   = string.Empty;
                return;
            }

            // Serialize PlayChallengeObjectiveDefinitionCodes
            this.DoSerializePlayChallengeObjectiveDefinitionCodesToWrapper();

            _playChallengeObjectiveDefinitionData       = JSONHelper.SerializeFromJSON(_playChallengeObjectiveDefinitionDataWrapper);
        }

        #endregion

        #region Public Methods; PlayChallengeObjectiveDefinitionCodes

        private string _playChallengeObjectiveDefinitionCodesKey = $"{DesignDataItemDataJSONWrapperKeys.DefinitionCodes}";

        private List<KeyValuePair<string, string>> _playChallengeObjectiveDefinitionCodes;

        public List<KeyValuePair<string, string>> PlayChallengeObjectiveDefinitionCodes
        {
            get { return _playChallengeObjectiveDefinitionCodes; }
        }

        /// <summary>
        /// Adds the PlayChallengeObjectiveDefinitionCode.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddPlayChallengeObjectiveDefinitionCode(string key, string value)
        {
            if (_playChallengeObjectiveDefinitionCodes == null) { return; }

            int index = this.DoFindPlayChallengeObjectiveDefinitionCode(key);

            if (index < 0) { _playChallengeObjectiveDefinitionCodes.Add(new KeyValuePair<string, string>(key, value)); }
        }

        /// <summary>
        /// Removes the PlayChallengeObjectiveDefinitionCode.
        /// </summary>
        /// <param name="key">The key.</param>
        public void RemovePlayChallengeObjectiveDefinitionCode(string key)
        {
            if (_playChallengeObjectiveDefinitionCodes.Count == 0) { return; }

            int index = this.DoFindPlayChallengeObjectiveDefinitionCode(key);

            if (index >= 0) { _playChallengeObjectiveDefinitionCodes.RemoveAt(index); }
        }

        /// <summary>
        /// Determines whether the PlayChallengeObjectiveDefinitionCode exist.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if PlayChallengeObjectiveDefinitionCode exists; otherwise, <c>false</c>.
        /// </returns>
        public bool HasPlayChallengeObjectiveDefinitionCodeYN(string key)
        {
            bool result = false;

            if (_playChallengeObjectiveDefinitionCodes == null) { return false; }

            int index = this.DoFindPlayChallengeObjectiveDefinitionCode(key);

            if (index >= 0) { result = true; }

            return result;
        }

        /// <summary>
        /// Gets the PlayChallengeObjectiveDefinitionCodes concatenated.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string GetConcatenatedPlayChallengeObjectiveDefinitionCodes()
        {
            #region Check Parameters

            if (_playChallengeObjectiveDefinitionCodes == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "_playChallengeObjectiveDefinitionCodes is nothing"));

            #endregion

            string result = "";

            // Go through each item
            foreach (KeyValuePair<string, string> item in _playChallengeObjectiveDefinitionCodes)
            {
                if (!string.IsNullOrEmpty(result)) { result += ","; }

                result += item.Key;
            }

            return result;
        }

        #endregion

        #region Private Methods; PlayChallengeObjectiveDefinitionCodes

        private int DoFindPlayChallengeObjectiveDefinitionCode(string key)
        {
            int result = -1;

            // Go through each item
            for (int i = 0; i < _playChallengeObjectiveDefinitionCodes.Count; i++)
            {
                // Get item
                KeyValuePair<string, string> item = _playChallengeObjectiveDefinitionCodes[i];

                if (item.Key == key)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        private void DoSerializePlayChallengeObjectiveDefinitionCodesToWrapper()
        {
            // Get pointsWrapper
            DataJSONWrapper         wrapper = _playChallengeObjectiveDefinitionDataWrapper.Find(_playChallengeObjectiveDefinitionCodesKey);

            if (wrapper == null)
            {
                // Create definitionCodesWrapper
                wrapper             = new DataJSONWrapper();
                wrapper.ID          = _playChallengeObjectiveDefinitionCodesKey;
                _playChallengeObjectiveDefinitionDataWrapper.Items.Add(wrapper);
            }

            wrapper.Params.Clear();

            // Go through each item
            foreach (KeyValuePair<string, string> item in _playChallengeObjectiveDefinitionCodes)
            {
                wrapper.SetParameterValue(item.Key, $"{item.Value}");
            }
        }

        private void DoDeserializePlayChallengeObjectiveDefinitionCodesFromWrapper()
        {
            _playChallengeObjectiveDefinitionCodes  = new List<KeyValuePair<string, string>>();

            // Get definitionCodesWrapper
            DataJSONWrapper                         wrapper = _playChallengeObjectiveDefinitionDataWrapper.Find(_playChallengeObjectiveDefinitionCodesKey);

            if (wrapper == null) { return; }

            // Go through each item
            foreach (ParameterJSONWrapper param in wrapper.Params)
            {
                KeyValuePair<string, string>        item = new KeyValuePair<string, string>(param.Key, param.Value);
                _playChallengeObjectiveDefinitionCodes.Add(item);
            }
        }

        #endregion
    }
}
