using Smart.Platform.Data;

namespace f30.Data.PlayAreaCells
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaCell data.
    /// </summary>
    public interface IPlayAreaCellDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by PlayGameID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameID(IDataItemCollection collection,
                                                    int playGameID);

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
        IDataItemCollection SelectByPlayGameIDCellCoordRange(   IDataItemCollection collection,
                                                                int relativeMemberID,
                                                                int playGameID,
                                                                int fromColumn,
                                                                int fromRow,
                                                                int toColumn,
                                                                int toRow,
                                                                bool loadRelationalTablesYN);

        /// <summary>
        /// Selects the items by PlayGameIDIsSpecialYN.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="isSpecialYN">if set to <c>true</c> [is special yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameIDIsSpecialYN(  IDataItemCollection collection,
                                                            int relativeMemberID,
                                                            int playGameID,
                                                            bool isSpecialYN,
                                                            bool loadRelationalTablesYN);
    }
}
