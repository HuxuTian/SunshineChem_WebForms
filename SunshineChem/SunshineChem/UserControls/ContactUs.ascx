<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.ascx.cs" Inherits="SunshineChem.UserControls.ContactUs" %>

<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<div class="contact-us-container">
    <div class="contact-us-title">
        <asp:Label runat="server" ID="ContactUsTitle" Text="Contact Us" />
    </div>
    <div class="contact-us-label">
        <asp:Label runat="server" ID="NameLabel" Text="Name" /><span style="color: red;">*</span>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="NameBox" ErrorMessage="(Name cannot be empty.)" ValidationGroup="ContactUs" CssClass="contact-us-validation-error-msg" />
    </div>
    <div>
        <telerik:RadTextBox runat="server" ID="NameBox" Skin="Silk" Width="500" />
    </div>

    <div class="contact-us-label">
        <asp:Label runat="server" ID="EmailLabel" Text="Email" /><span style="color: red;">*</span>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailBox" ValidationGroup="ContactUs" ErrorMessage="(Email address is invalid.)" CssClass="contact-us-validation-error-msg" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="EmailBox" ErrorMessage="(Email address is invalid.)" ValidationGroup="ContactUs" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" CssClass="contact-us-validation-error-msg" Display="Dynamic" />
    </div>
    <div>
        <telerik:RadTextBox runat="server" ID="EmailBox" Skin="Silk" Width="500" />
    </div>
    <div class="contact-us-label">
        <asp:Label runat="server" ID="MessageLabel" Text="Message" /><span style="color: red;">*</span>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="MessageBox" ErrorMessage="(Message cannot be empty.)" ValidationGroup="ContactUs" CssClass="contact-us-validation-error-msg" />
    </div>
    <div>
        <telerik:RadTextBox runat="server" ID="MessageBox" TextMode="MultiLine" Skin="Silk" Width="500" Height="150" />
    </div>
    <div class="contact-us-submit-button">
        <telerik:RadButton runat="server" Skin="Silk" ID="SubmitBtn" Text="Submit" CausesValidation="true" ValidationGroup="ContactUs" OnClick="SubmitBtn_Click" />
    </div>
    <div class="contact-us-required-msg">
        <span style="color: red;">*</span>
        <asp:Label runat="server" ID="RequiredMsg" Text="Required Fields" />
    </div>

</div>
<div>
    <div class="contact-us-info-container">
        <div class="contact-us-title-box">
            <i class="fa fa-map-marker"></i>
            Address
        </div>
        <div class="contact-us-content-box">
            <p>
                <strong>Sun-shine Chemical Technology Co., Ltd</strong>
                <br />
                No.8 Rd, Donghu High-Tech District
                <br />
                Wuhan, Hubei 430074
                <br />
                P.R.China
            </p>
        </div>
        <div class="contact-us-title-box">
            <i class="fa fa-envelope"></i>
            Email
        </div>
        <div class="contact-us-content-box">
            <p class="contact-us-email-content">
                <a style="color: blue" href="mailto:sales@sun-shinechem.com">sales@sun-shinechem.com</a>
            </p>
        </div>
        <div class="contact-us-title-box">
            <i class="fa fa-phone"></i>
            Phone
        </div>
        <div class="contact-us-content-box">
            <p class="contact-us-phone">
                Tel: +86-27-5925-3327
                <br />
                Fax: +86-27-5925-3326
            </p>
        </div>
    </div>
</div>

<%--<script>
    function EmailValidator(sender, args) {
        var email = $("<%= EmailBox.ClientID %>").val();
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/igm;
        if (!re.test(email)) {
            return false;
        }
    };
</script>--%>