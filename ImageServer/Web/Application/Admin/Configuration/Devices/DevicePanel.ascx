<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DevicePanel.ascx.cs"
    Inherits="ClearCanvas.ImageServer.Web.Application.Admin.Configuration.Devices.DevicePanel" %>
<%@ Register Src="~/Common/GridPager.ascx" TagName="GridPager" TagPrefix="uc8" %>
<%@ Register Src="DeviceGridView.ascx" TagName="DeviceGridView" TagPrefix="uc1" %>
<%@ Register TagPrefix="clearcanvas" Namespace="ClearCanvas.ImageServer.Web.Common.WebControls.UI" 
    Assembly="ClearCanvas.ImageServer.Web.Common" %>
<%@ Register Src="~/Common/ConfirmationDialog.ascx" TagName="ConfirmationDialog" TagPrefix="clearcanvas" %>
<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Table ID="Table" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
                BorderWidth="0px">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell HorizontalAlign="left" VerticalAlign="Bottom" Wrap="false" Width="100%">
                        <asp:Panel ID="Panel2" runat="server" CssClass="CSSToolbarPanelContainer">
                            <asp:Panel ID="Panel3" runat="server" CssClass="CSSToolbarPanelBorder" Wrap="False">
                                <asp:Panel ID="Panel4" runat="server" CssClass="CSSToolbarContent">
                                
                                 <clearcanvas:ToolbarButton
                                        ID="AddToolbarButton" runat="server" 
                                        EnabledImageURL="~/images/icons/AddEnabled.png" 
                                        DisabledImageURL="~/images/icons/AddDisabled.png"
                                        OnClick="AddButton_Click" AlternateText="Add a device" 
                                        />
                                        
                                  <clearcanvas:ToolbarButton
                                        ID="EditToolbarButton" runat="server" 
                                        EnabledImageURL="~/images/icons/EditEnabled.png" 
                                        DisabledImageURL="~/images/icons/EditDisabled.png"
                                        OnClick="EditButton_Click" AlternateText="Edit a device"
                                        />
                                   <clearcanvas:ToolbarButton
                                        ID="DeleteToolbarButton" runat="server" 
                                        EnabledImageURL="~/images/icons/DeleteEnabled.png" 
                                        DisabledImageURL="~/images/icons/DeleteDisabled.png"
                                        OnClick="DeleteButton_Click" AlternateText="Delete device"
                                        />
                                        
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell HorizontalAlign="right" VerticalAlign="Bottom" Wrap="false">
                        <asp:Panel ID="FilterPanel" runat="server" CssClass="CSSFilterPanelContainer">
                            <asp:Panel ID="Panel5" runat="server" CssClass="CSSFilterPanelBorder">
                                <asp:Panel ID="Panel6" runat="server" CssClass="CSSFilterPanelContent">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label1" runat="server" Text="AE Title" CssClass="CSSTextBoxLabel"
                                                    EnableViewState="False"></asp:Label><br />
                                                <asp:TextBox ID="AETitleFilter" runat="server" CssClass="CSSFilterTextBox" ToolTip="Filter the list by AE Title"></asp:TextBox></td>
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" Text="IP Address" CssClass="CSSTextBoxLabel"
                                                    EnableViewState="False"></asp:Label><br />
                                                <asp:TextBox ID="IPAddressFilter" runat="server" CssClass="CSSFilterTextBox" ToolTip="Filter the list by IP Address"></asp:TextBox></td>
                                            <td align="left" valign="bottom">
                                                <asp:CheckBox ID="EnabledOnlyFilter" runat="server" Text="Enabled" ToolTip="Show Enabled devices only"
                                                    CssClass="CSSCheckBox" /></td>
                                            <td align="left" valign="bottom">
                                                <asp:CheckBox ID="DHCPOnlyFilter" runat="server" Text="DHCP" ToolTip="Show only devices using DHCP"
                                                    CssClass="CSSCheckBox" /></td>
                                            <td align="right" valign="bottom">
                                                <asp:Panel ID="FilterButtonContainer" runat="server" CssClass="FilterButtonContainer">                                                        
                                                    <clearcanvas:ToolbarButton
                                                        ID="FilterToolbarButton" runat="server" 
                                                        EnabledImageURL="~/images/icons/QueryEnabled.png" 
                                                        DisabledImageURL="~/images/icons/QueryDisabled.png"
                                                        OnClick="FilterButton_Click" Tooltip="Filter devices"
                                                        />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow Height="100%">
                    <asp:TableCell ColumnSpan="2">
                        <uc1:DeviceGridView ID="DeviceGridViewControl1" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <uc8:GridPager ID="GridPager1" runat="server"></uc8:GridPager>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        
        <clearcanvas:ConfirmationDialog ID="ConfirmDialog1" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
