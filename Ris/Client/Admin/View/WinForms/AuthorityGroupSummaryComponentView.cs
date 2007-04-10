using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.Admin.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms view onto <see cref="AuthorityGroupSummaryComponent"/>
    /// </summary>
    [ExtensionOf(typeof(AuthorityGroupSummaryComponentViewExtensionPoint))]
    public class AuthorityGroupSummaryComponentView : WinFormsView, IApplicationComponentView
    {
        private AuthorityGroupSummaryComponent _component;
        private AuthorityGroupSummaryComponentControl _control;


        #region IApplicationComponentView Members

        public void SetComponent(IApplicationComponent component)
        {
            _component = (AuthorityGroupSummaryComponent)component;
        }

        #endregion

        public override object GuiElement
        {
            get
            {
                if (_control == null)
                {
                    _control = new AuthorityGroupSummaryComponentControl(_component);
                }
                return _control;
            }
        }
    }
}
