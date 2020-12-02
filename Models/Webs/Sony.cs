using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace StockScraper_API.Models.Webs
{
    public class Sony : IStockScraper
    {
        private readonly IDocument _document;
        public Sony(IDocument doc)
        {
            this._document = doc;
        }
        public string GetProductName()
        {
            return _document.QuerySelector(".prod-title").Text().Trim();
        }

        public string GetProductPrice()
        {

            return Helper.GetPrice(this._document, ".skuBestPrice");
        }

        public bool GetProductStock()
        {
            return Helper.GetByAttribute_Block(this._document, ".buy-button");
        }
    }
}
