namespace f30.Core.GridScape
{
    /// <summary>
    /// A wrapper for a CellCoord item.
    /// </summary>
    public class CellCoord
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CellCoord"/> class.
        /// </summary>
        private CellCoord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CellCoord" /> class.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        public CellCoord(int column, int row)
        {
            _column     = column;
            _row        = row;
        }

        #endregion

        #region Public Methods

        private int _column;

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        private int _row;

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        /// <summary>
        /// Checks whether the CellCoords are equal.
        /// </summary>
        /// <param name="cellCoord">The cellCoord.</param>
        /// <returns></returns>
        public bool Equals(CellCoord cellCoord)
        {
            bool result = false;

            if (cellCoord.Column == _column && cellCoord.Row == _row) { result = true; }

            return result;
        }

        #endregion
    }
}
