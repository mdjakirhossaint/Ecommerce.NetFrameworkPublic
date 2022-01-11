using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Order
{
    public class OrderServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Ecommerce.Entities.Order> GetAllOrderByUser(int ID)
        {
            var orderlist = db.Orders.Where(x => x.UserID == ID).ToList();
            return orderlist;
        }

        //public Ecommerce.Entities.Order GetOrderByID(int ID)
        //{
        //    var orderID= db.Orders.Select(x => x.ID).FirstOrDefault();
        //    return orderID;
        //}
        public List<OrderItem> GetAllOrderItemByOrderID(int ID, int UserID)
        {
            var orderItemList = db.OrderItems.Where(x => x.OrderID == ID && x.UserID==UserID).ToList();
            return orderItemList;
        }
    }
}
