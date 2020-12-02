using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Compragamer : IStockScraper
    {
        private readonly IDocument _document;

        public Compragamer(IDocument doc)
        {
            this._document = doc;
        }
  
        public string GetProductName()
        {
            return _document.QuerySelector("h1.filaNombre").QuerySelector("div").InnerHtml.Trim();
        }

        public string GetProductPrice()
        {
            return _document.QuerySelector("div.filaPrecio").QuerySelector(".precioEspecial").TextContent.Split("\n")[1].Trim().Replace("$", "");
        }

        public bool GetProductStock()
        {
            return _document.QuerySelector(".card-btns__add").Text().Trim() == "SIN STOCK" ? false : true;
        }

        
    }
}
