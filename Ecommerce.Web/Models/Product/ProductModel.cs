
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Models
{
    public class CreateProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProductShortDescription { get; set; }
        public decimal ProductSalePrice { get; set; }
        public decimal ProductRegularPrice { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public bool Status { get; set; }
        public bool IsFeatured { get; set; }
        public string ProductPictures { get; set; }
        public string ProductCode { get; set; }
        public bool IsFlashSale { get; set; }
        public bool IsStaticAds { get; set; }
        public bool IsLatestcAds { get; set; }
        public bool IsSlider { get; set; }
        public int? ManufacturerID { get; set; }

        public List<ProductPicture> ProductPictureList { get; set; }
        public Ecommerce.Entities.Category Category { get; set; }
        
        public int CategoryID { get; set; }
        public Branding Brand { get; set; }
        public int BrandID { get; set; }
        public Ecommerce.Entities.User User { get; set; }
        public int UserID { get; set; }
    }
    public class EditProductModel 
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProductShortDescription { get; set; }
        public decimal ProductSalePrice { get; set; }
        public decimal ProductRegularPrice { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public bool Status { get; set; }
        public bool IsFeatured { get; set; }
        public string ProductPictures { get; set; }
        public string ProductCode { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public virtual ProductPicture ProductPicture { get; set; }
        public List<ProductPicture> ProductPicturesList { get; set; }
        public List<Ecommerce.Entities.Category> Categories { get; set; }
        
        public List<Branding> Brands { get; set; }
        
        public Ecommerce.Entities.User User { get; set; }
        public int UserID { get; set; }
    }
}