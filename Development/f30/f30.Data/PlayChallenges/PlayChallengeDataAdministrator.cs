using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayChallenges
{
    /// <summary>
    /// Manages PlayChallenge data.
    /// </summary>
    public class PlayChallengeDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayChallengeDataAdministrator() : base() { }

        public PlayChallengeDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayChallengeCollection(this, _defaultCultureInfoName);
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
        public List<PlayChallengeWrapper> ToWrappers()
        {
            List<PlayChallengeWrapper> result = new List<PlayChallengeWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayChallengeWrapper wrapper = ((PlayChallenge)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByID(  int id,
                                    bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayChallengeDataAccessStrategy)_dataAccessStrategy).SelectByID(    _items,
                                                                                            id,
                                                                                            loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by PlayGameIDIsSpecialYN.
        /// </summary>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="isActiveYN">if set to <c>true</c> [is active yn].</param>
        public void LoadItemsByPlayGameIDIsActiveYN(int relativeMemberID,
                                                    int playGameID,
                                                    bool isActiveYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayChallengeDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameIDIsActiveYN(  _items,
                                                                                                            relativeMemberID,
                                                                                                            playGameID,
                                                                                                            isActiveYN);
            this.DoAfterLoad();
        }

        #endregion
    }
}
