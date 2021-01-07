using Smart.Platform.Data;

namespace f30.Data.PlayAreaCellTypePlayMoveLinks
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaCellTypePlayMoveLink data.
    /// </summary>
    public interface IPlayAreaCellTypePlayMoveLinkDataAccessStrategy
    {
        /// <summary>
        /// Selects the by PlayAreaCellTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playAreaCellTypeID">The PlayAreaCellTypeID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayAreaCellTypeID(IDataItemCollection collection, int playAreaCellTypeID);

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
