using Smart.Platform.Data;

namespace f30.Data.PlayChallengeTypePlayMoveLinks
{
    /// <summary>
    /// Defines a class which provides data access for PlayChallengeTypePlayMoveLink data.
    /// </summary>
    public interface IPlayChallengeTypePlayMoveLinkDataAccessStrategy
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
