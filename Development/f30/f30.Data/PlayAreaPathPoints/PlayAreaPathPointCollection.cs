﻿using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayAreaPathPoints
{
    /// <summary>
    /// Encapsulates a collection of PlayAreaPathPoint items.
    /// </summary>
    public class PlayAreaPathPointCollection : DataItemCollectionBase
    {
        #region Constructors

        private PlayAreaPathPointCollection() : base() { }

        public PlayAreaPathPointCollection(IDataAdministrator  dataAdministrator,
                                string              defaultCultureInfoName)
            : base(dataAdministrator, defaultCultureInfoName)
        { }

        public PlayAreaPathPointCollection(XmlDocument         dataDocument,
                                IDataAdministrator  dataAdministrator,
                                string              defaultCultureInfoName)
            : base(dataDocument, dataAdministrator, defaultCultureInfoName)
        { }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayAreaPathPoint"; }
        }

        public override IDataItem GetNewItem()
        {
            // Create the new item
            PlayAreaPathPoint item = new PlayAreaPathPoint(_dataDocument, this, _defaultCultureInfoName);

            // Set the ID
            item.ID = this.GetNextID();

            return item;
        }

        public override IDataItem GetNewItem(XmlNode node)
        {
            #region Check Parameters

            if (node == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "node is nothing"));

            #endregion

            // Create the item
            PlayAreaPathPoint item = new PlayAreaPathPoint(node, this, _defaultCultureInfoName);

            return item;
        }
        
        public override IDataItem GetNewItem(DataRow row, CultureInfo fromCultureInfo)
        {
            #region Check Parameters

            if (row == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "row is nothing"));
            if (fromCultureInfo == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "fromCultureInfo is nothing"));

            #endregion

            // Create the new item
            PlayAreaPathPoint item = (PlayAreaPathPoint)this.GetNewItem();

            // Go through each column
            foreach (DataColumn column in row.Table.Columns)
            {
                // Set the property in the item
                item.SetProperty(column.ColumnName, row[column.ColumnName].ToString(), false, fromCultureInfo);
            }

            return item;
        }

        #endregion

        #region Protected Override Methods

        protected override void HandleValidationPassed(object item, int propertyEnum, string message, ValidationResultTypes validationResult)
        {
            this.OnValidationPassed((IHasValidations)item, propertyEnum, message, validationResult);
        }

        protected override void HandleValidationFailed(object item, int propertyEnum, string message, ValidationResultTypes validationResult)
        {
            this.OnValidationFailed((IHasValidations)item, propertyEnum, message, validationResult);
        }

        #endregion
    }
}
