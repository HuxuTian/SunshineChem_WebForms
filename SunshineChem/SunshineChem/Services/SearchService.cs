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
            //var casValue = keyword.Fuzzy();
            //var casValueExac = keyword;
            var casValueWild = keyword.MultipleCharacterWildcard();
            var aliasValue = keyword.Fuzzy();
            var catValue = keyword.Fuzzy();
            var query = searchCriteria.Field("chemicalName", chemicalNameValue)
                .Or().Field("casNumber", casValueWild)
                .Or().Field("synonym", aliasValue)
                .Or().Field("catalogNumber", catValue)
                .Compile();

            return searcher.Search(query);

        }
    }
}