using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayAreaTiles
{
    /// <summary>
    /// Provides SQL Server data access for PlayAreaTile data.
    /// </summary>
    public class PlayAreaTileSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayAreaTileDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            RelativeMemberID,
            PlayGameID,
            Column,
            Row,
            LoadRelationalTablesYN
        }

        #region Constructors

        private PlayAreaTileSQLServerDataAccessStrategy() : base() { }

        public PlayAreaTileSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayAreaTiles")
        { }

        #endregion

        #region IPlayAreaTileDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by PlayGameID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayAreaTileDataAccessStrategy.SelectByPlayGameID(IDataItemCollection collection,
                                                                                int playGameID,
                                                                                bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayAreaTilesSelectByPlayGameID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by PlayGameID CellCoord.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayAreaTileDataAccessStrategy.SelectByPlayGameIDCellCoord(IDataItemCollection collection,
                                                                                int playGameID,
                                                                                int column,
                                                                                int row,
                                                                                bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);
            parameters.Add(StoredProcedureParameterKeys.Column.ToString(), column);
            parameters.Add(StoredProcedureParameterKeys.Row.ToString(), row);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayAreaTilesSelectByPlayGameIDCellCoord", parameters);

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
            IDataAdministratorProvider      dataAdministratorProvider = collection.DataAdministrator.DataAdministratorProvider;

            // Fill the PlayAreaTileTypes collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator          playAreaTileTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaTileTypes");
                if (playAreaTileTypesDA != null)
                {
                    playAreaTileTypesDA.Load(data.Tables[1]);
                }
            }
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
