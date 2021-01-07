using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using System;
using System.Collections.Generic;

namespace f30.Data.PlayAreaCells
{
    /// <summary>
    /// Encapsulates an indexed collection of PlayAreaCellWrappersIndexedByCellCoord.
    /// </summary>
    public class PlayAreaCellWrappersIndexedByCellCoord
    {
        private Dictionary<int, Dictionary<int, PlayAreaCell>> _index;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayAreaCellWrappersIndexedByCellCoord"/> class.
        /// </summary>
        public PlayAreaCellWrappersIndexedByCellCoord()
        {
            _index = new Dictionary<int, Dictionary<int, PlayAreaCell>>();
        }

        #endregion

        #region Public Methods

        public void Set(PlayAreaCellCollection collection)
        {
            #region Check Parameters

            if (collection == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "collection is nothing"));

            #endregion

            _index                              = new Dictionary<int, Dictionary<int, PlayAreaCell>>();

            // Go through each item
            foreach (IDataItem item in collection.Items)
            {
                PlayAreaCell                    pac = (PlayAreaCell)item;

                // Get columnIndex
                Dictionary<int, PlayAreaCell>   columnIndex = this.GetColumnIndex(pac.Column);

                // Set item in columnIndex
                columnIndex[pac.Row]            = pac;
            }
        }

        public void Set(PlayAreaCell item)
        {
            #region Check Parameters

            if (item == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "item is nothing"));

            #endregion

            // Get columnIndex
            Dictionary<int, PlayAreaCell>   columnIndex = this.GetColumnIndex(item.Column);

            // Set item in columnIndex
            columnIndex[item.Row]           = item;
        }

        public PlayAreaCell Get(int column, int row)
        {
            PlayAreaCell                    result = null;
      
            // Get columnIndex
            Dictionary<int, PlayAreaCell>   columnIndex = this.GetColumnIndex(column);

            if (columnIndex.ContainsKey(row)) { result = columnIndex[row]; }

            return result;
        }

        public bool ContainsKey(int column, int row)
        {
            // Get columnIndex
            Dictionary<int, PlayAreaCell> columnIndex = this.GetColumnIndex(column);

            if (columnIndex == null || !columnIndex.ContainsKey(row)) { return false; }

            return true;
        }

        #endregion

        #region Private Methods

        private Dictionary<int, PlayAreaCell> GetColumnIndex(int column)
        {
            Dictionary<int, PlayAreaCell> result = null;

            if (_index.ContainsKey(column)) { result = _index[column]; }
            else
            {
                result = new Dictionary<int, PlayAreaCell>();
                _index[column] = result;
            }

            return result;
        }

        #endregion
    }
}
