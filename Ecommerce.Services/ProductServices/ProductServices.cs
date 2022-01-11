
using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
   public class ProductServices
    {
        EcommerceContext db = new EcommerceContext();
        public void SaveProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void SaveMostView(MostView mostView)
        {
            db.MostViews.Add(mostView);
            db.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return db.Products.ToList();
        }

        public List<Product> GetMaxOrderQuantity()
        {
            var topProductsIds = db.OrderItems // table with a row for each view of a product
            .GroupBy(x => x.ProductID) //group all rows with same product id together
            .OrderByDescending(g => g.Count()) // move products with highest views to the top
            .Take(5) // take top 5
            .Select(g => g.FirstOrDefault().Product)
            .ToList(); // execute query and convert it to a list

            //var topProducts = db.Products // table with products information
            //    .Where(x => topProductsIds.Contains(x.ID)).ToList(); // get info of products that their Ids are retrieved in previous query
            return topProductsIds;
        }

        public Product GetProductByID(int ID)
        {
            return db.Products.Find(ID);
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = db.Products.Find(product.ID);
            db.ProductPictures.RemoveRange(existingProduct.ProductPictures);
            db.Entry(existingProduct).CurrentValues.SetValues(product);
            db.ProductPictures.AddRange(product.ProductPictures);
            return db.SaveChanges() > 0;
        }

        public List<Product> GetAllHotDealProduct()
        {
            var hotProduct = db.Products.Where(x => x.IsFlashSale).Take(2).ToList();
            return hotProduct;
        }

        public List<Product> CategoryWiseNineProduct(int categoryID)
        {
            var productList = db.Products.Where(product => product.CategoryID == categoryID).ToList();
            return productList;
        }
        public List<Product> ManufactureWiseProduct(int manufactureID)
        {
            var productList = db.Products.Where(product => product.ManufacturerID == manufactureID).ToList();
            return productList;
        }

        public List<Product> GetProductByIDs(List<int> productIDs)
        {
            return productIDs.Select(id => db.Products.Find(id)).ToList();
        }

        public List<Product> GetFeaturedProduct()
        {
            var productList = db.Products.Where(product => product.IsFeatured==true).ToList();
            return productList;
        }

        public List<Product> SearchProduct(string searchTerm, int? manufactureID, int? minimum, int? maximum)
        {

            var products = db.Products.ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(x => x.ProductName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            if (manufactureID.HasValue && manufactureID.Value>0)
            {
                products = products.Where(x => x.ManufacturerID == manufactureID).ToList();
            }

            if (minimum.HasValue && minimum.Value>0)
            {
                products = products.Where(x => x.ProductSalePrice >= minimum.Value).ToList();
            }
            if (maximum.HasValue && maximum.Value > 0)
            {
                products = products.Where(x => x.ProductSalePrice <= maximum.Value).ToList();
            }
            return products;
        }

        public List<BrandingPicture> GetAllBrand()
        {
            var brandList = db.BrandPictures.ToList();
            return brandList;
        }

        public int GetMinimumPrice()
        {
            var minimumPrice = db.Products.Min(x => x.ProductSalePrice);
            var miniMumprice = decimal.ToInt32(minimumPrice);
            return miniMumprice;
        }
        public int GetMaximumPrice()
        {
            var maximumPrice = db.Products.Max(x => x.ProductSalePrice);
            var maxiMumprice = decimal.ToInt32(maximumPrice);
            return maxiMumprice;
        }

        public List<Product> GetLatestProduct()
        {
            var latestProduct = db.Products.OrderByDescending(x => x.ID).ToList();
            return latestProduct;
        }

        public List<Product> GetMostViewProduct()
        {
            var topProductsIds = db.MostViews // table with a row for each view of a product
           .GroupBy(x => x.ProductID) //group all rows with same product id together
           .OrderByDescending(g => g.Count()) // move products with highest views to the top
           .Take(8) // take top 5
           .Select(g => g.FirstOrDefault().Product) 
           .ToList(); // execute query and convert it to a list

            //var topProducts = db.Products // table with products information
            //    .Where(x => topProductsIds.Contains(x.ID)).ToList(); // get info of products that their Ids are retrieved in previous query
            return topProductsIds;
        }

        public List<Product> GetProduct(List<int> productIds)
        {
            return db.Products.Where(product => productIds.Contains(product.ID)).ToList();
        }
    }
}
