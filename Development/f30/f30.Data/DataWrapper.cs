using f30.Data.PlayAreaCellTypePlayMoveLinks;
using f30.Data.PlayAreaCellTypes;
using f30.Data.PlayAreaTileTypePlayMoveLinks;
using f30.Data.PlayChallengeTypePlayMoveLinks;
using f30.Data.PlayAreaTileTypes;
using f30.Data.PlayChallengeObjectiveTypes;
using f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks;
using f30.Data.PlayChallengeTypes;
using f30.Data.PlayExperiencePlayExperienceStepLinks;
using f30.Data.PlayExperiences;
using f30.Data.PlayExperienceStepExercises;
using f30.Data.PlayExperienceStepPlayExperienceStepExerciseLinks;
using f30.Data.PlayExperienceSteps;
using f30.Data.PlayMoves;
using f30.Data.PlaySubsets;
using System;
using System.Collections.Generic;

namespace f30.Data
{
    public sealed class DataWrapper
    {
        #region Singleton Methods

        private static readonly Lazy<DataWrapper> _shared = new Lazy<DataWrapper>(() => new DataWrapper());

        public static DataWrapper Shared
        {
            get
            {
                return _shared.Value;
            }
        }

        #endregion

        #region Constructors

        private DataWrapper()
        {

        }

        #endregion

        #region Public Methods

        #endregion

        #region Public Methods; PlaySubsets

        /// <summary>
        /// Sets the PlaySubsetWrappers.
        /// </summary>
        /// <param name="playSubsetWrappers">The PlaySubsetWrappers.</param>
        public void Set(List<PlaySubsetWrapper> playSubsetWrappers)
        {
            _playSubsets                = new Dictionary<int, PlaySubsetWrapper>();

            // Go through each item
            foreach (PlaySubsetWrapper value in playSubsetWrappers)
            {
                _playSubsets[value.ID]  = value;
            }
        }

        private Dictionary<int, PlaySubsetWrapper> _playSubsets;

        /// <summary>
        /// Gets the PlaySubsets.
        /// </summary>
        /// <value>
        /// The PlaySubsets.
        /// </value>
        public Dictionary<int, PlaySubsetWrapper> PlaySubsets
        {
            get
            {
                return _playSubsets;
            }
        }

