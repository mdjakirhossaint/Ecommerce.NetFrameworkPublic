using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.BannerServices
{
    public class BannerServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Banner> GetAllBanner()
        {
            var bannerList = db.Banners.ToList();
            return bannerList;
        }

        public void SaveBanner(Banner banner)
        {
            db.Banners.Add(banner);
            db.SaveChanges();
        }
    }
}
