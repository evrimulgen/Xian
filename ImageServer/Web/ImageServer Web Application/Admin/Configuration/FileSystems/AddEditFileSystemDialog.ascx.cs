#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
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
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.ImageServer.Enterprise;
using ClearCanvas.ImageServer.Model;
using ClearCanvas.ImageServer.Web.Common;
using ImageServerWebApplication.Common;

namespace ImageServerWebApplication.Admin.Configuration.FileSystems
{
    //
    // Dialog for adding new device.
    //
    public partial class AddFilesystemDialog : UserControl
    {
        #region private variables
        // The server partitions that the new device can be associated with
        // This list will be determined by the user level permission.
        private IList<FilesystemTierEnum> _tiers = new List<FilesystemTierEnum>();

        private bool _editMode = false;
        private Filesystem _filesystem;
        #endregion

        #region public members
        /// <summary>
        /// Sets the list of filesystem tiers users allowed to pick for the new filesystem.
        /// </summary>
        public IList<FilesystemTierEnum> FilesystemTiers
        {
            set
            {
                _tiers = value;
            }

            get
            {
                return _tiers;
            }
        }

        /// <summary>
        /// Sets the dialog in edit mode or gets a value indicating whether the dialog is in edit mode.
        /// </summary>
        public bool EditMode
        {
            set { 
                _editMode = value;
                ViewState["AddEditFileSystemDialog_EditMode"] = value;
            }
            get { return _editMode; }
        }

        /// <summary>
        /// Sets the filesystem to be editted or retrieves the new filesystem to be added.
        /// </summary>
        public Filesystem FileSystem
        {
            set { _filesystem = value;
                ViewState["AddEditFilesystemDialog_FileSystem"] = value;
            }
            get { return _filesystem; }
        }

        #endregion // public members


        #region Events
        /// <summary>
        /// Defines the event handler for <seealso cref="OKClicked"/>.
        /// </summary>
        /// <param name="filesystem">The device being added.</param>
        public delegate void OKClickedEventHandler(Filesystem filesystem);
        /// <summary>
        /// Occurs when users click on "OK".
        /// </summary>
        public event OKClickedEventHandler OKClicked;

        #endregion Events

        #region Public delegates


        #endregion // public delegates

        #region Protected methods

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            
            // Set up the popup extender
            // These settings could been done in the aspx page as well
            // but if we are to javascript to display, that won't work.
            ModalPopupExtender1.PopupControlID = DialogPanel.UniqueID;
            ModalPopupExtender1.TargetControlID = DummyPanel.UniqueID;
            ModalPopupExtender1.BehaviorID = ModalPopupExtender1.UniqueID;

            ModalPopupExtender1.DropShadow = true;
            ModalPopupExtender1.Drag = true;
            ModalPopupExtender1.PopupDragHandleControlID = TitleBarPanel.UniqueID;


            // Register a javascript that can be called to popup this dialog on the client
            // 
            Page.RegisterClientScriptBlock("popupThisWindow",
                      @"<script language='javascript'>
                        function ShowAddDeviceDialog()
                        {  
                            var ctrl = $find('" + ModalPopupExtender1.UniqueID + @"'); 
                            ctrl.show();
                        }
                    </script>");


           
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
            {

            }
            else
            {
                // reload the device information that was editted
                if (ViewState["AddEditFileSystemDialog_EditMode"]!=null)
                    _editMode = (bool) ViewState["AddEditFileSystemDialog_EditMode"];

                FileSystem = ViewState["AddEditFilesystemDialog_FileSystem"] as Filesystem;
            }
        }


        /// <summary>
        /// Handles event when user clicks on "OK" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OKButton_Click(object sender, EventArgs e)
        {
            if (EditMode == false)
            {
                // is add mode... create a filesystem 
                FileSystem = new Filesystem();
            }

            FileSystem.Description = DescriptionTextBox.Text;
            FileSystem.FilesystemPath = PathTextBox.Text;
            FileSystem.ReadOnly = ReadCheckBox.Checked && WriteCheckBox.Checked == false;
            FileSystem.WriteOnly = WriteCheckBox.Checked && ReadCheckBox.Checked == false;
            FileSystem.Enabled = ReadCheckBox.Checked || WriteCheckBox.Checked;
            
            FileSystem.FilesystemTierEnum = FilesystemTiers[TiersDropDownList.SelectedIndex];
            
            if (OKClicked != null)
                OKClicked(FileSystem);

            Close();
           

        }

        
        protected void ReadOnlyCheckBox_Init(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {

        }

        #endregion Protected methods


        #region Public methods
        /// <summary>
        /// Displays the add device dialog box.
        /// </summary>
        public void Show()
        {
            // STRANGE AJAX BUG?: 
            //      This block of code will cause 
            //      WebForms.PageRequestManagerServerErrorException: Status code 500 when the dialog box is dismissed.
            //
            //
            // Pre-fill the data
            //
            //  AETitleTextBox.Text = "<Enter AE Title>";
            //  ActiveCheckBox.Checked = false;
            //  DHCPCheckBox.Checked = false;
            //  DescriptionTextBox.Text = "<Enter Description>";
            //  PortTextBox.Text = "<Port #>";

            if (EditMode)
            {
                // set the dialog box title and OK button text
                TitleLabel.Text = "Edit Filesystem";
                OKButton.Text = "Update";

                // set the data using the info in the filesystem to be editted
                DescriptionTextBox.Text = FileSystem.Description;
                PathTextBox.Text = FileSystem.FilesystemPath;
                ReadCheckBox.Checked = FileSystem.Enabled && (FileSystem.ReadOnly || (FileSystem.WriteOnly == false));
                WriteCheckBox.Checked = FileSystem.Enabled && (FileSystem.WriteOnly || (FileSystem.ReadOnly == false));

                
            }
            else
            {
                // set the dialog box title and OK button text
                TitleLabel.Text = "Add Filesystem";
                OKButton.Text = "Add";

                // Clear input
                DescriptionTextBox.Text = "";
                PathTextBox.Text = "";
                ReadCheckBox.Checked = true;
                WriteCheckBox.Checked = true;

            }


            // update the dropdown list
            TiersDropDownList.Items.Clear();
            foreach (FilesystemTierEnum tier in _tiers)
            {
                TiersDropDownList.Items.Add(new ListItem(tier.Description, tier.GetKey().Key.ToString()));
            }

            UpdatePanel.Update();
            ModalPopupExtender1.Show();
        }

        /// <summary>
        /// Dismisses the dialog box.
        /// </summary>
        public void Close()
        {
            // 
            // Clear all boxes
            //
            // STRANGE AJAX BUG?: 
            //      This block of code will cause 
            //      WebForms.PageRequestManagerServerErrorException: Status code 500 
            //      when other buttons are pressed AFTER the add device dialog box is dismissed.
            //
            //  Move the entire block into Show()
            //
            //  AETitleTextBox.Text = "<Enter AE Title>";
            //  ActiveCheckBox.Checked = false;
            //  DHCPCheckBox.Checked = false;
            //  DescriptionTextBox.Text = "<Enter Description>";
            //  PortTextBox.Text = "<Port #>";


            ModalPopupExtender1.Hide();
        }

        #endregion Public methods

        
    }
 
}
