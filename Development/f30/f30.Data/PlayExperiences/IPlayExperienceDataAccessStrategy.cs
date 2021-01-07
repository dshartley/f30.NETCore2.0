using Smart.Platform.Data;

namespace f30.Data.PlayExperiences
{
    /// <summary>
    /// Defines a class which provides data access for PlayExperience data.
    /// </summary>
    public interface IPlayExperienceDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by KeywordIndex.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The play subset identifier.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        /// <param name="loadRelationalTablesYN">if set to <c>true</c> [load relational tables yn].</param>
        /// <returns></returns>
        IDataItemCollection SelectByKeywordIndex(   IDataItemCollection collection, 
                                                    int playSubsetID,
                                                    string playExperienceKeywords,
                                                    bool loadRelationalTablesYN);

        /// <summary>
        /// Selects the by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlaySubsetID(IDataItemCollection collection,
                                                    int playSubsetID);

        /// <summary>
        /// Populates the KeywordIndex for PlayExperience.
        /// </summary>
        /// <param name="playExperienceID">The playExperienceID.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        void PopulateKeywordIndex(  int playExperienceID,
                                    int playSubsetID,
                                    string playExperienceKeywords);

        /// <summary>
        /// Populates the KeywordPlayChallengeObjectiveCodeIndex for PlayExperience.
        /// </summary>
        /// <param name="playExperienceID">The playExperienceID.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        /// <param name="playChallengeObjectiveCodes">The playChallengeObjectiveCodes.</param>
        void PopulateKeywordPlayChallengeObjectiveCodeIndex(int playExperienceID,
                                    int playSubsetID,
                                    string playExperienceKeywords,
                                    string playChallengeObjectiveCodes);
    }
}
