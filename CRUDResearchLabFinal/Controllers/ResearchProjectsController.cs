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
    public class ResearchProjectsController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: ResearchProjects
        public async Task<ActionResult> Index()
        {
            var researchProjects = db.ResearchProjects.Include(r => r.LabMember).Include(r => r.Publication);
            return View(await researchProjects.ToListAsync());
        }

        // GET: ResearchProjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchProject researchProject = await db.ResearchProjects.FindAsync(id);
            if (researchProject == null)
            {
                return HttpNotFound();
            }
            return View(researchProject);
        }

        // GET: ResearchProjects/Create
        public ActionResult Create()
        {
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName");
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit");
            return View();
        }

        // POST: ResearchProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ResearchProjectsID,Running,Completed,LabMembersID,PublicationsID,Descrptn")] ResearchProject researchProject)
        {
            if (ModelState.IsValid)
            {
                db.ResearchProjects.Add(researchProject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", researchProject.LabMembersID);
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit", researchProject.PublicationsID);
            return View(researchProject);
        }

        // GET: ResearchProjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchProject researchProject = await db.ResearchProjects.FindAsync(id);
            if (researchProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", researchProject.LabMembersID);
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit", researchProject.PublicationsID);
            return View(researchProject);
        }

        // POST: ResearchProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ResearchProjectsID,Running,Completed,LabMembersID,PublicationsID,Descrptn")] ResearchProject researchProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(researchProject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LabMembersID = new SelectList(db.LabMembers, "LabMembersID", "FirstName", researchProject.LabMembersID);
            ViewBag.PublicationsID = new SelectList(db.Publications, "PublicationsID", "ThematicUnit", researchProject.PublicationsID);
            return View(researchProject);
        }

        // GET: ResearchProjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchProject researchProject = await db.ResearchProjects.FindAsync(id);
            if (researchProject == null)
            {
                return HttpNotFound();
            }
            return View(researchProject);
        }

        // POST: ResearchProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ResearchProject researchProject = await db.ResearchProjects.FindAsync(id);
            db.ResearchProjects.Remove(researchProject);
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
