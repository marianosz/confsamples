using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Async.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public async Task<ActionResult> Index()
        {
            var webClient = new WebClient();

            string result = await webClient.DownloadStringTaskAsync(new Uri("www.bing.com/"));

            return View();
        }
    }
}