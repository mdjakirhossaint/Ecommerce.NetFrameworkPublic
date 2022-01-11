using Ecommerce.Service;
using Ecommerce.Services.BrandService;
using Ecommerce.Services.ManufactureServices;
using Ecommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Product
{
    public class SeachingProductController : Controller
    {
        CategoryServices categoryServices = new CategoryServices();
        ProductServices productServices = new ProductServices();
        BrandServices brandServices = new BrandServices();
        ManufacturerServices manufacturerServices = new ManufacturerServices();
        // GET: SeachingProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryWiseProduct(int ID)
        {
            ProductListViewModel model = new ProductListViewModel();
            var category = categoryServices.GetNineCategory();
            ViewBag.NineCategory = category;

            model.Products=productServices.CategoryWiseNineProduct(ID);
            model.Branding = brandServices.GetAllBrand();

            return View(model);
        }
        public ActionResult ManufactureWiseProduct(int ID)
        {
            ProductListViewModel model = new ProductListViewModel();
            var category = categoryServices.GetNineCategory();
            ViewBag.NineCategory = category;

            var manufacture = manufacturerServices.GetAllManufacturer().Take(6).ToList();
            ViewBag.manufacture = manufacture;

            model.ManufactureList = manufacturerServices.GetSixManufacture();
            model.Products = productServices.CategoryWiseNineProduct(ID);
            model.Branding = brandServices.GetAllBrand();
            model.Manufacturers = productServices.ManufactureWiseProduct(ID);

            return View(model);
        }

    }
}