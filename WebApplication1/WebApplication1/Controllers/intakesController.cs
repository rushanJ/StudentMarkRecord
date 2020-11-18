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
    public class intakesController : Controller
    {
        private student_dataEntities2 db = new student_dataEntities2();

        // GET: intakes
        public async Task<ActionResult> Index()
        {
            return View(await db.intakes.ToListAsync());
        }

        // GET: intakes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            intake intake = await db.intakes.FindAsync(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // GET: intakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: intakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] intake intake)
        {
            if (ModelState.IsValid)
            {
                db.intakes.Add(intake);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(intake);
        }

        // GET: intakes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            intake intake = await db.intakes.FindAsync(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // POST: intakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] intake intake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intake).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(intake);
        }

        // GET: intakes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            intake intake = await db.intakes.FindAsync(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // POST: intakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            intake intake = await db.intakes.FindAsync(id);
            db.intakes.Remove(intake);
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
