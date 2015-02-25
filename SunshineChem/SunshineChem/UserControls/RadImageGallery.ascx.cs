using SunshineChem.Extensions;
using SunshineChem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace SunshineChem.UserControls
{
    public partial class RadImageGallery : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var images = ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.SiteSettings).GetReferenceMediaItems(ConfigManager.SiteSetting.Carousel).Select(i => new ImageItem(i));
            HomeImageGalleryControl.DataSource = images;
            HomeImageGalleryControl.DataBind();
        }

        public class ImageItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string ImageData { get; set; }
            public string ThumnailData { get; set; }

            public ImageItem(IMedia media)
            {
                Title = media.Name;
                Description = string.Empty;
                ImageData = media.Properties["umbracoFile"].Value.ToString();
                ThumnailData = string.Empty;
            }
        }
    }
}