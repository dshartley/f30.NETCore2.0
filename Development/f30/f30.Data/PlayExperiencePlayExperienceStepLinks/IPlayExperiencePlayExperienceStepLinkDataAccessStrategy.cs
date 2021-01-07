using Smart.Platform.Data;

namespace f30.Data.PlayExperiencePlayExperienceStepLinks
{
    /// <summary>
    /// Defines a class which provides data access for PlayExperiencePlayExperienceStepLink data.
    /// </summary>
    public interface IPlayExperiencePlayExperienceStepLinkDataAccessStrategy
    {
        /// <summary>
        /// Selects the by PlayExperienceID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playExperienceID">The PlayExperienceID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayExperienceID(IDataItemCollection collection, int playExperienceID);

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
