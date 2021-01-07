using Smart.Platform.Data;

namespace f30.Data.PlayAreaTokens
{
    /// <summary>
    /// Defines a class which provides data access for PlayAreaToken data.
    /// </summary>
    public interface IPlayAreaTokenDataAccessStrategy
    {
        /// <summary>
        /// Selects the items by PlayGameID.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="playGameID">The play game identifier.</param>
        /// <returns></returns>
        IDataItemCollection SelectByPlayGameID( IDataItemCollection collection, 
                                                int playGameID);    
    }
}
