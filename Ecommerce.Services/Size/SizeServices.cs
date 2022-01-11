using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Size
{
    public class SizeServices
    {
        EcommerceContext db = new EcommerceContext();
        public void SaveSize(ProductSize productsize)
        {
            db.ProductSizes.Add(productsize);
            db.SaveChanges();
        }
        public ProductSize GetProductSizeByID(int ID)
        {
            return db.ProductSizes.Find(ID);
        }
        public List<ProductSize> GetProductSizeByIDs(List<int> IDs)
        {
            return IDs.Select(id => db.ProductSizes.Find(id)).ToList();
        }
        public List<ProductSize> GetProductSize(List<int> IDs)
        {
            return db.ProductSizes.Where(ProductSize => IDs.Contains(ProductSize.ID)).ToList();
        }
        public List<ProductSize> GetAllProductSize()
        {
            return db.ProductSizes.ToList();
        }
        public void UpdateAuction(ProductSize  productSize)
        {
            //var existingProduct = db.ProductSizes.Find(productSize.ID);
            //db.ProductProductSizes.RemoveRange(existingProduct.AuctionPictures);
            //context.Entry(existingProduct).CurrentValues.SetValues(auction);
            //context.AuctionPictures.AddRange(auction.AuctionPictures);
            //return context.SaveChanges() > 0;
            db.Entry(productSize).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }
        public void DeleteAuction(ProductSize productSize)
        {
            db.Entry(productSize).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
        //public List<ProductSize> SearchAuctions(int? categoryID, string searchTerm, int? pageNo, int pageSize)
        //{
        //    var auctions = db.ProductSizes.AsQueryable();

        //    if (categoryID.HasValue && categoryID.Value > 0)
        //    {
        //        auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
        //    }

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
        //    }

        //    pageNo = pageNo ?? 1;
        //    // pageNo = pageNo.HasValue ? pageNo.Value : 1;

        //    var skipCount = (pageNo.Value - 1) * pageSize;

        //    return auctions.OrderByDescending(x => x.CategoryID).Skip(skipCount).Take(pageSize).ToList();
        //}
        //public int GetAuctionsCount(int? categoryID, string searchTerm)
        //{
        //    var auctions = context.Auctions.AsQueryable();

        //    if (categoryID.HasValue && categoryID.Value > 0)
        //    {
        //        auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
        //    }

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        auctions = auctions.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
        //    }
        //    return auctions.Count();
        //}
        //public List<Auction> SearchAuctionsByCategory(int? categoryID)
        //{
        //    var auctions = context.Auctions.AsQueryable();

        //    if (categoryID.HasValue && categoryID.Value > 0)
        //    {
        //        auctions = auctions.Where(x => x.CategoryID == categoryID.Value);
        //    }
        //    return auctions.OrderByDescending(x => x.CategoryID).ToList();
        //}
    }
}
