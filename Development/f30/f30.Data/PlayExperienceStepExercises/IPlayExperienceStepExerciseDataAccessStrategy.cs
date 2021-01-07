using Smart.Platform.Data;

namespace f30.Data.PlayExperienceStepExercises
{
    /// <summary>
    /// Defines a class which provides data access for PlayExperienceStepExercise data.
    /// </summary>
    public interface IPlayExperienceStepExerciseDataAccessStrategy
    {
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
