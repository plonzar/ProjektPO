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
        void AddOperation(OperationEntity newOperation);
        List<OperationEntity> GetList(UserEntity user);
        void Update(OperationEntity operation);
        void Delete();
    }
}
