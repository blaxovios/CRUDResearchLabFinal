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
    public class LabAnnouncementsController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: LabAnnouncements
        public async Task<ActionResult> Index()
        {
            var labAnnouncements = db.LabAnnouncements.Include(l => l.Cours).Include(l => l.LabMember).Include(l => l.MemberCategory).Include(l => l.PublicationMedia).Include(l => l.Publication).Include(l => l.ResearchProject);
            return View(await labAnnouncements.ToListAsync());
        }

        // GET: LabAnnouncements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabAnnouncement labAnnouncement = await db.LabAnnouncements.FindAsync(id);
            if (labAnnouncement == null)
            {
                return HttpNotFound();
            }
            return View(labAnnouncement);
        }

        // GET: LabAnnouncements/Create
        public ActionResult Create()
        {
            ViewBag.CoursesID = new SelectList(db.Courses, "CoursesID", "Undergraduate");
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName");
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName");
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType");
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit");
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running");
            return View();
        }

        // POST: LabAnnouncements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LabAnnouncementsID,LabMembersID,MemberCategoriesID,PublicationMediaID,PublicationsID,ResearchProjectsID,CoursesID,Announcement")] LabAnnouncement labAnnouncement)
        {
            if (ModelState.IsValid)
            {
                db.LabAnnouncements.Add(labAnnouncement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CoursesID = new SelectList(db.Courses, "CoursesID", "Undergraduate", labAnnouncement.CoursesID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", labAnnouncement.LabMembersID);
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName", labAnnouncement.MemberCategoriesID);
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType", labAnnouncement.PublicationMediaID);
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit", labAnnouncement.PublicationsID);
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running", labAnnouncement.ResearchProjectsID);
            return View(labAnnouncement);
        }

        // GET: LabAnnouncements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabAnnouncement labAnnouncement = await db.LabAnnouncements.FindAsync(id);
            if (labAnnouncement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoursesID = new SelectList(db.Courses, "CoursesID", "Undergraduate", labAnnouncement.CoursesID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", labAnnouncement.LabMembersID);
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName", labAnnouncement.MemberCategoriesID);
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType", labAnnouncement.PublicationMediaID);
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit", labAnnouncement.PublicationsID);
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running", labAnnouncement.ResearchProjectsID);
            return View(labAnnouncement);
        }

        // POST: LabAnnouncements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LabAnnouncementsID,LabMembersID,MemberCategoriesID,PublicationMediaID,PublicationsID,ResearchProjectsID,CoursesID,Announcement")] LabAnnouncement labAnnouncement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labAnnouncement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CoursesID = new SelectList(db.Courses, "CoursesID", "Undergraduate", labAnnouncement.CoursesID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", labAnnouncement.LabMembersID);
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName", labAnnouncement.MemberCategoriesID);
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType", labAnnouncement.PublicationMediaID);
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit", labAnnouncement.PublicationsID);
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running", labAnnouncement.ResearchProjectsID);
            return View(labAnnouncement);
        }

        // GET: LabAnnouncements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabAnnouncement labAnnouncement = await db.LabAnnouncements.FindAsync(id);
            if (labAnnouncement == null)
            {
                return HttpNotFound();
            }
            return View(labAnnouncement);
        }

        // POST: LabAnnouncements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LabAnnouncement labAnnouncement = await db.LabAnnouncements.FindAsync(id);
            db.LabAnnouncements.Remove(labAnnouncement);
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
