using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayChallengeObjectives
{
    /// <summary>
    /// A wrapper for a PlayChallengeObjective item.
    /// </summary>
    public class PlayChallengeObjectiveWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayChallengeObjectiveWrapper"/> class.
        /// </summary>
        public PlayChallengeObjectiveWrapper()
        {
        }

        #endregion

        #region Public Methods

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _relativeMemberID;

        public int RelativeMemberID
        {
            get { return _relativeMemberID; }
            set { _relativeMemberID = value; }
        }

        private int _playChallengeID;

        public int PlayChallengeID
        {
            get { return _playChallengeID; }
            set { _playChallengeID = value; }
        }

        private int _playChallengeObjectiveTypeID;

        public int PlayChallengeObjectiveTypeID
        {
            get { return _playChallengeObjectiveTypeID; }
            set { _playChallengeObjectiveTypeID = value; }
        }

        private bool _isAchievedYN;

        public bool IsAchievedYN
        {
            get { return _isAchievedYN; }
            set { _isAchievedYN = value; }
        }

        private DateTime _dateActive;

        public DateTime DateActive
        {
            get { return _dateActive; }
            set { _dateActive = value; }
        }
        
        #endregion
    }
}
