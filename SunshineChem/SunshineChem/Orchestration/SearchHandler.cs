using SunshineChem.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace SunshineChem.Orchestration
{
    public class SearchHandler
    {
        public static IEnumerable<int> GetResultIDs(Examine.ISearchResults results)
        {
            return results.Select(r => int.Parse(r.Fields["id"]));
        } 
    }
}