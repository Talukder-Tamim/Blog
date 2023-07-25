using Blog.Database;
using Blog.Models.EntityModels;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class UserRepository
    {
        ApplicationDbContext _db;

        public UserRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool Add(Users user)
        {
            _db.Users.Add(user);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Users user)
        {
            _db.Users.Update(user);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Users user)
        {
            _db.Users.Remove(user);
            return _db.SaveChanges() > 0;
        }

        public ICollection<Users> GetAll()
        {
            return _db.Users.ToList();
        }

        public Users GetByID(int id)
        {
            return _db.Users.FirstOrDefault(c => c.Id == id);
        }

        public Users GetByEmail(string email)
        {
            return _db.Users.FirstOrDefault(c => c.email == email);
        }

        public Users GetByEmailAndPass(string email, string password) 
        {
            return _db.Users.Where(b => b.email == email && b.password == password).FirstOrDefault();
        }
    }
}
