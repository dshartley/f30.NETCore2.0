using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayChallengeTypes
{
    /// <summary>
    /// Provides SQL Server data access for PlayChallengeType data.
    /// </summary>
    public class PlayChallengeTypeSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayChallengeTypeDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            RelativeMemberID,
            PlayChallengeTypeID,
            PlayChallengeObjectiveCodes,
            PlaySubsetID,
            LoadWholePlayChallengeTypesOnlyYN,
            LoadRelationalTablesYN
        }

        #region Constructors

        private PlayChallengeTypeSQLServerDataAccessStrategy() : base() { }

        public PlayChallengeTypeSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayChallengeTypes")
        { }

        #endregion

        #region IPlayChallengeTypeDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by ID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayChallengeTypeDataAccessStrategy.SelectByID(IDataItemCollection collection,
                                                                            int id,
                                                                            bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.ID.ToString(), id);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengeTypesSelectByIDLoadRelationalTables", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by PlayChallengeObjectiveCodeIndex.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The play subset identifier.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        /// <param name="loadWholePlayChallengeTypesOnlyYN">if set to <c>true</c> [load whole play challenge types only yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        IDataItemCollection IPlayChallengeTypeDataAccessStrategy.SelectByPlayChallengeObjectiveCodeIndex(   IDataItemCollection collection,
                                                                                                            int playSubsetID,
                                                                                                            string playChallengeObjectiveCodes,
                                                                                                            bool loadWholePlayChallengeTypesOnlyYN,
                                                                                                            bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (string.IsNullOrEmpty(playChallengeObjectiveCodes)) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playChallengeObjectiveCodes is nothing"));
            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);
            parameters.Add(StoredProcedureParameterKeys.PlayChallengeObjectiveCodes.ToString(), playChallengeObjectiveCodes);
            parameters.Add(StoredProcedureParameterKeys.LoadWholePlayChallengeTypesOnlyYN.ToString(), loadWholePlayChallengeTypesOnlyYN);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengeTypesSelectByPlayChallengeObjectiveCodeIndex", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTablesAfterSelectByPlayChallengeObjectiveCodeIndex(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the by relativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayChallengeTypeDataAccessStrategy.SelectByRelativeMemberID(   IDataItemCollection collection,
                                                                                    int relativeMemberID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.RelativeMemberID.ToString(), relativeMemberID);

            // Call the stored procedure
            DataSet data = this.RunProcedureLoad("sp_PlayChallengeTypesSelectByRelativeMemberID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Selects the items by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayChallengeTypeDataAccessStrategy.SelectByPlaySubsetID(IDataItemCollection collection,
                                                                                    int playSubsetID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengeTypesSelectByPlaySubsetID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Populates the PlayChallengeObjectiveCodeIndex for PlayChallengeType.
        /// </summary>
        /// <param name="playChallengeTypeID">The playChallengeTypeID.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        void IPlayChallengeTypeDataAccessStrategy.PopulatePlayChallengeObjectiveCodeIndex(  int playChallengeTypeID,
                                                                                            int playSubsetID,
                                                                                            string playChallengeObjectiveCodes)
        {
            #region Check Parameters

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.ID.ToString(), playChallengeTypeID);
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);
            parameters.Add(StoredProcedureParameterKeys.PlayChallengeObjectiveCodes.ToString(), (playChallengeObjectiveCodes == null) ? String.Empty : playChallengeObjectiveCodes);

            // Call the stored procedure
            this.RunProcedureCommand("sp_PlayChallengeTypesPopulatePlayChallengeObjectiveCodeIndex", parameters);
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

            // Fill the PlayChallengeObjectiveTypes collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator          playChallengeObjectiveTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeObjectiveTypes");
                if (playChallengeObjectiveTypesDA != null)
                {
                    playChallengeObjectiveTypesDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayChallengeTypePlayChallengeObjectiveTypeLinks collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator          playChallengeTypePlayChallengeObjectiveTypeLinksDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeTypePlayChallengeObjectiveTypeLinks");
                if (playChallengeTypePlayChallengeObjectiveTypeLinksDA != null)
                {
                    playChallengeTypePlayChallengeObjectiveTypeLinksDA.Load(data.Tables[2]);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Does the load data set tables.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="System.ApplicationException"></exception>
        private void DoLoadDataSetTablesAfterSelectByPlayChallengeObjectiveCodeIndex(IDataItemCollection collection, DataSet data)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));
            if (data == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "data is nothing"));

            #endregion

            // Get dataAdministratorProvider
            IDataAdministratorProvider  dataAdministratorProvider = collection.DataAdministrator.DataAdministratorProvider;

            // Fill the PlayChallengeObjectiveTypes collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator      playChallengeObjectiveTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeObjectiveTypes");
                if (playChallengeObjectiveTypesDA != null)
                {
                    playChallengeObjectiveTypesDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayChallengeTypePlayChallengeObjectiveTypeLinks collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator      playChallengeTypePlayChallengeObjectiveTypeLinksDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeTypePlayChallengeObjectiveTypeLinks");
                if (playChallengeTypePlayChallengeObjectiveTypeLinksDA != null)
                {
                    playChallengeTypePlayChallengeObjectiveTypeLinksDA.Load(data.Tables[2]);
                }
            }

            // Fill the PlayMoves collection
            if (data.Tables.Count >= 4)
            {
                IDataAdministrator      playMovesDA = dataAdministratorProvider.GetDataAdministrator("PlayMoves");
                if (playMovesDA != null)
                {
                    playMovesDA.Load(data.Tables[3]);
                }
            }

            // Fill the PlayChallengeTypePlayMoveLinks collection
            if (data.Tables.Count >= 5)
            {
                IDataAdministrator      playChallengeTypePlayMoveLinksDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeTypePlayMoveLinks");
                if (playChallengeTypePlayMoveLinksDA != null)
                {
                    playChallengeTypePlayMoveLinksDA.Load(data.Tables[4]);
                }
            }
        }

        #endregion
    }
}
