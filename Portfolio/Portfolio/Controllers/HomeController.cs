using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private ApplicationDbContext _context;
        private IHttpContextAccessor _accessor;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _logger = logger;
            this._configuration = configuration;
            this._context = context;
            this._accessor = accessor;
        }
        public async Task<IActionResult> AboutMe()
        {

            await _context.ViewHistory.AddAsync(new ViewHistory
            {
                IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
            });

            await _context.SaveChangesAsync();

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
                var errors_pair = new List<Object>();

                foreach (var x in ModelState.Keys)
                {
                    if (ModelState[x].Errors.Count() > 0)
                    {
                        var v1 = x;
                        var v2 = ModelState[x].Errors[0].ErrorMessage;

                        errors_pair.Add(new { Key = x, ErrorMessage = ModelState[x].Errors[0].ErrorMessage });
                    }
                }

                return Content(JsonConvert.SerializeObject(errors_pair));
            }

            var result = false;

            try
            {
                result = new MaillingLib.MailingService(_configuration).Sending(message);
            }
            catch (Exception e)
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

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Views = _context.ViewHistory.Count().ToString();
        }
    }
}
