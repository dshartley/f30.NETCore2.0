using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayChallenges
{
    /// <summary>
    /// Provides SQL Server data access for PlayChallenge data.
    /// </summary>
    public class PlayChallengeSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayChallengeDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            PlayGameID,
            IsActiveYN,
            RelativeMemberID,
            LoadRelationalTablesYN
        }

        #region Constructors

        private PlayChallengeSQLServerDataAccessStrategy() : base() { }

        public PlayChallengeSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayChallenges")
        { }

        #endregion

        #region IPlayChallengeDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by ID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayChallengeDataAccessStrategy.SelectByID(    IDataItemCollection collection,
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
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengesSelectByIDLoadRelationalTables", parameters);

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
        /// <param name="isActiveYN">if set to <c>true</c> [is active yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayChallengeDataAccessStrategy.SelectByPlayGameIDIsActiveYN(  IDataItemCollection collection,
                                                                                            int relativeMemberID,
                                                                                            int playGameID,
                                                                                            bool isActiveYN)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.RelativeMemberID.ToString(), relativeMemberID);
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);
            parameters.Add(StoredProcedureParameterKeys.IsActiveYN.ToString(), isActiveYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengesSelectByPlayGameIDIsActiveYN", parameters);

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
            IDataAdministratorProvider  dataAdministratorProvider = collection.DataAdministrator.DataAdministratorProvider;

            // Fill the PlayChallengeTypes collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator      playChallengeTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeTypes");
                if (playChallengeTypesDA != null)
                {
                    playChallengeTypesDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayChallengeObjectives collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator      playChallengeObjectivesDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeObjectives");
                if (playChallengeObjectivesDA != null)
                {
                    playChallengeObjectivesDA.Load(data.Tables[2]);
                }
            }

            // Fill the PlayChallengeObjectiveTypes collection
            if (data.Tables.Count >= 4)
            {
                IDataAdministrator      playChallengeObjectiveTypesDA = dataAdministratorProvider.GetDataAdministrator("PlayChallengeObjectiveTypes");
                if (playChallengeObjectiveTypesDA != null)
                {
                    playChallengeObjectiveTypesDA.Load(data.Tables[3]);
                }
            }
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
