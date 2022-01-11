using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string ICon { get; set; }
        public bool Status { get; set; }
        public virtual List<CategoryPicture> CategoryPictures { get; set; }
    }
}
