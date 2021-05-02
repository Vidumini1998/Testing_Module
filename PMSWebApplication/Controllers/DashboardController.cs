using PMSWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PMSWebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Default
        public async Task<ActionResult> Index()
        {
            var projects = await db.Projects.ToListAsync();
            int count = projects.Count();
            ViewBag.Count = count;
            return View();
        }
    }
}