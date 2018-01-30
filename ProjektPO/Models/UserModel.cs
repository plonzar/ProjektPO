using ProjektPO.Abstract;
using ProjektPO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class UserModel: IUserModel
    {
        private ApplicationDB _context;

        public bool Register(string name, string password)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.FirstOrDefault(user => user.Name == name);
            if (dbEntry == null)
            {
                var userEntity = new UserEntity
                {
                    Name = name,
                    Password = password
                };
                _context.Users.Add(userEntity);
                _context.SaveChanges();
                _context.Dispose();
                return true;
            }
            else
            {
                _context.Dispose();
                return false;
            }
        }

        public bool Login(string name, string password)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.FirstOrDefault(user => user.Name == name && user.Password == password);
            if (dbEntry == null)
            {
                _context.Dispose();
                return false;
            }
            else
            {
                App.Current.Properties["loggedUserID"] = dbEntry.Id;
                _context.Dispose();
                return true;
            }
        }

        public bool EditUsername(string newUsername)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.FirstOrDefault(user => user.Name == newUsername);
            if (dbEntry != null)
            {
                _context.Dispose();
                return false;
            }
            else
            {
                dbEntry = _context.Users.Find((int)App.Current.Properties["loggedUserID"]);
                dbEntry.Name = newUsername;
                _context.SaveChanges();
                _context.Dispose();
                return true;
            }
        }

        public void EditPassword(string newPassword)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.Find((int)App.Current.Properties["loggedUserID"]);
            dbEntry.Password = newPassword;
            _context.SaveChanges();
            _context.Dispose();
        }

        public void DeleteAccount()
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.Find((int)App.Current.Properties["loggedUserID"]);
            _context.Users.Remove(dbEntry);
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
