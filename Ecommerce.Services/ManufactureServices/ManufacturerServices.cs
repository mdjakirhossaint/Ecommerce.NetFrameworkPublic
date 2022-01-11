using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.ManufactureServices
{
    public class ManufacturerServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Manufacturer> GetAllManufacturer()
        {
            var manufacturerList = db.Manufacturers.ToList();
            return manufacturerList;
        }
        public List<Manufacturer> GetSixManufacture()
        {
            var manufacture = db.Manufacturers.Take(6).ToList();
            return manufacture;
        }
    }
}
