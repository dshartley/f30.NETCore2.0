using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayGames
{
    /// <summary>
    /// Provides SQL Server data access for PlayGame data.
    /// </summary>
    public class PlayGameSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayGameDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            RelativeMemberID,
            LoadLatestOnlyYN,
            LoadRelationalTablesYN
        }

        #region Constructors

        private PlayGameSQLServerDataAccessStrategy() : base() { }

        public PlayGameSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayGames")
        { }

        #endregion

        #region IPlayGameDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by ID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayGameDataAccessStrategy.SelectByID( IDataItemCollection collection,
                                                                    int ID,
                                                                    bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.ID.ToString(), ID);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayGamesSelectByIDLoadRelationalTables", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by ID for PlayAreaPathBuilder.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayGameDataAccessStrategy.SelectByIDForPlayAreaPathBuilder(   IDataItemCollection collection,
                                                                                            int ID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.ID.ToString(), ID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayGamesSelectByIDForPlayAreaPathBuilder", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTablesForPlayAreaPathBuilder(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by RelativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        /// <param name="loadLatestOnlyYN">if set to <c>true</c> [load latest only yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayGameDataAccessStrategy.SelectByRelativeMemberID(   IDataItemCollection collection,
                                                                                    int relativeMemberID,
                                                                                    bool loadLatestOnlyYN,
                                                                                    bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.RelativeMemberID.ToString(), relativeMemberID);
            parameters.Add(StoredProcedureParameterKeys.LoadLatestOnlyYN.ToString(), loadLatestOnlyYN);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayGamesSelectByRelativeMemberID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        #endregion

        #region Protected Override Methods

        /// <summary>
        /// Builds and returns the collection of parameters. Remove the DateCreated parameter, because this data column 
        /// is only returned by select stored procedures and is not a column in the table.
        /// </summary>
        /// <param name="item">The data item.</param>
        /// <param name="outputParameters"></param>
        /// <returns>
        /// A <see cref="ParametersCollection"/> instance.
        /// </returns>
        protected override IParametersCollection BuildParameters(IDataItem item, bool outputParameters)
        {
            // Build the parameter collection in the base class
            IParametersCollection p = base.BuildParameters(item, outputParameters);

            // Remove the DateCreated parameter, because this data column is only returned by select stored procedures
            // and is not a column in the table
            //p.Remove(StoredProcedureParameterKeys.DateCreated.ToString());

            return p;
        }

        /// <summary>
        /// Does the load data set tables.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="System.ApplicationException"></exception>
        protected override void DoLoadDataSetTables(IDataItemCollection collection, DataSet data)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));
            if (data == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "data is nothing"));

            #endregion

            // Get dataAdministratorProvider
            IDataAdministratorProvider dataAdministratorProvider = collection.DataAdministrator.DataAdministratorProvider;

            // Fill the PlayGameData collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator playGameDataDA = dataAdministratorProvider.GetDataAdministrator("PlayGameData");
                if (playGameDataDA != null)
                {
                    playGameDataDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayAreaTokens collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator playAreaTokensDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaTokens");
                if (playAreaTokensDA != null)
                {
                    playAreaTokensDA.Load(data.Tables[2]);
                }
            }

            // Fill the PlayAreaCells collection
            if (data.Tables.Count >= 4)
            {
                IDataAdministrator playAreaCellsDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaCells");
                if (playAreaCellsDA != null)
                {
                    playAreaCellsDA.Load(data.Tables[3]);
                }
            }

            // Fill the PlayAreaCellTypes collection
            if (data.Tables.Count >= 5)
            {
                IDataAdministrator playAreaCellTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaCellTypes");
                if (playAreaCellTypesDA != null)
                {
                    playAreaCellTypesDA.Load(data.Tables[4]);
                }
            }

            // Fill the PlayAreaTileTypes collection
            if (data.Tables.Count >= 6)
            {
                IDataAdministrator playAreaTileTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaTileTypes");
                if (playAreaTileTypesDA != null)
                {
                    playAreaTileTypesDA.Load(data.Tables[5]);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Does the load data set tables for PlayAreaPathBuilder.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="System.ApplicationException"></exception>
        private void DoLoadDataSetTablesForPlayAreaPathBuilder(IDataItemCollection collection, DataSet data)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));
            if (data == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "data is nothing"));

            #endregion

            // Get dataAdministratorProvider
            IDataAdministratorProvider      dataAdministratorProvider = collection.DataAdministrator.DataAdministratorProvider;

            // Fill the PlayAreaCells collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator          playAreaCellsDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaCells");
                if (playAreaCellsDA != null)
                {
                    playAreaCellsDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayAreaCellTypes collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator          playAreaCellTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaCellTypes");
                if (playAreaCellTypesDA != null)
                {
                    playAreaCellTypesDA.Load(data.Tables[2]);
                }
            }
        }

        #endregion
    }
}
