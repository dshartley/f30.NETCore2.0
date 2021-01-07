using Smart.Platform.Data;

namespace f30.Data.PlayAreaCellTypes
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaCellType data.
    /// </summary>
    public interface IPlayAreaCellTypeDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlaySubsetID(   IDataItemCollection collection,
                                                    int playSubsetID);
    }
}
