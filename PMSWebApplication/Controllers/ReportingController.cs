using CrystalDecisions.CrystalReports.Engine;
using PMSWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PMSWebApplication.Controllers
{
    public class ReportingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reporting
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> PriorityReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<PriorityReport> priorityrep = new List<PriorityReport>();

            foreach (var task in tasks)
            {
                PriorityReport priority = new PriorityReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                //var total = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                priority.Id = task.Id;
                priority.ProjectName = project.ProjectName;
                //priority.PriorityNo = Prioritylist.PriorityNo;
                priority.Deadline = task.Deadline;

                priorityrep.Add(priority);
            }
            return View(priorityrep);

        }

        public async Task<ActionResult> DeadlineListReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<DeadlineListReport> deadlineListReport = new List<DeadlineListReport>();

            foreach (var task in tasks)
            {
                DeadlineListReport deadlines = new DeadlineListReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                //var total = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                deadlines.Id = task.Id;
                deadlines.ProjectName = project.ProjectName;
                deadlines.TaskName = task.TaskName;
                deadlines.Deadline = task.Deadline;

                deadlineListReport.Add(deadlines);
            }
            return View(deadlineListReport);

        }

        public async Task<ActionResult> TaskStatusReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<TaskStatusReport> taskStatusReport = new List<TaskStatusReport>();

            foreach (var task in tasks)
            {
                TaskStatusReport taskStatus = new TaskStatusReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                //var total = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                taskStatus.Id = task.Id;
                taskStatus.Deadline = task.Deadline;
                taskStatus.EmployeeName = task.AssignedEmployee;
                //taskStatus.ClientName = client.CompanyName;
                taskStatus.ProjectName = project.ProjectName;
                taskStatus.TaskName = task.TaskName;
                taskStatus.TaskStatus = task.TaskStatus;

                taskStatusReport.Add(taskStatus);
            }
            return View(taskStatusReport);

        }

        public ActionResult ExportTaskStatusReport()
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("\\Reports\\TaskStatusReport.rpt")));
            rd.SetDataSource(db.Projects.Select(c => new
            {
                ProjectName = c.ProjectName,
            }).ToList());

            rd.SetDataSource(db.Tasks.Select(c => new
            {
                Deadline = c.Deadline,
                TaskName = c.TaskName,
                TaskStatus = c.TaskStatus

            }).ToList());


            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }

        public async Task<ActionResult> DueAmountReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<DueAmountReport> duePaymentReport = new List<DueAmountReport>();

            foreach (var task in tasks)
            {
                DueAmountReport paid = new DueAmountReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var payment = await db.Payments.FindAsync(task.ProjectId);
                //var total = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                paid.Id = task.Id;
                paid.PayDate = payment.PayDate;
                paid.InvoiceNo = payment.InvoiceNo;
                //paid.ClientName = 
                paid.ProjectName = project.ProjectName;
                paid.TaskName = task.TaskName;
                paid.PaidAmount = payment.PaymentAmount;

                duePaymentReport.Add(paid);
            }
            return View(duePaymentReport);
        }

        public async Task<ActionResult> ExportDueAmountReport()
        {
            //empEntities context = new empEntities();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("//Reports//DueAmountReport.rpt")));

            //var project = await db.Projects.ToListAsync();

            //foreach (var task in project)
            //{
            //    rd.SetDataSource(db.Payments.Where(x => x.ProjectId == task.Id).Select(c => new
            //    {
            //        //Projectname = task.ProjectName,
            //        ProjectId = c.ProjectId,
            //        TaskId = c.TaskId
            //    }).ToList());
            //}

            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<DueAmountReport> duePaymentReport = new List<DueAmountReport>();

            foreach (var task in tasks)
            {
                DueAmountReport paid = new DueAmountReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var payment = await db.Payments.FindAsync(task.ProjectId);

                //paid.Id = task.Id;
                //paid.PayDate = payment.PayDate;
                paid.InvoiceNo = payment.InvoiceNo;
                paid.ProjectName = project.ProjectName;
                paid.TaskName = task.TaskName;
                //paid.PaidAmount = payment.PaymentAmount;

                duePaymentReport.Add(paid);
            }

            rd.SetDataSource(duePaymentReport);
            //foreach (var task in duePaymentReport)
            //{
            //    rd.SetDataSource(db.v.Where(x => x.ProjectId == task.Id).Select(c => new
            //    {
            //        //Projectname = task.ProjectName,
            //        ProjectId = c.ProjectId,
            //        TaskId = c.TaskId
            //    }).ToList());
            //} 

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

        [HttpPost]
        public async Task<ActionResult> DueAmountReport(int ProjectId)
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            var payments = db.Payments.Include(p => p.Project).Include(p => p.Task).Where(p => p.ProjectId == ProjectId);
            return View(await payments.ToListAsync());
        }

        //public ActionResult ExportPDueAmountReport()
        //{
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("DueAmount.rpt")));
        //    rd.SetDataSource(db.Payments.Select(p => new
        //    {
        //        InvoiceNo = p.InvoiceNo,
        //        PayDate = p.PayDate,
        //        PaymentAmount = p.PaymentAmount

        //    }).ToList());

        //    //rd.SetDataSource(db.Projects.Select(r => new
        //    //{
        //    //    ProjectName = r.ProjectName
        //    //}).ToList());

        //    //rd.SetDataSource(db.Tasks.Select(t => new
        //    //{
        //    //    TaskName = t.TaskName
        //    //}).ToList());

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();


        //    rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
        //    rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
        //    rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

        //    try
        //    {
        //        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        return File(stream, "application/pdf", "Due_Amount_Report.pdf");
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<ActionResult> UpcomingPaymentReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<UpcomingPaymentReport> upcomingPaymetReport = new List<UpcomingPaymentReport>();

            foreach (var task in tasks)
            {
                UpcomingPaymentReport paid = new UpcomingPaymentReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var payment = await db.Payments.FindAsync(task.ProjectId);
                var contact = await db.Contacts.FindAsync(task.ProjectId);
                //var client = await db.Clients.FindAsync(task.ProjectId);
                var count = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                paid.Id = task.Id;
                paid.Deadline = task.Deadline;
                paid.ProjectName = project.ProjectName;
                paid.TaskName = task.TaskName;
                //paid.ClientName = client.CompanyName;
                //paid.ContactNo = contact.ContactNo;
                paid.TotalPayment = task.TaskWisePayment;
                paid.PaidAmount = payment.PaymentAmount;
                paid.Balance = (task.TaskWisePayment - count);

                upcomingPaymetReport.Add(paid);
            }
            return View(upcomingPaymetReport);

        }

        public async Task<ActionResult> MonthlyReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<MonthlyReport> monthlyReport = new List<MonthlyReport>();

            foreach (var task in tasks)
            {
                MonthlyReport month = new MonthlyReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var payment = await db.Payments.FindAsync(task.ProjectId);
                var contact = await db.Contacts.FindAsync(task.ProjectId);
                //var client = await db.Clients.FindAsync(task.ProjectId);
                var count = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                month.Id = task.Id;
                month.Deadline = task.Deadline;
                month.ProjectName = project.ProjectName;
                //month.ClientName = client.CompanyName;
                //month.BugFixes = 
                //month.ProjectStatus = project.ProjectStatus;
                month.TotalPayment = task.TaskWisePayment;

                monthlyReport.Add(month);
            }
            return View(monthlyReport);

        }

        [HttpPost]
        public async Task<ActionResult> MonthlyReport(DateTime? Sdate)
        {
            ViewBag.Sdate = new SelectList(db.Tasks, "Id", "Sdate");
            var tasks = db.Tasks.Include(p => p.Project).Include(p => p.Payments);
            return View(await tasks.ToListAsync());
        }


        public async Task<ActionResult> ProjectStatusReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<ProjectStatusReport> projectStatusReport = new List<ProjectStatusReport>();

            foreach (var task in tasks)
            {
                ProjectStatusReport projectStatus = new ProjectStatusReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                //var total = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                projectStatus.Id = task.Id;
                projectStatus.Deadline = task.Deadline;
                projectStatus.EmployeeName = task.AssignedEmployee;
                //projectStatus.ClientName = client.CompanyName;
                projectStatus.ProjectName = project.ProjectName;
                //projectStatus.ProjectStatus = task.Status;

                projectStatusReport.Add(projectStatus);
            }
            return View(projectStatusReport);

        }


        public async Task<ActionResult> RevenueReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<RevenueReport> revenueReport = new List<RevenueReport>();

            foreach (var task in tasks)
            {
                RevenueReport paid = new RevenueReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var payment = await db.Payments.FindAsync(task.ProjectId);
                var contact = await db.Contacts.FindAsync(task.ProjectId);
                //var client = await db.Clients.FindAsync(task.ProjectId);
                var count = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                paid.Id = task.Id;
                paid.PayDate = payment.PayDate;
                paid.InvoiceNo = payment.InvoiceNo;
                paid.ProjectName = project.ProjectName;
                //paid.ClientName = client.CompanyName;
                paid.PaymentMethod = payment.PayMethod;
                paid.Description = payment.PayDiscription;
                paid.PaymentAmount = payment.PaymentAmount;


                revenueReport.Add(paid);
            }
            return View(revenueReport);

        }

        public ActionResult RevenueReport(string PaymentMethod)
        {

            var payments = db.Payments;
            //if (!String.IsNullOrEmpty(PaymentMethod))
            //{
            //    payments = payments.Where(p => p.PayMethod.Contains(PaymentMethod) || p.PayMethod.Contains(PaymentMethod));
            //}
            // Pass your list out to your view
            return View(payments.ToList());
        }

        public async Task<ActionResult> PaymentHistoryReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<PaymentHistoryReport> paymentHistoryReport = new List<PaymentHistoryReport>();

            foreach (var task in tasks)
            {
                PaymentHistoryReport paid = new PaymentHistoryReport();
                var project = await db.Projects.FindAsync(task.ProjectId);
                var payment = await db.Payments.FindAsync(task.ProjectId);

                paid.Id = task.Id;
                paid.PayDate = payment.PayDate;
                paid.InvoiceNo = payment.InvoiceNo;
                paid.ProjectName = project.ProjectName;
                paid.TaskName = task.TaskName;
                paid.PayMethod = payment.PayMethod;
                paid.Description = payment.PayDiscription;
                paid.PaymentAmount = payment.PaymentAmount;

                paymentHistoryReport.Add(paid);
            }
            return View(paymentHistoryReport);

        }

        //public async Task<ActionResult> ExportPaymentHistoryReport()
        //{
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("//Reports//PaymentHistoryReport.rpt")));
        //    rd.SetDataSource(db.Payments.Select(p => new
        //    {
        //        //Id = p.Id,
        //        InvoiceNo = p.InvoiceNo,
        //        //PayDate = p.PayDate,
        //        //PaymentAmount = p.PaymentAmount,
        //        PayMethod = p.PayMethod,
        //        Description = p.PayDiscription

        //    }).ToList());

        //    //rd.SetDataSource(db.Projects.Select(r => new
        //    //{
        //    //    ProjectName = r.ProjectName,
        //    //}).ToList());

        //    //rd.SetDataSource(db.Tasks.Select(t => new
        //    //{
        //    //    TaskName = t.TaskName
        //    //}).ToList());

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();


        //    rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
        //    rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
        //    rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);

        //    return File(stream, "application/pdf", "PaymentHistoryReport.pdf");

        //}


        public async Task<ActionResult> IncomeReport()
        {
            var tasks = await db.Tasks.Where(x => x.Deadline > DateTime.Today).ToListAsync();
            List<IncomeReport> incomeReport = new List<IncomeReport>();

            foreach (var task in tasks)
            {
                //IncomeReport income = new IncomeReport();
                //var project = await db..FindAsync(task.ProjectId);
                //var payment = await db.Payments.FindAsync(task.ProjectId);
                //var contact = await db.Contacts.FindAsync(task.ProjectId);
                ////var client = await db.Clients.FindAsync(task.ProjectId);
                //var count = db.Payments.Where(x => x.ProjectId == project.Id && x.TaskId == task.Id).Select(x => x.PaymentAmount).Sum();

                //income.Revenue = task.Id;
                //income.Expences = task.Deadline;
                //income.NetIncome  = project.ProjectName;

                //incomeReport.Add(month);
            }
            return View(incomeReport);

        }
    }
}
    
