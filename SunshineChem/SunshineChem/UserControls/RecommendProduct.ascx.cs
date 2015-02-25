using SunshineChem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbraco.Core;
using Umbraco.Core.Models;
using SunshineChem.Extensions;
using Umbraco.Core.Services;

namespace SunshineChem.UserControls
{
    public partial class RecommendProduct : System.Web.UI.UserControl
    {
        internal IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            var dataSource = ContentService.GetById(ConfigManager.SiteSettings).GetReferenceItems(ConfigManager.SiteSetting.RecommendProduct).Select(i => new GridItem(i));
            GridRecommendProduct.DataSource = dataSource;
            GridRecommendProduct.DataBind();
        }

        public void GenerateMockProductData()
        {
            var random = new Random();
            string CatNum = "M" + random.Next(1000, 9999);
            string Syno = "GLPG" + random.Next(1000, 9999);
            string chemName = System.IO.Path.GetRandomFileName();
            string CasNum = string.Format("{0}-{1}-{2}", random.Next(1000000, 9999999), random.Next(10, 99), random.Next(0, 9));
            string Package = "N/A";
            string Price = "$" + random.Next(100, 9999);

            var content = ContentService.CreateContent(CasNum, ContentService.GetById(ConfigManager.ProductRepository), "product");
            content.Properties["catalogNumber"].Value = CatNum;
            content.Properties["chemicalName"].Value = chemName;
            content.Properties["casNumber"].Value = CasNum;
            content.Properties["package"].Value = Package;
            content.Properties["price"].Value = Price;
            content.Properties["synonym"].Value = Syno;
            ContentService.Save(content);
            ContentService.Publish(content);
        }

        public class GridItem
        {
            public int ID { get; set; }
            public string CatNumber { get; set; }
            public string Name { get; set; }
            public string CasNumber { get; set; }
            public string Package { get; set; }
            public string Price { get; set; }
            public string NavigationUrl { get; set; }

            public GridItem(IContent content)
            {
                ID = content.Id;
                CatNumber = content.GetFieldValue("catalogNumber");//.Properties["catalogNumber"].Value.ToString();
                Name = content.GetFieldValue("chemicalName");//Properties["chemicalName"].Value.ToString();
                CasNumber = content.GetFieldValue("casNumber");//Properties["casNumber"].Value.ToString();
                Package = content.GetFieldValue("package");//Properties["package"].Value.ToString();
                Price = content.GetFieldValue("price");//Properties["price"].Value.ToString();
                NavigationUrl = content.GetUrl();
            }
        }
    }
}