using Smart.Platform.Data;
using Smart.Platform.Data.Validation;
using Smart.Platform.Diagnostics;
using System;
using System.Data;
using System.Globalization;
using System.Xml;

namespace f30.Data.PlayChallengeObjectives
{
    /// <summary>
    /// Encapsulates a collection of PlayChallengeObjective items.
    /// </summary>
    public class PlayChallengeObjectiveCollection : DataItemCollectionBase
    {
        #region Constructors

        private PlayChallengeObjectiveCollection() : base() { }

        public PlayChallengeObjectiveCollection(IDataAdministrator  dataAdministrator,
                                string              defaultCultureInfoName)
            : base(dataAdministrator, defaultCultureInfoName)
        { }

        public PlayChallengeObjectiveCollection(XmlDocument         dataDocument,
                                IDataAdministrator  dataAdministrator,
                                string              defaultCultureInfoName)
            : base(dataDocument, dataAdministrator, defaultCultureInfoName)
        { }

        #endregion

        #region Public Override Methods

        public override string DataType
        {
            get { return "PlayChallengeObjective"; }
        }

        public override IDataItem GetNewItem()
        {
            // Create the new item
            PlayChallengeObjective item = new PlayChallengeObjective(_dataDocument, this, _defaultCultureInfoName);

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
            PlayChallengeObjective item = new PlayChallengeObjective(node, this, _defaultCultureInfoName);

            return item;
        }
        
        public override IDataItem GetNewItem(DataRow row, CultureInfo fromCultureInfo)
        {
            #region Check Parameters

            if (row == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "row is nothing"));
            if (fromCultureInfo == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "fromCultureInfo is nothing"));

            #endregion

            // Create the new item
            PlayChallengeObjective item = (PlayChallengeObjective)this.GetNewItem();

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
