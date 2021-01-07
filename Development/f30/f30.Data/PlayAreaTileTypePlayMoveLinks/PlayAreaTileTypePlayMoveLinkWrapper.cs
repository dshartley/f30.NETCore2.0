namespace f30.Data.PlayAreaTileTypePlayMoveLinks
{
    /// <summary>
    /// A wrapper for a PlayAreaTileTypePlayMoveLink item.
    /// </summary>
    public class PlayAreaTileTypePlayMoveLinkWrapper : DataItemWrapperBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaTileTypePlayMoveLinkWrapper"/> class.
        /// </summary>
        public PlayAreaTileTypePlayMoveLinkWrapper() : base()
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
                return "PlayAreaTileTypePlayMoveLink";
            }
        }

        #endregion

        #region Public Methods

        private int _playAreaTileTypeID;

        public int PlayAreaTileTypeID
        {
            get { return _playAreaTileTypeID; }
            set { _playAreaTileTypeID = value; }
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
