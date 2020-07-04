using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            this._configuration = configuration;
        }
        public IActionResult AboutMe()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Message message)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact");
            }

            var result = false;

            try
            {
                result = new MaillingLib.MailingService(_configuration).Sending(message);
            }
            catch(Exception e)
            {
                var x = e.Message;
            }

            return Content(JsonConvert.SerializeObject(result));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
