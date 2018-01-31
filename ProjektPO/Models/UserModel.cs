using ProjektPO.Abstract;
using ProjektPO.Entity;
using ProjektPO.ViewModels;
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

        public bool Register(UserViewModel user)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.FirstOrDefault(x => x.Name == user.Name);
            if (dbEntry == null)
            {
                var userEntity = new UserEntity
                {
                    Name = user.Name,
                    Password = user.Password
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

        public bool Login(UserViewModel user)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
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
            var categories = _context.Categories.ToList();
            var categoryItems = _context.CategoryItems.ToList();
            var operations = _context.Operations.ToList();
            foreach (var category in categories)
            {
                if (category.UserEntityId == dbEntry.Id)
                {
                    foreach (var categoryItem in categoryItems)
                    {
                        if (categoryItem.UserEntityId == dbEntry.Id && categoryItem.CategoryEntityId == category.Id)
                        {
                            foreach (var operation in operations)
                            {
                                if (operation.UserEntityId == dbEntry.Id && operation.CategoryItemEntityId == categoryItem.Id)
                                {
                                    _context.Operations.Remove(operation);
                                }
                            }
                            _context.CategoryItems.Remove(categoryItem);
                        }
                    }
                    _context.Categories.Remove(category);
                }
            }
            _context.Users.Remove(dbEntry);
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
