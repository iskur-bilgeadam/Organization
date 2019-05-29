using Organization.DAL;
using Organization.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.BLL
{
   public class UserBLL
    {
        DataContext db = new DataContext();
        public List<Users> GetUsers()
        {
            return db.Users.ToList();
        }

        public Users GetUser(string email)
        {
            return db.Users.FirstOrDefault(x=>x.E_mail==email);
        }

        public void AddUser(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
