using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayMoves
{
    /// <summary>
    /// Manages PlayMove data.
    /// </summary>
    public class PlayMoveDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayMoveDataAdministrator() : base() { }

        public PlayMoveDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayMoveCollection(this, _defaultCultureInfoName);
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
        public List<PlayMoveWrapper> ToWrappers()
        {
            List<PlayMoveWrapper> result = new List<PlayMoveWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayMoveWrapper wrapper = ((PlayMove)item).ToWrapper();

                    result.Add(wrapper);
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the items by playSubsetID.
        /// </summary>
        /// <param name="playSubsetID">The playSubsetID.</param>
        public void LoadItemsByPlaySubsetID(int playSubsetID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayMoveDataAccessStrategy)_dataAccessStrategy).SelectByPlaySubsetID(   _items,
                                                                                                playSubsetID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by playAreaCellTypeID.
        /// </summary>
        /// <param name="playAreaCellTypeID">The playAreaCellTypeID.</param>
        public void LoadItemsByPlayAreaCellTypeID(int playAreaCellTypeID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayMoveDataAccessStrategy)_dataAccessStrategy).SelectByPlayAreaCellTypeID(_items,
                                                                                                playAreaCellTypeID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by playAreaTileTypeID.
        /// </summary>
        /// <param name="playAreaTileTypeID">The playAreaTileTypeID.</param>
        public void LoadItemsByPlayAreaTileTypeID(int playAreaTileTypeID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayMoveDataAccessStrategy)_dataAccessStrategy).SelectByPlayAreaTileTypeID(_items,
                                                                                                playAreaTileTypeID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by playAreaTileID.
        /// </summary>
        /// <param name="playAreaTileID">The playAreaTileID.</param>
        public void LoadItemsByPlayAreaTileID(int playAreaTileID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayMoveDataAccessStrategy)_dataAccessStrategy).SelectByPlayAreaTileID(_items,
                                                                                                playAreaTileID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by playGameID CellCoord.
        /// </summary>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        public void LoadItemsByPlayGameIDCellCoord(int playGameID, int column, int row)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayMoveDataAccessStrategy)_dataAccessStrategy).SelectByPlayGameIDCellCoord(    _items,
                                                                                                        playGameID, 
                                                                                                        column, 
                                                                                                        row);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by playChallengeTypeID.
        /// </summary>
        /// <param name="playChallengeTypeID">The playChallengeTypeID.</param>
        public void LoadItemsByPlayChallengeTypeID(int playChallengeTypeID)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayMoveDataAccessStrategy)_dataAccessStrategy).SelectByPlayChallengeTypeID(_items,
                                                                                                playChallengeTypeID);
            this.DoAfterLoad();
        }

        #endregion
    }
}
