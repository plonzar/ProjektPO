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
        void AddOperation(Action newOperation);
        List<OperationEntity> GetList();
        void Update(Action action);
        void Delete();
        void AddOperation(OperationViewModel newOperation, int userId);
        List<OperationViewModel> GetList(int userId);
        void Update(OperationViewModel operation);
        void Delete(int operatonId);
    }
}
