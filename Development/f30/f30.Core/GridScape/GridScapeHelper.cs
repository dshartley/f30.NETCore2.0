using System;

namespace f30.Core.GridScape
{
    /// <summary>
    /// A helper class for GridScape functions.
    /// </summary>
    public class GridScapeHelper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridScapeHelper"/> class.
        /// </summary>
        private GridScapeHelper()
        {
        }

        #endregion

        #region Public Static Methods; CellCoord

        /// <summary>
        /// Gets the neighbour CellCoord at side.
        /// </summary>
        /// <param name="currentCellCoord">The currentCellCoord.</param>
        /// <param name="side">The side.</param>
        /// <returns></returns>
        public static CellCoord GetNeighbourCellCoordAtSide(CellCoord currentCellCoord, CellSides side)
        {
            CellCoord result = new CellCoord(currentCellCoord.Column, currentCellCoord.Row);

            switch (side)
            {
                case CellSides.Top:
                    result.Row      -= 1;
                    break;
                case CellSides.Right:
                    result.Column   += 1;
                    break;
                case CellSides.Bottom:
                    result.Row      += 1;
                    break;
                case CellSides.Left:
                    result.Column   -= 1;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Gets the neighbour side at cellCoord.
        /// </summary>
        /// <param name="currentCellCoord">The currentCellCoord.</param>
        /// <param name="cellCoord">The cellCoord.</param>
        /// <returns></returns>
        public static CellSides GetNeighbourSideAtCellCoord(CellCoord currentCellCoord, CellCoord cellCoord)
        {
            if (cellCoord.Column == currentCellCoord.Column + 1
                && cellCoord.Row == currentCellCoord.Row) { return CellSides.Right; }

            if (cellCoord.Column == currentCellCoord.Column - 1
                && cellCoord.Row == currentCellCoord.Row) { return CellSides.Left; }

            if (cellCoord.Column == currentCellCoord.Column
                && cellCoord.Row == currentCellCoord.Row + 1) { return CellSides.Bottom; }

            if (cellCoord.Column == currentCellCoord.Column
                && cellCoord.Row == currentCellCoord.Row - 1) { return CellSides.Top; }

            throw new ApplicationException("GetNeighbourSideAtCellCoord incorrect cellCoord");
        }

        #endregion

        #region Public Static Methods; Cell Rotation

        /// <summary>
        /// To trueDegrees from side with rotation.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="rotation">The rotation.</param>
        /// <returns></returns>
        public static int ToTrueDegrees(CellSides side, int rotation)
        {
            // Get indicatedDegrees
            int                     indicatedDegrees = GridScapeHelper.ToIndicatedDegrees(side);

            int                     r = rotation;

            if (rotation > 360 || rotation < 0)
            {
                r                   = GridScapeHelper.ToValidRotation(rotation);
            }

            if (r > indicatedDegrees)
            {
                indicatedDegrees    += 360;
            }

            int                     result = indicatedDegrees - rotation;

            return result;
        }

        /// <summary>
        /// To indicatedDegrees from side.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <returns></returns>
        public static int ToIndicatedDegrees(CellSides side)
        {
            switch (side)
            {
                case CellSides.Top:
                    return 0;
                case CellSides.Right:
                    return 90;
                case CellSides.Bottom:
                    return 180;
                case CellSides.Left:
                    return 270;
            }

            return 0;
        }

        /// <summary>
        /// To side from trueDegrees with rotation.
        /// </summary>
        /// <param name="trueDegrees">The trueDegrees.</param>
        /// <param name="rotation">The rotation.</param>
        /// <returns></returns>
        public static CellSides ToSide(int trueDegrees, int rotation)
        {
            int         r = rotation;

            if (rotation > 360 || rotation < 0)
            {
                r       = GridScapeHelper.ToValidRotation(rotation);
            }

            // Get indicatedDegrees
            int         indicatedDegrees = trueDegrees + r;

            if (indicatedDegrees >= 360)
            {
                int     quotient = Math.DivRem(indicatedDegrees, 360, out indicatedDegrees);
            }

            // Get side from indicatedDegrees
            CellSides   result = GridScapeHelper.ToSide(indicatedDegrees);

            return result;
        }

        #endregion

        #region Private Static Methods; Cell Rotation

        private static int ToValidRotation(int rotation)
        {
            int         result = rotation;
            int         remainder = 0;

            if (rotation > 360)
            {                
                int     quotient = Math.DivRem(rotation, 360, out remainder);
                result  = remainder;
            }
            else if (rotation < 0)
            {
                int     quotient = Math.DivRem(Math.Abs(rotation), 360, out remainder);
                result  = 360 - remainder;
            }

            return result;
        }

        private static CellSides ToSide(int indicatedDegrees)
        {
            CellSides result = CellSides.Top;

            switch (indicatedDegrees)
            {
                case 0:
                    result = CellSides.Top;
                    break;
                case 90:
                    result = CellSides.Right;
                    break;
                case 180:
                    result = CellSides.Bottom;
                    break;
                case 270:
                    result = CellSides.Left;
                    break;
                default:
                    result = CellSides.Top;
                    break;
            }

            return result;
        }

        #endregion
    }
}
