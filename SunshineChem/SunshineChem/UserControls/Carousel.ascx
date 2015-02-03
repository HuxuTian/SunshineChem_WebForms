<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="Umbraco721.UserControls.Carousel" %>

<link type="text/css" href="../Styles/carousel.css" rel="stylesheet" />
<script type="text/javascript" src="../Script/jssor.slider.mini.js"></script>
<script type="text/javascript" src="../Script/carousel.js"></script>

<div class="slider-wraper">
    <div id="slider1_container" class="carousel-slider-container">
        <!-- Slides Container -->
        <div u="slides" class="carousel-slides-wraper">
            <asp:Repeater runat="server" ID="ImageDataSource" ItemType="Umbraco.Core.Models.IMedia">
                <ItemTemplate>
                    <div>
                        <a u="image" href="#">
                            <img src="<%# Item.Properties["umbracoFile"].Value.ToString() %>" />
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- bullet navigator container -->
        <div u="navigator" class="jssorb01 carousel-bullet-navigator">
            <!-- bullet navigator item prototype -->
            <div u="prototype" class="carousel-bullet-navigator-item "></div>
        </div>
        <!-- Arrow Left -->
        <span u="arrowleft" class="carousel-arrow-left-btn jssora05l"></span>
        <!-- Arrow Right -->
        <span u="arrowright" class="carousel-arrow-right-btn jssora05r"></span>
    </div>
</div>
