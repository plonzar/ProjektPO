using ProjektPO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public bool Login()
        {
            var user = new UserModel();
            return user.Login(this.Name, this.Password);
        }

        public bool Register()
        {
            var user = new UserModel();
            return user.Register(this.Name, this.Password);
        }

        public bool EditUsername(string newUsername)
        {
            var user = new UserModel();
            return user.EditUsername(newUsername);
        }

        public void EditPassword(string newPassword)
        {
            var user = new UserModel();
            user.EditPassword(newPassword);
        }

        public void DeleteAccount()
        {
            var user = new UserModel();
            user.DeleteAccount();
        }
    }
}
