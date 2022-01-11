using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Models.Category
{
    public class CreateCategoryModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryPictures { get; set; }
        public bool Status { get; set; }


        public List<CategoryPicture> CategoryPictureList { get; set; }
    }
}