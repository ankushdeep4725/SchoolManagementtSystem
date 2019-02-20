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
    public class StudentMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentMasters
        public ActionResult Index()
        {
            var studentMasters = db.StudentMasters.Include(s => s.ClassMaster).Include(s => s.TeacherMaster);
            return View(studentMasters.ToList());
        }

        // GET: StudentMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // GET: StudentMasters/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassMasters, "ClassId", "ClassName");
            ViewBag.TeacherId = new SelectList(db.TeacherMasters, "TeacherId", "TeacherName");
            return View();
        }

        // POST: StudentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,ClassId,TeacherId,Address,Mobile,Gender,Email")] StudentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                db.StudentMasters.Add(studentMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassMasters, "ClassId", "ClassName", studentMaster.ClassId);
            ViewBag.TeacherId = new SelectList(db.TeacherMasters, "TeacherId", "TeacherName", studentMaster.TeacherId);
            return View(studentMaster);
        }

        // GET: StudentMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassMasters, "ClassId", "ClassName", studentMaster.ClassId);
            ViewBag.TeacherId = new SelectList(db.TeacherMasters, "TeacherId", "TeacherName", studentMaster.TeacherId);
            return View(studentMaster);
        }

        // POST: StudentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,ClassId,TeacherId,Address,Mobile,Gender,Email")] StudentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassMasters, "ClassId", "ClassName", studentMaster.ClassId);
            ViewBag.TeacherId = new SelectList(db.TeacherMasters, "TeacherId", "TeacherName", studentMaster.TeacherId);
            return View(studentMaster);
        }

        // GET: StudentMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // POST: StudentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.Find(id);
            db.StudentMasters.Remove(studentMaster);
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
