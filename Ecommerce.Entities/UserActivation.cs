using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class UserActivation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public System.Guid ActivationCode { get; set; }
    }
}
