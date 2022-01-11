using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string ManufacturerName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
