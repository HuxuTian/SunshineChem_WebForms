<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedContent.ascx.cs" Inherits="SunshineChem.UserControls.FeaturedContent" %>

<asp:Repeater ID="FeaturedContentRepeater" runat="server" ItemType="SunshineChem.UserControls.FeaturedContent.FeaturedContentItem">
    <ItemTemplate>
        <div class="featured-content-item">
            <a href="<%# Item.ReferenceContent %>">
                <asp:Image runat="server" ID="ContentImage" ImageUrl="<%# Item.ImageUrl %>" CssClass="featured-content-item-image" />
            </a>
            <div><%# Item.Caption %></div>
            <asp:HyperLink runat="server" ID="ContentLink" Text="<%# Item.ReadMoreText %>" NavigateUrl="<%# Item.ReferenceContent %>" />
        </div>
    </ItemTemplate>
</asp:Repeater>
