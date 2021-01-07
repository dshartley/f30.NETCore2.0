using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayAreaCellTypes
{
    /// <summary>
    /// Provides SQL Server data access for PlayAreaCellType data.
    /// </summary>
    public class PlayAreaCellTypeSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayAreaCellTypeDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID,
            PlaySubsetID
        }

        #region Constructors

        private PlayAreaCellTypeSQLServerDataAccessStrategy() : base() { }

        public PlayAreaCellTypeSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayAreaCellTypes")
        { }

        #endregion

        #region IPlayAreaCellTypeDataAccessStrategy Methods

        /// <summary>
        /// Selects the items by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        IDataItemCollection IPlayAreaCellTypeDataAccessStrategy.SelectByPlaySubsetID(IDataItemCollection collection,
                                                                                    int playSubsetID)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            // Get the parameters collection
            SQLServerParametersCollection   parameters = new SQLServerParametersCollection();
            parameters.Add(StoredProcedureParameterKeys.PlaySubsetID.ToString(), playSubsetID);

            // Call the stored procedure
            DataSet                         data = this.RunProcedureLoad("sp_PlayAreaCellTypesSelectByPlaySubsetID", parameters);

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
