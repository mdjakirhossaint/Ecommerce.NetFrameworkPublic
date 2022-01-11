using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class UserOrderViewModel:LayoutViewModel
    {
        public virtual List<Product> OrderProducts { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}