<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeSearchBox.ascx.cs" Inherits="SunshineChem.UserControls.HomeSearchBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadTextBox runat="server" Skin="Silk" Width="200px" ID="SearchTextBox" />
<telerik:RadButton runat="server" Skin="Silk" ID="SearchButton" OnClick="SearchButton_Click" Text="Search" CssClass="search-button" />
