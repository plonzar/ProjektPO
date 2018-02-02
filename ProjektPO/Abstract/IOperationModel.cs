using ProjektPO.Entity;
using ProjektPO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Abstract
{
    public interface IOperationModel
    {
<<<<<<< HEAD
        void AddOperation(OperationViewModel newOperation, int userId);
=======
        void AddOperation(OperationViewModel newOperation, int userId, int categoryId);
>>>>>>> origin/Wojciech_Skwarun
        List<OperationViewModel> GetList(int userId);
        void Update(OperationViewModel operation);
        void Delete(int operatonId);
    }
}
