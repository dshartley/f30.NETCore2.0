namespace f30.Data.PlayExperiencePlayExperienceStepLinks
{
    /// <summary>
    /// A wrapper for a PlayExperiencePlayExperienceStepLink item.
    /// </summary>
    public class PlayExperiencePlayExperienceStepLinkWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperiencePlayExperienceStepLinkWrapper"/> class.
        /// </summary>
        public PlayExperiencePlayExperienceStepLinkWrapper() : base()
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
                return "PlayExperiencePlayExperienceStepLink";
            }
        }

        #endregion

        #region Public Methods

        private int _playExperienceID;

        public int PlayExperienceID
        {
            get { return _playExperienceID; }
            set { _playExperienceID = value; }
        }

        private int _playExperienceStepID;

        public int PlayExperienceStepID
        {
            get { return _playExperienceStepID; }
            set { _playExperienceStepID = value; }

        }

        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        #endregion
    }
}
