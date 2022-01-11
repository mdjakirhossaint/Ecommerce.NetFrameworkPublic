using Ecommerce.Data;
using Ecommerce.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.UserType
{
    public class UserTypeController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        UserServices userService = new UserServices();
        // GET: UserType
        public ActionResult Index()
        {
            var userlist = userService.GetAllUserType();
            ViewBag.userList = userlist;
            return View();
        }
        public ActionResult AddUserType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUserType(Ecommerce.Entities.UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.UserTypes.Add(userType);
                db.SaveChanges();
            }
            return View(userType);
        }
    }
}