<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.ascx.cs" Inherits="SunshineChem.UserControls.ProductDetails" %>
<%--<div><%# Product.Id %></div>--%>


<div>
    <asp:Label runat="server" ID="ChemicalName" Text=" " CssClass="product-chemical-name"/>
</div>
<div>
    <asp:Image runat="server" ID="ProductImage" CssClass="product-image"/>
</div>
<div>
    <asp:Label runat="server" ID="Synonym" CssClass="product-synonym"/>
</div>
<div>
    <asp:Label runat="server" ID="Formula" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="MolecularWeight" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="MfcdNumber" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="CasNumber" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="Description" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="Purity" CssClass=""/>
</div>
<div>
    <asp:HyperLink runat="server" ID="HNMR" Text="HNMR" CssClass=""/>
</div>
<div>
    <asp:HyperLink runat="server" ID="HPLC" CssClass=""/>
</div>
<div>
    <asp:HyperLink runat="server" ID="MS" CssClass=""/>
</div>
<div>
    <asp:HyperLink runat="server" ID="COA" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="Storage" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="Price" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="Shipping" CssClass=""/>
</div>
<div>
    <asp:Label runat="server" ID="Package" CssClass=""/>
</div>

<div>
    <asp:Label runat="server" ID="Solubility" CssClass=""/>
</div>

