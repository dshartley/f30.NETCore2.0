using Smart.Platform.Data;
using Smart.Platform.Data.DataAccessStrategies;
using Smart.Platform.Data.DataAccessStrategies.SQLServer;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;

namespace f30.Data.PlayAreaPathPoints
{
    /// <summary>
    /// Provides SQL Server data access for PlayAreaPathPoint data.
    /// </summary>
    public class PlayAreaPathPointSQLServerDataAccessStrategy : SQLServerDataAccessStrategyBase, IPlayAreaPathPointDataAccessStrategy
    {
        public enum StoredProcedureParameterKeys
        {
            ID
        }

        #region Constructors

        private PlayAreaPathPointSQLServerDataAccessStrategy() : base() { }

        public PlayAreaPathPointSQLServerDataAccessStrategy(string connectionString,
                                                    CultureInfo cultureInfo)
            : base(connectionString, cultureInfo, "PlayAreaPathPoints")
        { }

        #endregion

        #region IPlayAreaPathPointDataAccessStrategy Methods

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
