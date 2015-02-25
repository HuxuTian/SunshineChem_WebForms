using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunshineChem.Utilities
{
    public class ConfigManager
    {
        // Content Nodes
        public const int HomeNode = 1092;
        public const int ImagesFolder = 1096;
        public const int ProductRepository = 1098;
        public const int ProductDetail = 1092;
        public const int ProductNode = 1103;

        // Config Items
        public const int SiteSettings = 1115;

        public class SiteSetting
        {
            // Field name alias
            public const string RecommendProduct = "recommendProduct";
            public const string FeaturedContent = "featuredContent";
            public const string Carousel = "carousel";
        }
    }
}