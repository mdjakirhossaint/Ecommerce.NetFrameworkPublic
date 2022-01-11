using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class SubCategory
    {
        public int ID { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public int? CategoryID { get; set; }
    }
}
