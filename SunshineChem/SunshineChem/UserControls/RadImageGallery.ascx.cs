using SunshineChem.Extensions;
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
            var carouselConfig = ApplicationContext.Current.Services.ContentService.GetById(1107).Properties["images"].Value.ToString();
            var images = ApplicationContext.Current.Services.MediaService.GetByIds(ContentServiceExtension.IDsToIDList(carouselConfig)).Select(i => new ImageItem(i));

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