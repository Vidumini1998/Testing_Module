using CrystalDecisions.CrystalReports.Engine;
using PMSWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSWebApplication.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> ExportPaymentReport()
        {
            //empEntities context = new empEntities();

            ReportDocument rd = new ReportDocument();
            //var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            var project = await db.Projects.ToListAsync();
            rd.Load(Path.Combine(Server.MapPath("//Report//PaymentReport.rpt")));
            foreach (var task in project)
            {
                rd.SetDataSource(db.Payments.Where(x => x.ProjectId == task.Id).Select(c => new
                {
                    //Projectname = task.ProjectName,
                    ProjectId = c.ProjectId,
                    TaskId = c.TaskId
                }).ToList());
            }              

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "PaymentReport.pdf");
        }

    }
}  
    