using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Data;
using Ecommerce.Entities;
namespace Ecommerce.Web.Controllers.Gender
{
    public class GenderController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        
        // GET: Gender
        public ActionResult Index()
        {
            var genderList = db.Genders.ToList();
            return View(genderList);
        }

        public ActionResult AddGender()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGender(Ecommerce.Entities.Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(gender);
                db.SaveChanges();
            }
            return View(gender);
        }
    }
}