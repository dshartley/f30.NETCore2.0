using Smart.Platform.Data;

namespace f30.Data.PlayAreaTileTypes
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaTileType data.
    /// </summary>
    public interface IPlayAreaTileTypeDataAccessStrategy
    {
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
