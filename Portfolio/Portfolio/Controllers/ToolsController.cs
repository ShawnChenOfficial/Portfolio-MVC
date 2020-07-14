using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Controllers
{
    [Route("api/[action]")]
    public class ToolsController : Controller
    {

        private ApplicationDbContext _context;

        public ToolsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public string GetViewers()
        {
            var x = _context.ViewHistory.GroupBy(g => g.IP).Select(s => s.Max(m => m.UTC_DateTime)).Count().ToString();

            return x;
        }


        public List<ViewHistory> GetViewsWithDetails()
        {
            return _context.ViewHistory.ToList();
        }
    }
}
