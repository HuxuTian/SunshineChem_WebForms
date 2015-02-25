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
            var images = ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.SiteSettings).GetReferenceMediaItems(ConfigManager.SiteSetting.Carousel);          
            ImageDataSource.DataSource = images;
            ImageDataSource.DataBind();
        }
    }
}