using Smart.Platform.Data;

namespace f30.Data.PlayAreaTiles
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaTile data.
    /// </summary>
    public interface IPlayAreaTileDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by PlayGameID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameID(IDataItemCollection collection,
                                                int playGameID,
                                                bool loadRelationalTablesYN);

        /// <summary>
        /// Selects the items by PlayGameID CellCoord.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameIDCellCoord(IDataItemCollection collection,
                                                                int playGameID,
                                                                int column,
                                                                int row,
                                                                bool loadRelationalTablesYN);
    }
}
