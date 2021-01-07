﻿using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayResults
{
    /// <summary>
    /// Manages PlayResult data.
    /// </summary>
    public class PlayResultDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayResultDataAdministrator() : base() { }

        public PlayResultDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayResultCollection(this, _defaultCultureInfoName);
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
        public List<PlayResultWrapper> ToWrappers()
        {
            List<PlayResultWrapper> result = new List<PlayResultWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayResultWrapper wrapper = ((PlayResult)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by relativeMemberID.
        /// </summary>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        public void LoadItemsByRelativeMemberID(int relativeMemberID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayResultDataAccessStrategy)_dataAccessStrategy).SelectByRelativeMemberID(   _items,
                                                                                                    relativeMemberID);
            this.DoAfterLoad();
        }

        #endregion
    }
}
