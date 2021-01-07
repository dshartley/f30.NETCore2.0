using Smart.Platform.Data;
using f30.Core;
using System;
using Smart.Platform.Net.Serialization.JSON;
using System.Collections.Generic;
using Smart.Platform.Diagnostics;

namespace f30.Data
{
    /// <summary>
    /// A base class for classes which are wrappers for a DataItem.
    /// </summary>
    public abstract class DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataItemWrapperBase"/> class.
        /// </summary>
        public DataItemWrapperBase()
        {
        }

        #endregion

        #region Public Methods

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _playSubsetID;

        public int PlaySubsetID
        {
            get { return _playSubsetID; }
            set { _playSubsetID = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _indexDefinitionData;

        public string IndexDefinitionData
        {
            get { return _indexDefinitionData; }
            set { _indexDefinitionData = value; }
        }

        private DataItemStatusTypes _status = DataItemStatusTypes.New;

        public DataItemStatusTypes Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <returns></returns>
        public string GetDisplayName()
        {
            return $"<{this.DataType}>_{this.ID}";
        }

        private int _versionID;

        public int VersionID
        {
            get { return _versionID; }
            set { _versionID = value; }
        }

        private DateTime _versionDate;

        public DateTime VersionDate
        {
            get { return _versionDate; }
            set { _versionDate = value; }
        }

        private int _versionOwnerID;

        public int VersionOwnerID
        {
            get { return _versionOwnerID; }
            set { _versionOwnerID = value; }
        }

        private ExportStatusTypes _exportStatus;

        public ExportStatusTypes ExportStatus
        {
            get { return _exportStatus; }
            set { _exportStatus = value; }
        }

        #endregion

        #region Public Abstract Members

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public abstract string DataType { get; }

        #endregion

        #region Public Methods; IndexDefinitionData

        protected DataJSONWrapper _indexDefinitionDataWrapper = null;

        public DataJSONWrapper IndexDefinitionDataWrapper
        {
            get { return _indexDefinitionDataWrapper; }
            set { _indexDefinitionDataWrapper = value; }
        }

        /// <summary>
        /// Deserializes the IndexDefinitionData.
        /// </summary>
        public void DeserializeIndexDefinitionData()
        {
            _indexDefinitionDataWrapper         = new DataJSONWrapper();

            if (!string.IsNullOrEmpty(_indexDefinitionData))
            {
                _indexDefinitionDataWrapper     = JSONHelper.DeserializeToJSON(_indexDefinitionData);
            }

            // Deserialize IndexDefinitions
            this.DoDeserializeIndexDefinitionsFromWrapper();
        }

        /// <summary>
        /// Serializes the IndexDefinitionData.
        /// </summary>
        public void SerializeIndexDefinitionData()
        {
            if (_indexDefinitionDataWrapper == null)
            {
                _indexDefinitionData    = string.Empty;
                return;
            }

            // Serialize IndexDefinitions
            this.DoSerializeIndexDefinitionsToWrapper();

            _indexDefinitionData        = JSONHelper.SerializeFromJSON(_indexDefinitionDataWrapper);
        }

        private Dictionary<string, List<KeyValuePair<string, string>>> _indexDefinitions;

        public Dictionary<string, List<KeyValuePair<string, string>>> IndexDefinitions
        {
            get { return _indexDefinitions; }
        }

        /// <summary>
        /// Adds the IndexDefinition.
        /// </summary>
        /// <param name="groupKey">The group key.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddIndexDefinition(string groupKey, string key, string value)
        {
            if (_indexDefinitions == null) { return; }

            // Get group
            List<KeyValuePair<string, string>>      group = (_indexDefinitions.ContainsKey(groupKey)) ? _indexDefinitions[groupKey] : null;

            if (group == null)
            {

                group                               = new List<KeyValuePair<string, string>>();
                _indexDefinitions[groupKey]         = group;
            }

            int index = this.DoFindIndexDefinition(groupKey, key);

            if (index < 0) { group.Add(new KeyValuePair<string, string>(key, value)); }
        }

        /// <summary>
        /// Removes the IndexDefinition.
        /// </summary>
        /// <param name="groupKey">The group key.</param>
        /// <param name="key">The key.</param>
        public void RemoveIndexDefinition(string groupKey, string key)
        {
            if (!_indexDefinitions.ContainsKey(groupKey)) { return; }

            // Get group
            List<KeyValuePair<string, string>>      group = _indexDefinitions[groupKey];

            int                                     index = this.DoFindIndexDefinition(groupKey, key);

            if (index >= 0)
            {
                group.RemoveAt(index);

                // Remove empty group
                if (group.Count == 0) { _indexDefinitions.Remove(groupKey); }
            }
        }

        /// <summary>
        /// Determines whether the IndexDefinition exist.
        /// </summary>
        /// <param name="groupKey">The group key.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if IndexDefinition exists; otherwise, <c>false</c>.
        /// </returns>
        public bool HasIndexDefinitionYN(string groupKey, string key)
        {
            bool result = false;

            if (_indexDefinitions == null) { return false; }

            int index = this.DoFindIndexDefinition(groupKey, key);

            if (index >= 0) { result = true; }

            return result;
        }

        /// <summary>
        /// Gets the index keywords concatenated.
        /// </summary>
        /// <param name="groupKey">The group key.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string GetConcatenatedIndexDefinitionKeywords(string groupKey)
        {
            #region Check Parameters

            if (_indexDefinitionDataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "_indexDefinitionDataWrapper is nothing"));

            #endregion

            string result = "";

            if (!_indexDefinitions.ContainsKey(groupKey)) { return result; }

            // Get group
            List<KeyValuePair<string, string>>      group = _indexDefinitions[groupKey];

            // Go through each item
            foreach (KeyValuePair<string, string> item in group)
            {
                if (!string.IsNullOrEmpty(result)) { result += ","; }

                result                              += item.Key;
            }

            return result;
        }

        #endregion

        #region Private Methods; IndexDefinitions

        private int DoFindIndexDefinition(string groupKey, string key)
        {
            int                                     result = -1;

            if (_indexDefinitions == null) { return result; }
            if (!_indexDefinitions.ContainsKey(groupKey)) { return result; }

            // Get group
            List<KeyValuePair<string, string>>      group = _indexDefinitions[groupKey];

            // Go through each item
            for (int i = 0; i < group.Count; i++)
            {
                // Get item
                KeyValuePair<string, string>        item = group[i];

                if (item.Key == key)
                {
                    result                          = i;
                    break;
                }
            }

            return result;
        }

        private void DoSerializeIndexDefinitionsToWrapper()
        {
            _indexDefinitionDataWrapper                 = new DataJSONWrapper();

            // Go through each item
            foreach (KeyValuePair<string, List<KeyValuePair<string, string>>> kv in _indexDefinitions)
            {
                // Get group
                List<KeyValuePair<string, string>>      group = kv.Value;

                // Get groupWrapper
                DataJSONWrapper                         groupWrapper = new DataJSONWrapper();

                // Create groupWrapper
                groupWrapper                            = new DataJSONWrapper();
                groupWrapper.ID                         = kv.Key;
                _indexDefinitionDataWrapper.Items.Add(groupWrapper);

                // Go through each item
                foreach (KeyValuePair<string, string> item in group)
                {
                    groupWrapper.SetParameterValue(item.Key, $"{item.Value}");
                }
            }
        }

        private void DoDeserializeIndexDefinitionsFromWrapper()
        {
            _indexDefinitions                           = new Dictionary<string, List<KeyValuePair<string, string>>>();

            // Go through each item
            foreach (DataJSONWrapper item in _indexDefinitionDataWrapper.Items)
            {
                // Get groupKey
                string                                  groupKey = item.ID;

                // Create group
                List<KeyValuePair<string, string>>      group = new List<KeyValuePair<string, string>>();

                // Go through each item
                foreach (ParameterJSONWrapper param in item.Params)
                {
                    KeyValuePair<string, string>        kv = new KeyValuePair<string, string>(param.Key, param.Value);
                    group.Add(kv);
                }

                _indexDefinitions[groupKey]             = group;
            }
        }

        #endregion
    }
}
