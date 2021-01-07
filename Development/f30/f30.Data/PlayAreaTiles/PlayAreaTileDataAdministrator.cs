using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayAreaTiles
{
    /// <summary>
    /// Manages PlayAreaTile data.
    /// </summary>
    public class PlayAreaTileDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayAreaTileDataAdministrator() : base() { }

        public PlayAreaTileDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayAreaTileCollection(this, _defaultCultureInfoName);
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
        public List<PlayAreaTileWrapper> ToWrappers()
        {
            List<PlayAreaTileWrapper> result = new List<PlayAreaTileWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayAreaTileWrapper wrapper = ((PlayAreaTile)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by PlayGameID.
        /// </summary>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByPlayGameID(int playGameID, bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayAreaTileDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameID( _items,
                                                                                                playGameID,
                                                                                                loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by PlayGameID CellCoord.
        /// </summary>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByPlayGameIDCellCoord( int playGameID,
                                                    int column,
                                                    int row,
                                                    bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayAreaTileDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameIDCellCoord(_items,
                                                                                                        playGameID,
                                                                                                        column,
                                                                                                        row,
                                                                                                        loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        #endregion
    }
}
