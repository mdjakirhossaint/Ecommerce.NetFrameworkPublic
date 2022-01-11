using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class CartViewModel : LayoutViewModel
    {
        public List<int> CartProductIDs { get; set; }
        public virtual List<Product> CartProducts { get; set; }
    }
}