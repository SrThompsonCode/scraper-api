using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockScraper_API.Models.Webs
{
    public class Darto : IStockScraper
    {
        private readonly IDocument _document;
       
        public Darto(IDocument doc)
        {
            this._document = doc;
        }
        public string GetProductName()
        {
            return _document.QuerySelector(".product-name").InnerHtml;
        }

        public string GetProductPrice()
        {
            return _document.QuerySelector(".product-price").InnerHtml.Replace("$", "");
        }

        public bool GetProductStock()
        {
            return _document.QuerySelector(".js-addtocart").GetAttribute("value") == "Sin stock" ? false : true;
        }
    }
}
