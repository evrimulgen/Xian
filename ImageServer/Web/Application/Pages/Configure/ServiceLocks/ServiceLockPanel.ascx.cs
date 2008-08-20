#region License

// Copyright (c) 2006-2008, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClearCanvas.ImageServer.Model;
using ClearCanvas.ImageServer.Model.EntityBrokers;
using ClearCanvas.ImageServer.Web.Common.Data;
using MessageBox=ClearCanvas.ImageServer.Web.Application.Controls.MessageBox;

namespace ClearCanvas.ImageServer.Web.Application.Pages.Configure.ServiceLocks
{
    /// <summary>
    /// Panel to display list of devices for a particular server partition.
    /// </summary>
    public partial class ServiceLockPanel : UserControl
    {
        #region Private members

        #endregion Private members

        #region Events

        public delegate void ServiceLockUpdatedListener(ServiceLock serviceLock);

        public event ServiceLockUpdatedListener ServiceLockUpdated;
        
        #endregion Events

        #region Public Properties

        #endregion


        #region protected methods


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            IList<ServiceLockTypeEnum> types = ServiceLockTypeEnum.GetAll();
            TypeDropDownList.Items.Add(new ListItem(App_GlobalResources.SR.All)); 
            foreach (ServiceLockTypeEnum t in types)
            {
                TypeDropDownList.Items.Add(new ListItem(t.Description, t.Lookup));
            }

            EditServiceLockDialog.ServiceLockUpdated += AddEditServiceLockDialog_ServiceLockUpdated; 
            // setup child controls
            GridPagerTop.ItemName = App_GlobalResources.SR.GridPagerServiceSingleItem;
            GridPagerTop.PuralItemName = App_GlobalResources.SR.GridPagerServiceMultipleItems;
            GridPagerTop.Target = ServiceLockGridViewControl.TheGrid;
            
            GridPagerBottom.ItemName = App_GlobalResources.SR.GridPagerServiceSingleItem;
            GridPagerBottom.PuralItemName = App_GlobalResources.SR.GridPagerServiceMultipleItems;
            GridPagerBottom.Target = ServiceLockGridViewControl.TheGrid;
            
            StatusFilter.Items.Add(new ListItem(App_GlobalResources.SR.All));
            StatusFilter.Items.Add(new ListItem(App_GlobalResources.SR.Enabled));
            StatusFilter.Items.Add(new ListItem(App_GlobalResources.SR.Disabled));

            ConfirmEditDialog.Confirmed += ConfirmEditDialog_Confirmed;

            GridPagerTop.GetRecordCountMethod = delegate {
                                                           return
                                                               ServiceLockGridViewControl.ServiceLocks != null
                                                                   ? ServiceLockGridViewControl.ServiceLocks.Count
                                                                   : 0; };
            GridPagerBottom.GetRecordCountMethod = delegate
            {
                return
                    ServiceLockGridViewControl.ServiceLocks != null
                        ? ServiceLockGridViewControl.ServiceLocks.Count
                        : 0;
            };
        }

        
        protected override void OnPreRender(EventArgs e)
        {
            UpdateToolbarButtons();
            UpdateListPanel();
            base.OnPreRender(e);
            
        }



        protected void UpdateListPanel()
        {
            ServiceLockGridViewControl.Refresh();
        }

        protected void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            LoadServiceLocks();

        }


        protected void EditServiceScheduleButton_Click(object sender, ImageClickEventArgs e)
        {
            ServiceLock service = ServiceLockGridViewControl.SelectedServiceLock;
            if (service != null)
            {
                EditServiceLock(service);
            }
        }



        protected void RefreshButton_Click(object sender, ImageClickEventArgs e)
        {
            LoadServiceLocks();
        }

        #endregion Protected methods


        #region Private Methods
        void AddEditServiceLockDialog_ServiceLockUpdated(ServiceLock serviceLock)
        {
            DataBind();
            if (ServiceLockUpdated != null)
                ServiceLockUpdated(serviceLock);
        }

        void ConfirmEditDialog_Confirmed(object data)
        {
            ShowEditServiceLockDialog();
        }



        private void EditServiceLock(ServiceLock service)
        {
            EditServiceLockDialog.ServiceLock = service;

            if (service != null)
            {
                if (service.Lock)
                {
                    ConfirmEditDialog.Message = App_GlobalResources.SR.ServiceLockUpdate_Confirm_ServiceIsLocked;
                    ConfirmEditDialog.MessageType =
                        MessageBox.MessageTypeEnum.YESNO;
                    ConfirmEditDialog.Show();
                }
                else
                {
                    ShowEditServiceLockDialog();
                }

            }


        }


        private void ShowEditServiceLockDialog()
        {
            EditServiceLockDialog.Show();
        }


        #endregion Private Methods


        #region Public methods

        public override void DataBind()
        {
            LoadServiceLocks();
            base.DataBind();
        }

        /// <summary>
        /// Load the devices for the partition based on the filters specified in the filter panel.
        /// </summary>
        /// <remarks>
        /// This method only reloads and binds the list bind to the internal grid. <seealso cref="UpdateUI()"/> should be called
        /// to explicit update the list in the grid. 
        /// <para>
        /// This is intentionally so that the list can be reloaded so that it is available to other controls during postback.  In
        /// some cases we may not want to refresh the list if there's no change. Calling <seealso cref="UpdateUI()"/> will
        /// give performance hit as the data will be transfered back to the browser.
        ///  
        /// </para>
        /// </remarks>
        public void LoadServiceLocks()
        {
            ServiceLockSelectCriteria criteria = new ServiceLockSelectCriteria();

            ServiceLockConfigurationController controller = new ServiceLockConfigurationController();

            if (TypeDropDownList.SelectedValue != App_GlobalResources.SR.All)
            {
                criteria.ServiceLockTypeEnum.EqualTo(ServiceLockTypeEnum.GetEnum(TypeDropDownList.SelectedValue));
            }
            
            if (StatusFilter.SelectedIndex != 0)
            {
                if (StatusFilter.SelectedIndex == 1)
                    criteria.Enabled.EqualTo(true);
                else
                    criteria.Enabled.EqualTo(false);
            }

            criteria.Enabled.SortDesc(1);
            criteria.ServiceLockTypeEnum.SortAsc(2);
            criteria.ScheduledTime.SortAsc(3);

            IList<Model.ServiceLock> services = controller.GetServiceLocks(criteria);

            ServiceLockCollection items = new ServiceLockCollection();
            items.Add(services);

            ServiceLockGridViewControl.ServiceLocks = items;

            ServiceLockGridViewControl.DataBind();
        }

        /// <summary>
        /// Updates the device list window in the panel.
        /// </summary>
        /// <remarks>
        /// This method should only be called when necessary as the information in the list window needs to be transmitted back to the client.
        /// If the list is not changed, call <seealso cref="LoadServiceLocks()"/> instead.
        /// </remarks>
        public void UpdateToolbarButtons()
        {

            ServiceLock service = ServiceLockGridViewControl.SelectedServiceLock;
            EditServiceScheduleButton.Enabled = service != null;

            ToolbarUpdatePanel.Update();
        }


        #endregion Public methods
    }
}