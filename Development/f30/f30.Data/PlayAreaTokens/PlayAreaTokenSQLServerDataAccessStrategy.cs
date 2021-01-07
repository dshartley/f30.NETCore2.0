using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayAreaTokens
{
    /// <summary>
    /// Provides SQL Server data access for PlayAreaToken data.
    /// </summary>
    public class PlayAreaTokenSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayAreaTokenDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            PlayGameID,
            RelativeMemberID
        }

        #region Constructors

        private PlayAreaTokenSQLServerDataAccessStrategy() : base() { }

        public PlayAreaTokenSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayAreaTokens")
        { }

        #endregion

        #region IPlayAreaTokenDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by PlayGameID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayAreaTokenDataAccessStrategy.SelectByPlayGameID(IDataItemCollection collection,
                                                                                int playGameID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlayGameID.ToString(), playGameID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayAreaTokensSelectByPlayGameID", parameters);

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
