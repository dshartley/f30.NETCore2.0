using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayExperiences
{
    /// <summary>
    /// Provides SQL Server data access for PlayExperience data.
    /// </summary>
    public class PlayExperienceSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayExperienceDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            PlaySubsetID,
            PlayExperienceID,
            PlayExperienceKeywords,
            PlayChallengeObjectiveCodes,
            RelativeMemberID,
            LoadRelationalTablesYN
        }

        #region Constructors

        private PlayExperienceSQLServerDataAccessStrategy() : base() { }

        public PlayExperienceSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayExperiences")
        { }

        #endregion

        #region IPlayExperienceDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by KeywordIndex.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The play subset identifier.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        IDataItemCollection IPlayExperienceDataAccessStrategy.SelectByKeywordIndex( IDataItemCollection collection,
                                                                                    int playSubsetID,
                                                                                    string playExperienceKeywords,
                                                                                    bool loadRelationalTablesYN)
        {
            #region Check Parameters

            if (string.IsNullOrEmpty(playExperienceKeywords)) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "playExperienceKeywords is nothing"));
            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);
            parameters.Add(StoredProcedureParameterKeys.PlayExperienceKeywords.ToString(), playExperienceKeywords);
            parameters.Add(StoredProcedureParameterKeys.LoadRelationalTablesYN.ToString(), loadRelationalTablesYN);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayExperiencesSelectByKeywordIndex", parameters);

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
        IDataItemCollection IPlayExperienceDataAccessStrategy.SelectByPlaySubsetID(IDataItemCollection collection,
                                                                                    int playSubsetID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayExperiencesSelectByPlaySubsetID", parameters);

            // Fill the collection with the loaded data
            this.FillCollection(collection, data.Tables[0]);

            // Process the additional dataset tables
            this.DoLoadDataSetTables(collection, data);

            return collection;
        }

        /// <summary>
        /// Populates the KeywordIndex for PlayExperience.
        /// </summary>
        /// <param name="playExperienceID"></param>
        /// <param name="playSubsetID"></param>
        /// <param name="playExperienceKeywords"></param>
        void IPlayExperienceDataAccessStrategy.PopulateKeywordIndex(int playExperienceID,
                                                                    int playSubsetID,
                                                                    string playExperienceKeywords)
        {
            #region Check Parameters

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.ID.ToString(), playExperienceID);
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);
            parameters.Add(StoredProcedureParameterKeys.PlayExperienceKeywords.ToString(), (playExperienceKeywords == null) ? String.Empty : playExperienceKeywords);

            // Call the stored procedure
            this.RunProcedureCommand("sp_PlayExperiencesPopulateKeywordIndex", parameters);
        }

        /// <summary>
        /// Populates the KeywordPlayChallengeObjectiveCodeIndex for PlayExperience.
        /// </summary>
        /// <param name="playExperienceID">The playExperienceID.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        void IPlayExperienceDataAccessStrategy.PopulateKeywordPlayChallengeObjectiveCodeIndex(  int playExperienceID,
                                                                                                int playSubsetID,
                                                                                                string playExperienceKeywords,
                                                                                                string playChallengeObjectiveCodes)
        {
            #region Check Parameters

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.ID.ToString(), playExperienceID);
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);
            parameters.Add(StoredProcedureParameterKeys.PlayExperienceKeywords.ToString(), (playExperienceKeywords == null) ? String.Empty : playExperienceKeywords);
            parameters.Add(StoredProcedureParameterKeys.PlayChallengeObjectiveCodes.ToString(), (playChallengeObjectiveCodes == null) ? String.Empty : playChallengeObjectiveCodes);

            // Call the stored procedure
            this.RunProcedureCommand("sp_PlayExperiencesPopulateKeywordPlayChallengeObjectiveCodeIndex", parameters);
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

            // Fill the PlayExperienceSteps collection
            if (data.Tables.Count >= 2)
            {
                IDataAdministrator      playExperienceStepsDA = dataAdministratorProvider.GetDataAdministrator("PlayExperienceSteps");
                if (playExperienceStepsDA != null)
                {
                    playExperienceStepsDA.Load(data.Tables[1]);
                }
            }

            // Fill the PlayExperiencePlayExperienceStepLinks collection
            if (data.Tables.Count >= 3)
            {
                IDataAdministrator playExperiencePlayExperienceStepLinksDA = dataAdministratorProvider.GetDataAdministrator("PlayExperiencePlayExperienceStepLinks");
                if (playExperiencePlayExperienceStepLinksDA != null)
                {
                    playExperiencePlayExperienceStepLinksDA.Load(data.Tables[2]);
                }
            }
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
