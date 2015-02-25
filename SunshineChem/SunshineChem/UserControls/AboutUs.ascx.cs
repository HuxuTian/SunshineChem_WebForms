using SunshineChem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbraco.Core;
using SunshineChem.Extensions;
using SunshineChem.Configuration;

namespace SunshineChem.UserControls
{
    public partial class AboutUs : System.Web.UI.UserControl
    {
        public string Content
        {
            get
            {
                return ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.SiteSettings).GetFieldValue(SiteSetting.AboutUs);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}