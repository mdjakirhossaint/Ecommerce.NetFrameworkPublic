using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Nationilty
{
    public class NationalityController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        // GET: Nationality
        public ActionResult Index()
        {
            var nationalityList = db.Nationilities.ToList();
            return View(nationalityList);
        }

        public ActionResult AddNationality()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNationality(Ecommerce.Entities.Nationility nationilty)
        {
            if (ModelState.IsValid)
            {
                db.Nationilities.Add(nationilty);
                db.SaveChanges();
            }
            return View(nationilty);
        }
    }
}