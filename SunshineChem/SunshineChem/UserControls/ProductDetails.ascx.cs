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
using SunshineChem.Utilities;

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
            Formula.Text = Product.GetFieldValue("formula").GetChemFormulaString();
            MolecularWeight.Text = Product.GetFieldValue("molecularWeight");
            MfcdNumber.Text = Product.GetFieldValue("mfcNumber");
            CasNumber.Text = Product.GetFieldValue("casNumber");
            Description.Text = Product.GetFieldValue("description");
            Purity.Text = Product.GetFieldValue("purity");
            HPLC.NavigateUrl = Product.GetReferenceMediaItem("hplc").GetImageUrl();
            HNMR.NavigateUrl = Product.GetReferenceMediaItem("hnmr").GetImageUrl();
            MS.NavigateUrl = Product.GetReferenceMediaItem("ms").GetImageUrl();
            COA.NavigateUrl = Product.GetReferenceMediaItem("coa").GetImageUrl();
            Storage.Text = Product.GetFieldValue("storage");
            Shipping.Text = Product.GetFieldValue("shipping");
            Package.Text = Product.GetFieldValue("package");
            Solubility.Text = Product.GetFieldValue("solubility");
            PriceTable.DataSource = Product.GetFieldValue("priceList").GetKeyValuePairs();
            PriceTable.DataBind();
        }
    }
}