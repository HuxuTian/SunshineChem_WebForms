using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SunshineChem.Extensions;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace SunshineChem.UserControls
{
    public partial class MainNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var rootNodes = ContentServiceExtension.GetChildrenByContentType(SunshineChem.Utilities.ConfigManager.HomeNode, "LandingPage").Select(i => new NavItem { ID = i.Id, ParentID = null, Name = i.Name, NavigationUrl = i.GetUrl() });
            var nodes = rootNodes.ToList();
            
            foreach (var rn in rootNodes)
            {
                if (ContentServiceExtension.HasChildren(rn.ID))
                {
                    var children = ApplicationContext.Current.Services.ContentService.GetChildren(rn.ID).Select(c => new NavItem { ID = c.Id, ParentID = rn.ID, Name = c.Name, NavigationUrl = c.GetUrl() });
                    nodes.AddRange(children);
                }
            }

            var homeNode = ApplicationContext.Current.Services.ContentService.GetById(SunshineChem.Utilities.ConfigManager.HomeNode);
            nodes.Insert(0, new NavItem { ID = homeNode.Id, Name = homeNode.Name, NavigationUrl = homeNode.GetUrl(), ParentID = null });

            MainNavMenu.DataTextField = "Name";
            MainNavMenu.DataFieldID = "ID";  
            MainNavMenu.DataFieldParentID = "ParentID";
            MainNavMenu.DataNavigateUrlField = "NavigationUrl";

            MainNavMenu.DataSource = nodes;
            MainNavMenu.DataBind();
        }

        public class NavItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int? ParentID { get; set; }
            public string NavigationUrl { get; set; }

            public NavItem()
            {

            }
            public NavItem(IContent c)
            {
                Name = c.Name;
                ID = c.Id;
                ParentID = c.ParentId;
                NavigationUrl = c.GetUrl();
            }
        }
    }
}