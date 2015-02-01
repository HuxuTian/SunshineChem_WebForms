using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace SunshineChem.Extensions
{
    public static class MediaServiceExtension
    {
        private static IMediaService MediaService { get { return ApplicationContext.Current.Services.MediaService; } }

        public static string GetImageUrl(int mediaID)
        {
            return MediaService.GetById(mediaID).GetImageUrl();
        }
        public static string GetImageUrl(this IMedia media)
        {
            return media.Properties["umbracoFile"].Value.ToString();
        }
    }
}