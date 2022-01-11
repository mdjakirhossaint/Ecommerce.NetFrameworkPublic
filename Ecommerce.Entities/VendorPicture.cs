using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class VendorPicture
    {
        public int ID { get; set; }
        public int? VendorID { get; set; }
        public int? PictureID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
