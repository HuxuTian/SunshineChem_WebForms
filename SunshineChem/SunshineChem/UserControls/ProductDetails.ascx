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
    <div role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active">
                <a href="#ChemicalInfo" aria-controls="ChemicalInfo" role="tab" data-toggle="tab">Chemical Info</a>
            </li>
            <li role="presentation">
                <a href="#QualityControl" aria-controls="QualityControl" role="tab" data-toggle="tab">Quality Control</a>
            </li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="ChemicalInfo">
                <div>
                    <asp:Label runat="server" ID="Purity" CssClass="" />
                </div>
                <div>
                    <asp:Label runat="server" ID="Storage" CssClass="" />
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
            <div role="tabpanel" class="tab-pane" id="QualityControl">
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
            </div>
        </div>
    </div>
</div>
<div class="product-detail-price-container">
    <div class="price-title-box">
        <strong>Price</strong>
    </div>
    <div class="price-content-box">
        <table>
            <asp:Repeater ID="PriceTable" runat="server" ItemType="System.Collections.Generic.Dictionary<string, string>">
                <HeaderTemplate>
                    <thead>
                        <tr class="price-content-box-title">
                            <td class="price-title-left">Size</td>
                            <td>Price</td>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="price-title-left"><%# Item["size"]%></td>
                        <td><%# Item["price"] %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="bulk-inquiry-box">
        <i class="fa fa-shopping-cart"></i>
        <strong>Bulk Inquiry</strong>
    </div>
</div>

<script>
    $('#QualityControl a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    })
</script>
