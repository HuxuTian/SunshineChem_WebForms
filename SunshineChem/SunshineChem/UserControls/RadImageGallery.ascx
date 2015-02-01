<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RadImageGallery.ascx.cs" Inherits="SunshineChem.UserControls.RadImageGallery" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<%--<script type="text/javascript" >
    function pageLoad() {
        $find('<%= HomeImageGalleryControl.ClientID%>').playSlideshow();
    }
</script>--%>

<div id="ImageGalleryWrap">
    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanelImgGallery">
        <telerik:RadImageGallery runat="server" ID="HomeImageGalleryControl" Height="250px" DataTitleField="Title" DataImageField="ImageData">
            <ThumbnailsAreaSettings Mode="ImageSliderPreview" ShowScrollButtons="true" />
            <ImageAreaSettings ShowDescriptionBox="False" />
            <ToolbarSettings ShowSlideshowButton="false" ShowFullScreenButton="false" Position="None" />
            <ClientSettings>
                <AnimationSettings SlideshowSlideDuration="100">
                    <NextImagesAnimation Type="HorizontalSlide" Easing="EaseInExpo" Speed="1000" />
                    <PrevImagesAnimation Type="VerticalStripes" Easing="EaseOutBack" Speed="1000" />
                </AnimationSettings>
            </ClientSettings>
        </telerik:RadImageGallery>
    </telerik:RadAjaxPanel>
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>  
<script type="text/javascript">
    function pageLoad() {
        var id = "#" + $("div[id*=HomeImageGalleryControl]").first().attr("id");
        $find(id).playSlideshow();
    }  
</script>
