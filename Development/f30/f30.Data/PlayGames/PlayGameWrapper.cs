using System;
using System.Collections.Generic;
using System.Text;

namespace f30.Data.PlayGames
{
    /// <summary>
    /// A wrapper for a PlayGame item.
    /// </summary>
    public class PlayGameWrapper: DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGameWrapper"/> class.
        /// </summary>
        public PlayGameWrapper()
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
                return "PlayGame";
            }
        }

        #endregion

        #region Public Methods

        private int _relativeMemberID;

        public int RelativeMemberID
        {
            get { return _relativeMemberID; }
            set { _relativeMemberID = value; }
        }

        private DateTime _dateCreated;

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        #endregion
    }
}
