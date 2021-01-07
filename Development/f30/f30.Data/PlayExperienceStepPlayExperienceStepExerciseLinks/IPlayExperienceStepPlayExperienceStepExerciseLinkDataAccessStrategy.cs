using Smart.Platform.Data;

namespace f30.Data.PlayExperienceStepPlayExperienceStepExerciseLinks
{
    /// <summary>
    /// Defines a class which provides data access for PlayExperienceStepPlayExperienceStepExerciseLink data.
    /// </summary>
    public interface IPlayExperienceStepPlayExperienceStepExerciseLinkDataAccessStrategy
    {
        /// <summary>
        /// Selects the by PlayExperienceStepID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playExperienceStepID">The PlayExperienceStepID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayExperienceStepID(IDataItemCollection collection, int playExperienceStepID);

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
