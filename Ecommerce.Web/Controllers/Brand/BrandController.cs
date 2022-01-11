using Ecommerce.Web.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Entities;
using Ecommerce.Services.BrandService;

namespace Ecommerce.Web.Controllers.Brand
{
    public class BrandController : Controller
    {
        BrandServices brandServices = new BrandServices();
        // GET: Brand
        public ActionResult Index()
        {
            var brand = brandServices.GetAllBrand();

            return View(brand);
        }
        public ActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(CreateBrandModel model)
        {
            Branding brand = new Branding();
            brand.BrandName = model.BrandName;
            brand.Description = model.Description;
            brand.Status = model.Status;
           

            if (!string.IsNullOrEmpty(model.BrandPictures))
            {
                var pictureIDs = model.BrandPictures
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(ID => int.Parse(ID)).ToList();

                brand.BrandingPictures = new List<BrandingPicture>();
                brand.BrandingPictures.AddRange(pictureIDs
                    .Select(x => new BrandingPicture() { PictureID = x }).ToList());
            }
            brandServices.SaveBrand(brand);

            return RedirectToAction("Index");
        }
    }
}