using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class CategoryListingViwModel : LayoutViewModel
    {
        public virtual List<Category> Categories { get; set; }
        public int CategoryID { get; set; }
        public virtual List<CategoryPicture> CategoryPictures { get; set; }
    }
}