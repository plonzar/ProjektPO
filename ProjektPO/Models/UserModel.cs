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
            var users = _context.Users;
            if (users != null)
            {
                foreach (var user_ in users)
                {
                    if (user_.Name == user.Name)
                    {
                        return false;
                    }
                }
            }
            var userEntity = new UserEntity()
            {
                Name = user.Name,
                Password = user.Password
            };
             _context.Users.Add(userEntity);
             _context.SaveChanges();
             return true;
        }

        public bool Login(UserViewModel user)
        {
            _context = new ApplicationDB();
            var users = _context.Users;
            if (users != null)
            {
                foreach (var user_ in users)
                {
                    if (user_.Name == user.Name && user_.Password == user.Password)
                    {
                        App.Current.Properties["loggedUserID"] = user_.Id;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EditUsername(string newUsername)
        {
            _context = new ApplicationDB();
            var users = _context.Users;
            foreach (var user_ in users)
            {
                if (user_.Name == newUsername)
                {
                    return false;
                }
            }
            var dbEntry = _context.Users.Find((int)App.Current.Properties["loggedUserID"]);
            dbEntry.Name = newUsername;
            _context.SaveChanges();
            return true;
        }

        public void EditPassword(string newPassword)
        {
            _context = new ApplicationDB();
            var dbEntry = _context.Users.Find((int)App.Current.Properties["loggedUserID"]);
            dbEntry.Password = newPassword;
            _context.SaveChanges();
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
        }

        public List<CategoryViewModel> UserCategories(int userId)
        {
            _context = new ApplicationDB();
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            var categories = _context.Categories.Where(x=>x.UserEntityId == userId).ToList();
            foreach (var category in categories)
            {
                var categoryViewModel = new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    UserId = category.ToString(),
                    CategoryItems = null,
                };
                categoryViewModels.Add(categoryViewModel);
            }
            return categoryViewModels;
        }
    }
}
