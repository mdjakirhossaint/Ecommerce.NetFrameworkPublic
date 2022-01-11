using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Product
    {
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

        public string HotOrNewOrBigSale { get; set; }


        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        public virtual Branding Brand { get; set; }
        public virtual int BrandID { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
        public int? VendorID { get; set; }
        public virtual  Vendor Vendor { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int? ManufacturerID { get; set; }
        public virtual List<ProductProductSize> ProductProductSizes { get; set; }
        public virtual List<ProductPicture> ProductPictures { get; set; }
    }
}
