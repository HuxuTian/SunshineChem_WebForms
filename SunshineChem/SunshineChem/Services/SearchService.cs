using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examine.LuceneEngine.SearchCriteria;
using Examine.SearchCriteria;

namespace SunshineChem.Services
{
    public class SearchService
    {
        public static Examine.ISearchResults GetSearchResults(string keyword)
        {
            var searcher = Examine.ExamineManager.Instance.SearchProviderCollection["ProductSearcher"];
            var searchCriteria = searcher.CreateSearchCriteria(BooleanOperation.Or);

            var chemicalNameValue = keyword.Fuzzy();
            var casValue = keyword;
            var aliasValue = keyword.MultipleCharacterWildcard();
            var catValue = keyword.MultipleCharacterWildcard();
            var query = searchCriteria.Field("chemicalName", chemicalNameValue).Or().Field("casNumber", casValue).Or().Field("synonym", aliasValue).Or().Field("catNumber", catValue).Compile();

            return searcher.Search(query);
            
        }
    }
}