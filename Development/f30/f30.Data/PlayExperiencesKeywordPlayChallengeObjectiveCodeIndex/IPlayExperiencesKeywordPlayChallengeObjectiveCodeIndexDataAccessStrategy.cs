using Smart.Platform.Data;

namespace f30.Data.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex
{
    /// <summary>
    /// Defines a class which provides data access for PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex data.
    /// </summary>
    public interface IPlayExperiencesKeywordPlayChallengeObjectiveCodeIndexDataAccessStrategy
    {
        /// <summary>
        /// Selects items by playExperienceKeywords.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <param name="playExperienceKeywords">The playExperienceKeywords.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayExperienceKeywords( IDataItemCollection collection,
                                                            int playSubsetID,
                                                            string playExperienceKeywords);
    }
}
