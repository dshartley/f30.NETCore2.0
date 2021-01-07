using f30.Core;
using System;

namespace f30.Data.PlayExperienceStepResults
{
    /// <summary>
    /// A wrapper for a PlayExperienceStepResult item.
    /// </summary>
    public class PlayExperienceStepResultWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperienceStepResultWrapper"/> class.
        /// </summary>
        public PlayExperienceStepResultWrapper() : base()
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
                return "PlayExperienceStepResult";
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

        private DateTime _dateCompleted;

        public DateTime DateCompleted
        {
            get { return _dateCompleted; }
            set { _dateCompleted = value; }
        }

        private bool _repeatedYN;

        public bool RepeatedYN
        {
            get { return _repeatedYN; }
            set { _repeatedYN = value; }
        }

        #endregion
    }
}
