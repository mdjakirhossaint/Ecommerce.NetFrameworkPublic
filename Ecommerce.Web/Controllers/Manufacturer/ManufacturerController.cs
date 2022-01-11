using Ecommerce.Data;
using Ecommerce.Services.ManufactureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Manufacturer
{
    public class ManufacturerController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        ManufacturerServices manufacturerServices = new ManufacturerServices();
        // GET: Manufacturer
        public ActionResult Index()
        {
            var manufacturerList = manufacturerServices.GetAllManufacturer();
            return View(manufacturerList);
        }
        public ActionResult AddManufacturers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddManufacturers(Ecommerce.Entities.Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
            }
            return View();
        }
    }
}