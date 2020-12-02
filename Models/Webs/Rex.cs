using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Rex : IStockScraper
    {
        private readonly IDocument _document;

        public Rex(IDocument doc)
        {
            this._document = doc;
        }
        public string GetProductName()
        {
            return _document.QuerySelector(".base").InnerHtml;
        }

        public string GetProductPrice()
        {
            return _document.QuerySelector(".old-price").Text().Trim().Replace("$", "");

        }

        public bool GetProductStock()
        {
            return _document.QuerySelector("#product-addtocart-button").Text().Trim() == "Agregar al carrito" ? true: false;
        }
    }
}
