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
        private static IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }
        private static IMediaService MediaService { get { return ApplicationContext.Current.Services.MediaService; } }

        public static string GetImageUrl(int mediaID)
        {
            return MediaService.GetById(mediaID).GetImageUrl();
        }
        public static string GetImageUrl(this IMedia media)
        {
            var url = string.Empty;
            if (media != null)
            {
                url = media.Properties["umbracoFile"].Value.ToString();
            }
            return url;
        }

        public static IEnumerable<IMedia> GetReferenceMediaItems(this IContent content, string fieldAlias)
        {
            return MediaService.GetByIds(ContentServiceExtension.IDsToIDList(content.GetFieldValue(fieldAlias)));
        }

        public static IMedia GetReferenceMediaItem(this IContent content, string fieldAlias)
        {
            var value = content.Properties[fieldAlias].Value;
            if(value != null) 
            {
                return MediaService.GetById(int.Parse(value.ToString()));
            }
            return null;
        }
    }
}