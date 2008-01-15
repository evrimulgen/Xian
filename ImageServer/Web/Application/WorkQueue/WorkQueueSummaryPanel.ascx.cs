using System;
using System.Drawing;
using System.Web.UI;
using ClearCanvas.ImageServer.Model;

namespace ClearCanvas.ImageServer.Web.Application.WorkQueue
{
    /// <summary>
    /// WorkQueue Summary Panel 
    /// </summary>
    public partial class WorkQueueSummaryPanel : System.Web.UI.UserControl
    {
        
        #region Private members
        private WorkQueueSummary _workqueueSummary;
        #endregion Private members

		#region Public Properties

        public WorkQueueSummary WorkQueueSummary
        {
            get { return _workqueueSummary; }
            set { _workqueueSummary = value; }
        }
        
        #endregion Public Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            WorkQueueType.Text = _workqueueSummary.Type.Description;

            WorkQueueStatus.Text = _workqueueSummary.Status.Description;
            WorkQueueStatus.ToolTip = _workqueueSummary.Status.LongDescription;
            
            ScheduledTime.Text = _workqueueSummary.ScheduledDateTime.ToString();

            PatientID.Text = _workqueueSummary.PatientID;

            PatientsName.Text = _workqueueSummary.PatientName;

        }

        #endregion Protected Methods
    }
}