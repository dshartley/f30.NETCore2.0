using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;
using f30.Core;
using f30.Data.PlayExperienceSteps;

namespace f30.Data.PlayExperiences
{
    /// <summary>
    /// Manages PlayExperience data.
    /// </summary>
    public class PlayExperienceDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayExperienceDataAdministrator() : base() { }

        public PlayExperienceDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayExperienceCollection(this, _defaultCultureInfoName);
        }

        /// <summary>
        /// Sets up the foreign keys. To set up a foreign key get the data administrator for the relevant foreign key
        /// from the data administrator provider and handle the DataItemPrimaryKeyModified event. In handling this event
        /// update the foreign key of items in the collection accordingly.
        /// </summary>
        protected override void SetupForeignKeys()
        {
            // No foreign keys
        }

        #endregion

        #region Public Override Methods

        public override void HandleDataItemModified(IDataItem item, int propertyEnum, string message)
        {
            #region Check Parameters

            if (item == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "item is nothing"));
            if (message == string.Empty) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "message is nothing"));

            #endregion

            this.OnDataItemModified(item, propertyEnum, message);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To the wrappers.
        /// </summary>
        /// <returns></returns>
        public List<PlayExperienceWrapper> ToWrappers()
        {
            List<PlayExperienceWrapper> result = new List<PlayExperienceWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayExperienceWrapper wrapper = ((PlayExperience)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by KeywordIndex.
        /// </summary>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByKeywordIndex(int playSubsetID,
                                            string playExperienceKeywords,
                                            bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayExperienceDataAccessStrategy)_dataAccessStrategy).SelectByKeywordIndex( _items,
                                                                                                    playSubsetID,
                                                                                                    playExperienceKeywords,
                                                                                                    loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by playSubsetID.
        /// </summary>
        /// <param name="relativeMemberID">The playSubsetID.</param>
        public void LoadItemsByPlaySubsetID(int playSubsetID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayExperienceDataAccessStrategy)_dataAccessStrategy).SelectByPlaySubsetID(_items,
                                                                                                    playSubsetID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Populates the KeywordIndex for items in the collection.
        /// </summary>
        public void PopulateKeywordIndex()
        {
            // Get groupName
            string                      groupName = IndexDefinitionGroups.General.ToString();

            // Go through each item
            foreach (IDataItem item in _items.Items)
            {
                // Create PlayExperienceWrapper
                PlayExperienceWrapper   wrapper = ((PlayExperience)item).ToWrapper();

                wrapper.DeserializeIndexDefinitionData();

                // Get playExperienceKeywords
                string                  playExperienceKeywords = wrapper.GetConcatenatedIndexDefinitionKeywords(groupName);

                ((IPlayExperienceDataAccessStrategy)_dataAccessStrategy).PopulateKeywordIndex(  wrapper.ID,
                                                                                                wrapper.PlaySubsetID,
                                                                                                playExperienceKeywords);
            }
        }

        /// <summary>
        /// Populates the KeywordPlayChallengeObjectiveCodeIndex for items in the collection.
        /// </summary>
        /// <param name="playExperienceWrapper">The playExperienceWrapper.</param>
        /// <param name="playExperienceStepWrappers">The playExperienceStepWrappers.</param>
        public void PopulateKeywordPlayChallengeObjectiveCodeIndex( PlayExperienceWrapper playExperienceWrapper,
                                                                    List<PlayExperienceStepWrapper> playExperienceStepWrappers)
        {
            #region Check Parameters

            if (playExperienceWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceWrapper is nothing"));
            if (playExperienceStepWrappers == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepWrappers is nothing"));

            #endregion

            // Get groupName
            string      groupName = IndexDefinitionGroups.General.ToString();

            playExperienceWrapper.DeserializeIndexDefinitionData();
            playExperienceWrapper.DeserializePlayChallengeObjectiveDefinitionData();

            // Get playExperienceKeywords
            string      playExperienceKeywords = playExperienceWrapper.GetConcatenatedIndexDefinitionKeywords(groupName);

            // Get playChallengeObjectiveCodes
            string      playChallengeObjectiveCodes = this.DoGetConcatenatedPlayChallengeObjectiveDefinitionCodes(  playExperienceWrapper,
                                                                                                                    playExperienceStepWrappers);

            ((IPlayExperienceDataAccessStrategy)_dataAccessStrategy).PopulateKeywordPlayChallengeObjectiveCodeIndex(playExperienceWrapper.ID,
                                                                                                                    playExperienceWrapper.PlaySubsetID,
                                                                                                                    playExperienceKeywords,
                                                                                                                    playChallengeObjectiveCodes);
        }

        #endregion

        #region Private Methods

        public string DoGetConcatenatedPlayChallengeObjectiveDefinitionCodes(   PlayExperienceWrapper playExperienceWrapper,
                                                                                List<PlayExperienceStepWrapper> playExperienceStepWrappers)
        {
            #region Check Parameters

            if (playExperienceWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceWrapper is nothing"));
            if (playExperienceStepWrappers == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceStepWrappers is nothing"));

            #endregion

            string          result = string.Empty;

            result          += playExperienceWrapper.GetConcatenatedPlayChallengeObjectiveDefinitionCodes();

            // Go through each item
            foreach (PlayExperienceStepWrapper item in playExperienceStepWrappers)
            {
                item.DeserializePlayChallengeObjectiveDefinitionData();

                // Get playChallengeObjectiveCodes
                string      playChallengeObjectiveCodes = item.GetConcatenatedPlayChallengeObjectiveDefinitionCodes();

                result      += (!string.IsNullOrEmpty(result)) ? $",{playChallengeObjectiveCodes}" : playChallengeObjectiveCodes;
            }

            return result;
        }

        #endregion
    }
}
