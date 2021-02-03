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
    public class LabMembersController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: LabMembers
        public async Task<ActionResult> Index()
        {
            var labMembers = db.LabMembers.Include(l => l.MemberCategory);
            return View(await labMembers.ToListAsync());
        }

        // GET: LabMembers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabMember labMember = await db.LabMembers.FindAsync(id);
            if (labMember == null)
            {
                return HttpNotFound();
            }
            return View(labMember);
        }

        // GET: LabMembers/Create
        public ActionResult Create()
        {
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName");
            return View();
        }

        // POST: LabMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LabMembersID,FirstName,Surname,WebPage,Email,ShortCV,MemberCategoriesID")] LabMember labMember)
        {
            if (ModelState.IsValid)
            {
                db.LabMembers.Add(labMember);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName", labMember.MemberCategoriesID);
            return View(labMember);
        }

        // GET: LabMembers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabMember labMember = await db.LabMembers.FindAsync(id);
            if (labMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName", labMember.MemberCategoriesID);
            return View(labMember);
        }

        // POST: LabMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LabMembersID,FirstName,Surname,WebPage,Email,ShortCV,MemberCategoriesID")] LabMember labMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labMember).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MemberCategoriesID = new SelectList(db.MemberCategories, "MemberCategoriesID", "CategoryName", labMember.MemberCategoriesID);
            return View(labMember);
        }

        // GET: LabMembers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabMember labMember = await db.LabMembers.FindAsync(id);
            if (labMember == null)
            {
                return HttpNotFound();
            }
            return View(labMember);
        }

        // POST: LabMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LabMember labMember = await db.LabMembers.FindAsync(id);
            db.LabMembers.Remove(labMember);
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
