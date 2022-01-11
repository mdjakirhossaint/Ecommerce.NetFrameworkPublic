using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class ProductProductSize
    {
        public int ID { get; set; }
        public int  ProductID { get; set; }
        public int ProductSizeID { get; set; }
        public ProductSize ProductSize { get; set; }
    }
}
