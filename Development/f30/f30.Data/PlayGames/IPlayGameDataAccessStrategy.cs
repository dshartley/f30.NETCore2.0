using Smart.Platform.Data;

namespace f30.Data.PlayGames
{
    /// <summary>
    /// Defines a class which provides data access for PlayGame data.
    /// </summary>
    public interface IPlayGameDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by ID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="ID">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByID( IDataItemCollection collection, 
                                        int ID,
                                        bool loadRelationalTablesYN);

        /// <summary>
        /// Selects the items by ID for PlayAreaPathBuilder.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        IDataItemCollection SelectByIDForPlayAreaPathBuilder(   IDataItemCollection collection,
                                                                int ID);

        /// <summary>
        /// Selects the items by RelativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="loadLatestOnlyYN">if set to <c>true</c> [load latest only yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByRelativeMemberID(   IDataItemCollection collection,
                                                        int relativeMemberID,
                                                        bool loadLatestOnlyYN,
                                                        bool loadRelationalTablesYN);
    }
}
