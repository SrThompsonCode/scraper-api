using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Philips : IStockScraper
    {
        private readonly IDocument _document;
        public Philips(IDocument doc)
        {
            this._document = doc;
        }
        public string GetProductName()
        {
            return Helper.GetText(_document, ".nombre-producto");
        }

        public string GetProductPrice()
        {
            return Helper.GetPrice(_document, ".current-price").Replace("$", "");
        }

        public bool GetProductStock()
        {
            return Helper.GetByAttribute_Disabled(_document, ".add-to-cart");
        }
    }
}
