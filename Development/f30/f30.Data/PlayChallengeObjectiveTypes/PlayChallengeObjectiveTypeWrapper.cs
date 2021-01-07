namespace f30.Data.PlayChallengeObjectiveTypes
{
    /// <summary>
    /// A wrapper for a PlayChallengeObjectiveType item.
    /// </summary>
    public class PlayChallengeObjectiveTypeWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayChallengeObjectiveTypeWrapper"/> class.
        /// </summary>
        public PlayChallengeObjectiveTypeWrapper() : base()
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
                return "PlayChallengeObjectiveType";
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

        private string _onCompleteData;

        public string OnCompleteData
        {
            get { return _onCompleteData; }
            set { _onCompleteData = value; }
        }

        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _definitionData;

        public string DefinitionData
        {
            get { return _definitionData; }
            set { _definitionData = value; }
        }

        #endregion
    }
}
