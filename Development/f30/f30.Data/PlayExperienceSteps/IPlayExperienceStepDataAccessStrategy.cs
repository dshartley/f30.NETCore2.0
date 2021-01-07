using Smart.Platform.Data;

namespace f30.Data.PlayExperienceSteps
{
    /// <summary>
    /// Defines a class which provides data access for PlayExperienceStep data.
    /// </summary>
    public interface IPlayExperienceStepDataAccessStrategy
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
        /// Selects the by playSubsetID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playSubsetID">The playSubsetID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlaySubsetID(IDataItemCollection collection,
                                                    int playSubsetID);
    }
}
