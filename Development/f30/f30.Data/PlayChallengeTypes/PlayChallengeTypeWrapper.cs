using f30.Core;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Collections.Generic;
using f30.Data.PlayChallengeTypePlayChallengeObjectiveTypeLinks;
using f30.Data.PlayChallengeTypePlayMoveLinks;

namespace f30.Data.PlayChallengeTypes
{
    /// <summary>
    /// A wrapper for a PlayChallengeType item.
    /// </summary>
    public class PlayChallengeTypeWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayChallengeTypeWrapper"/> class.
        /// </summary>
        public PlayChallengeTypeWrapper() : base()
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
                return "PlayChallengeType";
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

        #endregion

        #region Public Methods; PlayChallengeTypePlayChallengeObjectiveTypeLinks

        private List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> _playChallengeTypePlayChallengeObjectiveTypeLinks = new List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper>();

        public List<PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> PlayChallengeTypePlayChallengeObjectiveTypeLinks
        {
            get
            {
                return _playChallengeTypePlayChallengeObjectiveTypeLinks;
            }
        }

        /// <summary>
        /// Adds the PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void AddPlayChallengeTypePlayChallengeObjectiveTypeLink(PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper wrapper)
        {
            #region Check Parameters

            if (wrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "wrapper is nothing"));

            #endregion

