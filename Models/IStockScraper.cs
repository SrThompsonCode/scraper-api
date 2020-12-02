using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace StockScraper_API.Models
{

    public interface IStockScraper
    {

        string GetProductName();
        string GetProductPrice();
        bool GetProductStock();

    }
    
//     case "www.gezatek.com.ar/TEST":
//                        //Do something with LINQ
//                        //var blueListItemsLinq = document.All.Where(m =>  m.ClassList.Contains("product-short-info"));

//                        //foreach (var item in blueListItemsLinq)
//                        //{
//                        //    Console.WriteLine(item.InnerHtml);
//                        //}
//                        ////Or directly with CSS selectors
//                        //var blueListItemsCssSelector = document.QuerySelectorAll("div.product-short-info");
//                        //foreach (var item in blueListItemsCssSelector)
//                        //{
//                        //    var child = item.FirstElementChild;
//                        //    Console.WriteLine(item.InnerHtml);
//                        //}
//                        var scriptPrice2 = document.Scripts.FirstOrDefault(x => x.OuterHtml.Contains("#cuotas-sin-interes"));
//    var stocky = document.QuerySelector(".no_hay_stock");
//    var test3 = document.QuerySelector("div.col-md-9");
//    var test4 = Like(document.QuerySelector("div.col-md-9").InnerHtml, "hay_stock");
//    string test2 = FindTextBetween(document.Source.Text, "<strong>", "</strong>");
//    var test = document.QuerySelectorAll("button.agregado");
//    productName = document.QuerySelector("div.product-info").QuerySelector("h3").InnerHtml.Trim();
//                        productPrice = document.QuerySelector("div.precio_web").QuerySelector("h7").InnerHtml.Trim();
//                        //buttonStock = document.QuerySelector("div.product-short-info").QuerySelector(".hay_stock");
//                        foreach (var item in document.QuerySelector(".col-md-9").QuerySelector(".row").QuerySelector("button.agregarProductoVer").Attributes.ToList())
//                        {
//                            Console.WriteLine(item);
//                        }
//if (!document.QuerySelector(".col-md-9").QuerySelector(".row").QuerySelector("button.agregarProductoVer").Attributes.ToList().Exists(x => x.Value == "display: none;"))
//    buttonStock = document.QuerySelector(".col-md-9").QuerySelector(".row").QuerySelector("button.agregarProductoVer");
//break;
    



}
