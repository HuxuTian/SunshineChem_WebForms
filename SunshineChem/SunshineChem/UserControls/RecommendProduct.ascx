<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendProduct.ascx.cs" Inherits="SunshineChem.UserControls.RecommendProduct" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<div class="recommend-product-table-title">
    Recommend Products
</div>
<telerik:RadGrid runat="server" Skin="Silk" ID="GridRecommendProduct" Height="100%" Width="100%" AutoGenerateColumns="False" GroupPanelPosition="Top">
    <MasterTableView DataKeyNames="ID">
        <Columns>
            <telerik:GridHyperLinkColumn DataTextField="CatNumber" HeaderText="Cat. No." DataNavigateUrlFields="NavigationUrl" />
            <telerik:GridBoundColumn DataField="Name" HeaderText="Name" />
            <telerik:GridBoundColumn DataField="CasNumber" HeaderText="CAS Number" />
            <telerik:GridBoundColumn DataField="Package" HeaderText="Package" />
            <telerik:GridBoundColumn DataField="Price" HeaderText="Price" />
        </Columns>
    </MasterTableView>
    <ClientSettings>
        <Resizing AllowRowResize="true" />
        <Scrolling AllowScroll="true" UseStaticHeaders="true" SaveScrollPosition="true" />
    </ClientSettings>
    <HeaderStyle HorizontalAlign="Justify" Font-Italic="True" Font-Size="Small"></HeaderStyle>
    <ItemStyle Height="40px" Font-Size="Small" VerticalAlign="Middle" HorizontalAlign="Justify"></ItemStyle>
    <AlternatingItemStyle BackColor="#E0E0E0" Font-Size="Small" Height="40px" VerticalAlign="Middle" HorizontalAlign="Justify" />
</telerik:RadGrid>