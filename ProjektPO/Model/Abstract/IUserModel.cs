using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model.Abstract
{
    public interface IUserModel
    {
        void Register();
        void Login();
        void Logout();
        void Edit();
        void Delete();
    }
}
