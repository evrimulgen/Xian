using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms view onto <see cref="CannedTextEditorComponent"/>
    /// </summary>
    [ExtensionOf(typeof(CannedTextEditorComponentViewExtensionPoint))]
    public class CannedTextEditorComponentView : WinFormsView, IApplicationComponentView
    {
        private CannedTextEditorComponent _component;
        private CannedTextEditorComponentControl _control;


        #region IApplicationComponentView Members

        public void SetComponent(IApplicationComponent component)
        {
            _component = (CannedTextEditorComponent)component;
        }

        #endregion

        public override object GuiElement
        {
            get
            {
                if (_control == null)
                {
                    _control = new CannedTextEditorComponentControl(_component);
                }
                return _control;
            }
        }
    }
}
