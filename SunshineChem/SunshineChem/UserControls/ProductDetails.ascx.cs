using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using SunshineChem.Extensions;

namespace SunshineChem.UserControls
{
    public partial class ProductDetails : System.Web.UI.UserControl
    {
        private IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }
        public IContent Product { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = UmbracoContext.Current.PageId;

            if (!id.HasValue)
            {
                id = -1;
            }

            Product = ContentService.GetById(id.Value);
            ChemicalName.Text = Product.GetFieldValue("chemicalName");
            ProductImage.ImageUrl = Product.GetReferenceMediaItem("chemicalStructure").GetImageUrl();
            Synonym.Text = Product.GetFieldValue("synonym");
            HNMR.NavigateUrl = Product.GetReferenceMediaItem("hnmr").GetImageUrl();
        }
    }
}