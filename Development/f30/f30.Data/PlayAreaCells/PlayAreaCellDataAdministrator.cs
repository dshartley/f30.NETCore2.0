using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayAreaCells
{
    /// <summary>
    /// Manages PlayAreaCell data.
    /// </summary>
    public class PlayAreaCellDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayAreaCellDataAdministrator() : base() { }

        public PlayAreaCellDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayAreaCellCollection(this, _defaultCultureInfoName);
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
        public List<PlayAreaCellWrapper> ToWrappers()
        {
            List<PlayAreaCellWrapper> result = new List<PlayAreaCellWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayAreaCellWrapper wrapper = ((PlayAreaCell)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by PlayGameID.
        /// </summary>
        /// <param name="playGameID">The play game identifier.</param>
        public void LoadItemsByPlayGameID(int playGameID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayAreaCellDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameID( _items,
                                                                                                playGameID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by PlayGameIDCellCoordRange.
        /// </summary>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="fromColumn">From column.</param>
        /// <param name="fromRow">From row.</param>
        /// <param name="toColumn">To column.</param>
        /// <param name="toRow">To row.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByPlayGameIDCellCoordRange(int relativeMemberID,
                                                        int playGameID,
                                                        int fromColumn,
                                                        int fromRow,
                                                        int toColumn,
                                                        int toRow,
                                                        bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayAreaCellDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameIDCellCoordRange(   _items,
                                                                                                                relativeMemberID,
                                                                                                                playGameID,
                                                                                                                fromColumn,
                                                                                                                fromRow,
                                                                                                                toColumn,
                                                                                                                toRow,
                                                                                                                loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by PlayGameIDIsSpecialYN.
        /// </summary>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="isSpecialYN">if set to <c>true</c> [is special yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByPlayGameIDIsSpecialYN(   int relativeMemberID,
                                                        int playGameID,
                                                        bool isSpecialYN,
                                                        bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayAreaCellDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameIDIsSpecialYN(  _items,
                                                                                                            relativeMemberID,
                                                                                                            playGameID,
                                                                                                            isSpecialYN,
                                                                                                            loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        #endregion
    }
}
