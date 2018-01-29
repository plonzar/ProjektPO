
namespace ProjektPO.Abstract
{
    public interface IUserModel
    {
        void Register();
        void Login();
        bool Register();
        bool Login();
        void Logout();
        void Edit();
        void Delete();
        void Edit_Username();
        void Edit_Password();
        void Delete_Account();
    }
}
