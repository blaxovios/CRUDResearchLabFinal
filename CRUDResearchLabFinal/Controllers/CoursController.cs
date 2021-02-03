using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDResearchLabFinal.Models;

namespace CRUDResearchLabFinal.Controllers
{
    public class CoursController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: Cours
        public async Task<ActionResult> Index()
        {
            var courses = db.Courses.Include(c => c.LabAnnouncement).Include(c => c.LabMember);
            return View(await courses.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement");
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CoursesID,Undergraduate,Postgraduate,LabMembersID,LabAnnouncementsID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(cours);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement", cours.LabAnnouncementsID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", cours.LabMembersID);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement", cours.LabAnnouncementsID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", cours.LabMembersID);
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CoursesID,Undergraduate,Postgraduate,LabMembersID,LabAnnouncementsID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement", cours.LabAnnouncementsID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", cours.LabMembersID);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cours cours = await db.Courses.FindAsync(id);
            db.Courses.Remove(cours);
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
