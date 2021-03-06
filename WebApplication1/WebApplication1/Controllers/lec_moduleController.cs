﻿using System;
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
    public class lec_moduleController : Controller
    {
        private student_dataEntities2 db = new student_dataEntities2();

        // GET: lec_module
        public async Task<ActionResult> Index()
        {
            var lec_module = db.lec_module.Include(l => l.degree1).Include(l => l.intake1).Include(l => l.module1).Include(l => l.lecturer1);
            return View(await lec_module.ToListAsync());
        }

       
        // GET: lec_module/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lec_module lec_module = await db.lec_module.FindAsync(id);
            if (lec_module == null)
            {
                return HttpNotFound();
            }
            return View(lec_module);
        }

        // GET: lec_module/Create
        public ActionResult Create(int? id)
        {
            var lecturers = db.lecturers
                    .Select(s => new
                    {

                        Text = id,
                        Value = id

                    })
                    .ToList();

            ViewBag.degree = new SelectList(db.degrees, "id", "name");
            ViewBag.intake = new SelectList(db.intakes, "id", "name");
            ViewBag.module = new SelectList(db.modules, "id", "code");
            ViewBag.lecturer = new SelectList(lecturers, "Value", "Text");
            return View();
        }

        // POST: lec_module/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,lecturer,module,degree,intake")] lec_module lec_module)
        {
            if (ModelState.IsValid)
            {
                db.lec_module.Add(lec_module);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }



            ViewBag.degree = new SelectList(db.degrees, "id", "name", lec_module.degree);
            ViewBag.intake = new SelectList(db.intakes, "id", "name", lec_module.intake);
            ViewBag.module = new SelectList(db.modules, "id", "code", lec_module.module);
            ViewBag.lecturer = new SelectList(db.lecturers, "id", "uni_id", lec_module.lecturer);
            return View(lec_module);
        }

        // GET: lec_module/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lec_module lec_module = await db.lec_module.FindAsync(id);
            if (lec_module == null)
            {
                return HttpNotFound();
            }
            ViewBag.degree = new SelectList(db.degrees, "id", "name", lec_module.degree);
            ViewBag.intake = new SelectList(db.intakes, "id", "name", lec_module.intake);
            ViewBag.module = new SelectList(db.modules, "id", "code", lec_module.module);
            ViewBag.lecturer = new SelectList(db.lecturers, "id", "uni_id", lec_module.lecturer);
            return View(lec_module);
        }

        // POST: lec_module/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,lecturer,module,degree,intake")] lec_module lec_module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lec_module).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.degree = new SelectList(db.degrees, "id", "name", lec_module.degree);
            ViewBag.intake = new SelectList(db.intakes, "id", "name", lec_module.intake);
            ViewBag.module = new SelectList(db.modules, "id", "code", lec_module.module);
            ViewBag.lecturer = new SelectList(db.lecturers, "id", "uni_id", lec_module.lecturer);
            return View(lec_module);
        }

        // GET: lec_module/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lec_module lec_module = await db.lec_module.FindAsync(id);
            if (lec_module == null)
            {
                return HttpNotFound();
            }
            return View(lec_module);
        }

        // POST: lec_module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            lec_module lec_module = await db.lec_module.FindAsync(id);
            db.lec_module.Remove(lec_module);
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
