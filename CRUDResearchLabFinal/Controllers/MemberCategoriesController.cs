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
    public class MemberCategoriesController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: MemberCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.MemberCategories.ToListAsync());
        }

        // GET: MemberCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberCategory memberCategory = await db.MemberCategories.FindAsync(id);
            if (memberCategory == null)
            {
                return HttpNotFound();
            }
            return View(memberCategory);
        }

        // GET: MemberCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MemberCategoriesID,CategoryName,Descrptn")] MemberCategory memberCategory)
        {
            if (ModelState.IsValid)
            {
                db.MemberCategories.Add(memberCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(memberCategory);
        }

        // GET: MemberCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberCategory memberCategory = await db.MemberCategories.FindAsync(id);
            if (memberCategory == null)
            {
                return HttpNotFound();
            }
            return View(memberCategory);
        }

        // POST: MemberCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MemberCategoriesID,CategoryName,Descrptn")] MemberCategory memberCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(memberCategory);
        }

        // GET: MemberCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberCategory memberCategory = await db.MemberCategories.FindAsync(id);
            if (memberCategory == null)
            {
                return HttpNotFound();
            }
            return View(memberCategory);
        }

        // POST: MemberCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MemberCategory memberCategory = await db.MemberCategories.FindAsync(id);
            db.MemberCategories.Remove(memberCategory);
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
