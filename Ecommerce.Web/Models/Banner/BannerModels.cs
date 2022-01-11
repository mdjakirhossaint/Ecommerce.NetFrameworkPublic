using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Models
{
    public class CreateBannerModel
    {
        public int ID { get; set; }
        public string BannerName { get; set; }
        public bool Status { get; set; }
        public string ProductURL { get; set; }
        public string BannerPictures { get; set; }
        public virtual List<BannerPicture> BannerPictureList { get; set; }
    }
}