            _playChallengeTypePlayChallengeObjectiveTypeLinks.Add(wrapper);
        }

        /// <summary>
        /// Removes the PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void RemovePlayChallengeTypePlayChallengeObjectiveTypeLink(PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper wrapper)
        {
            #region Check Parameters

            if (wrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "wrapper is nothing"));

            #endregion

            _playChallengeTypePlayChallengeObjectiveTypeLinks.Remove(wrapper);
        }

        /// <summary>
        /// Gets the PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper by specified PlayExperienceStep ID.
        /// </summary>
        /// <param name="playChallengeObjectiveTypeID">The design play experience step identifier.</param>
        /// <returns></returns>
        public PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper GetPlayChallengeTypePlayChallengeObjectiveTypeLinkByPlayChallengeObjectiveTypeID(int playChallengeObjectiveTypeID)
        {
            PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper result = null;

            // Go through each item
            foreach (PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper item in _playChallengeTypePlayChallengeObjectiveTypeLinks)
            {
                if (item.PlayChallengeObjectiveTypeID == playChallengeObjectiveTypeID) { return item; }
            }

            return result;
        }

        /// <summary>
        /// Gets the index of the highest PlayChallengeTypePlayChallengeObjectiveTypeLink.
        /// </summary>
        /// <returns></returns>
        public int GetHighestPlayChallengeTypePlayChallengeObjectiveTypeLinkIndex()
        {
            int result = -1;

            // Go through each item
            foreach (PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper item in _playChallengeTypePlayChallengeObjectiveTypeLinks)
            {
                // Check ExportStatus
                if (item.ExportStatus == ExportStatusTypes.PendingDelete) { continue; }

                if (item.Index > result) { result = item.Index; }
            }

            return result;
        }

        /// <summary>
        /// Determines whether this item has the specified PlayChallengeObjectiveType.
        /// </summary>
        /// <param name="playChallengeObjectiveTypeID">The playChallengeObjectiveTypeID.</param>
        /// <returns>
        ///   <c>true</c> if [has PlayChallengeObjectiveType]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasPlayChallengeObjectiveType(int playChallengeObjectiveTypeID)
        {
            bool result = false;

            // Go through each item
            foreach (PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper item in _playChallengeTypePlayChallengeObjectiveTypeLinks)
            {
                if (item.PlayChallengeObjectiveTypeID == playChallengeObjectiveTypeID) { return true; }
            }

            return result;
        }

        /// <summary>
        /// Gets a sorted list of PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper.
        /// </summary>
        /// <returns></returns>
        public SortedList<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> GetSortedPlayChallengeTypePlayChallengeObjectiveTypeLinks()
        {
            SortedList<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> result = new SortedList<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper>();

            // Go through each item
            foreach (PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper item in _playChallengeTypePlayChallengeObjectiveTypeLinks)
            {
                result.Add(item.Index, item);
            }

            // Nb: Usage
            //foreach (KeyValuePair<int, PlayChallengeTypePlayChallengeObjectiveTypeLinkWrapper> pair in result)
            //{
            //    Console.WriteLine("{0} and {1}", pair.Key, pair.Value);
            //}

            return result;
        }

        #endregion

        #region Public Methods; PlayChallengeTypePlayMoveLinks

        private List<PlayChallengeTypePlayMoveLinkWrapper> _playChallengeTypePlayMoveLinks = new List<PlayChallengeTypePlayMoveLinkWrapper>();

        public List<PlayChallengeTypePlayMoveLinkWrapper> PlayChallengeTypePlayMoveLinks
        {
            get
            {
                return _playChallengeTypePlayMoveLinks;
            }
        }

        /// <summary>
        /// Adds the PlayChallengeTypePlayMoveLinkWrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void AddPlayChallengeTypePlayMoveLink(PlayChallengeTypePlayMoveLinkWrapper wrapper)
        {
            #region Check Parameters

            if (wrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "wrapper is nothing"));

            #endregion

            _playChallengeTypePlayMoveLinks.Add(wrapper);
        }

        /// <summary>
        /// Removes the PlayChallengeTypePlayMoveLinkWrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void RemovePlayChallengeTypePlayMoveLink(PlayChallengeTypePlayMoveLinkWrapper wrapper)
        {
            #region Check Parameters

            if (wrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "wrapper is nothing"));

            #endregion

            _playChallengeTypePlayMoveLinks.Remove(wrapper);
        }

        /// <summary>
        /// Gets the PlayChallengeTypePlayMoveLinkWrapper by specified PlayMove ID.
        /// </summary>
        /// <param name="playMoveID">The playMoveID.</param>
        /// <returns></returns>
        public PlayChallengeTypePlayMoveLinkWrapper GetPlayChallengeTypePlayMoveLinkByPlayMoveID(int playMoveID)
        {
            PlayChallengeTypePlayMoveLinkWrapper result = null;

            // Go through each item
            foreach (PlayChallengeTypePlayMoveLinkWrapper item in _playChallengeTypePlayMoveLinks)
            {
                if (item.PlayMoveID == playMoveID) { return item; }
            }

            return result;
        }

        /// <summary>
        /// Gets the index of the highest PlayChallengeTypePlayMoveLink.
        /// </summary>
        /// <returns></returns>
        public int GetHighestPlayChallengeTypePlayMoveLinkIndex()
        {
            int result = -1;

            // Go through each item
            foreach (PlayChallengeTypePlayMoveLinkWrapper item in _playChallengeTypePlayMoveLinks)
            {
                // Check ExportStatus
                if (item.ExportStatus == ExportStatusTypes.PendingDelete) { continue; }

                if (item.Index > result) { result = item.Index; }
            }

            return result;
        }

        /// <summary>
        /// Determines whether this item has the specified PlayMove.
        /// </summary>
        /// <param name="playMoveID">The playMoveID.</param>
        /// <returns>
        ///   <c>true</c> if [has PlayMove]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasPlayMove(int playMoveID)
        {
            bool result = false;

            // Go through each item
            foreach (PlayChallengeTypePlayMoveLinkWrapper item in _playChallengeTypePlayMoveLinks)
            {
                if (item.PlayMoveID == playMoveID) { return true; }
            }

            return result;
        }

        /// <summary>
        /// Gets a sorted list of PlayChallengeTypePlayMoveLinkWrappers.
        /// </summary>
        /// <returns></returns>
        public SortedList<int, PlayChallengeTypePlayMoveLinkWrapper> GetSortedPlayChallengeTypePlayMoveLinks()
        {
            SortedList<int, PlayChallengeTypePlayMoveLinkWrapper> result = new SortedList<int, PlayChallengeTypePlayMoveLinkWrapper>();

            // Go through each item
            foreach (PlayChallengeTypePlayMoveLinkWrapper item in _playChallengeTypePlayMoveLinks)
            {
                result.Add(item.Index, item);
            }

            // Nb: Usage
            //foreach (KeyValuePair<int, PlayChallengeTypePlayMoveLinkWrapper> pair in result)
            //{
            //    Console.WriteLine("{0} and {1}", pair.Key, pair.Value);
            //}

            return result;
        }

        #endregion
    }
}
