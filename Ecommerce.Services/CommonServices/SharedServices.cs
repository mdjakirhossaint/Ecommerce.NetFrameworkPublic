using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.CommonServices
{
    public class SharedServices
    {
        EcommerceContext context = new EcommerceContext();
        public int SavePicture(Picture picture)
        {
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.ID;
        }
        public decimal CalculateDiscountAmount(DateTime orderDate, decimal discountAmount)
        {

            var perDayDiscount = (discountAmount / 90);
            var dayCount =(decimal) (DateTime.Now.Date - orderDate.Date).TotalDays;
            var currentBalance = perDayDiscount * dayCount;
            return currentBalance;
         }
    }
}
