using SunshineChem.Configuration;
using SunshineChem.Extensions;
using System;
using Umbraco.Core;

namespace Umbraco721.UserControls
{
    public partial class Carousel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var images = ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.SiteSettings).GetReferenceMediaItems(SiteSetting.Carousel);          
            ImageDataSource.DataSource = images;
            ImageDataSource.DataBind();
        }
    }
}