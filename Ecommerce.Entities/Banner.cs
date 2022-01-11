using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
   public class Banner
    {
        public int ID { get; set; }
        public string BannerName { get; set; }
        public bool Status { get; set; }
        public string ProductURL { get; set; }

        public virtual List<BannerPicture> BannerPictures { get; set; }
    }
}
