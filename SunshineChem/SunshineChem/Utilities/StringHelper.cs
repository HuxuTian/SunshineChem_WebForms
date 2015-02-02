using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunshineChem.Utilities
{
    public static class StringHelper
    {
        public static string GetChemFormulaString(string formula)
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
    }
}