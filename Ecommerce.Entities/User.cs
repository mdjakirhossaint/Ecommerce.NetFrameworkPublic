using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required.")]
        [Phone(ErrorMessage = "Please Enter Your Mobile Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2)]
        [Index("Username", IsUnique = true)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        public bool Status { get; set; }
        public Gender Gender { get; set; }
        public int GenderID { get; set; }
        public Religious Religious { get; set; }
        public int ReligiousID { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeID { get; set; }
        public virtual List<UserPicture> UserPictures { get; set; }
        public virtual List<Order> Orders { get; set; }


    }
}
