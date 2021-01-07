using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;
using f30.Core;
using f30.Data.PlayChallengeObjectiveTypes;
using f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks;

namespace f30.Data.PlayChallengeTypes
{
    /// <summary>
    /// Manages PlayChallengeType data.
    /// </summary>
    public class PlayChallengeTypeDataAdministrator : DataAdministratorBase
    {
        #region Constructors

        private PlayChallengeTypeDataAdministrator() : base() { }

        public PlayChallengeTypeDataAdministrator( IDataManagementPolicy       dataManagementPolicy,
                                        IDataAccessStrategy         dataAccessStrategy,
                                        string                      defaultCultureInfoName,
                                        IDataAdministratorProvider  dataAdministratorProvider)
            : base(dataManagementPolicy, dataAccessStrategy, defaultCultureInfoName, dataAdministratorProvider)
        { }

        #endregion

        #region Protected Override Methods

        protected override IDataItemCollection NewCollection()
        {
            return new PlayChallengeTypeCollection(this, _defaultCultureInfoName);
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
        public List<PlayChallengeTypeWrapper> ToWrappers()
        {
            List<PlayChallengeTypeWrapper> result = new List<PlayChallengeTypeWrapper>();

            if (this._items == null) { return result; }

            // Go through each item
            foreach (IDataItem item in this._items.Items)
            {
                // Include items that are not deleted or obsolete
                if (item.Status != DataItemStatusTypes.Deleted && item.Status != DataItemStatusTypes.Obsolete)
                {
                    // Get item wrapper
                    PlayChallengeTypeWrapper wrapper = ((PlayChallengeType)item).ToWrapper();

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
            _items = ((IPlayChallengeTypeDataAccessStrategy)_dataAccessStrategy).SelectByID(_items,
                                                                                            id,
                                                                                            loadRelationalTablesYN);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Loads the items by PlayChallengeObjectiveCodeIndex.
        /// </summary>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        /// <param name="loadWholePlayChallengeTypesOnlyYN">if set to <c>true</c> [load whole play challenge types only yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        public void LoadItemsByPlayChallengeObjectiveCodeIndex( int playSubsetID,
                                                                string playChallengeObjectiveCodes,
                                                                bool loadWholePlayChallengeTypesOnlyYN,
                                                                bool loadRelationalTablesYN)
        {
            #region Check Parameters

            #endregion

            this.SetupCollection();

            // Load the data
            _items = ((IPlayChallengeTypeDataAccessStrategy)_dataAccessStrategy).SelectByPlayChallengeObjectiveCodeIndex(   _items,
                                                                                                                            playSubsetID,
                                                                                                                            playChallengeObjectiveCodes,
                                                                                                                            loadWholePlayChallengeTypesOnlyYN,
                                                                                                                            loadRelationalTablesYN);
            this.DoAfterLoad();
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
            _items = ((IPlayChallengeTypeDataAccessStrategy)_dataAccessStrategy).SelectByRelativeMemberID(   _items,
                                                                                                    relativeMemberID);
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
            _items = ((IPlayChallengeTypeDataAccessStrategy)_dataAccessStrategy).SelectByPlaySubsetID(_items,
                                                                                                    playSubsetID);
            this.DoAfterLoad();
        }

        /// <summary>
        /// Populates the PlayChallengeObjectiveCodeIndex for the item.
        /// </summary>
        /// <param name="playChallengeTypeWrapper">The playChallengeTypeWrapper.</param>
        /// <param name="playChallengeObjectiveTypeWrappers">The playChallengeObjectiveTypeWrappers.</param>
        /// <exception cref="ApplicationException"></exception>
        public void PopulatePlayChallengeObjectiveCodeIndex(PlayChallengeTypeWrapper playChallengeTypeWrapper,
                                                            List<PlayChallengeObjectiveTypeWrapper> playChallengeObjectiveTypeWrappers)
        {
            #region Check Parameters

            if (playChallengeTypeWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypeWrapper is nothing"));
            if (playChallengeObjectiveTypeWrappers == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectiveTypeWrappers is nothing"));

            #endregion

            // Get playChallengeObjectiveCodes
            string playChallengeObjectiveCodes = this.DoGetConcatenatedPlayChallengeObjectiveCodes( playChallengeTypeWrapper,
                                                                                                    playChallengeObjectiveTypeWrappers);

            ((IPlayChallengeTypeDataAccessStrategy)_dataAccessStrategy).PopulatePlayChallengeObjectiveCodeIndex(    playChallengeTypeWrapper.ID,
                                                                                                                    playChallengeTypeWrapper.PlaySubsetID,
                                                                                                                    playChallengeObjectiveCodes);
        }

        #endregion

        #region Private Methods

        public string DoGetConcatenatedPlayChallengeObjectiveCodes( PlayChallengeTypeWrapper playChallengeTypeWrapper,
                                                                    List<PlayChallengeObjectiveTypeWrapper> playChallengeObjectiveTypeWrappers)
        {
            #region Check Parameters

            if (playChallengeTypeWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeTypeWrapper is nothing"));
            if (playChallengeObjectiveTypeWrappers == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectiveTypeWrappers is nothing"));

            #endregion

            string      result = string.Empty;

            // Go through each item
            foreach (PlayChallengeObjectiveTypeWrapper item in playChallengeObjectiveTypeWrappers)
            {
                result  += (!string.IsNullOrEmpty(result)) ? $",{item.Code}" : item.Code;
            }

            return result;
        }

        #endregion
    }
}
