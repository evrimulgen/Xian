using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Configuration;
using ClearCanvas.ImageViewer.Services.DicomServer;

namespace ClearCanvas.ImageViewer.Configuration
{
    /// <summary>
    /// Extension point for views onto <see cref="DicomServerConfigurationComponent"/>
    /// </summary>
    [ExtensionPoint]
    public class DicomServerConfigurationComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// DicomServerConfigurationComponent class
    /// </summary>
    [AssociateView(typeof(DicomServerConfigurationComponentViewExtensionPoint))]
    public class DicomServerConfigurationComponent : ConfigurationApplicationComponent
    {
        private string _aeTitle;
        private int _port;
        private string _storageDir;
		private bool _enabled;

        /// <summary>
        /// Constructor
        /// </summary>
        public DicomServerConfigurationComponent()
        {
		}

        public override void Start()
        {
			Refresh();
			base.Start();

			this.Validation.Add(new AETitleValidatonRule());
			this.Validation.Add(new PortValidationRule());
        }

        public override void Stop()
        {
            base.Stop();
        }

        public void Refresh()
        {
			BlockingOperation.Run(this.ConnectToClientInternal);
			SignalPropertyChanged();
		}

		private void ConnectToClientInternal()
		{
			try
			{
				_enabled = true;
				DicomServerConfigurationHelper.Refresh(true);

				_aeTitle = DicomServerConfigurationHelper.AETitle;
				_port = DicomServerConfigurationHelper.Port;
				_storageDir = DicomServerConfigurationHelper.InterimStorageDirectory;
			}
			catch
			{
				_aeTitle = "";
				_port = 0;
				_storageDir = "";
				_enabled = false;

				this.Host.DesktopWindow.ShowMessageBox(SR.MessageFailedToRetrieveServerSettings, MessageBoxActions.Ok);
			}
		}

        public override void Save()
        {
            try
            {
				DicomServerConfigurationHelper.Update("localhost", _aeTitle, _port, _storageDir);
            }
            catch
            {
				this.Host.DesktopWindow.ShowMessageBox(SR.MessageFailedToUpdateServerSettings, MessageBoxActions.Ok);
			}
        }

        private void SignalPropertyChanged()
        {
            NotifyPropertyChanged("AETitle");
            NotifyPropertyChanged("Port");
            NotifyPropertyChanged("InterimStorageDirectory");
            NotifyPropertyChanged("Enabled");
        }

        #region Properties

        public string AETitle
        {
            get { return _aeTitle; }
            set 
            { 
                _aeTitle = value;
                this.Modified = true;
            }
        }

        public int Port
        {
            get { return _port; }
            set 
            { 
                _port = value;
                this.Modified = true;
            }
        }

        public string StorageDir
        {
            get { return _storageDir; }
            set 
            { 
                _storageDir = value;
                this.Modified = true;
            }
        }

        public bool Enabled
        {
			get { return _enabled; }
        }

        #endregion

    }
}
