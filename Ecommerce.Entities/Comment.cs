using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public int? Rating { get; set; }

        public int? UserID { get; set; }

        public DateTime? TimeStamp { get; set; }
        public int AuctionID { get; set; }

        public int EntityID { get; set; }

        public int RecordID { get; set; }
        public virtual List<Product> Product { get; set; }

    }
}
