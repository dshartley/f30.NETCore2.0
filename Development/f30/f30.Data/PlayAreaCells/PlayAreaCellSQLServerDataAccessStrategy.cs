using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayAreaCells
{
    /// <summary>
    /// Provides SQL Server data access for PlayAreaCell data.
    /// </summary>
    public class PlayAreaCellSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayAreaCellDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            RelativeMemberID,
            PlayGameID,
            FromColumn,
            ToColumn,
            FromRow,
            ToRow,
            IsSpecialYN,
            LoadRelationalTablesYN
        }

        #region Constructors

        private PlayAreaCellSQLServerDataAccessStrategy() : base() { }

        public PlayAreaCellSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayAreaCells")
        { }

        #endregion

        #region IPlayAreaCellDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by PlayGameID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The playGameID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayAreaCellDataAccessStrategy.SelectByPlayGameID( IDataItemCollection collection,
                                                                                int playGameID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection       parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);

            // Call the stored procedure
            DataSet                             data = this.RunProcedureLoad("sp_PlayAreaCellsSelectByPlayGameID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by PlayGameIDCellCoordRange.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="fromColumn">From column.</param>
        /// <param name="fromRow">From row.</param>
        /// <param name="toColumn">To column.</param>
        /// <param name="toRow">To row.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayAreaCellDataAccessStrategy.SelectByPlayGameIDCellCoordRange(   IDataItemCollection collection,
                                                                                                int relativeMemberID,
                                                                                                int playGameID,
                                                                                                int fromColumn,
                                                                                                int fromRow,
                                                                                                int toColumn,
                                                                                                int toRow,
                                                                                                bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.RelativeMemberID.ToString(), relativeMemberID);
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);
            parameters.Add(StoredProcedureParameterKeys.FromColumn.ToString(), fromColumn);
            parameters.Add(StoredProcedureParameterKeys.FromRow.ToString(), fromRow);
            parameters.Add(StoredProcedureParameterKeys.ToColumn.ToString(), toColumn);
            parameters.Add(StoredProcedureParameterKeys.ToRow.ToString(), toRow);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet data = this.RunProcedureLoad("sp_PlayAreaCellsSelectByPlayGameIDCellCoordRange", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by PlayGameIDIsSpecialYN.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="isSpecialYN">if set to <c>true</c> [is special yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayAreaCellDataAccessStrategy.SelectByPlayGameIDIsSpecialYN(  IDataItemCollection collection,
                                                                                            int relativeMemberID,
                                                                                            int playGameID,
                                                                                            bool isSpecialYN,
                                                                                            bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.RelativeMemberID.ToString(), relativeMemberID);
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);
            parameters.Add(StoredProcedureParameterKeys.IsSpecialYN.ToString(), isSpecialYN);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet data = this.RunProcedureLoad("sp_PlayAreaCellsSelectByPlayGameIDIsSpecialYN", parameters);

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

            // Fill the PlayAreaTiles collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator playAreaTilesDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaTiles");
                if (playAreaTilesDA != null)
                {
                    playAreaTilesDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayAreaTileData collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator playAreaTileDataDA = dataAdministratorProvider.GetDataAdministrator("PlayAreaTileData");
                if (playAreaTileDataDA != null)
                {
                    playAreaTileDataDA.Load(data.Tables[2]);
                }
            }

        }

        #endregion

        #region Private Methods

        #endregion
    }
}
