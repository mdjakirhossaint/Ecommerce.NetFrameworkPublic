
using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
   public class CategoryServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public void GetAllCategory()
        {
             db.Categories.ToList();
        }
        public void SaveCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetNineCategory()
        {
            var category = db.Categories.Take(9).ToList();

            return category;
        }
        public List<CategoryPicture> GetAllCategoryPicture()
        {
            var category = db.CategoryPictures.ToList();

            return category;
        }
        public Category GetCategoryByID(int ID)
        {
            return db.Categories.Find(ID);
          
        }
    }
}
