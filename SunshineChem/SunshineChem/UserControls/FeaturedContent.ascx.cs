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
using Umbraco.Core.Services;

namespace SunshineChem.UserControls
{
    public partial class FeaturedContent : System.Web.UI.UserControl
    {
        private IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            var itemIDs = ContentService.GetById(ConfigManager.FeaturedContentConfig).GetFieldValue("items");
            var items = ContentService.GetByIds(ContentServiceExtension.IDsToIDList(itemIDs)).Select(c => new FeaturedContentItem(c));
            FeaturedContentRepeater.DataSource = items;
            FeaturedContentRepeater.DataBind();
            //DeleteNodes();
        }

        public void DeleteNodes()
        {
            var children = ContentService.GetChildren(ConfigManager.ProductRepository).Where(c => c.ContentType.Alias.Equals("Product"));
            //var count = children.Count();
            //var toMove = children.Take(count - 20);
            foreach (var c in children)
            {
                ContentService.Move(c, 3148);
            }            
        }


        public class FeaturedContentItem
        {
            public int ID { get; set; }
            public string ImageUrl { get; set; }
            public string Caption { get; set; }
            public string ReadMoreText { get; set; }
            public string ReferenceContent { get; set; }

            public FeaturedContentItem(IContent content)
            {
                ID = content.Id;
                ImageUrl = ApplicationContext.Current.Services.MediaService.GetById(int.Parse(content.GetFieldValue("featuredContentImage"))).GetImageUrl();
                Caption = content.GetFieldValue("featuredContentCaption");
                ReadMoreText = content.GetFieldValue("readMoreText");
                var referenceItem = content.GetReferenceItem("referenceContent");
                ReferenceContent = string.Format("{0}?id={1}", referenceItem.GetUrl(), referenceItem.Id);
            }
        }
    }
}