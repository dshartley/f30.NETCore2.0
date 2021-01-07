using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayMoves
{
    /// <summary>
    /// Provides SQL Server data access for PlayMove data.
    /// </summary>
    public class PlayMoveSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayMoveDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            RelativeMemberID,
            PlaySubsetID,
            PlayAreaCellTypeID,
            PlayAreaTileTypeID,
            PlayChallengeTypeID,
            PlayAreaTileID,
            PlayGameID,
            Column,
            Row
        }

        #region Constructors

        private PlayMoveSQLServerDataAccessStrategy() : base() { }

        public PlayMoveSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayMoves")
        { }

        #endregion

        #region IPlayMoveDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayMoveDataAccessStrategy.SelectByPlaySubsetID(   IDataItemCollection collection,
                                                                                int playSubsetID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayMovesSelectByPlaySubsetID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by playAreaCellTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaCellTypeID">The playAreaCellTypeID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayMoveDataAccessStrategy.SelectByPlayAreaCellTypeID(IDataItemCollection collection,
                                                                                int playAreaCellTypeID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayAreaCellTypeID.ToString(), playAreaCellTypeID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayMovesSelectByPlayAreaCellTypeID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by playAreaTileTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaTileTypeID">The playAreaTileTypeID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayMoveDataAccessStrategy.SelectByPlayAreaTileTypeID(IDataItemCollection collection,
                                                                                int playAreaTileTypeID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection       parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayAreaTileTypeID.ToString(), playAreaTileTypeID);

            // Call the stored procedure
            DataSet                             data = this.RunProcedureLoad("sp_PlayMovesSelectByPlayAreaTileTypeID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by playAreaTileID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaTileID">The playAreaTileID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayMoveDataAccessStrategy.SelectByPlayAreaTileID(IDataItemCollection collection,
                                                                                int playAreaTileID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection       parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayAreaTileID.ToString(), playAreaTileID);

            // Call the stored procedure
            DataSet                             data = this.RunProcedureLoad("sp_PlayMovesSelectByPlayAreaTileID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by playGameID CellCoord.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayMoveDataAccessStrategy.SelectByPlayGameIDCellCoord(IDataItemCollection collection,
                                                    int playGameID,
                                                    int column,
                                                    int row)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection       parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);
            parameters.Add(StoredProcedureParameterKeys.Column.ToString(), column);
            parameters.Add(StoredProcedureParameterKeys.Row.ToString(), row);

            // Call the stored procedure
            DataSet                             data = this.RunProcedureLoad("sp_PlayMovesSelectByPlayGameIDCellCoord", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by playChallengeTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playChallengeTypeID">The playChallengeTypeID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayMoveDataAccessStrategy.SelectByPlayChallengeTypeID(IDataItemCollection collection,
                                                                                int playChallengeTypeID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayChallengeTypeID.ToString(), playChallengeTypeID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayMovesSelectByPlayChallengeTypeID", parameters);

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

        #endregion

        #region Private Methods

        #endregion
    }
}
