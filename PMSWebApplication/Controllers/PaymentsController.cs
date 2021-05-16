using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMSWebApplication.Models;
using PMSWebApplication.Models.DomainModels;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace PMSWebApplication.Controllers
{
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public async Task<ActionResult> Index()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            var payments = db.Payments.Include(p => p.Project).Include(p => p.Task);
            return View(await payments.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Index(int ProjectId)
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            var payments = db.Payments.Include(p => p.Project).Include(p => p.Task).Where(p=>p.ProjectId==ProjectId);
            return View(await payments.ToListAsync());
        }
       


        // GET: Payments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "TaskName");
            return View();
        }
       



        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,TaskId,InvoiceNo,PayDate,PaymentAmount,PayMethod,PayDiscription")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", payment.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "TaskName", payment.TaskId);
            return View(payment);
        }

        


        // GET: Payments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", payment.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "TaskName", payment.TaskId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,TaskId,InvoiceNo,PayDate,PaymentAmount,PayMethod,PayDiscription")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", payment.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "TaskName", payment.TaskId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payment payment = await db.Payments.FindAsync(id);
            db.Payments.Remove(payment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Upcomming Payements
        public async Task<ActionResult> UpCommingPayments()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<UpcommingPayment> upcommingPayemets = new List<UpcommingPayment>();
           
            foreach (var task in tasks)
            {
                UpcommingPayment payment = new UpcommingPayment();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var count = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                payment.Id = task.Id;
                payment.Payment = (task.TaskWisePayment - count);
                payment.TaskName = task.TaskName;
                payment.ProjectName = project.ProjectName;
                payment.Deadline = task.Deadline;

                upcommingPayemets.Add(payment);
            }
            return View(upcommingPayemets);
     
        }
        public async Task<ActionResult> Duepayment()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<Duepayment> duepayment = new List<Duepayment>();

            foreach (var task in tasks)
            {
                Duepayment paid = new Duepayment();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var total = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                paid.Id = task.Id;
                paid.PaidAmount = total;
                paid.TaskName = task.TaskName;
                paid.ProjectName = project.ProjectName;
                paid.Deadline = task.Deadline;

                duepayment.Add(paid);
            }
            return View(duepayment);

        }

        public async Task<ActionResult> ExportPaymentReport()
        {
            //empEntities context = new empEntities();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("//Reports//PaymentReport.rpt")));
            //rd.SetDataSource(db.Payments.Select(c => new
            //{
            //    ProjectId = c.ProjectId,
            //    TaskId = c.TaskId
            //}).ToList());

            var project = await db.Projects.ToListAsync();
            //var project = await db.Payments.ToListAsync();

            foreach (var task in project)
            {
                rd.SetDataSource(db.Payments.Where(x => x.ProjectId == task.Id).Select(c => new
                {
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
