using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASC.Utilities;
using ASC_1.Services;
using ASC_1.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASC_1.Controllers
{
    public class HomeController : AnonymousController
    {
        private IOptions<ApplicationSettings> _settings;
        public HomeController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
        }
        //[FromServices] IEmailSender emailSender
        public IActionResult Index()
        {
            HttpContext.Session.SetSession("Test", _settings.Value);
            var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");
            ViewBag.Title = _settings.Value.ApplicationTitle;
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

       
    }
}
