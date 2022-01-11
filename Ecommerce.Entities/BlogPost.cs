using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class BlogPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Description { get; set; }
        public virtual List<BlogPicture> BlogPictures { get; set; }
    }
}
