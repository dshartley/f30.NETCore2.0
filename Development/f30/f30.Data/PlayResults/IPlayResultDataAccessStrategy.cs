using Smart.Platform.Data;

namespace f30.Data.PlayResults
{
    /// <summary>
    /// Defines a class which provides data access for PlayResult data.
    /// </summary>
    public interface IPlayResultDataAccessStrategy
    {

        /// <summary>
        /// Selects the by relativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByRelativeMemberID(   IDataItemCollection collection, 
                                                        int relativeMemberID);


    }
}
