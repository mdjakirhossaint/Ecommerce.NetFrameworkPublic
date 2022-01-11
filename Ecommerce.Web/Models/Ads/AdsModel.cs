using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Models.Ads
{
    public class CreateAdsModel
    {
        public int ID { get; set; }
        public string SBannerName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string SecoundBannerPictures { get; set; }
        public virtual List<SecoundBannerPicture> SecoundBannerPictureList { get; set; }
    }
}