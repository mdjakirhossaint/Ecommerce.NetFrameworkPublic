using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Models.Brand
{
    public class CreateBrandModel
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string BrandPictures { get; set; }
        public bool Status { get; set; }


        public List<BrandingPicture> CategoryPictureList { get; set; }
    }
}