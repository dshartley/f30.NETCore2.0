namespace f30.Data.PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex
{
    /// <summary>
    /// A wrapper for a PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex item.
    /// </summary>
    public class PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper"/> class.
        /// </summary>
        public PlayExperiencesKeywordPlayChallengeObjectiveCodeIndexWrapper() : base()
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
                return "PlayExperiencesKeywordPlayChallengeObjectiveCodeIndex";
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

        private string _playExperienceKeyword;

        public string PlayExperienceKeyword
        {
            get { return _playExperienceKeyword; }
            set { _playExperienceKeyword = value; }
        }

        private string _playChallengeObjectiveCode;

        public string PlayChallengeObjectiveCode
        {
            get { return _playChallengeObjectiveCode; }
            set { _playChallengeObjectiveCode = value; }
        }

        #endregion
    }
}
