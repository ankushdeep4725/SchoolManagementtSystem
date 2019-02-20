using SchoolManagementtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementtSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult StudentView()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var mymodel = new ViewModel();
            mymodel.ClassMastersss = db.ClassMasters.ToList();
            mymodel.TeacherMastersss = db.TeacherMasters.ToList();

            return View(mymodel);
        }


    }
}