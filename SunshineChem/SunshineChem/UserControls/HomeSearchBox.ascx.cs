using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examine.LuceneEngine.SearchCriteria;
using SunshineChem.Services;
using SunshineChem.Orchestration;
using Umbraco.Core;
using SunshineChem.Utilities;
using SunshineChem.Extensions;

namespace SunshineChem.UserControls
{
    public partial class HomeSearchBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchTextBox.Text = Request["q"];
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var productPage = ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.ProductNode).GetUrl();
            var redirectUrl = string.Format("{0}?{1}={2}", productPage, "q", SearchTextBox.Text);
            Response.Redirect(redirectUrl);
        }
    }
}