using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using StockScraper_API.Models;
using StockScraper_API.Models.Webs;

namespace web_scrapper.Models
{
    public class WebScraperModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public bool Stock { get; set; }
        public DateTime Fecha { get; set; }
        public string Url { get; set; }



        public static async Task<WebScraperModel> GET(string url)
        {
            WebScraperModel prod = new WebScraperModel();
            if (url.Length > 0)
            {
                // Load default configuration
                IConfiguration config = Configuration.Default.WithDefaultLoader();
                // Create a new browsing context
                var context = BrowsingContext.New(config);
                // This is where the HTTP request happens, returns <IDocument> that // we can query later
                var document = await context.OpenAsync(url);
                // Log the data to the console

                if (document == null)
                    return null;


                IStockScraper stockScraper = null;
                switch (context.Current.Location.Host)
                {
                    //"productListPriceTo":"19999","productPriceFrom":"17999","productPriceTo"
                    case "www.logitechstore.com.ar":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Logiech);
                        break;
                    case "www.venex.com.ar":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Venex);
                        break;
                    case "compragamer.com":
                        stockScraper = StockScraperFactory.Build(document, eWebType.CompraGamer);
                        break;

                    case "www.darto.org":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Darto);
                        break;

                    case "somosrex.com":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Rex);
                        break;

                    case "store.sony.com.ar":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Sony);

                        break;

                    case "www.tienda.philips.com.ar":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Philips);

                        break;

                    case "www.falabella.com.ar":
                        stockScraper = StockScraperFactory.Build(document, eWebType.Falabella);

                        break;
                    case "": break;
                    default:
                        return null;

                }

                prod.Name = stockScraper.GetProductName();
                prod.Price = stockScraper.GetProductPrice();
                prod.Stock = stockScraper.GetProductStock();



                prod.Fecha = DateTime.Now;
                prod.Url = document.DocumentUri;
            }

            return prod;


        }





    }
}
