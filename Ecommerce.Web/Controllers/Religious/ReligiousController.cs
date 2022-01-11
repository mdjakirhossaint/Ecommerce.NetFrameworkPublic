using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Religious
{
    public class ReligiousController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        // GET: Religious
        public ActionResult Index()
        {
            var religiousList = db.Religiouses.ToList();
            return View(religiousList);
        }
        public ActionResult AddReligious()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReligious(Ecommerce.Entities.Religious religious)
        {
            if (ModelState.IsValid)
            {
                db.Religiouses.Add(religious);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}