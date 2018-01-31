using ProjektPO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class UserModel: IUserModel
    {

        public bool Register()
        {
            return true;
        }

        public bool Login()
        {
            return true;
        }

        public void Logout()
        {

        }

        public void Edit_Username()
        {

        }

        public void Edit_Password()
        {

        }

        public void Delete_Account()
        {

        }
    }
}
