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
    public class PublicationsController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: Publications
        public async Task<ActionResult> Index()
        {
            var publications = db.Publications.Include(p => p.LabAnnouncement).Include(p => p.LabMember).Include(p => p.PublicationMedia).Include(p => p.ResearchProject);
            return View(await publications.ToListAsync());
        }

        // GET: Publications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = await db.Publications.FindAsync(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // GET: Publications/Create
        public ActionResult Create()
        {
            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement");
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName");
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType");
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PublicationsID,ThematicUnit,LabMembersID,PublicationYear,PublicationMediaID,ResearchProjectsID,LabAnnouncementsID")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(publication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement", publication.LabAnnouncementsID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", publication.LabMembersID);
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType", publication.PublicationMediaID);
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running", publication.ResearchProjectsID);
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = await db.Publications.FindAsync(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement", publication.LabAnnouncementsID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", publication.LabMembersID);
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType", publication.PublicationMediaID);
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running", publication.ResearchProjectsID);
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PublicationsID,ThematicUnit,LabMembersID,PublicationYear,PublicationMediaID,ResearchProjectsID,LabAnnouncementsID")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publication).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LabAnnouncementsID = new SelectList(db.LabAnnouncements, "LabAnnouncementsID", "Announcement", publication.LabAnnouncementsID);
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", publication.LabMembersID);
            ViewBag.PublicationMediaID = new SelectList(db.PublicationMedias, "PublicationMediaID", "PublicationType", publication.PublicationMediaID);
            ViewBag.ResearchProjectsID = new SelectList(db.ResearchProjects, "ResearchProjectsID", "Running", publication.ResearchProjectsID);
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = await db.Publications.FindAsync(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Publication publication = await db.Publications.FindAsync(id);
            db.Publications.Remove(publication);
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
