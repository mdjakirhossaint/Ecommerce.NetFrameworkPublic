using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.UserServices
{
    public class UserServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Gender> GetAllGenders()
        {
            return db.Genders.ToList();
        }
        public List<Religious> GetAllReligious()
        {
            return db.Religiouses.ToList();
        }

        public List<UserType> GetAllUserType()
        {
            return db.UserTypes.ToList();
        }

        public User GetUserByID(int ID)
        {
            var user = db.Users.Find(ID);
            return user;
        }

        public void SaveUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

    }
}
