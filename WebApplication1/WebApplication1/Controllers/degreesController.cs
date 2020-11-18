using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class degreesController : Controller
    {
        private student_dataEntities2 db = new student_dataEntities2();

        // GET: degrees
        public async Task<ActionResult> Index()
        {
            var degrees = db.degrees.Include(d => d.department1);
            return View(await degrees.ToListAsync());
        }

        // GET: degrees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree degree = await db.degrees.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: degrees/Create
        public ActionResult Create()
        {
            ViewBag.department = new SelectList(db.departments, "id", "name");
            return View();
        }

        // POST: degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,faculty,department")] degree degree)
        {
            if (ModelState.IsValid)
            {
                db.degrees.Add(degree);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.department = new SelectList(db.departments, "id", "name", degree.department);
            return View(degree);
        }

        // GET: degrees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree degree = await db.degrees.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            ViewBag.department = new SelectList(db.departments, "id", "name", degree.department);
            return View(degree);
        }

        // POST: degrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,faculty,department")] degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.department = new SelectList(db.departments, "id", "name", degree.department);
            return View(degree);
        }

        // GET: degrees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree degree = await db.degrees.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            degree degree = await db.degrees.FindAsync(id);
            db.degrees.Remove(degree);
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
