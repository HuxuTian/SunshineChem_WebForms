using SunshineChem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using SunshineChem.Extensions;

namespace SunshineChem.UserControls
{
    public partial class ProductCategoryPanel : System.Web.UI.UserControl
    {
        private IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            var rootItems = ContentService.GetById(ConfigManager.ProductRepository).GetChildrenByContentType("Container");
            var dataSource = rootItems.Select(i => new NavItem() { ID = i.Id, Name = i.Name, ParentID = null }).ToList();
            foreach (var i in rootItems)
            {
                if (i.HasChildren())
                {
                    dataSource.AddRange(i.GetChildrenByContentType("Container").Select(c => new NavItem(c)));
                }
            }


            ProductCategoryMenu.DataTextField = "Name";
            ProductCategoryMenu.DataFieldID = "ID";
            ProductCategoryMenu.DataFieldParentID = "ParentID";
            ProductCategoryMenu.DataValueField = "ID";

            ProductCategoryMenu.DataSource = dataSource.OrderBy(i => i.Name);
            ProductCategoryMenu.DataBind();
        }

        protected void ProductCategoryMenu_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {
            ViewState["ID"] = e.Item.Value;
            ProductResultGrid.Rebind();
        }

        protected void ProductResultGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var dataSource = new List<GridItem>();
            if (ViewState["ID"] != null)
            {
                var id = int.Parse(ViewState["ID"].ToString());
                dataSource = ContentService.GetById(id).GetDescendantsByContentType("Product").Select(i => new GridItem(i)).ToList();
            }
            else
            {
                dataSource = ContentService.GetById(ConfigManager.ProductRepository).GetDescendantsByContentType("Product").Select(i => new GridItem(i)).ToList();
            }
            ProductResultGrid.DataSource = dataSource;
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
                CatNumber = content.Properties["catalogNumber"].Value.ToString();
                Name = content.Properties["chemicalName"].Value.ToString();
                CasNumber = content.Properties["casNumber"].Value.ToString();
                Package = content.Properties["package"].Value.ToString();
                Price = content.Properties["price"].Value.ToString();
                NavigationUrl = string.Format("{0}?id={1}", ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.ProductDetail).GetUrl(), content.Id);
            }
        }

        public class NavItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int? ParentID { get; set; }

            public NavItem()
            {

            }
            public NavItem(IContent c)
            {
                Name = c.Name;
                ID = c.Id;
                ParentID = c.ParentId;
            }
        }
    }
}