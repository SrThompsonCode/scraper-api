using System;
using System.Collections.Generic;
using System.Linq;
using StockScraper_API.Models.Webs;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace StockScraper_API.Models
{
    public enum eWebType
    {
        Venex,
        CompraGamer,
        Logiech,
        Darto,
        Rex,
        Philips,
        Sony,
        Falabella
    }

    public class StockScraperFactory
    {

        public static IStockScraper Build(IDocument document, eWebType type)
        {


            switch (type)
            {
                case eWebType.Venex:
                    return new Venex(document);

                case eWebType.CompraGamer:
                    return new Compragamer(document);

                case eWebType.Logiech:
                    return new Logitech(document);

                case eWebType.Darto:
                    return new Darto(document);
                case eWebType.Rex:
                    return new Rex(document);
                case eWebType.Philips:
                    return new Philips(document);
                case eWebType.Sony:
                    return new Sony(document);
                case eWebType.Falabella:
                    return new Falabella(document);
                    break;
                default:
                    return null;
            }
        }
    }


}
