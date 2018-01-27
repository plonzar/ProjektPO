using ProjektPO.Entity;
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
    }
}
