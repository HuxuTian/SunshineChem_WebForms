<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategoryPanel.ascx.cs" Inherits="SunshineChem.UserControls.ProductCategoryPanel" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<div style="float: left; width: 200px;">
    <telerik:RadMenu runat="server" Flow="Vertical" Width="100%" OnItemClick="ProductCategoryMenu_ItemClick" Skin="Silk" ID="ProductCategoryMenu"></telerik:RadMenu>
</div>

<asp:Panel runat="server" ID="SearchResultsPanel" Visible="false">
    <div style="float: left; width: 225px; font-size: 13px;">
        <div class="search-title-box">
            <strong>Search</strong>
        </div>
        <div class="search-content-box">
            <div>
                Search for 
            <span style="color: red;">"<%= SearchKeyword  %>"</span>
            </div>
            <div>
                Found 
            <span style="color: red"><%= ResultCount %></span> result(s) in 
            <span style="color: blue"><%= ElapsedTime %></span> seconds
            </div>
            <div class="search-block">
                <telerik:RadTextBox runat="server" ID="SearchPageSearchBox" Skin="Silk" Width="203" />
                <telerik:RadButton runat="server" ID="SearchPageButton" OnClick="SearchPageButton_Click" Text="Search" Skin="Silk" CssClass="search-page-search-btn" />
                <telerik:RadButton runat="server" ID="ResetSearchButton" OnClick="ResetSearchButton_Click" Text="Reset" Skin="Silk" CssClass="search-page-reset-btn" />
            </div>
        </div>
    </div>
</asp:Panel>

<div style="float: right; width: 75%">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ProductCategoryMenu">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ProductResultGrid" LoadingPanelID="LoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ProductResultGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ProductResultGrid" LoadingPanelID="LoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <telerik:RadAjaxLoadingPanel runat="server" Skin="Silk" ID="LoadingPanel"></telerik:RadAjaxLoadingPanel>

    <telerik:RadGrid runat="server" ID="ProductResultGrid" Skin="Silk" AutoGenerateColumns="false" AllowPaging="true" PageSize="15"
        OnNeedDataSource="ProductResultGrid_NeedDataSource" OnItemCommand="ProductResultGrid_ItemCommand">
        <MasterTableView DataKeyNames="ID" AllowSorting="true" AllowNaturalSort="false">
            <Columns>
                <telerik:GridHyperLinkColumn DataTextField="CatNumber" HeaderText="Cat. No." DataNavigateUrlFields="NavigationUrl" />
                <telerik:GridBoundColumn DataField="Name" HeaderText="Name" />
                <telerik:GridBoundColumn DataField="CasNumber" HeaderText="CAS#" />
                <telerik:GridBoundColumn DataField="Package" HeaderText="Package" />
                <telerik:GridBoundColumn DataField="Price" HeaderText="Price" />
            </Columns>
            <NestedViewSettings>
                <ParentTableRelation>
                    <telerik:GridRelationFields MasterKeyField="ID" DetailKeyField="ID" />
                </ParentTableRelation>
            </NestedViewSettings>
            <NestedViewTemplate>
                <div style="overflow: hidden; border-bottom: 1px dashed #ddd;">
                    <div style="float: left;">
                        <asp:Image runat="server" ImageUrl='<%# Eval("ImageUrl") %>' />
                    </div>
                    <div style="float: right; margin-right: 30px;">
                        <table class="table table-bordered">
                            <tr>
                                <td>Name</td>
                                <td><%# Eval("Name")%></td>
                            </tr>
                            <tr>
                                <td>Synonym</td>
                                <td><%# Eval("Synonym")%></td>
                            </tr>
                            <tr>
                                <td>CAS#</td>
                                <td><%# Eval("CasNumber")%></td>
                            </tr>
                            <tr>
                                <td>Cat#</td>
                                <td><%# Eval("CatNumber")%></td>
                            </tr>
                            <tr>
                                <td>Formula</td>
                                <td><%# Eval("Formula")%></td>
                                <%--<td>C<sub>21</sub>H<sub>34</sub></td>--%>
                            </tr>
                            <tr>
                                <td>Molecular Weight</td>
                                <td><%# Eval("MolecularWeight")%></td>
                            </tr>
                            <tr>
                                <td>Purity</td>
                                <td><%# Eval("purity")%></td>
                            </tr>
                            <tr>
                                <td>Solubility</td>
                                <td><%# Eval("solubility")%></td>
                            </tr>
                            <tr>
                                <td>Storage</td>
                                <td><%# Eval("storage")%></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </NestedViewTemplate>
        </MasterTableView>
        <SortingSettings EnableSkinSortStyles="true" />
        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true" />
            <Resizing AllowRowResize="true" />
        </ClientSettings>
    </telerik:RadGrid>
</div>
