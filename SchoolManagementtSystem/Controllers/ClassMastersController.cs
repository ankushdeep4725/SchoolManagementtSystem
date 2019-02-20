using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagementtSystem.Models;

namespace SchoolManagementtSystem.Controllers
{
    [Authorize]
    public class ClassMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassMasters
        public ActionResult Index()
        {
            return View(db.ClassMasters.ToList());
        }

        // GET: ClassMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassMaster classMaster = db.ClassMasters.Find(id);
            if (classMaster == null)
            {
                return HttpNotFound();
            }
            return View(classMaster);
        }

        // GET: ClassMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName")] ClassMaster classMaster)
        {
            if (ModelState.IsValid)
            {
                db.ClassMasters.Add(classMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classMaster);
        }

        // GET: ClassMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassMaster classMaster = db.ClassMasters.Find(id);
            if (classMaster == null)
            {
                return HttpNotFound();
            }
            return View(classMaster);
        }

        // POST: ClassMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName")] ClassMaster classMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classMaster);
        }

        // GET: ClassMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassMaster classMaster = db.ClassMasters.Find(id);
            if (classMaster == null)
            {
                return HttpNotFound();
            }
            return View(classMaster);
        }

        // POST: ClassMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassMaster classMaster = db.ClassMasters.Find(id);
            db.ClassMasters.Remove(classMaster);
            db.SaveChanges();
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
