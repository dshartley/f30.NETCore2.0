namespace f30.Data.PlayExperienceStepPlayExperienceStepExerciseLinks
{
    /// <summary>
    /// A wrapper for a PlayExperienceStepPlayExperienceStepExerciseLink item.
    /// </summary>
    public class PlayExperienceStepPlayExperienceStepExerciseLinkWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperienceStepPlayExperienceStepExerciseLinkWrapper"/> class.
        /// </summary>
        public PlayExperienceStepPlayExperienceStepExerciseLinkWrapper() : base()
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
                return "PlayExperienceStepPlayExperienceStepExerciseLink";
            }
        }

        #endregion

        #region Public Methods

        private int _playExperienceStepID;

        public int PlayExperienceStepID
        {
            get { return _playExperienceStepID; }
            set { _playExperienceStepID = value; }
        }

        private int _playExperienceStepExerciseID;

        public int PlayExperienceStepExerciseID
        {
            get { return _playExperienceStepExerciseID; }
            set { _playExperienceStepExerciseID = value; }

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
