using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Logitech : IStockScraper
    {
        private readonly IDocument _document;

        public Logitech(IDocument doc)
        {
            this._document = doc;
        }

        public string GetProductName()
        {
            return _document.QuerySelector("article.content").QuerySelector("h1").QuerySelector("div").InnerHtml.Trim();
        }

        public string GetProductPrice()
        {
            var scriptPrice = _document.Scripts.FirstOrDefault(x => x.OuterHtml.Contains("productListPriceTo"));
            string productPrice = FindTextBetween(scriptPrice.OuterHtml, "productPriceFrom", "productPriceTo");
            productPrice = productPrice.Replace("'", "");
            productPrice = productPrice.Replace(@":", "");
            productPrice = productPrice.Replace(@"\", "");
            productPrice = productPrice.Replace(@"""", "");
            productPrice = productPrice.Replace("\"", "");
            productPrice = productPrice.Replace(@",", "");

            return productPrice;
        }

        public bool GetProductStock()
        {
            return _document.QuerySelector(".buy-in-page-button").Attributes.ToList().Exists(x => x.Value == "display:block") ? true : false;
        }

      


        public static string FindTextBetween(string text, string left, string right)
        {
            // TODO: Validate input arguments

            int beginIndex = text.IndexOf(left); // find occurence of left delimiter
            if (beginIndex == -1)
                return string.Empty; // or throw exception?

            beginIndex += left.Length;

            int endIndex = text.IndexOf(right, beginIndex); // find occurence of right delimiter
            if (endIndex == -1)
                return string.Empty; // or throw exception?

            return text.Substring(beginIndex, endIndex - beginIndex).Trim();
        }
    }

}
