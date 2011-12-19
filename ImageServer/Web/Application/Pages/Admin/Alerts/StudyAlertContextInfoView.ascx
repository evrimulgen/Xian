<%--  License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

--%>


<%@ Import namespace="ClearCanvas.ImageServer.Core.Validation"%>
<%@ Import namespace="ClearCanvas.ImageServer.Services.WorkQueue"%>
<%@ Import namespace="ClearCanvas.ImageServer.Web.Common.Utilities"%>
<%@ Import Namespace="Resources" %>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudyAlertContextInfoView.ascx.cs" Inherits="ClearCanvas.ImageServer.Web.Application.Pages.Admin.Alerts.StudyAlertContextInfoView" %>
<%@ Import Namespace="ClearCanvas.ImageServer.Model"%>

<%  StudyAlertContextInfo data = this.Alert.ContextData as StudyAlertContextInfo;
    String viewStudyUrl = HtmlUtility.ResolveStudyDetailsUrl(Page, data.ServerPartitionAE, data.StudyInstanceUid);
%>

<div >
<table cellpadding="0" cellspacing="0" style="margin-top: 3px;">
    <tr >
        <td><a href='<%=viewStudyUrl%>' target="_blank" style="color: #6699CC; text-decoration: none; font-weight: bold;"><%=Labels.WorkQueueAlertContextDataView_ViewStudy%></a></td>        
    </tr>
</table>

</div>
