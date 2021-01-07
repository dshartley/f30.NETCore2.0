using System;

namespace f30.Core
{
    /// <summary>
    /// A helper class for DesignDataItems.
    /// </summary>
    public class DesignDataItemHelper
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignDataItemHelper"/> class.
        /// </summary>
        private DesignDataItemHelper() { }

        #endregion

        #region Public Static Methods

        public static string ToKey(CellSides cellSide)
        {
            #region Check Parameters

            #endregion

            string result = string.Empty;

            switch (cellSide)
            {
                case CellSides.Top:
                    result = "0";
                    break;
                case CellSides.Right:
                    result = "90";
                    break;
                case CellSides.Bottom:
                    result = "180";
                    break;
                case CellSides.Left:
                    result = "270";
                    break;
                default:
                    break;
            }

            return result;
        }

        #endregion
    }
}
