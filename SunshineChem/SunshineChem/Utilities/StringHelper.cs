using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SunshineChem.Utilities
{
    public static class StringHelper
    {
        public static string GetChemFormulaString(this string formula)
        {
            string result = string.Empty;
            foreach (var c in formula)
            {
                if (Char.IsLetter(c))
                {
                    result += c.ToString();
                }
                else if (char.IsDigit(c))
                {
                    result += string.Format("{0}{1}{2}", "<sub>", c, "</sub>");
                }
            }
            return result;
        }

        /// <summary>
        /// Used only for RB-KeyValue Editor plug-in 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static ICollection<Dictionary<string, string>> GetKeyValuePairs(this string keyValues)
        {
            var result = new List<Dictionary<string, string>>();
            var dict = new Dictionary<string, string>();
            var regxPattern = "\\\"(\\w|\\d|\\$)*\\\"";
            var regx = new Regex(regxPattern);
            var matches = regx.Matches(keyValues);
            for (int i=0; i< matches.Count; i++)
            {
                string key = string.Empty;
                string value = string.Empty;
                
                if (matches[i].Value.Contains("key"))
                {
                    key = "size";
                    value = matches[i + 1].Value.Replace("\"", "");
                    dict.Add(key, value);
                }
                else if (matches[i].Value.Contains("value"))
                {
                    key = "price";
                    value = matches[i + 1].Value.Replace("\"", "");
                    dict.Add(key, value);
                }

                if ((i + 1) % 4 == 0)
                {
                    result.Add(dict);
                    dict = new Dictionary<string, string>();
                }
            }
            return result;
        }
    }
}