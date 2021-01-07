using System;
using System.Collections.Generic;
using System.Text;
using f30.Data.PlayMoves;
using f30.Data.PlayChallengeObjectives;
using Smart.Platform.Diagnostics;

namespace f30.Data.PlayChallenges
{
    /// <summary>
    /// A wrapper for a PlayChallenge item.
    /// </summary>
    public class PlayChallengeWrapper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayChallengeWrapper"/> class.
        /// </summary>
        public PlayChallengeWrapper()
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

        private int _playGameID;

        public int PlayGameID
        {
            get { return _playGameID; }
            set { _playGameID = value; }
        }

        private int _playMoveID;

        public int PlayMoveID
        {
            get { return _playMoveID; }
            set { _playMoveID = value; }
        }

        private int _playChallengeTypeID;

        public int PlayChallengeTypeID
        {
            get { return _playChallengeTypeID; }
            set { _playChallengeTypeID = value; }
        }

        private bool _isActiveYN;

        public bool IsActiveYN
        {
            get { return _isActiveYN; }
            set { _isActiveYN = value; }
        }

        private bool _isCompleteYN;

        public bool IsCompleteYN
        {
            get { return _isCompleteYN; }
            set { _isCompleteYN = value; }
        }

        private DateTime _dateActive;

        public DateTime DateActive
        {
            get { return _dateActive; }
            set { _dateActive = value; }
        }

        #endregion

        #region Public Methods; PlayMoveWrapper

        private PlayMoveWrapper _playMoveWrapper = null;

        public PlayMoveWrapper PlayMoveWrapper
        {
            get
            {
                return _playMoveWrapper;
            }
            set
            {
                _playMoveWrapper = value;
            }
        }

        #endregion

        #region Public Methods; PlayChallengeTypePlayMoveLinks

        private List<PlayChallengeObjectiveWrapper> _playChallengeObjectiveWrappers = new List<PlayChallengeObjectiveWrapper>();

        public List<PlayChallengeObjectiveWrapper> PlayChallengeObjectiveWrappers
        {
            get
            {
                return _playChallengeObjectiveWrappers;
            }
        }

        /// <summary>
        /// Adds the PlayChallengeObjectiveWrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void AddPlayChallengeObjective(PlayChallengeObjectiveWrapper wrapper)
        {
            #region Check Parameters

            if (wrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "wrapper is nothing"));

            #endregion

            _playChallengeObjectiveWrappers.Add(wrapper);
        }

        /// <summary>
        /// Removes the PlayChallengeObjectiveWrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void RemovePlayChallengeObjective(PlayChallengeObjectiveWrapper wrapper)
        {
            #region Check Parameters

            if (wrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "wrapper is nothing"));

            #endregion

            _playChallengeObjectiveWrappers.Remove(wrapper);
        }

        #endregion
    }
}
