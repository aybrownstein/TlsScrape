using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TlsScraping.Scraper;

namespace TlsScrape.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TlsScraperController : ControllerBase
    {
        [Route("scrape")]
        public List<TlsResult> Scrape()
        {
            return Scraper.ScrapeTls();
        }
    }
}
