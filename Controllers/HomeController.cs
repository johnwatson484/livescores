using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livescores.Models;
using System.Net;
using Newtonsoft.Json;

namespace Livescores.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://lynxmagnus.com/footballscores/api/fixtures?startDate=";

            url = string.Format("{0}{1}&endDate={2}", url, DateTime.Now.Date.AddDays(-7).ToString("s"), DateTime.Now.ToString("s"));

            string json;
            List<Fixture> fixtures = new List<Fixture>();

            using (WebClient client = new WebClient())
            {
                try
                {
                    json = client.DownloadString(url);
                }
                catch (Exception)
                {
                    json = null;
                }
            }

            if (json != null)
            {
                fixtures = JsonConvert.DeserializeObject<List<Fixture>>(json);  
            }

            return View(fixtures);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
