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
    public class PublicationMediasController : Controller
    {
        private ResearchLabEntities db = new ResearchLabEntities();

        // GET: PublicationMedias
        public async Task<ActionResult> Index()
        {
            return View(await db.PublicationMedias.ToListAsync());
        }

        // GET: PublicationMedias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationMedia publicationMedia = await db.PublicationMedias.FindAsync(id);
            if (publicationMedia == null)
            {
                return HttpNotFound();
            }
            return View(publicationMedia);
        }

        // GET: PublicationMedias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicationMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PublicationMediaID,PublicationType")] PublicationMedia publicationMedia)
        {
            if (ModelState.IsValid)
            {
                db.PublicationMedias.Add(publicationMedia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(publicationMedia);
        }

        // GET: PublicationMedias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationMedia publicationMedia = await db.PublicationMedias.FindAsync(id);
            if (publicationMedia == null)
            {
                return HttpNotFound();
            }
            return View(publicationMedia);
        }

        // POST: PublicationMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PublicationMediaID,PublicationType")] PublicationMedia publicationMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicationMedia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(publicationMedia);
        }

        // GET: PublicationMedias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationMedia publicationMedia = await db.PublicationMedias.FindAsync(id);
            if (publicationMedia == null)
            {
                return HttpNotFound();
            }
            return View(publicationMedia);
        }

        // POST: PublicationMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PublicationMedia publicationMedia = await db.PublicationMedias.FindAsync(id);
            db.PublicationMedias.Remove(publicationMedia);
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
