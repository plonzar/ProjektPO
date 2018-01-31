﻿using ProjektPO.Abstract;
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
            List<int> categoryIDs = new List<int>();
            foreach (var category in _context.Categories.Where(x => x.UserEntityId == dbEntry.Id))
            {
                categoryIDs.Add(category.Id);
            }
            List<int> categoryItemIDs = new List<int>();
            foreach (int categoryID in categoryIDs)
            {
                foreach (var categoryItem in _context.CategoryItems.Where(x => x.UserEntityId == dbEntry.Id && x.CategoryEntityId == categoryID))
                {
                    categoryItemIDs.Add(categoryItem.Id);
                }
            }
            foreach(int categoryItemID in categoryItemIDs)
            {
                foreach(var operation in _context.Operations.Where(x => x.UserEntityId == dbEntry.Id && x.CategoryItemEntityId == categoryItemID))
                {
                    _context.Operations.Remove(operation);
                }
            }
            foreach (int categoryID in categoryIDs)
            {
                foreach (var categoryItem in _context.CategoryItems.Where(x => x.UserEntityId == dbEntry.Id && x.CategoryEntityId == categoryID))
                {
                    _context.CategoryItems.Remove(categoryItem);
                }
            }
            foreach (var category in _context.Categories.Where(x => x.UserEntityId == dbEntry.Id))
            {
                _context.Categories.Remove(category);
            }
            _context.Users.Remove(dbEntry);
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
