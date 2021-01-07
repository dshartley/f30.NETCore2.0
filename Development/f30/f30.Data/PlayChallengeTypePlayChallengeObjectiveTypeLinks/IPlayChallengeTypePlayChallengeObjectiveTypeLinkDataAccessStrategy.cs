using Smart.Platform.Data;

namespace f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks
{
    /// <summary>
    /// Defines a class which provides data access for PlayChallengeTypePlayChallengeObjectiveTypeLink data.
    /// </summary>
    public interface IPlayChallengeTypePlayChallengeObjectiveTypeLinkDataAccessStrategy
    {
        /// <summary>
        /// Selects the by PlayChallengeTypeID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playChallengeTypeID">The PlayChallengeTypeID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayChallengeTypeID(IDataItemCollection collection, int playChallengeTypeID);

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
