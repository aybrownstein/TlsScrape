using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace TlsScraping.Scraper
{
   public static class Scraper
    {
        public static List<TlsResult> ScrapeTls()
        {
            var results = new List<TlsResult>();
            var html = GetTlsHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            IHtmlCollection<IElement> elements = document.QuerySelectorAll(".post");
            foreach(IElement result in elements)
            {
                var tlsResult = new TlsResult();
                tlsResult.Title = result.QuerySelector("h2").TextContent;
                tlsResult.LinkUrl = result.QuerySelector("a").Attributes["href"].Value;

                var imageElement = result.QuerySelector("img");
                if(imageElement != null)
                {
                    var imageSrcValue = imageElement.Attributes["src"].Value;
                    tlsResult.ImgUrl = imageSrcValue;
                }

                tlsResult.Blurb = result.QuerySelector("p").TextContent;
            }
            return results;   
                }

        private static string GetTlsHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            string url = "https://www.thelakewoodscoop.com";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}
