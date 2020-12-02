using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Falabella : IStockScraper
    {
        public IDocument _document;

        public Falabella(IDocument doc)
        {
            this._document = doc;
        }
        public string GetProductName()
        {
            return Helper.GetText(_document, ".product-name");
        }

        public string GetProductPrice()
        {
            return Helper.GetPrice(_document, ".copy13");
        }

        public bool GetProductStock()
        {
            return Helper.GetText(_document, ".jsx-1816208196") == "Agregar a la Bolsa" ? true : false;
        }
    }
}
