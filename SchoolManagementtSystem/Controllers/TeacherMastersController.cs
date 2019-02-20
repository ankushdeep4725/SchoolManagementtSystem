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
    public class TeacherMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherMasters
        public ActionResult Index()
        {
            return View(db.TeacherMasters.ToList());
        }

        // GET: TeacherMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherMaster teacherMaster = db.TeacherMasters.Find(id);
            if (teacherMaster == null)
            {
                return HttpNotFound();
            }
            return View(teacherMaster);
        }

        // GET: TeacherMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,TeacherName,Qualification")] TeacherMaster teacherMaster)
        {
            if (ModelState.IsValid)
            {
                db.TeacherMasters.Add(teacherMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherMaster);
        }

        // GET: TeacherMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherMaster teacherMaster = db.TeacherMasters.Find(id);
            if (teacherMaster == null)
            {
                return HttpNotFound();
            }
            return View(teacherMaster);
        }

        // POST: TeacherMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,TeacherName,Qualification")] TeacherMaster teacherMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherMaster);
        }

        // GET: TeacherMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherMaster teacherMaster = db.TeacherMasters.Find(id);
            if (teacherMaster == null)
            {
                return HttpNotFound();
            }
            return View(teacherMaster);
        }

        // POST: TeacherMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherMaster teacherMaster = db.TeacherMasters.Find(id);
            db.TeacherMasters.Remove(teacherMaster);
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
