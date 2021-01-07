using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayGames
{
    /// <summary>
    /// Manages PlayGame data.
    /// </summary>
    public class PlayGameDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayGameDataAdministrator() : base() { }

        public PlayGameDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayGameCollection(this, _defaultCultureInfoName);
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
        public List<PlayGameWrapper> ToWrappers()
        {
            List<PlayGameWrapper> result = new List<PlayGameWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayGameWrapper wrapper = ((PlayGame)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by ID.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByID(  int ID,
                                    bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayGameDataAccessStrategy)_dataAccessStrategy).SelectByID( _items,
                                                                                    ID,
                                                                                    loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by ID for PlayAreaPathBuilder.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void LoadItemsByIDForPlayAreaPathBuilder(int ID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayGameDataAccessStrategy)_dataAccessStrategy).SelectByIDForPlayAreaPathBuilder(   _items,
                                                                                                            ID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by RelativeMemberID.
        /// </summary>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="loadLatestOnlyYN">if set to <c>true</c> [load latest only yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByRelativeMemberID(int relativeMemberID,
                                                bool loadLatestOnlyYN,
                                                bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayGameDataAccessStrategy)_dataAccessStrategy).SelectByRelativeMemberID(   _items,
                                                                                                    relativeMemberID,
                                                                                                    loadLatestOnlyYN,
                                                                                                    loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        #endregion
    }
}
