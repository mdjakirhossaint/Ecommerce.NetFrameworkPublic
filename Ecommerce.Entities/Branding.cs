using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Branding
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual List<BrandingPicture> BrandingPictures { get; set; }
    }
}
