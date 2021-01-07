using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex
{
    /// <summary>
    /// Manages PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex data.
    /// </summary>
    public class PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator() : base() { }

        public PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexCollection(this, _defaultCultureInfoName);
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
        public List<PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper> ToWrappers()
        {
            List<PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper> result = new List<PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper wrapper = ((PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by playExperienceKeywords.
        /// </summary>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        public void LoadItemsByPlayExperienceKeywords(int playSubsetID, string playExperienceKeywords)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAccessStrategy)_dataAccessStrategy).SelectByPlayExperienceKeywords(_items,
                                                                                                                                                    playSubsetID, 
                                                                                                                                                    playExperienceKeywords);

            this.DoAfterLoad();
        }

        #endregion
    }
}
