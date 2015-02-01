<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategoryPanel.ascx.cs" Inherits="SunshineChem.UserControls.ProductCategoryPanel" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<telerik:RadMenu runat="server" Flow="Vertical" Width="300" OnItemClick="ProductCategoryMenu_ItemClick" Skin="Silk" ID="ProductCategoryMenu" ></telerik:RadMenu>

<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ProductCategoryMenu">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ProductResultGrid" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadGrid runat="server" ID="ProductResultGrid" Skin="Silk" Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnNeedDataSource="ProductResultGrid_NeedDataSource" >
    <MasterTableView DataKeyNames="ID">
        <Columns>
            <telerik:GridBoundColumn DataField="ID" />
            <telerik:GridBoundColumn DataField="Name" />
            <telerik:GridBoundColumn DataField="CasNumber" />
        </Columns>
    </MasterTableView>
    <ClientSettings>
        <Resizing AllowRowResize="true" />
    </ClientSettings>
</telerik:RadGrid>