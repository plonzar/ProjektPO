using ProjektPO.Entity;
using ProjektPO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Models
{
    public class OperationModel: IOperationModel
    {
        private ApplicationDB appContext = new ApplicationDB();
        public void AddOperation(OperationEntity newOperation)
        {
            if (newOperation != null)
                appContext.Operations.Add(newOperation);

            appContext.SaveChanges();
        }

        public List<OperationEntity> GetList(UserEntity user)
        {
            var list = appContext.Operations
                                 .Where(o => o.UserEntityId == user.Id)//spytać się czy to to samo id
                                 .ToList();
            return list;
        }

        public void Update(OperationEntity newOperation)
        {
            var operation = appContext.Operations.Find(newOperation.Id);

            operation.UserEntityId = newOperation.UserEntityId;
            operation.UserEntity = newOperation.UserEntity;
            operation.Amount = newOperation.Amount;
            //operation.Date = newOperation.Date;
            operation.Amount = newOperation.Amount;
            operation.CategoryItemEntityId = newOperation.CategoryItemEntityId;
            operation.CategoryItem = newOperation.CategoryItem;
            operation.Type = newOperation.Type;
            operation.Note = newOperation.Note;

            appContext.SaveChanges();
        }

        public void Delete()
        {

        }
    }
}
