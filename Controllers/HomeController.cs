using System;
using System.Collections.Generic;
using HackerNewsClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Codecool.HackerNewsClient.Models;
using Codecool.HackerNewsClient.Service;
using Newtonsoft.Json;

namespace HackerNewsClient.Controllers
{
    /// <summary>
    /// HomeController is a generic controller responsible for communicating with
    /// external or internal data sources (API or other data services).
    /// It contains methods communicating with the external API and
    /// serializing the data into News object.
    /// The methods return ActionResult which generates respective HTML page (View)
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// returns index page with top news
        /// </summary>
        /// <param name="page"> parameter of current page index </param>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            //this.ViewData["page"] = page;

            var news = APICaller.GetNews(page);
            var model = new NewsModel
            {
                NewsList = news,
                CurrentPage = page,
                IsPrevPageAvailable = page - 1 > 0,
                PrevPage = page - 1,
                IsNextPageAvailable = page < 10,
                NextPage = page + 1
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
