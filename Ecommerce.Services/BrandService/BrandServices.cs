using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.BrandService
{
    public class BrandServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Branding> GetAllBrand()
        {
            return db.Brands.ToList();
        }

        public void SaveBrand(Branding brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }
    }
}
