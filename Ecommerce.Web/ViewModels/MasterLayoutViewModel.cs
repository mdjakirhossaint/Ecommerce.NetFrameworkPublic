using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class MasterLayoutViewModel : LayoutViewModel
    {
        public virtual List<Slider> Slider { get; set; }
        public virtual List<Product> HotProduct { get; set; }
        public virtual List<Product> FeaturedProduct { get; set; }
        public virtual List<Product> NewArrivalProduct { get; set; }
        public virtual List<Product> NewProduct { get; set; }
        public virtual List<Product> LatestProduct { get; set; }
        public virtual List<Product> MostViewProduct { get; set; }
        public virtual List<Product> hotSaleProduct { get; set; }
        public virtual List<Product> bestSaleProduct { get; set; }
    }
}