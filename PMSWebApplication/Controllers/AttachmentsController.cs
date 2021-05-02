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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace PMSWebApplication.Controllers
{
    public class AttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attachments
        public async Task<ActionResult> Index()
        {
            var attachments = db.Attachments.Include(a => a.Project).Include(a => a.User);
            return View(await attachments.ToListAsync());
        }

        // GET: Attachments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: Attachments/Create
        public ActionResult Create()
        {

            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            ViewBag.UserId = new SelectList(users, "Id", "Email");
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,UserId,FileName,FileType,Type,Description")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", attachment.ProjectId);
            ViewBag.UserId = new SelectList(users, "Id", "Email", attachment.UserId);
            return View(attachment);
        }

        // GET: Attachments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }

            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", attachment.ProjectId);
            ViewBag.UserId = new SelectList(users, "Id", "Email", attachment.UserId);
            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,UserId,FileName,FileType,Type,Description")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", attachment.ProjectId);
            ViewBag.UserId = new SelectList(users, "Id", "Email", attachment.UserId);
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Attachment attachment = await db.Attachments.FindAsync(id);
            db.Attachments.Remove(attachment);
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
    }
}
