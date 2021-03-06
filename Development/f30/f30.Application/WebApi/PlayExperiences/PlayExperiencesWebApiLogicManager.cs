﻿using f30.Data;
using f30.Data.PlayExperiences;
using Smart.Platform.Data;
using Smart.Platform.Diagnostics;
using Smart.Platform.Net.Serialization.JSON;
using System;
using System.Globalization;

namespace f30.Application.WebApi.PlayExperiences
{
    /// <summary>
    /// Manages the application layer for the PlayExperiencesWebApi.
    /// </summary>
    public class PlayExperiencesWebApiLogicManager
    {
        // Note: In keeping with storing data in a universal culture format, abstract the responsibility
        // for culture formatting up to the application data layer
        private CultureInfo _fromCultureInfo = new CultureInfo("en-GB");

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayExperiencesWebApiLogicManager"/> class.
        /// </summary>
        public PlayExperiencesWebApiLogicManager() { }

        #endregion

        #region Public Methods

        private DataManager _dataManager;

        /// <summary>
        /// Gets or sets the data manager.
        /// </summary>
        /// <value>The data manager.</value>
        public DataManager DataManager
        {
            get { return _dataManager; }
            set { _dataManager = value; }
        }

        /// <summary>
        /// Insert the item.
        /// </summary>
        /// <param name="dataWrapper">The data wrapper.</param>
        /// <exception cref="System.ApplicationException"></exception>
        public void Insert(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            _dataManager.PlayExperienceDataAdministrator.Initialise();

            // Create a new data item
            PlayExperience item = (PlayExperience)_dataManager.PlayExperienceDataAdministrator.Items.AddItem();

            item.CopyFromWrapper(dataWrapper, this._fromCultureInfo);

            // Set the item status so that the item is inserted
            item.Status = DataItemStatusTypes.New;

            // Save to the database
            _dataManager.PlayExperienceDataAdministrator.Save();

            // Set the parameters in the JSON wrapper to be returned
            dataWrapper.Items.Clear();
            dataWrapper.Params.Clear();
            dataWrapper.ID = item.ID.ToString();

        }

        /// <summary>
        /// Update the item.
        /// </summary>
        /// <param name="dataWrapper">The data wrapper.</param>
        /// <exception cref="System.ApplicationException"></exception>
        public void Update(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            _dataManager.PlayExperienceDataAdministrator.Initialise();

            // Create a new data item
            PlayExperience item = (PlayExperience)_dataManager.PlayExperienceDataAdministrator.Items.AddItem();

            item.CopyFromWrapper(dataWrapper, this._fromCultureInfo);

            // Set the item status so that the item is updated
            item.Status = DataItemStatusTypes.Modified;

            // Save to the database
            _dataManager.PlayExperienceDataAdministrator.Save();

            // Set the parameters in the JSON wrapper to be returned
            dataWrapper.Items.Clear();
            dataWrapper.Params.Clear();

        }

        /// <summary>
        /// Delete the item.
        /// </summary>
        /// <param name="dataWrapper">The data wrapper.</param>
        /// <exception cref="System.ApplicationException"></exception>
        public void Delete(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            _dataManager.PlayExperienceDataAdministrator.Initialise();

            // Create a new data item
            PlayExperience item = (PlayExperience)_dataManager.PlayExperienceDataAdministrator.Items.AddItem();

            item.ID = Int32.Parse(dataWrapper.ID);

            // Set the item status so that the item is deleted
            item.Status = DataItemStatusTypes.Deleted;

            // Save to the database
            _dataManager.PlayExperienceDataAdministrator.Save();

            // Set the parameters in the JSON wrapper to be returned
            dataWrapper.Items.Clear();
            dataWrapper.Params.Clear();

        }

        /// <summary>
        /// Loads the by relativeMemberID.
        /// </summary>
        /// <param name="relativeMemberID">The relativeMemberID.</param>
        /// <param name="dataWrapper">The data wrapper.</param>
        /// <exception cref="ApplicationException"></exception>
        public void LoadByRelativeMemberID( int relativeMemberID,
                                            DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            _dataManager.PlayExperienceDataAdministrator.Initialise();

            // Load the data
            _dataManager.PlayExperienceDataAdministrator.LoadItemsByRelativeMemberID(relativeMemberID);

            // Put the data in a wrapper
            dataWrapper = this.DataToWrapper(dataWrapper);
        }

        #endregion

        #region Private Methods

        private DataJSONWrapper DataToWrapper(DataJSONWrapper dataWrapper)
        {
            #region Check Parameters

            if (dataWrapper == null) throw new ApplicationException(ExceptionManager.MessageMethodFailed(System.Reflection.MethodBase.GetCurrentMethod(), "dataWrapper is nothing"));

            #endregion

            dataWrapper.Items.Clear();

            // Put the items in the wrapper
            DataJSONWrapper w = _dataManager.PlayExperienceDataAdministrator.ToWrapper();
            w.ID = "PlayExperiences";

            dataWrapper.Items.Add(w);

            return dataWrapper;
        }

        #endregion
    }
}