        /// <summary>
        /// Get PlaySubsetWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlaySubsetWrapper GetPlaySubset(int byID)
        {
            // Go through each item
            foreach (PlaySubsetWrapper value in _playSubsets.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlaySubset.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlaySubset(int ID)
        {
            _playSubsets.Remove(ID);
        }

        /// <summary>
        /// Clears the PlaySubsets.
        /// </summary>
        public void ClearPlaySubsets()
        {
            _playSubsets = new Dictionary<int, PlaySubsetWrapper>();
        }

        #endregion

        #region Public Methods; PlayAreaCellTypes

        /// <summary>
        /// Sets the PlayAreaCellTypeWrappers.
        /// </summary>
        /// <param name="playAreaCellTypeWrappers">The PlayAreaCellTypeWrappers.</param>
        public void Set(List<PlayAreaCellTypeWrapper> playAreaCellTypeWrappers)
        {
            _playAreaCellTypes = new Dictionary<int, PlayAreaCellTypeWrapper>();

            // Go through each item
            foreach (PlayAreaCellTypeWrapper value in playAreaCellTypeWrappers)
            {
                _playAreaCellTypes[value.ID] = value;
            }
        }

        private Dictionary<int, PlayAreaCellTypeWrapper> _playAreaCellTypes;

        /// <summary>
        /// Gets the PlayAreaCellTypes.
        /// </summary>
        /// <value>
        /// The PlayAreaCellTypes.
        /// </value>
        public Dictionary<int, PlayAreaCellTypeWrapper> PlayAreaCellTypes
        {
            get
            {
                return _playAreaCellTypes;
            }
        }

        /// <summary>
        /// Get PlayAreaCellTypeWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayAreaCellTypeWrapper GetPlayAreaCellType(int byID)
        {
            // Go through each item
            foreach (PlayAreaCellTypeWrapper value in _playAreaCellTypes.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayAreaCellType.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayAreaCellType(int ID)
        {
            _playAreaCellTypes.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayAreaCellTypes.
        /// </summary>
        public void ClearPlayAreaCellTypes()
        {
            _playAreaCellTypes = new Dictionary<int, PlayAreaCellTypeWrapper>();
        }

        #endregion

        #region Public Methods; PlayAreaTileTypes

        /// <summary>
        /// Sets the PlayAreaCellTypeWrappers.
        /// </summary>
        /// <param name="playAreaTileTypeWrappers">The PlayAreaTileTypeWrappers.</param>
        public void Set(List<PlayAreaTileTypeWrapper> playAreaTileTypeWrappers)
        {
            _playAreaTileTypes = new Dictionary<int, PlayAreaTileTypeWrapper>();

            // Go through each item
            foreach (PlayAreaTileTypeWrapper value in playAreaTileTypeWrappers)
            {
                _playAreaTileTypes[value.ID] = value;
            }
        }

        private Dictionary<int, PlayAreaTileTypeWrapper> _playAreaTileTypes;

        /// <summary>
        /// Gets the PlayAreaTileTypes.
        /// </summary>
        /// <value>
        /// The PlayAreaTileTypes.
        /// </value>
        public Dictionary<int, PlayAreaTileTypeWrapper> PlayAreaTileTypes
        {
            get
            {
                return _playAreaTileTypes;
            }
        }

        /// <summary>
        /// Get PlayAreaTileTypeWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayAreaTileTypeWrapper GetPlayAreaTileType(int byID)
        {
            // Go through each item
            foreach (PlayAreaTileTypeWrapper value in _playAreaTileTypes.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayAreaTileType.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayAreaTileType(int ID)
        {
            _playAreaTileTypes.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayAreaTileTypes.
        /// </summary>
        public void ClearPlayAreaTileTypes()
        {
            _playAreaTileTypes = new Dictionary<int, PlayAreaTileTypeWrapper>();
        }

        #endregion

        #region Public Methods; PlayChallengeObjectiveTypes

        /// <summary>
        /// Sets the PlayChallengeObjectiveTypeWrappers.
        /// </summary>
        /// <param name="playChallengeObjectiveTypeWrappers">The PlayChallengeObjectiveTypeWrappers.</param>
        public void Set(List<PlayChallengeObjectiveTypeWrapper> playChallengeObjectiveTypeWrappers)
        {
            _playChallengeObjectiveTypes = new Dictionary<int, PlayChallengeObjectiveTypeWrapper>();

            // Go through each item
            foreach (PlayChallengeObjectiveTypeWrapper value in playChallengeObjectiveTypeWrappers)
            {
                _playChallengeObjectiveTypes[value.ID] = value;
            }
        }

        private Dictionary<int, PlayChallengeObjectiveTypeWrapper> _playChallengeObjectiveTypes;

        /// <summary>
        /// Gets the PlayChallengeObjectiveTypes.
        /// </summary>
        /// <value>
        /// The PlayChallengeObjectiveTypes.
        /// </value>
        public Dictionary<int, PlayChallengeObjectiveTypeWrapper> PlayChallengeObjectiveTypes
        {
            get
            {
                return _playChallengeObjectiveTypes;
            }
        }

        /// <summary>
        /// Get PlayChallengeObjectiveTypeWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayChallengeObjectiveTypeWrapper GetPlayChallengeObjectiveType(int byID)
        {
            // Go through each item
            foreach (PlayChallengeObjectiveTypeWrapper value in _playChallengeObjectiveTypes.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayChallengeObjectiveType.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayChallengeObjectiveType(int ID)
        {
            _playChallengeObjectiveTypes.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayChallengeObjectiveTypes.
        /// </summary>
        public void ClearPlayChallengeObjectiveTypes()
        {
            _playChallengeObjectiveTypes = new Dictionary<int, PlayChallengeObjectiveTypeWrapper>();
        }

        #endregion

        #region Public Methods; PlayChallengeTypes

        /// <summary>
        /// Sets the PlayChallengeTypeWrappers.
        /// </summary>
        /// <param name="playChallengeTypeWrappers">The PlayChallengeTypeWrappers.</param>
        public void Set(List<PlayChallengeTypeWrapper> playChallengeTypeWrappers)
        {
            _playChallengeTypes = new Dictionary<int, PlayChallengeTypeWrapper>();

            // Go through each item
            foreach (PlayChallengeTypeWrapper value in playChallengeTypeWrappers)
            {
                _playChallengeTypes[value.ID] = value;
            }
        }

        private Dictionary<int, PlayChallengeTypeWrapper> _playChallengeTypes;

        /// <summary>
        /// Gets the PlayChallengeTypes.
        /// </summary>
        /// <value>
        /// The PlayChallengeTypes.
        /// </value>
        public Dictionary<int, PlayChallengeTypeWrapper> PlayChallengeTypes
        {
            get
            {
                return _playChallengeTypes;
            }
        }

        /// <summary>
        /// Get PlayChallengeTypeWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayChallengeTypeWrapper GetPlayChallengeType(int byID)
        {
            // Go through each item
            foreach (PlayChallengeTypeWrapper value in _playChallengeTypes.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayChallengeType.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayChallengeType(int ID)
        {
            _playChallengeTypes.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayChallengeTypes.
        /// </summary>
        public void ClearPlayChallengeTypes()
        {
            _playChallengeTypes = new Dictionary<int, PlayChallengeTypeWrapper>();
        }

        #endregion

        #region Public Methods; PlayExperiences

        /// <summary>
        /// Sets the PlayExperienceWrappers.
        /// </summary>
        /// <param name="playExperienceWrappers">The PlayExperienceWrappers.</param>
        public void Set(List<PlayExperienceWrapper> playExperienceWrappers)
        {
            _playExperiences = new Dictionary<int, PlayExperienceWrapper>();

            // Go through each item
            foreach (PlayExperienceWrapper value in playExperienceWrappers)
            {
                _playExperiences[value.ID] = value;
            }
        }

        private Dictionary<int, PlayExperienceWrapper> _playExperiences;

        /// <summary>
        /// Gets the PlayExperiences.
        /// </summary>
        /// <value>
        /// The PlayExperiences.
        /// </value>
        public Dictionary<int, PlayExperienceWrapper> PlayExperiences
        {
            get
            {
                return _playExperiences;
            }
        }

        /// <summary>
        /// Get PlayExperienceWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayExperienceWrapper GetPlayExperience(int byID)
        {
            // Go through each item
            foreach (PlayExperienceWrapper value in _playExperiences.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayExperience.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayExperience(int ID)
        {
            _playExperiences.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayExperiences.
        /// </summary>
        public void ClearPlayExperiences()
        {
            _playExperiences = new Dictionary<int, PlayExperienceWrapper>();
        }

        #endregion

        #region Public Methods; PlayExperienceSteps

        /// <summary>
        /// Sets the PlayExperienceStepWrappers.
        /// </summary>
        /// <param name="playExperienceStepWrappers">The PlayExperienceStepWrappers.</param>
        public void Set(List<PlayExperienceStepWrapper> playExperienceStepWrappers)
        {
            _playExperienceSteps = new Dictionary<int, PlayExperienceStepWrapper>();

            // Go through each item
            foreach (PlayExperienceStepWrapper value in playExperienceStepWrappers)
            {
                _playExperienceSteps[value.ID] = value;
            }
        }

        private Dictionary<int, PlayExperienceStepWrapper> _playExperienceSteps;

        /// <summary>
        /// Gets the PlayExperienceSteps.
        /// </summary>
        /// <value>
        /// The PlayExperienceSteps.
        /// </value>
        public Dictionary<int, PlayExperienceStepWrapper> PlayExperienceSteps
        {
            get
            {
                return _playExperienceSteps;
            }
        }

        /// <summary>
        /// Get PlayExperienceStepWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayExperienceStepWrapper GetPlayExperienceStep(int byID)
        {
            // Go through each item
            foreach (PlayExperienceStepWrapper value in _playExperienceSteps.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayExperienceStep.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayExperienceStep(int ID)
        {
            _playExperienceSteps.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayExperienceSteps.
        /// </summary>
        public void ClearPlayExperienceSteps()
        {
            _playExperienceSteps = new Dictionary<int, PlayExperienceStepWrapper>();
        }

        #endregion

        #region Public Methods; PlayExperienceStepExercises

        /// <summary>
        /// Sets the PlayExperienceStepExerciseWrappers.
        /// </summary>
        /// <param name="playExperienceStepExerciseWrappers">The PlayExperienceStepExerciseWrappers.</param>
        public void Set(List<PlayExperienceStepExerciseWrapper> playExperienceStepExerciseWrappers)
        {
            _playExperienceStepExercises = new Dictionary<int, PlayExperienceStepExerciseWrapper>();

            // Go through each item
            foreach (PlayExperienceStepExerciseWrapper value in playExperienceStepExerciseWrappers)
            {
                _playExperienceStepExercises[value.ID] = value;
            }
        }

        private Dictionary<int, PlayExperienceStepExerciseWrapper> _playExperienceStepExercises;

        /// <summary>
        /// Gets the PlayExperienceStepExercises.
        /// </summary>
        /// <value>
        /// The PlayExperienceStepExercises.
        /// </value>
        public Dictionary<int, PlayExperienceStepExerciseWrapper> PlayExperienceStepExercises
        {
            get
            {
                return _playExperienceStepExercises;
            }
        }

        /// <summary>
        /// Get PlayExperienceStepExerciseWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayExperienceStepExerciseWrapper GetPlayExperienceStepExercise(int byID)
        {
            // Go through each item
            foreach (PlayExperienceStepExerciseWrapper value in _playExperienceStepExercises.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayExperienceStepExercise.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayExperienceStepExercise(int ID)
        {
            _playExperienceStepExercises.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayExperienceStepExercises.
        /// </summary>
        public void ClearPlayExperienceStepExercises()
        {
            _playExperienceStepExercises = new Dictionary<int, PlayExperienceStepExerciseWrapper>();
        }

        #endregion

        #region Public Methods; PlayExperienceStepPlayExperienceStepExerciseLinks

        /// <summary>
        /// Sets the PlayExperienceStepPlayExperienceStepExerciseLinkWrappers.
        /// </summary>
        /// <param name="playExperienceStepPlayExperienceStepExerciseLinkWrappers">The PlayExperienceStepPlayExperienceStepExerciseLinkWrappers.</param>
        public void Set(List<PlayExperienceStepPlayExperienceStepExerciseLinkWrapper> playExperienceStepPlayExperienceStepExerciseLinkWrappers)
        {
            _playExperienceStepPlayExperienceStepExerciseLinks                  = new Dictionary<int, PlayExperienceStepPlayExperienceStepExerciseLinkWrapper>();

            // Go through each item
            foreach (PlayExperienceStepPlayExperienceStepExerciseLinkWrapper value in playExperienceStepPlayExperienceStepExerciseLinkWrappers)
            {
                _playExperienceStepPlayExperienceStepExerciseLinks[value.ID]    = value;
            }
        }

        private Dictionary<int, PlayExperienceStepPlayExperienceStepExerciseLinkWrapper> _playExperienceStepPlayExperienceStepExerciseLinks;

        /// <summary>
        /// Gets the PlayExperienceStepPlayExperienceStepExerciseLinks.
        /// </summary>
        /// <value>
        /// The PlayExperienceStepPlayExperienceStepExerciseLinks.
        /// </value>
        public Dictionary<int, PlayExperienceStepPlayExperienceStepExerciseLinkWrapper> PlayExperienceStepPlayExperienceStepExerciseLinks
        {
            get
            {
                return _playExperienceStepPlayExperienceStepExerciseLinks;
            }
        }

        /// <summary>
        /// Get PlayExperienceStepPlayExperienceStepExerciseLinkWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayExperienceStepPlayExperienceStepExerciseLinkWrapper GetPlayExperienceStepPlayExperienceStepExerciseLink(int byID)
        {
            // Go through each item
            foreach (PlayExperienceStepPlayExperienceStepExerciseLinkWrapper value in _playExperienceStepPlayExperienceStepExerciseLinks.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayExperienceStepPlayExperienceStepExerciseLink.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayExperienceStepPlayExperienceStepExerciseLink(int ID)
        {
            _playExperienceStepPlayExperienceStepExerciseLinks.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayExperienceStepPlayExperienceStepExerciseLinks.
        /// </summary>
        public void ClearPlayExperienceStepPlayExperienceStepExerciseLinks()
        {
            _playExperienceStepPlayExperienceStepExerciseLinks = new Dictionary<int, PlayExperienceStepPlayExperienceStepExerciseLinkWrapper>();
        }

        #endregion

        #region Public Methods; PlayExperiencePlayExperienceStepLinks

        /// <summary>
        /// Sets the PlayExperiencePlayExperienceStepLinkWrappers.
        /// </summary>
        /// <param name="playExperiencePlayExperienceStepLinkWrappers">The PlayExperiencePlayExperienceStepLinkWrappers.</param>
        public void Set(List<PlayExperiencePlayExperienceStepLinkWrapper> playExperiencePlayExperienceStepLinkWrappers)
        {
            _playExperiencePlayExperienceStepLinks                  = new Dictionary<int, PlayExperiencePlayExperienceStepLinkWrapper>();

            // Go through each item
            foreach (PlayExperiencePlayExperienceStepLinkWrapper value in playExperiencePlayExperienceStepLinkWrappers)
            {
                _playExperiencePlayExperienceStepLinks[value.ID]    = value;
            }
        }

        private Dictionary<int, PlayExperiencePlayExperienceStepLinkWrapper> _playExperiencePlayExperienceStepLinks;

        /// <summary>
        /// Gets the PlayExperiencePlayExperienceStepLinks.
        /// </summary>
        /// <value>
        /// The PlayExperiencePlayExperienceStepLinks.
        /// </value>
        public Dictionary<int, PlayExperiencePlayExperienceStepLinkWrapper> PlayExperiencePlayExperienceStepLinks
        {
            get
            {
                return _playExperiencePlayExperienceStepLinks;
            }
        }

        /// <summary>
        /// Get PlayExperiencePlayExperienceStepLinkWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayExperiencePlayExperienceStepLinkWrapper GetPlayExperiencePlayExperienceStepLink(int byID)
        {
            // Go through each item
            foreach (PlayExperiencePlayExperienceStepLinkWrapper value in _playExperiencePlayExperienceStepLinks.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayExperiencePlayExperienceStepLink.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayExperiencePlayExperienceStepLink(int ID)
        {
            _playExperiencePlayExperienceStepLinks.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayExperiencePlayExperienceStepLinks.
        /// </summary>
        public void ClearPlayExperiencePlayExperienceStepLinks()
        {
            _playExperiencePlayExperienceStepLinks = new Dictionary<int, PlayExperiencePlayExperienceStepLinkWrapper>();
        }

        #endregion

        #region Public Methods; PlayChallengeTypePlayChallengeObjectiveTypeLinks

        /// <summary>
        /// Sets the PlayChallengeTypePlayChallengeObjectiveTypeLinkWrappers.
        /// </summary>
        /// <param name="playChallengeTypePlayChallengeObjectiveTypeLinkWrappers">The PlayChallengeTypePlayChallengeObjectiveTypeLinkWrappers.</param>
        public void Set(List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> playChallengeTypePlayChallengeObjectiveTypeLinkWrappers)
        {
            _playChallengeTypePlayChallengeObjectiveTypeLinks                   = new Dictionary<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper>();

            // Go through each item
            foreach (PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper value in playChallengeTypePlayChallengeObjectiveTypeLinkWrappers)
            {
                _playChallengeTypePlayChallengeObjectiveTypeLinks[value.ID]     = value;

                // Get PlayChallengeTypeWrapper
                PlayChallengeTypeWrapper                                        pctw = _playChallengeTypes[value.PlayChallengeTypeID];

                if (pctw != null)
                {
                    pctw.AddPlayChallengeTypePlayChallengeObjectiveTypeLink(value);
                }
            }
        }

        private Dictionary<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> _playChallengeTypePlayChallengeObjectiveTypeLinks;

        /// <summary>
        /// Gets the PlayChallengeTypePlayChallengeObjectiveTypeLinks.
        /// </summary>
        /// <value>
        /// The PlayChallengeTypePlayChallengeObjectiveTypeLinks.
        /// </value>
        public Dictionary<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> PlayChallengeTypePlayChallengeObjectiveTypeLinks
        {
            get
            {
                return _playChallengeTypePlayChallengeObjectiveTypeLinks;
            }
        }

        /// <summary>
        /// Get PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper GetPlayChallengeTypePlayChallengeObjectiveTypeLink(int byID)
        {
            // Go through each item
            foreach (PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper value in _playChallengeTypePlayChallengeObjectiveTypeLinks.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayChallengeTypePlayChallengeObjectiveTypeLink.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayChallengeTypePlayChallengeObjectiveTypeLink(int ID)
        {
            _playChallengeTypePlayChallengeObjectiveTypeLinks.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayChallengeTypePlayChallengeObjectiveTypeLinks.
        /// </summary>
        public void ClearPlayChallengeTypePlayChallengeObjectiveTypeLinks()
        {
            _playChallengeTypePlayChallengeObjectiveTypeLinks = new Dictionary<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper>();
        }

        #endregion

        #region Public Methods; PlayMoves

        /// <summary>
        /// Sets the PlayMoveWrappers.
        /// </summary>
        /// <param name="playMoveWrappers">The PlayMoveWrappers.</param>
        public void Set(List<PlayMoveWrapper> playMoveWrappers)
        {
            _playMoves = new Dictionary<int, PlayMoveWrapper>();

            // Go through each item
            foreach (PlayMoveWrapper value in playMoveWrappers)
            {
                _playMoves[value.ID] = value;
            }
        }

        private Dictionary<int, PlayMoveWrapper> _playMoves;

        /// <summary>
        /// Gets the PlayMoves.
        /// </summary>
        /// <value>
        /// The PlayMoves.
        /// </value>
        public Dictionary<int, PlayMoveWrapper> PlayMoves
        {
            get
            {
                return _playMoves;
            }
        }

        /// <summary>
        /// Get PlayMoveWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayMoveWrapper GetPlayMove(int byID)
        {
            // Go through each item
            foreach (PlayMoveWrapper value in _playMoves.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayMove.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayMove(int ID)
        {
            _playMoves.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayMoves.
        /// </summary>
        public void ClearPlayMoves()
        {
            _playMoves = new Dictionary<int, PlayMoveWrapper>();
        }

        #endregion

        #region Public Methods; PlayAreaCellTypePlayMoveLinks

        /// <summary>
        /// Sets the PlayAreaCellTypePlayMoveLinkWrappers.
        /// </summary>
        /// <param name="playAreaCellTypePlayMoveLinkWrappers">The PlayAreaCellTypePlayMoveLinkWrappers.</param>
        public void Set(List<PlayAreaCellTypePlayMoveLinkWrapper> playAreaCellTypePlayMoveLinkWrappers)
        {
            _playAreaCellTypePlayMoveLinks = new Dictionary<int, PlayAreaCellTypePlayMoveLinkWrapper>();

            // Go through each item
            foreach (PlayAreaCellTypePlayMoveLinkWrapper value in playAreaCellTypePlayMoveLinkWrappers)
            {
                _playAreaCellTypePlayMoveLinks[value.ID] = value;
            }
        }

        private Dictionary<int, PlayAreaCellTypePlayMoveLinkWrapper> _playAreaCellTypePlayMoveLinks;

        /// <summary>
        /// Gets the PlayAreaCellTypePlayMoveLinks.
        /// </summary>
        /// <value>
        /// The PlayAreaCellTypePlayMoveLinks.
        /// </value>
        public Dictionary<int, PlayAreaCellTypePlayMoveLinkWrapper> PlayAreaCellTypePlayMoveLinks
        {
            get
            {
                return _playAreaCellTypePlayMoveLinks;
            }
        }

        /// <summary>
        /// Get PlayAreaCellTypePlayMoveLinkWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayAreaCellTypePlayMoveLinkWrapper GetPlayAreaCellTypePlayMoveLink(int byID)
        {
            // Go through each item
            foreach (PlayAreaCellTypePlayMoveLinkWrapper value in _playAreaCellTypePlayMoveLinks.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayAreaCellTypePlayMoveLink.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayAreaCellTypePlayMoveLink(int ID)
        {
            _playAreaCellTypePlayMoveLinks.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayAreaCellTypePlayMoveLinks.
        /// </summary>
        public void ClearPlayAreaCellTypePlayMoveLinks()
        {
            _playAreaCellTypePlayMoveLinks = new Dictionary<int, PlayAreaCellTypePlayMoveLinkWrapper>();
        }

        #endregion

        #region Public Methods; PlayAreaTileTypePlayMoveLinks

        /// <summary>
        /// Sets the PlayAreaTileTypePlayMoveLinkWrappers.
        /// </summary>
        /// <param name="playAreaTileTypePlayMoveLinkWrappers">The PlayAreaTileTypePlayMoveLinkWrappers.</param>
        public void Set(List<PlayAreaTileTypePlayMoveLinkWrapper> playAreaTileTypePlayMoveLinkWrappers)
        {
            _playAreaTileTypePlayMoveLinks = new Dictionary<int, PlayAreaTileTypePlayMoveLinkWrapper>();

            // Go through each item
            foreach (PlayAreaTileTypePlayMoveLinkWrapper value in playAreaTileTypePlayMoveLinkWrappers)
            {
                _playAreaTileTypePlayMoveLinks[value.ID] = value;
            }
        }

        private Dictionary<int, PlayAreaTileTypePlayMoveLinkWrapper> _playAreaTileTypePlayMoveLinks;

        /// <summary>
        /// Gets the PlayAreaTileTypePlayMoveLinks.
        /// </summary>
        /// <value>
        /// The PlayAreaTileTypePlayMoveLinks.
        /// </value>
        public Dictionary<int, PlayAreaTileTypePlayMoveLinkWrapper> PlayAreaTileTypePlayMoveLinks
        {
            get
            {
                return _playAreaTileTypePlayMoveLinks;
            }
        }

        /// <summary>
        /// Get PlayAreaTileTypePlayMoveLinkWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayAreaTileTypePlayMoveLinkWrapper GetPlayAreaTileTypePlayMoveLink(int byID)
        {
            // Go through each item
            foreach (PlayAreaTileTypePlayMoveLinkWrapper value in _playAreaTileTypePlayMoveLinks.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayAreaTileTypePlayMoveLink.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayAreaTileTypePlayMoveLink(int ID)
        {
            _playAreaTileTypePlayMoveLinks.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayAreaTileTypePlayMoveLinks.
        /// </summary>
        public void ClearPlayAreaTileTypePlayMoveLinks()
        {
            _playAreaTileTypePlayMoveLinks = new Dictionary<int, PlayAreaTileTypePlayMoveLinkWrapper>();
        }

        #endregion

        #region Public Methods; PlayChallengeTypePlayMoveLinks

        /// <summary>
        /// Sets the PlayChallengeTypePlayMoveLinkWrappers.
        /// </summary>
        /// <param name="playChallengeTypePlayMoveLinkWrappers">The PlayChallengeTypePlayMoveLinkWrappers.</param>
        public void Set(List<PlayChallengeTypePlayMoveLinkWrapper> playChallengeTypePlayMoveLinkWrappers)
        {
            _playChallengeTypePlayMoveLinks                 = new Dictionary<int, PlayChallengeTypePlayMoveLinkWrapper>();

            // Go through each item
            foreach (PlayChallengeTypePlayMoveLinkWrapper value in playChallengeTypePlayMoveLinkWrappers)
            {
                _playChallengeTypePlayMoveLinks[value.ID]   = value;

                // Get PlayChallengeTypeWrapper
                PlayChallengeTypeWrapper                    pctw = _playChallengeTypes[value.PlayChallengeTypeID];

                if (pctw != null)
                {
                    pctw.AddPlayChallengeTypePlayMoveLink(value);
                }
            }
        }

        private Dictionary<int, PlayChallengeTypePlayMoveLinkWrapper> _playChallengeTypePlayMoveLinks;

        /// <summary>
        /// Gets the PlayChallengeTypePlayMoveLinks.
        /// </summary>
        /// <value>
        /// The PlayChallengeTypePlayMoveLinks.
        /// </value>
        public Dictionary<int, PlayChallengeTypePlayMoveLinkWrapper> PlayChallengeTypePlayMoveLinks
        {
            get
            {
                return _playChallengeTypePlayMoveLinks;
            }
        }

        /// <summary>
        /// Get PlayChallengeTypePlayMoveLinkWrapper.
        /// </summary>
        /// <param name="byID">The byID.</param>
        /// <returns></returns>
        public PlayChallengeTypePlayMoveLinkWrapper GetPlayChallengeTypePlayMoveLink(int byID)
        {
            // Go through each item
            foreach (PlayChallengeTypePlayMoveLinkWrapper value in _playChallengeTypePlayMoveLinks.Values)
            {
                if (value.ID == byID)
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the PlayChallengeTypePlayMoveLink.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        public void RemovePlayChallengeTypePlayMoveLink(int ID)
        {
            _playChallengeTypePlayMoveLinks.Remove(ID);
        }

        /// <summary>
        /// Clears the PlayChallengeTypePlayMoveLinks.
        /// </summary>
        public void ClearPlayChallengeTypePlayMoveLinks()
        {
            _playChallengeTypePlayMoveLinks = new Dictionary<int, PlayChallengeTypePlayMoveLinkWrapper>();
        }

        #endregion
    }
}
