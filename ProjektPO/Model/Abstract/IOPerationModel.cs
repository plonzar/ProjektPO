using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model.Abstract
{
    public interface IOperationModel
    {
        void AddOperation(Action newOperation);
        List<Operation> GetList();
        void Update(Action action);
        void Delete();
    }
}
