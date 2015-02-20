<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.ascx.cs" Inherits="SunshineChem.UserControls.ProductDetails" %>
<div class="product-detail-container">
    <div class="product-detail-info-container">
        <div class="product-detail-info">
            <asp:Label runat="server" ID="ChemicalName" Text=" " CssClass="product-chemical-name" />
            <asp:Label runat="server" ID="Synonym" CssClass="product-general-prop" />
            <asp:Label runat="server" ID="Formula" CssClass="product-general-prop" />
            <asp:Label runat="server" ID="MfcdNumber" CssClass="product-general-prop" />
            <asp:Label runat="server" ID="MolecularWeight" CssClass="product-general-prop" />
            <asp:Label runat="server" ID="CasNumber" CssClass="product-general-prop" />
        </div>
        <div class="product-detail-image">
            <asp:Image runat="server" ID="ProductImage" CssClass="product-image" />
        </div>
    </div>

    <div class="product-detail-description">
        <p class="product-detail-description-header">Description</p>
        <asp:Label runat="server" ID="Description" CssClass="" />
    </div>
    <div>
        <asp:Label runat="server" ID="Purity" CssClass="" />
    </div>
    <div class="pdf-link-icon">
        <asp:HyperLink runat="server" ID="HNMR" Text="HNMR" CssClass="pdf-link" />
    </div>
    <div class="pdf-link-icon">
        <asp:HyperLink runat="server" ID="HPLC" Text="HPLC" CssClass="pdf-link" />
    </div>
    <div class="pdf-link-icon">
        <asp:HyperLink runat="server" ID="MS" Text="MS" CssClass="pdf-link" />
    </div>
    <div class="pdf-link-icon">
        <asp:HyperLink runat="server" ID="COA" Text="COA" CssClass="pdf-link" />
    </div>
    <div>
        <asp:Label runat="server" ID="Storage" CssClass="" />
    </div>
    <div>
        <asp:Label runat="server" ID="Price" CssClass="" />
    </div>
    <div>
        <asp:Label runat="server" ID="Shipping" CssClass="" />
    </div>
    <div>
        <asp:Label runat="server" ID="Package" CssClass="" />
    </div>

    <div>
        <asp:Label runat="server" ID="Solubility" CssClass="" />
    </div>
</div>

<div class="product-detail-price-container">
    Price:
    <table>
        <asp:Repeater ID="PriceTable" runat="server" ItemType="System.Collections.Generic.Dictionary<string, string>">
            <HeaderTemplate>
                <tr>
                    <td>Size</td>
                    <td>Price</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Item["size"]%></td>
                    <td><%# Item["price"] %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
