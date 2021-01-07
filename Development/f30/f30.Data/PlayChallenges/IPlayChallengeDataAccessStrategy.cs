using Smart.Platform.Data;

namespace f30.Data.PlayChallenges
{
    /// <summary>
    /// Defines a class which provides data access for PlayChallenge data.
    /// </summary>
    public interface IPlayChallengeDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by ID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByID( IDataItemCollection collection,
                                        int id,
                                        bool loadRelationalTablesYN);

        /// <summary>
        /// Selects the items by PlayGameIDIsActiveYN.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relative member identifier.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <param name="isActiveYN">if set to <c>true</c> [is active yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameIDIsActiveYN(   IDataItemCollection collection, 
                                                            int relativeMemberID,
                                                            int playGameID,
                                                            bool isActiveYN);
    }
}
