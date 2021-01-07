using f30.Core;

namespace f30.Data.PlayExperienceStepExercises
{
    /// <summary>
    /// A wrapper for a PlayExperienceStepExercise item.
    /// </summary>
    public class PlayExperienceStepExerciseWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperienceStepExerciseWrapper"/> class.
        /// </summary>
        public PlayExperienceStepExerciseWrapper() : base()
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
                return "PlayExperienceStepExercise";
            }
        }

        #endregion

        #region Public Methods

        private PlayExperienceStepExerciseTypes _playExperienceStepExerciseType;

        public PlayExperienceStepExerciseTypes PlayExperienceStepExerciseType
        {
            get { return _playExperienceStepExerciseType; }
            set { _playExperienceStepExerciseType = value; }
        }

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

        #endregion
    }
}
