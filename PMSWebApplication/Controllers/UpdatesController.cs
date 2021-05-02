using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PMSWebApplication.Models;
using PMSWebApplication.Models.DomainModels;

namespace PMSWebApplication.Controllers
{
    public class UpdatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Updates
        public async Task<ActionResult> Index()
        {
            var updates = db.Updates.Include(u => u.Attachment).Include(u => u.Project).Include(u => u.User);
            return View(await updates.ToListAsync());
        }

        // GET: Updates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update update = await db.Updates.FindAsync(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            return View(update);
        }

        // GET: Updates/Create
        public ActionResult Create()
        {
            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.AttachmentId = new SelectList(db.Attachments, "Id", "FileName");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            ViewBag.UserId = new SelectList(users, "Id", "Email");
            return View();
        }

        // POST: Updates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,UserId,AttachmentId,Deadline")] Update update)
        {
            if (ModelState.IsValid)
            {
                db.Updates.Add(update);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.AttachmentId = new SelectList(db.Attachments, "Id", "FileName", update.AttachmentId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", update.ProjectId);
            ViewBag.UserId = new SelectList(users, "Id", "Email", update.UserId);
            return View(update);
        }

        // GET: Updates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update update = await db.Updates.FindAsync(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.AttachmentId = new SelectList(db.Attachments, "Id", "ProjectId", update.AttachmentId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", update.ProjectId);
            ViewBag.UserId = new SelectList(users, "Id", "Email", update.UserId);
            return View(update);
        }

        // POST: Updates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,UserId,AttachmentId,Deadline")] Update update)
        {
            if (ModelState.IsValid)
            {
                db.Entry(update).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var users = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)).Users;

            ViewBag.AttachmentId = new SelectList(db.Attachments, "Id", "ProjectId", update.AttachmentId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", update.ProjectId);
            ViewBag.UserId = new SelectList(users, "Id", "Email", update.UserId);
            return View(update);
        }

        // GET: Updates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update update = await db.Updates.FindAsync(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            return View(update);
        }

        // POST: Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Update update = await db.Updates.FindAsync(id);
            db.Updates.Remove(update);
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
