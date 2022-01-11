using Ecommerce.Service;
using Ecommerce.Services.BrandService;
using Ecommerce.Services.SliderServices;
using Ecommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        CategoryServices categoryServices = new CategoryServices();
        BrandServices brandServices = new BrandServices();
        SliderServices sliderServices = new SliderServices();
        ProductServices productServices = new ProductServices();
        public ActionResult Index()
        {
            var category=categoryServices.GetNineCategory();
            ViewBag.NineCategory = category;

            MasterLayoutViewModel model = new MasterLayoutViewModel();
            model.Branding = brandServices.GetAllBrand();
            model.Slider = sliderServices.GetAllSliders().Take(5).ToList();
            model.HotProduct = productServices.GetAllHotDealProduct();
            model.FeaturedProduct = productServices.GetFeaturedProduct();
            model.NewArrivalProduct = productServices.GetAllProduct().OrderByDescending(x => x.ID).ToList();
            model.NewProduct = productServices.GetAllProduct().Take(10).ToList();
            model.LatestProduct = productServices.GetAllProduct().Take(20).ToList();
            model.NewProduct = productServices.GetAllProduct();
            //model.MostViewProduct = productServices.GetAllProduct().OrderByDescending(x=>x.ID).Take(10).ToList();
            model.MostViewProduct = productServices.GetMostViewProduct().ToList();
            model.hotSaleProduct = productServices.GetAllProduct().OrderByDescending(x=>x.ProductSalePrice).ThenByDescending(s=>s.ProductRegularPrice).Take(20).ToList();
            //model.bestSaleProduct = productServices.GetAllProduct().Take(4).ToList();
            model.bestSaleProduct = productServices.GetMaxOrderQuantity().ToList();
            return View(model);
        }
        
    }
}