using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Desktop;

namespace ClearCanvas.Ris.Client.Adt.Folders
{
    /// <summary>
    /// Extension point for views onto <see cref="FolderOptionComponent"/>
    /// </summary>
    [ExtensionPoint]
    public class FolderOptionComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// FolderOptionComponent class
    /// </summary>
    [AssociateView(typeof(FolderOptionComponentViewExtensionPoint))]
    public class FolderOptionComponent : ApplicationComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FolderOptionComponent()
        {
        }

        public override void Start()
        {
            // TODO prepare the component for its live phase
            base.Start();
        }

        public override void Stop()
        {
            // TODO prepare the component to exit the live phase
            // This is a good place to do any clean up
            base.Stop();
        }

        public void Accept()
        {
            if (this.HasValidationErrors)
            {
                this.ShowValidation(true);
            }
            else
            {
                this.ExitCode = ApplicationComponentExitCode.Normal;
                Host.Exit();
            }
        }

        public void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.Cancelled;
            Host.Exit();
        }

    }
}
