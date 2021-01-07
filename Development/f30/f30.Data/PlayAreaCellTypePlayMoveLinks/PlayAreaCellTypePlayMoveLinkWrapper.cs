namespace f30.Data.PlayAreaCellTypePlayMoveLinks
{
    /// <summary>
    /// A wrapper for a PlayAreaCellTypePlayMoveLink item.
    /// </summary>
    public class PlayAreaCellTypePlayMoveLinkWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaCellTypePlayMoveLinkWrapper"/> class.
        /// </summary>
        public PlayAreaCellTypePlayMoveLinkWrapper() : base()
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
                return "PlayAreaCellTypePlayMoveLink";
            }
        }

        #endregion

        #region Public Methods

        private int _playAreaCellTypeID;

        public int PlayAreaCellTypeID
        {
            get { return _playAreaCellTypeID; }
            set { _playAreaCellTypeID = value; }
        }

        private int _playMoveID;

        public int PlayMoveID
        {
            get { return _playMoveID; }
            set { _playMoveID = value; }

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
