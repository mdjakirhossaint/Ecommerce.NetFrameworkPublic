using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Checkout
{
    public class CheckoutServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Product> GetProductsForCheckout(List<int> IDs)
        {
                return db.Products.Where(product => IDs.Contains(product.ID)).ToList();
        }
        public int SaveOrder(Ecommerce.Entities.Order order)
        {
            db.Orders.Add(order);
            return db.SaveChanges();
        }
    }
}
