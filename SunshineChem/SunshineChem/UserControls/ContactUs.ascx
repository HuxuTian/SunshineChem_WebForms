<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.ascx.cs" Inherits="SunshineChem.UserControls.ContactUs" %>

<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<div class="contact-us-container">
    <div class="contact-us-title">
        <%= FormTitle %>
    </div>
    <div class="contact-us-label">
        <%= FormNameLabel %><span style="color: red;">*</span>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="NameBox" ErrorMessage="(Name cannot be empty.)" ValidationGroup="ContactUs" CssClass="contact-us-validation-error-msg" />
    </div>
    <div>
        <telerik:RadTextBox runat="server" ID="NameBox" Skin="Silk" Width="500" />
    </div>

    <div class="contact-us-label">
        <%= FormEmailLabel %><span style="color: red;">*</span>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailBox" ValidationGroup="ContactUs" ErrorMessage="(Email address is invalid.)" CssClass="contact-us-validation-error-msg" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="EmailBox" ErrorMessage="(Email address is invalid.)" ValidationGroup="ContactUs" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" CssClass="contact-us-validation-error-msg" Display="Dynamic" />
    </div>
    <div>
        <telerik:RadTextBox runat="server" ID="EmailBox" Skin="Silk" Width="500" />
    </div>
    <div class="contact-us-label">
        <%= FormMessageLabel %><span style="color: red;">*</span>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="MessageBox" ErrorMessage="(Message cannot be empty.)" ValidationGroup="ContactUs" CssClass="contact-us-validation-error-msg" />
    </div>
    <div>
        <telerik:RadTextBox runat="server" ID="MessageBox" TextMode="MultiLine" Skin="Silk" Width="500" Height="150" />
    </div>
    <div class="contact-us-submit-button">
        <telerik:RadButton runat="server" Skin="Silk" ID="SubmitBtn" CausesValidation="true" ValidationGroup="ContactUs" OnClick="SubmitBtn_Click" />
    </div>
    <div class="contact-us-required-msg">
        <span style="color: red;">*</span>
        <%= RequiredFieldLabel %>
    </div>

</div>
<div>
    <div class="contact-us-info-container">
        <div class="contact-us-title-box">
            <i class="fa fa-map-marker"></i>
            <%= AddressLabel %>
        </div>
        <div class="contact-us-content-box">
            <p>
                <strong><%= CompanyTitle %></strong>
                <br />
                <%= Address1 %>
                <br />
                <%= Address2 %>
                <br />
                <%= Address3 %>
            </p>
        </div>
        <div class="contact-us-title-box">
            <i class="fa fa-envelope"></i>
            <%= EmailLabel %>
        </div>
        <div class="contact-us-content-box">
            <p class="contact-us-email-content">
                <a style="color: blue" href="mailto:"><%= Email %></a>
            </p>
        </div>
        <div class="contact-us-title-box">
            <i class="fa fa-phone"></i>
            <%= PhoneLabel %>
        </div>
        <div class="contact-us-content-box">
            <p class="contact-us-phone">
                <%= Phone %>
                <br />
                <%= Fax %>
            </p>
        </div>
    </div>
</div>