using Smart.Platform.Data;

namespace f30.Data.PlayMoves
{
    /// <summary>
    /// Defines a class which provides data access for PlayMove data.
    /// </summary>
    public interface IPlayMoveDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlaySubsetID(IDataItemCollection collection,
                                                    int playSubsetID);

        /// <summary>
        /// Selects the items by playAreaCellTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaCellTypeID">The playAreaCellTypeID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayAreaCellTypeID(IDataItemCollection collection,
                                                    int playAreaCellTypeID);

        /// <summary>
        /// Selects the items by playAreaTileTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaTileTypeID">The playAreaTileTypeID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayAreaTileTypeID(IDataItemCollection collection,
                                                    int playAreaTileTypeID);

        /// <summary>
        /// Selects the items by playAreaTileID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaTileID">The playAreaTileID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayAreaTileID( IDataItemCollection collection,
                                                    int playAreaTileID);

        /// <summary>
        /// Selects the items by playGameID CellCoord.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The playGameID.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameIDCellCoord(IDataItemCollection collection,
                                                        int playGameID,
                                                        int column,
                                                        int row);

        /// <summary>
        /// Selects the items by playChallengeTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playChallengeTypeID">The playChallengeTypeID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayChallengeTypeID(IDataItemCollection collection,
                                                    int playChallengeTypeID);
    }
}
