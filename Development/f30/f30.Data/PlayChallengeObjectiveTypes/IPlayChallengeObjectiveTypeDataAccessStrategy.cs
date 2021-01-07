using Smart.Platform.Data;

namespace f30.Data.PlayChallengeObjectiveTypes
{
    /// <summary>
    /// Defines a class which provides data access for PlayChallengeObjectiveType data.
    /// </summary>
    public interface IPlayChallengeObjectiveTypeTypeDataAccessStrategy
    {

        /// <summary>
        /// Selects the by relativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByRelativeMemberID(   IDataItemCollection collection, 
                                                        int relativeMemberID);

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
