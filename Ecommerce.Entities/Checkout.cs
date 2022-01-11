using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Checkout
    {
        public int ID { get; set; }
        public DateTime? OrdereDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPercen { get; set; }
        public decimal DiscoutBalanace { get; set; }
        public decimal PayableBalance { get; set; }
        public decimal DiscountCurrentBalance { get; set; }
        public decimal DiscountVariationBalance { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
    }
}
