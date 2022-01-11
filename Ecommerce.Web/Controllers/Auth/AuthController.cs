using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Auth
{
    public class AuthController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var customer = db.Users.Where(u => u.Username == username && u.Password == password && u.UserTypeID == 4).FirstOrDefault();
            var admin = db.Users.Where(user => user.Username == username && user.Password == password && user.UserTypeID==1).FirstOrDefault();
            
            if (admin != null || customer != null)
            {
                if (admin != null)
                {
                    Session["ID"] = admin.ID;
                    Session["UserTypeID"] = admin.UserTypeID;
                    Session["FirstName"] = admin.FirstName;
                    Session["LastName"] = admin.LastName;
                    Session["Username"] = admin.Username;
                    Session["Password"] = admin.Password;
                    Session["Email"] = admin.EmailAddress;

                    return RedirectToAction("Index", "AdminDashboard", new { id = Session["ID"] });
                }
                if (customer != null)
                {
                    Session["ID"] = customer.ID;
                    Session["UserType_ID"] = customer.UserTypeID;
                    Session["FirstName"] = customer.FirstName;
                    Session["LastName"] = customer.LastName;
                    Session["Username"] = customer.Username;
                    Session["Password"] = customer.Password;

                    return RedirectToAction("Index", "UserDashboard", new { id = Session["ID"] });
                }
            }
            else
            {

                ViewBag.message = "Username or Password is incorrect !";


            }

            Session["ID"] = string.Empty;
            Session["UserType_ID"] = string.Empty;
            Session["GenderName"] = string.Empty;
            Session["FullName"] = string.Empty;
            Session["Username"] = string.Empty;

            ViewBag.message = "Username or Password is incorrect !";
            return View();
        }
        public ActionResult Logout()
        {

            Session["ID"] = string.Empty;
            Session["UserType_ID"] = string.Empty;
            Session["GenderName"] = string.Empty;
            Session["FullName"] = string.Empty;
            Session["Username"] = string.Empty;

            return RedirectToAction("Login");
        }
    }
}