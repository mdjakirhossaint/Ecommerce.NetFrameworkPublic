using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Ads
{
   public  class AdsServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<SecoundBanner> GetAllSecoundBanner()
        {
            var banner = db.SecoundBanners.ToList();
            return banner;
        }
        public void SaveSecoundBanner(SecoundBanner secoundBanner)
        {
            db.SecoundBanners.Add(secoundBanner);
            db.SaveChanges();
        }
    }
}
