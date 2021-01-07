using Smart.Platform.Data;

namespace f30.Data.PlaySubsets
{
    /// <summary>
    /// Defines a class which provides data access for PlaySubset data.
    /// </summary>
    public interface IPlaySubsetDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by RelativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <returns></returns>
        IDataItemCollection SelectByRelativeMemberID(IDataItemCollection collection,
                                                        int relativeMemberID);
    }
}
