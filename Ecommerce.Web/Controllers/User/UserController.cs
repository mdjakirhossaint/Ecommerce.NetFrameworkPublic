using Ecommerce.Data;
using Ecommerce.Entities;
using Ecommerce.Services.UserServices;
using Ecommerce.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.User
{
    public class UserController : Controller
    {
        UserServices userServices = new UserServices();
        EcommerceContext db = new EcommerceContext();
        // GET: User
        public ActionResult Index()
        {
            var userList = db.Users.ToList();
            return View(userList);
        }
        public ActionResult AddUser()
        {
            CreateUserModel model = new CreateUserModel();
            model.Genders = userServices.GetAllGenders();
            model.Religious = userServices.GetAllReligious();
            //ViewBag.Genders = db.Genders.ToList();
            //ViewBag.Religious= db.Religiouses.ToList();
            ////ViewBag.UserTypes= db.UserTypes.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddUser(CreateUserModel model)
        {
            
            Ecommerce.Entities.User user = new Ecommerce.Entities.User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.EmailAddress = model.EmailAddress;
            user.Status = model.Status;
            user.GenderID = model.GenderID;
            user.ReligiousID = model.ReligiousID;
            user.UserTypeID = 4;
            user.Username = model.Username;
            user.Password = model.Password;
            user.ConfirmPassword = model.ConfirmPassword;

            userServices.SaveUser(user);
            string message = string.Empty;
            switch (user.ID)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + user.ID.ToString();
                    SendActivationEmail(user);
                    break;
            }
            ViewBag.Message = message;

            return RedirectToAction("Index");
        }
        public ActionResult Activation()
        {
            ViewBag.Message = "Invalid Activation code.";
            if (RouteData.Values["id"] != null)
            {
                Guid activationCode = new Guid(RouteData.Values["id"].ToString());
                EcommerceContext db = new EcommerceContext();
                UserActivation userActivation = db.UserActivations.Where(p => p.ActivationCode == activationCode).FirstOrDefault();
                if (userActivation != null)
                {
                    db.UserActivations.Remove(userActivation);
                    db.SaveChanges();
                    ViewBag.Message = "Activation successful.";
                }
            }

            return View();
        }
        private void SendActivationEmail(Ecommerce.Entities.User user)
        {
            Guid activationCode = Guid.NewGuid();
            EcommerceContext db = new EcommerceContext();
            db.UserActivations.Add(new UserActivation
            {
                UserID = user.ID,
                ActivationCode = activationCode
            });
            db.SaveChanges();

            using (MailMessage mm = new MailMessage("masudrana36295@gmail.com", user.EmailAddress))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + user.Username + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format("{0}://{1}/Home/Activation/{2}", Request.Url.Scheme, Request.Url.Authority, activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("masudrana36295@gmail.com", "<password>");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}