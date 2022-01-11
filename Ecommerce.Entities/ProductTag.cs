using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class ProductTag
    {
        public int ID { get; set; }
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        public virtual Tag Tag { get; set; }
        public int TagID { get; set; }
    }
}
