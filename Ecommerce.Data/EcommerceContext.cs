
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("name=Ecommerce")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Religious> Religiouses { get; set; }
        public DbSet<Nationility> Nationilities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Branding> Brands { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<BrandingPicture> BrandPictures { get; set; }
        public DbSet<CategoryPicture> CategoryPictures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderPicture> SliderPictures { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductProductSize> ProductProductSizes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SignUpLetter> SignUpLetters { get; set; }
        public DbSet<SecoundBannerPicture> SecoundBannerPictures { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }
        public DbSet<SecoundBanner> SecoundBanners { get; set; }
        public DbSet<BannerPicture> BannerPictures { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPicture> BlogPictures { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MostView> MostViews { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
        public DbSet<WishListProduct> WishListProducts { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        public DbSet<SubCategoryPicture> SubCategoryPictures { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorPicture> VendorPictures { get; set; }
        public DbSet<CurrentBalance> CurrentBalances { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
    }
}

