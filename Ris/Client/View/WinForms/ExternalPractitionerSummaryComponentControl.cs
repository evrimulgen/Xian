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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="StaffSummaryComponent"/>
    /// </summary>
    public partial class ExternalPractitionerSummaryComponentControl : ApplicationComponentUserControl
    {
        private ExternalPractitionerSummaryComponent _component;

        /// <summary>
        /// Constructor
        /// </summary>
        public ExternalPractitionerSummaryComponentControl(ExternalPractitionerSummaryComponent component)
            : base(component)
        {
            InitializeComponent();
            _component = component;

            _practitionerTableView.ToolbarModel = _component.PractitionersListActionModel;
            _practitionerTableView.MenuModel = _component.PractitionersListActionModel;

            _practitionerTableView.Table = _component.Practitioners;
            _practitionerTableView.DataBindings.Add("Selection", _component, "SelectedPractitioner", true, DataSourceUpdateMode.OnPropertyChanged);

            _firstName.DataBindings.Add("Value", _component, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            _lastName.DataBindings.Add("Value", _component, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);

            _okButton.DataBindings.Add("Visible", _component, "ShowAcceptCancelButtons");
            _okButton.DataBindings.Add("Enabled", _component, "AcceptEnabled");
            _cancelButton.DataBindings.Add("Visible", _component, "ShowAcceptCancelButtons");
        }

        private void _staffs_Load(object sender, EventArgs e)
        {
            //_component.LoadStaffTable();
        }

        private void _staffs_ItemDoubleClicked(object sender, EventArgs e)
        {
            _component.DoubleClickSelectedPractitioner();
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            using (new CursorManager(Cursors.WaitCursor))
            {
                _component.Search();
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            _component.Accept();        
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }
    }
}
