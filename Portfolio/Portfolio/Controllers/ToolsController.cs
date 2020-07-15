using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _accessor;

        public ToolsController(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            this._context = context;
            this._accessor = accessor;
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

        public async Task<bool> NewViewer()
        {
            try
            {
                await _context.ViewHistory.AddAsync(new ViewHistory
                {
                    IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
