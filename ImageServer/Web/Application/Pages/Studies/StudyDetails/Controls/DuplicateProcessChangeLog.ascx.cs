#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using ClearCanvas.ImageServer.Common.Utilities;
using ClearCanvas.ImageServer.Core.Data;
using ClearCanvas.ImageServer.Model;
using Resources;

namespace ClearCanvas.ImageServer.Web.Application.Pages.Studies.StudyDetails.Controls
{
    public partial class DuplicateProcessChangeLog : System.Web.UI.UserControl
    {
        private ProcessDuplicateChangeLog _changeLog;
        public StudyHistory HistoryRecord;

        protected ProcessDuplicateChangeLog ChangeLog
        {
            get
            {
                if (_changeLog==null)
                {
                    _changeLog = XmlUtils.Deserialize<ProcessDuplicateChangeLog>(HistoryRecord.ChangeDescription);
                }

                return _changeLog;
            }
        }

        /// <summary>
        /// </summary>
        protected String ActionDescription
        {
            get
            {
                if (ChangeLog == null)
                {
                    return SR.Unknown;
                }
                else
                {
                    switch(ChangeLog.Action)
                    {
                        case ProcessDuplicateAction.Delete:
                            return SR.StudyDetails_History_Duplicate_Delete;
                        case ProcessDuplicateAction.OverwriteAsIs:
                            return SR.StudyDetails_History_Duplicate_OverwriteAsIs;
                        case ProcessDuplicateAction.OverwriteUseDuplicates:
                            return SR.StudyDetails_History_Duplicate_OverwriteWithDuplicateData;

                        case ProcessDuplicateAction.OverwriteUseExisting:
                            return SR.StudyDetails_History_Duplicate_OverwriteWithExistingData;

                        default:
                            return ChangeLog.Action.ToString();

                    }
                }
            }
        }

        protected String ChangeLogShortDescription
        {
            get
            {
                if (ChangeLog == null)
                {
                    return SR.Unknown;
                }

                switch (ChangeLog.Action)
                {
                    case ProcessDuplicateAction.Delete:
                        return SR.StudyDetails_History_Duplicate_Delete;
                    case ProcessDuplicateAction.OverwriteAsIs:
                        return SR.StudyDetails_History_Duplicate_OverwriteAsIs;
                    case ProcessDuplicateAction.OverwriteUseDuplicates:
                        return SR.StudyDetails_History_Duplicate_OverwriteWithDuplicateData;

                    case ProcessDuplicateAction.OverwriteUseExisting:
                        return SR.StudyDetails_History_Duplicate_OverwriteWithExistingData;

                    default:
                        return ChangeLog.Action.ToString();

                }
            }
        }

    }
}