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
    public class stu_moduleController : Controller
    {
        private student_dataEntities2 db = new student_dataEntities2();

        // GET: stu_module
        public async Task<ActionResult> Index()
        {
            var stu_module = db.stu_module.Include(s => s.lec_module).Include(s => s.student1);
            return View(await stu_module.ToListAsync());
        }

        // GET: stu_module/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stu_module stu_module = await db.stu_module.FindAsync(id);
            if (stu_module == null)
            {
                return HttpNotFound();
            }
            return View(stu_module);
        }

        // GET: stu_module/Create
        public ActionResult Create()
        {
            ViewBag.module = new SelectList(db.lec_module, "id", "id");
            ViewBag.student = new SelectList(db.students, "id", "uni_id");
            return View();
        }

        // POST: stu_module/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,student,module,assignmentMark,examMark")] stu_module stu_module)
        {
            if (ModelState.IsValid)
            {
                db.stu_module.Add(stu_module);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.module = new SelectList(db.lec_module, "id", "id", stu_module.module);
            ViewBag.student = new SelectList(db.students, "id", "uni_id", stu_module.student);
            return View(stu_module);
        }

        // GET: stu_module/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stu_module stu_module = await db.stu_module.FindAsync(id);
            if (stu_module == null)
            {
                return HttpNotFound();
            }
            ViewBag.module = new SelectList(db.lec_module, "id", "id", stu_module.module);
            ViewBag.student = new SelectList(db.students, "id", "uni_id", stu_module.student);
            return View(stu_module);
        }

        // POST: stu_module/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,student,module,assignmentMark,examMark")] stu_module stu_module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_module).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.module = new SelectList(db.lec_module, "id", "id", stu_module.module);
            ViewBag.student = new SelectList(db.students, "id", "uni_id", stu_module.student);
            return View(stu_module);
        }

        // GET: stu_module/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stu_module stu_module = await db.stu_module.FindAsync(id);
            if (stu_module == null)
            {
                return HttpNotFound();
            }
            return View(stu_module);
        }

        // POST: stu_module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            stu_module stu_module = await db.stu_module.FindAsync(id);
            db.stu_module.Remove(stu_module);
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
