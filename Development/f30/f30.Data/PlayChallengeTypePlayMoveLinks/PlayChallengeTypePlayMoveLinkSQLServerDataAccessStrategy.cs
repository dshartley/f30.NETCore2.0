using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayChallengeTypePlayMoveLinks
{
    /// <summary>
    /// Provides SQL Server data access for PlayChallengeTypePlayMoveLink data.
    /// </summary>
    public class PlayChallengeTypePlayMoveLinkSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayChallengeTypePlayMoveLinkDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            RelativeMemberID,
            PlayChallengeTypeID,
            PlaySubsetID
        }

        #region Constructors

        private PlayChallengeTypePlayMoveLinkSQLServerDataAccessStrategy() : base() { }

        public PlayChallengeTypePlayMoveLinkSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayChallengeTypePlayMoveLinks")
        { }

        #endregion

        #region IPlayChallengeTypePlayMoveLinkDataAccessStrategy Methods

        /// <summary>
        /// Selects the by PlayChallengeTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playChallengeTypeID">The PlayChallengeTypeID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        IDataItemCollection IPlayChallengeTypePlayMoveLinkDataAccessStrategy.SelectByPlayChallengeTypeID(   IDataItemCollection collection,
                                                                                                                int playChallengeTypeID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayChallengeTypeID.ToString(), playChallengeTypeID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengeTypePlayMoveLinksSelectByPlayChallengeTypeID", parameters);

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
        IDataItemCollection IPlayChallengeTypePlayMoveLinkDataAccessStrategy.SelectByPlaySubsetID(IDataItemCollection collection,
                                                                                    int playSubsetID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayChallengeTypePlayMoveLinksSelectByPlaySubsetID", parameters);

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
