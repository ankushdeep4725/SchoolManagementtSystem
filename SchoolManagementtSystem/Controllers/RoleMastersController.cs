using Microsoft.AspNet.Identity.EntityFramework;
using SchoolManagementtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementtSystem.Controllers
{
    public class RoleMastersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult RoleIndex()
        {
            var roleList = db.Roles.ToList();
            return View(roleList);
        }

        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole identity)
        {
            db.Roles.Add(identity);
            db.SaveChanges();
            return RedirectToAction("RoleIndex");
        }
    }
}
