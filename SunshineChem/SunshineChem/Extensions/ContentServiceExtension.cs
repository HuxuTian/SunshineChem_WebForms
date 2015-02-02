using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace SunshineChem.Extensions
{
    public static class ContentServiceExtension
    {
        private static IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }
        /// <summary>
        /// A given node has children or not?
        /// </summary>
        /// <param name="contentID">Given node ID</param>
        /// <returns>Bool</returns>
        public static bool HasChildren(int contentID)
        {
            bool hasChildren = false;
            var children = ContentService.GetChildren(contentID);
            if (children != null)
            {
                hasChildren = true;
            }
            return hasChildren;
        }

        public static bool HasChildren(this IContent content)
        {
            return HasChildren(content.Id);
        }

        /// <summary>
        /// Get Conent Path
        /// </summary>
        /// <param name="content">Given content</param>
        /// <param name="removeRootPrefix">The name of root node that needs to remove from path</param>
        /// <returns>Content path string</returns>
        public static string GetContentPath(this IContent content, string removeRootPrefix = null)
        {
            var currentContent = content;

            // Path goes from root
            string path = "/";

            var originalPath = content.Path;
            var paths = originalPath.Split(',');
            foreach (var str in paths)
            {
                // root node "Content" is -1
                if (!str.Equals("-1"))
                {
                    // Make the node name legal by replacing " " with "-"
                    var name = ContentService.GetById(int.Parse(str)).Name.Replace(" ", "-");

                    if (removeRootPrefix == null)
                    {
                        path += name + "/";
                    }
                    else
                    {
                        // Remove root node from path
                        if (!name.Equals(removeRootPrefix))
                        {
                            path += name + "/";
                        }
                    }                                      
                }
            }           
            return path;
        }

        public static string GetUrl(this IContent content)
        {
            return umbraco.library.NiceUrl(content.Id);
        }

        /// <summary>
        /// Get filtered descendants by content type for a given node
        /// </summary>
        /// <param name="contentID">Given node ID</param>
        /// <param name="contentTypeAlias">Document type alias, case sensetivity</param>
        /// <returns>A list of Content nodes</returns>
        public static IEnumerable<IContent> GetDescendantsByContentType(int contentID, string contentTypeAlias)
        {
            var decendants = ContentService.GetDescendants(contentID);
            return decendants.Where(d => d.ContentType.Alias.Equals(contentTypeAlias));
        }
        public static IEnumerable<IContent> GetDescendantsByContentType(this IContent content, string contentTypeAlias)
        {
            return GetDescendantsByContentType(content.Id, contentTypeAlias);
        }

        /// <summary>
        /// Get filtered children by content type for a given node
        /// </summary>
        /// <param name="contentID">Given node ID</param>
        /// <param name="contentTypeAlias">Document type alias, case sensetivity</param>
        /// <returns>A list of Content nodes</returns>
        public static IEnumerable<IContent> GetChildrenByContentType(int contentID, string contentTypeAlias)
        {
            var decendants = ContentService.GetChildren(contentID);
            return decendants.Where(d => d.ContentType.Alias.Equals(contentTypeAlias));
        }
        public static IEnumerable<IContent> GetChildrenByContentType(this IContent content, string contentTypeAlias)
        {
            return GetChildrenByContentType(content.Id, contentTypeAlias);
        }

        public static IEnumerable<int> IDsToIDList(string IDs)
        {
            var stringArray= IDs.Split(',');
            var IDList = new List<int>();
            foreach (var id in stringArray)
            {
                int i = -2;
                if (int.TryParse(id, out i))
                {
                    IDList.Add(i);
                }
            }
            return IDList;
        }

        public static string GetFieldValue(int contentID, string fieldAlias)
        {
            return ContentService.GetById(contentID).GetFieldValue(fieldAlias);
        }

        public static string GetFieldValue(this IContent content, string fieldAlias)
        {
            var property = content.Properties[fieldAlias];
            var value = string.Empty;
            if (property.Value != null)
            {
                value = property.Value.ToString();
            }
            return value;
        }

        public static IContent GetReferenceItem(this IContent content, string fieldAlias)
        {
            return ContentService.GetById(int.Parse(GetFieldValue(content, fieldAlias)));
        }
    }
}