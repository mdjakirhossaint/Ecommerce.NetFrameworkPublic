using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class CurrentBalance
    {
        public int ID { get; set; }
        public decimal CurrentBal { get; set; }
        public virtual Order Order { get; set; }
        public int OrderID { get; set; }
    }
}
