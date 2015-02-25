using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using SunshineChem.Extensions;

namespace SunshineChem.Configuration
{
    public static class SiteSetting
    {
        // Field name alias
        public const string RecommendProduct = "recommendProduct";
        public const string FeaturedContent = "featuredContent";
        public const string Carousel = "carousel";
        public const string AboutUs = "aboutUs";
        public const string CompanyTitle = "companyTitle";
        public const string Address1 = "address1";
        public const string Address2 = "address2";
        public const string Address3 = "address3";
        public const string Email = "email";
        public const string Phone = "phone";
        public const string Fax = "fax";
        public const string AddressLabel = "addressLabel";
        public const string EmailLabel = "emailLabel";
        public const string PhoneLabel = "phoneLabel";
        public const string FormTitle = "formTitle";
        public const string FormNameLabel = "formNameLabel";
        public const string FormEmailLabel = "formEmailLabel";
        public const string FormMessageLabel = "formMessageLabel";
        public const string RequiredFieldLabel = "requiredFieldLabel";
        public const string SubmitButtonText = "submitButtonText";

        // Only used for get simple string value(eg. label, text)
        public static string GetFieldValue(string fieldAlias)
        {
            return ApplicationContext.Current.Services.ContentService.GetById(ConfigManager.SiteSettings).GetFieldValue(fieldAlias);           
        }
    }
}