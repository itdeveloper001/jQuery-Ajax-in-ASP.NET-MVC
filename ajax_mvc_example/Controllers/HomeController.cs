using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ajax_mvc_example.Models;

namespace ajax_mvc_example.Controllers
{
    public class HomeController : Controller
    {
        dbdemoEntities db = new dbdemoEntities();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbluser t)
        {
            tbluser u = new tbluser();
            u.name = t.name;
            u.pass = t.pass;
            db.tblusers.Add(u);
            db.SaveChanges();

            return Json(u, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail()
        {
            var query = db.tblusers.ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}