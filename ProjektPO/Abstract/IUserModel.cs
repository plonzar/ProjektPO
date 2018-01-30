using ProjektPO.ViewModels;
namespace ProjektPO.Abstract
{
    public interface IUserModel
    {
        bool Register(string username, string password);
        bool Login(string username, string password);
        bool EditUsername(string newUsername);
        void EditPassword(string newPassword);
        void DeleteAccount();
    }
}
