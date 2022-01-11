using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class ProductListViewModel : LayoutViewModel
    {
        public virtual List<Product> Products { get; set; }
        public virtual List<Product> Manufacturers { get; set; }
        public virtual List<Manufacturer> ManufactureList { get; set; }
    }
    public class ProductDeatailViewModel : LayoutViewModel
    {
        public virtual Product Products { get; set; }
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductShortDescription { get; set; }
        public decimal ProductSalePrice { get; set; }
        public decimal ProductRegularPrice { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public string ProductCode { get; set; }
        public bool Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsFlashSale { get; set; }
        public bool IsStaticAds { get; set; }
        public bool IsLatestcAds { get; set; }
        public bool IsSlider { get; set; }

        public int EntityID { get; set; }


        public virtual List<Category> Category { get; set; }
       
        public int CategoryID { get; set; }
        public virtual Branding Brand { get; set; }
        public int BrandID { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }

        public virtual List<ProductPicture> ProductPictures { get; set; }
        public virtual List<Product> FeaturedProduct { get; set; }
        public virtual List<Product> LatestProduct { get; set; }
        public virtual List<Product> MostViewProduct { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}