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
using Telerik.Web.UI;
using SunshineChem.Orchestration;
using SunshineChem.Services;

namespace SunshineChem.UserControls
{
    public partial class ProductCategoryPanel : System.Web.UI.UserControl
    {
        private IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Enter page to browse products by category
            if (string.IsNullOrEmpty(Request["q"]))
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
            else // Enter page by search, HIDE  category menu
            {
                ProductCategoryMenu.Visible = false;
            }

        }

        protected void ProductCategoryMenu_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {
            // Put category node id into ViewState for grid update
            ViewState["ID"] = e.Item.Value;
            ProductResultGrid.Rebind();
        }

        protected void ProductResultGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var dataSource = new List<GridViewItem>();

            // Enter page as search
            if (!string.IsNullOrEmpty(Request["q"]))
            {

                var searchTerm = Request["q"].ToString();
                var nodeIDs = SearchHandler.GetResultIDs(SearchService.GetSearchResults(searchTerm));
                if (nodeIDs != null && nodeIDs.Count() > 0)
                {
                    dataSource = ContentService.GetByIds(nodeIDs).Select(i => new GridViewItem(i)).ToList();
                }
            }
            else if (ViewState["ID"] != null) // Update grid datasource by giving category node id
            {
                var id = int.Parse(ViewState["ID"].ToString());
                dataSource = ContentService.GetById(id).GetDescendantsByContentType("Product").Select(i => new GridViewItem(i)).ToList();
            }
            else // First time enter this page, show all products
            {
                dataSource = ContentService.GetById(ConfigManager.ProductRepository).GetDescendantsByContentType("Product").Select(i => new GridViewItem(i)).ToList();
            }

            ProductResultGrid.DataSource = dataSource;
        }

        protected void ProductResultGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("RowClick") || e.CommandName.Equals("ExpandCollapse"))
            {
                e.Item.Selected = true;
                bool lastState = e.Item.Expanded;

                if (e.CommandName == "ExpandCollapse")
                {
                    lastState = !lastState;
                }

                CollapseAllRows();
                e.Item.Expanded = !lastState;

            }
        }

        private void CollapseAllRows()
        {
            foreach (GridItem item in ProductResultGrid.MasterTableView.Items)
            {
                item.Expanded = false;
            }
        }

        public class GridViewItem
        {
            public int ID { get; set; }
            public string CatNumber { get; set; }
            public string Name { get; set; }
            public string CasNumber { get; set; }
            public string Package { get; set; }
            public string Price { get; set; }
            public string NavigationUrl { get; set; }
            public string ImageUrl { get; set; }
            public string Synonym { get; set; }
            public string Formula { get; set; }
            public string MolecularWeight { get; set; }
            public string Purity { get; set; }
            public string Solubility { get; set; }
            public string Storage { get; set; }

            public GridViewItem(IContent content)
            {
                ID = content.Id;
                CatNumber = content.GetFieldValue("catalogNumber");
                Name = content.GetFieldValue("chemicalName");
                CasNumber = content.GetFieldValue("casNumber");
                Package = content.GetFieldValue("package");
                Price = content.GetFieldValue("price");
                ImageUrl = content.GetReferenceMediaItem("chemicalStructure").GetImageUrl();
                NavigationUrl = content.GetUrl();
                Synonym = content.GetFieldValue("synonym");
                Formula = content.GetFieldValue("formula").GetChemFormulaString();
                MolecularWeight = content.GetFieldValue("molecularWeight");
                Purity = content.GetFieldValue("purity");
                Solubility = content.GetFieldValue("solubility");
                Storage = content.GetFieldValue("storage");
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