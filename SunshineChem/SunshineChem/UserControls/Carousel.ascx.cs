using SunshineChem.Extensions;
using SunshineChem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbraco.Core;

namespace Umbraco721.UserControls
{
    public partial class Carousel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var carouselConfig = ApplicationContext.Current.Services.ContentService.GetById(1107).Properties["images"].Value.ToString();
            var images = ApplicationContext.Current.Services.MediaService.GetByIds(ContentServiceExtension.IDsToIDList(carouselConfig));          
            ImageDataSource.DataSource = images;
            ImageDataSource.DataBind();
        }
    }
}