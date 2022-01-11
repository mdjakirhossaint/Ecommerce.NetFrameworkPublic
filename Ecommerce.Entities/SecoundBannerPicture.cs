using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class SecoundBannerPicture
    {
        public int ID { get; set; }
        public virtual SecoundBanner SecoundBanner { get; set; }
        public int SecoundBannerID { get; set; }
        public int PictureID { get; set; }
        public virtual Picture Picture { get; set; }

    }
}
