using Smart.Platform.Data;

namespace f30.Data.PlayChallengeTypes
{
    /// <summary>
    /// Defines a class which provides data access for PlayChallengeType data.
    /// </summary>
    public interface IPlayChallengeTypeDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by ID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByID(IDataItemCollection collection,
                                        int id,
                                        bool loadRelationalTablesYN);

        /// <summary>
        /// Selects the items by PlayChallengeObjectiveCodeIndex.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The play subset identifier.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        /// <param name="loadWholePlayChallengeTypesOnlyYN">if set to <c>true</c> [load whole play challenge types only yn].</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayChallengeObjectiveCodeIndex(IDataItemCollection collection,
                                                                    int playSubsetID,
                                                                    string playChallengeObjectiveCodes,
                                                                    bool loadWholePlayChallengeTypesOnlyYN,
                                                                    bool loadRelationalTablesYN);

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

        /// <summary>
        /// Populates the PlayChallengeObjectiveCodeIndex for PlayChallengeType.
        /// </summary>
        /// <param name="playChallengeTypeID">The playChallengeTypeID.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        void PopulatePlayChallengeObjectiveCodeIndex(   int playChallengeTypeID,
                                                        int playSubsetID,
                                                        string playChallengeObjectiveCodes);
    }
}
