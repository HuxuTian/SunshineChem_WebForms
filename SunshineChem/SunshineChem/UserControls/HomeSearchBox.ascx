<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeSearchBox.ascx.cs" Inherits="SunshineChem.UserControls.HomeSearchBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:radtextbox runat="server" skin="Silk" width="200px" id="SearchTextBox" />
<telerik:radbutton runat="server" skin="Silk" id="SearchButton" CausesValidation="false" OnClick="SearchButton_Click" text="Search" cssclass="search-button" />
