using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Helper
    {
        
   
        public static string GetPrice(IDocument doc, string selector)
        {
            Regex digitsOnly = new Regex(@"[^\d]");

            var result = doc.QuerySelector(selector);
            if (result != null)
                return digitsOnly.Replace(result.Text().Trim(), "");
            else
                return "";
        }
        public static string GetText(IDocument doc, string selector)
        {
            var result = doc.QuerySelector(selector);
            if (result != null)
                return result.Text().Trim();
            else
                return "";
        }

        public static bool GetByAttribute_Block(IDocument doc, string selector)
        {
            var result = doc.QuerySelector(selector);
            
            return result.Attributes.ToList().Exists(x => x.Value == "display:block");
        }
        public static bool GetByAttribute_Disabled(IDocument doc, string selector)
        {
            var result = doc.QuerySelector(selector);
            return !result.Attributes.ToList().Exists(x => x.Name == "disabled");
        }
    }
}
