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
    public class lecturersController : Controller
    {
        private student_dataEntities2 db = new student_dataEntities2();

        // GET: lecturers
        public async Task<ActionResult> Index()
        {
            var lecturers = db.lecturers.Include(l => l.department1);
            return View(await lecturers.ToListAsync());
        }

        // GET: lecturers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturer lecturer = await db.lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // GET: lecturers/Create
        public ActionResult Create()
        {
            ViewBag.department = new SelectList(db.departments, "id", "name");
            return View();
        }

        // POST: lecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,uni_id,firstName,lastName,email,contactNo,department,password,role,lecturerStatus")] lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.lecturers.Add(lecturer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.department = new SelectList(db.departments, "id", "name", lecturer.department);
            return View(lecturer);
        }

        // GET: lecturers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturer lecturer = await db.lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            ViewBag.department = new SelectList(db.departments, "id", "name", lecturer.department);
            return View(lecturer);
        }

        // POST: lecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,uni_id,firstName,lastName,email,contactNo,department,password,role,lecturerStatus")] lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.department = new SelectList(db.departments, "id", "name", lecturer.department);
            return View(lecturer);
        }

        // GET: lecturers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturer lecturer = await db.lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // POST: lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            lecturer lecturer = await db.lecturers.FindAsync(id);
            db.lecturers.Remove(lecturer);
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
