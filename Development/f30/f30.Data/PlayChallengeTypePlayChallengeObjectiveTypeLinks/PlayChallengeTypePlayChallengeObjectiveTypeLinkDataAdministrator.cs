﻿using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks
{
    /// <summary>
    /// Manages PlayChallengeTypePlayChallengeObjectiveTypeLink data.
    /// </summary>
    public class PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator() : base() { }

        public PlayChallengeTypePlayChallengeObjectiveTypeLinkDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayChallengeTypePlayChallengeObjectiveTypeLinkCollection(this, _defaultCultureInfoName);
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
        public List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> ToWrappers()
        {
            List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> result = new List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper wrapper = ((PlayChallengeTypePlayChallengeObjectiveTypeLink)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by PlayChallengeTypeID.
        /// </summary>
        /// <param name="playChallengeTypeID">The PlayChallengeTypeID.</param>
        public void LoadItemsByPlayChallengeTypeID(int playChallengeTypeID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayChallengeTypePlayChallengeObjectiveTypeLinkDataAccessStrategy)_dataAccessStrategy).SelectByPlayChallengeTypeID(_items, playChallengeTypeID);

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
            _items = ((IPlayChallengeTypePlayChallengeObjectiveTypeLinkDataAccessStrategy)_dataAccessStrategy).SelectByPlaySubsetID(_items,
                                                                                                    playSubsetID);
            this.DoAfterLoad();
        }

        #endregion
    }
}
