using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Venex : IStockScraper
    {
        private readonly IDocument  _document;

        public Venex(IDocument doc)
        {
            this._document = doc;
        }
        public string GetProductName()
        {
            return  _document.QuerySelector("h1.tituloProducto").InnerHtml.Trim();

        }

        public string GetProductPrice()
        {
           return _document.QuerySelector("div.textPrecio").InnerHtml.Trim().Replace("$", "");
        }

        public bool GetProductStock()
        {
            return _document.QuerySelector(".btn-block").Text().Trim() == "Comprar" ? true : false;
        }
    }
}
