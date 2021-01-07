using f30.Core;

namespace f30.Data.PlaySubsets
{
    /// <summary>
    /// A wrapper for a PlaySubset item.
    /// </summary>
    public class PlaySubsetWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaySubsetWrapper"/> class.
        /// </summary>
        public PlaySubsetWrapper() : base()
        {
        }

        #endregion

        #region Public Override Methods

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public override string DataType
        {
            get
            {
                return "PlaySubset";
            }
        }

        #endregion

        #region Public Methods

        private string _contentData;

        public string ContentData
        {
            get { return _contentData; }
            set { _contentData = value; }
        }

        #endregion
    }
}
