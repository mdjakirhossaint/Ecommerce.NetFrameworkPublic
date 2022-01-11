using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class ShopViewModel : LayoutViewModel
    {
        public virtual List<Product> Products { get; set; }
        public virtual List<Manufacturer> Manufacturers { get; set; }
        public virtual List<ProductSize> ProductSizes { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int ManufactureID { get; set; }
        public int TagID { get; set; }
        public int ProductSizeID { get; set; }
        public string SearchTerm { get; set; }

    }
    public class FilterProductViewModel : LayoutViewModel
    {
        public virtual List<Product> Products { get; set; }
    }
}