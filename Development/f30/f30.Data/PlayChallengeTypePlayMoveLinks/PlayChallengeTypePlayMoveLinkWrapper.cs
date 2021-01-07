namespace f30.Data.PlayChallengeTypePlayMoveLinks
{
    /// <summary>
    /// A wrapper for a PlayChallengeTypePlayMoveLink item.
    /// </summary>
    public class PlayChallengeTypePlayMoveLinkWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayChallengeTypePlayMoveLinkWrapper"/> class.
        /// </summary>
        public PlayChallengeTypePlayMoveLinkWrapper() : base()
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
                return "PlayChallengeTypePlayMoveLink";
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

        private int _playMoveID;

        public int PlayMoveID
        {
            get { return _playMoveID; }
            set { _playMoveID = value; }

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
