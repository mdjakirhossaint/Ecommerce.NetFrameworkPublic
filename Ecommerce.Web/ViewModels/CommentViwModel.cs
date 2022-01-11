using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class CommentViwModel
    {
        public string Text { get; set; }
        public int Rating { get; set; }
        public int EntityID { get; set; }
        public int RecordID { get; set; }

    }
    public class CommentListViwModel:LayoutViewModel
    {
        public virtual List<Ecommerce.Entities.Comment> Comments { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual User User { get; set; }
    }
}