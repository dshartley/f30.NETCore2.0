using Smart.Platform.Data;

namespace f30.Data.PlayAreaTileTypePlayMoveLinks
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaTileTypePlayMoveLink data.
    /// </summary>
    public interface IPlayAreaTileTypePlayMoveLinkDataAccessStrategy
    {
        /// <summary>
        /// Selects the by PlayAreaTileTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaTileTypeID">The PlayAreaTileTypeID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayAreaTileTypeID(IDataItemCollection collection, int playAreaTileTypeID);

        /// <summary>
        /// Selects the by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlaySubsetID(IDataItemCollection collection,
                                                    int playSubsetID);
    }
}
