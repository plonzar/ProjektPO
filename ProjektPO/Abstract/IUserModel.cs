using System.Collections.Generic;
using ProjektPO.ViewModels;
namespace ProjektPO.Abstract
{
    public interface IUserModel
    {
        bool Register(UserViewModel user);
        bool Login(UserViewModel user);
        bool EditUsername(string newUsername);
        void EditPassword(string newPassword);
        void DeleteAccount();
        List<CategoryViewModel> UserCategories(int userId);
    }
}
