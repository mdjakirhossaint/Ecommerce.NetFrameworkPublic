using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Models.User
{
    public class CreateUserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int ReligiousID { get; set; }
        public int UserTypeID { get; set; }
        public int GenderID { get; set; }
        public List<Religious> Religious { get; set; }
        public List<Gender> Genders { get; set; }
        public List<UserType> UserTypes { get; set; }
        public UserType UserType { get; set; }
    }
}