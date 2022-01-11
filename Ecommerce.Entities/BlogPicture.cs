using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class BlogPicture
    {
        public int ID { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public int BlogPostID { get; set; }
        public virtual Picture Picture { get; set; }
        public int PictureID { get; set; }
    }
}
