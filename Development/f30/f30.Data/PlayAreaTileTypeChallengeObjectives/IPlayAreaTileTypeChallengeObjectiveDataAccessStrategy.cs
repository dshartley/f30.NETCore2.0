using Smart.Platform.Data;

namespace f30.Data.PlayAreaTileTypeChallengeObjectives
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaTileTypeChallengeObjective data.
    /// </summary>
    public interface IPlayAreaTileTypeChallengeObjectiveDataAccessStrategy
    {

        /// <summary>
        /// Selects the by relativeMemberID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        /// <returns></returns>
        IDataItemCollection SelectByRelativeMemberID(   IDataItemCollection collection, 
                                                        int relativeMemberID);


    }
}
