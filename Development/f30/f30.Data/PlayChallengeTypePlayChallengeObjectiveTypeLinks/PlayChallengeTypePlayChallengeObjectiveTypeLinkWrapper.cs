namespace f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks
{
    /// <summary>
    /// A wrapper for a PlayChallengeTypePlayChallengeObjectiveTypeLink item.
    /// </summary>
    public class PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper"/> class.
        /// </summary>
        public PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper() : base()
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
                return "PlayChallengeTypePlayChallengeObjectiveTypeLink";
            }
        }

        #endregion

        #region Public Methods

        private int _playChallengeTypeID;

        public int PlayChallengeTypeID
        {
            get { return _playChallengeTypeID; }
            set { _playChallengeTypeID = value; }
        }

        private int _playChallengeObjectiveTypeID;

        public int PlayChallengeObjectiveTypeID
        {
            get { return _playChallengeObjectiveTypeID; }
            set { _playChallengeObjectiveTypeID = value; }

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
