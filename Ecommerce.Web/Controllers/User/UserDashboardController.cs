using Ecommerce.Data;
using Ecommerce.Entities;
using Ecommerce.Service;
using Ecommerce.Services.BrandService;
using Ecommerce.Services.Comment;
using Ecommerce.Services.Order;
using Ecommerce.Services.UserServices;
using Ecommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.User
{
    public class UserDashboardController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        CommentServices commentServices = new CommentServices();
        CategoryServices categoryServices = new CategoryServices();
        BrandServices brandServices = new BrandServices();
        UserServices userServices = new UserServices();
        ProductServices productServices = new ProductServices();
        OrderServices orderServices = new OrderServices();
        // GET: UserDashboard
        public ActionResult Index(int ID)
        {
            var id = ID;

            LayoutViewModel model = new LayoutViewModel();
            var category = categoryServices.GetNineCategory();
            ViewBag.NineCategory = category;
            model.Branding = brandServices.GetAllBrand();
            return View(model);
        }
        public ActionResult commentsList(int ID)
        {
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);
            var user = db.Users.Where(u => u.Username == username && u.Password == password && u.UserTypeID == 4).FirstOrDefault();

            if (user==null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else {
                var category = categoryServices.GetNineCategory();
                ViewBag.NineCategory = category;
                CommentListViwModel model = new CommentListViwModel();
                model.Branding = brandServices.GetAllBrand();
                //model.Comments = commentServices.GetAllCommentByUserID(ID);
                model.User = userServices.GetUserByID(ID);
                    if (model.User != null)
                    {
                        model.Comments = commentServices.GetCommentsByUser(ID, (int)EntityEnums.Product);

                        if (model.Comments != null && model.Comments.Count > 0)
                        {
                            var productIDs = model.Comments.Select(x => x.RecordID).ToList();

                            model.Products = productServices.GetProductByIDs(productIDs);
                        }
                        //model.userRoles = model.User.Roles.Select(userRole => model.AvailableRoles.FirstOrDefault(role => role.Id == userRole.RoleId)).ToList();
                    }
                return View(model);
            }
        }
        public ActionResult MyOrderList(int ID)
        {
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);
            var user = db.Users.Where(u => u.Username == username && u.Password == password && u.UserTypeID == 4).FirstOrDefault();

            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else {
                UserOrderViewModel model = new UserOrderViewModel();
                var category = categoryServices.GetNineCategory();
                ViewBag.NineCategory = category;
                model.Branding = brandServices.GetAllBrand();
                
                model.Orders = orderServices.GetAllOrderByUser(ID);


                return View(model);
            }
            
        }
    }
}