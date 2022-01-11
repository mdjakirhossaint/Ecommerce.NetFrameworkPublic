using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
   public class UserPicture
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PictureID { get; set; }
        public virtual Picture  Picture { get; set; }
    }
}
