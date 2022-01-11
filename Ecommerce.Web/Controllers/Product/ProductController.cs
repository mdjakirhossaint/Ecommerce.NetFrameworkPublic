


using Ecommerce.Entities;
using Ecommerce.Service;
using Ecommerce.Services.BrandService;
using Ecommerce.Services.Comment;
using Ecommerce.Services.ManufactureServices;
using Ecommerce.Web.Models;
using Ecommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Product
{
    public class ProductController : Controller
    {
        CategoryServices categoryServices = new CategoryServices();
        ProductServices productServices = new ProductServices();
        BrandServices brandServices = new BrandServices();
        ManufacturerServices manufacturerServices = new ManufacturerServices();
        CommentServices commentService = new CommentServices();
        // GET: Product
        public ActionResult Index()
        {
            var productlist = productServices.GetAllProduct();
            return View(productlist);
        }

        public ActionResult AddProduct()
        {
            var category = categoryServices.GetAllCategories();
            ViewBag.category = category;

            var brand = brandServices.GetAllBrand();
            ViewBag.brand = brand;
            var manufacture = manufacturerServices.GetAllManufacturer();
            ViewBag.manufacture = manufacture;

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(CreateProductModel model)
        {
            Ecommerce.Entities.Product product = new Ecommerce.Entities.Product();

            product.ProductName = model.ProductName;
            product.CategoryID = model.CategoryID;
            product.ProductSalePrice = model.ProductSalePrice;
            product.ProductRegularPrice = model.ProductRegularPrice;
            product.IsFeatured = model.IsFeatured;
            product.Status = model.Status;
            product.BrandID = model.BrandID ;
            product.UserID = 1;
            product.ProductDescription = model.ProductDescription;
            product.ProductShortDescription = model.ProductShortDescription;
            product.ProductCode = model.ProductCode;
            product.IsFlashSale = model.IsFlashSale;
            product.IsLatestcAds = model.IsLatestcAds;
            product.IsSlider = model.IsSlider;
            product.IsStaticAds = model.IsStaticAds;
            product.ManufacturerID = model.ManufacturerID;


            if (!string.IsNullOrEmpty(model.ProductPictures))
            {
                var pictureIDs = model.ProductPictures
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(ID => int.Parse(ID)).ToList();

                product.ProductPictures = new List<ProductPicture>();
                product.ProductPictures.AddRange(pictureIDs
                    .Select(x => new ProductPicture() { PictureID = x }).ToList());
            }
            productServices.SaveProduct(product);
         

            return RedirectToAction("Index");
        }
        public ActionResult EditProduct(int ID)
        {
            EditProductModel model = new EditProductModel();
            var product = productServices.GetProductByID(ID);

            model.ID = product.ID;
            model.ProductName = product.ProductName;
            model.ProductSalePrice = product.ProductSalePrice;
            model.ProductRegularPrice = product.ProductRegularPrice;
            model.ProductShortDescription = product.ProductShortDescription;
            model.ProductDescription = product.ProductDescription;
            model.IsFeatured = product.IsFeatured;
            model.ProductCode = product.ProductCode;
            model.Status = product.Status;
            model.UserID = product.UserID;
            model.Categories = categoryServices.GetAllCategories();
            model.Brands = brandServices.GetAllBrand();

            model.ProductPicturesList = product.ProductPictures;


            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(EditProductModel model)
        {
            Ecommerce.Entities.Product product = productServices.GetProductByID(model.ID);
            //product.ID = model.ID;
            product.ProductName = model.ProductName;
            product.ProductSalePrice = model.ProductSalePrice;
            product.ProductRegularPrice = model.ProductRegularPrice;
            product.ProductShortDescription = model.ProductShortDescription;
            product.ProductDescription = model.ProductDescription;
            product.IsFeatured = model.IsFeatured;
            product.Status = model.Status;
            product.UserID = model.UserID;

            if (!string.IsNullOrEmpty(model.ProductPictures))
            {
                var pictureIDs = model.ProductPictures
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(ID => int.Parse(ID)).ToList();

                product.ProductPictures = new List<ProductPicture>();
                product.ProductPictures.AddRange(pictureIDs
                    .Select(x => new ProductPicture() { PictureID = x }).ToList());
            }
            productServices.UpdateProduct(product);

            return RedirectToAction("Index");
        }

        public ActionResult CategoryWiseProductList()
        {
            return View();
        }
        public ActionResult DetailProduct(int ID)
        {
            var category = categoryServices.GetNineCategory();
            ViewBag.NineCategory = category;

            //var featuredProduct = productServices.GetFeaturedProduct().Take(5);
            //ViewBag.FeaturedProduct = featuredProduct;

            var brandList = productServices.GetAllBrand(); 
            ViewBag.brandList = brandList;
            ProductDeatailViewModel model = new ProductDeatailViewModel();
            model.EntityID = (int)EntityEnums.Product;
            //var product = productServices.GetProductByID(ID);
            //model.ID = product.ID;
            //model.ProductName = product.ProductName;
            //model.ProductShortDescription = product.ProductShortDescription;
            //model.ProductDescription = product.ProductDescription;
            //model.ProductRegularPrice = product.ProductRegularPrice;
            //model.ProductSalePrice = product.ProductSalePrice;
            model.FeaturedProduct = productServices.GetFeaturedProduct();
            model.Products = productServices.GetProductByID(ID);
            model.Branding = brandServices.GetAllBrand();
            model.LatestProduct = productServices.GetLatestProduct();
            model.MostViewProduct = productServices.GetMostViewProduct().ToList();
            model.Comments = commentService.GetComments((int)EntityEnums.Product, model.Products.ID);
           

            return View(model);
        }
        [HttpPost]       
        public ActionResult MostViewProduct(int ID)
        {
            var productID = ID;
            MostView mostView = new MostView();
            mostView.ProductID = productID;
            productServices.SaveMostView(mostView);
            return View();
        }
    }
}