
namespace ProjektPO.Abstract
{
    public interface IUserModel
    {
        bool Register();
        bool Login();
        void Logout();
        void Edit_Username();
        void Edit_Password();
        void Delete_Account();
    }
}
