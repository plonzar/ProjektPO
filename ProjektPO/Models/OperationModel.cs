using ProjektPO.Entity;
using ProjektPO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektPO.ViewModels;

namespace ProjektPO.Models
{
<<<<<<< HEAD
    public class OperationModel : IOperationModel//heheszki_2
    {
        private ApplicationDB appContext = new ApplicationDB();
        public void AddOperation(OperationViewModel newOperationViewModel, int userId)// 
        {
=======
    public class OperationModel: IOperationModel
    public class OperationModel : IOperationModel//2
    {
        public void AddOperation(Action newOperation)
        private ApplicationDB appContext = new ApplicationDB();
        public void AddOperation(OperationViewModel newOperationViewModel, int userId)
        {

>>>>>>> origin/stage
            if (newOperationViewModel != null)
            {
                OperationEntity newOperation = new OperationEntity()
                {
                    UserEntityId = userId,
                    Note = newOperationViewModel.Note,
                    Type = newOperationViewModel.Type,
                    Amount = newOperationViewModel.Amount,
                    Id = newOperationViewModel.Id,
                    Date = newOperationViewModel.Date,
                    CategoryItemEntityId = newOperationViewModel.OperationCategory.CategoryEntityId,
                    CategoryItem = newOperationViewModel.OperationCategory
                };
                appContext.Operations.Add(newOperation);
            }
            appContext.SaveChanges();
        }

<<<<<<< HEAD
        public List<OperationViewModel> GetList(int userId)//  -> zwraca list<operationviewmodel>
        {
=======
        public List<OperationEntity> GetList()
        public List<OperationViewModel> GetList(int userId)//  -> zwraca list<operationviewmodel>
        {
            List<OperationEntity> temp = new List<OperationEntity>();
>>>>>>> origin/stage
            List<OperationViewModel> viewModelsList = new List<OperationViewModel>();
            var entitiesList = appContext.Operations
                                 .Where(o => o.UserEntityId == userId)
                                 .ToList();

<<<<<<< HEAD
            foreach(var entity in entitiesList)
=======
            foreach (var entity in entitiesList)
>>>>>>> origin/stage
            {
                viewModelsList.Add(new OperationViewModel()
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    Amount = entity.Amount,
                    OperationCategory = entity.CategoryItem,
                    Type = entity.Type,
                    UserId = entity.UserEntityId.ToString(),
                    Note = entity.Note
<<<<<<< HEAD
                } );
            }

            return viewModelsList;
        }

        public void Update(OperationViewModel updatedOperation)//operation view model
=======
                });
            }

            return temp;
            return viewModelsList;
        }

        public void Update(Action newOperation)
        public void Update(OperationViewModel updatedOperation)
>>>>>>> origin/stage
        {
            var updatedEntity = appContext.Operations.Find(updatedOperation.Id);

            updatedEntity.Id = updatedOperation.Id;
            updatedEntity.Date = updatedOperation.Date;
            updatedEntity.Amount = updatedOperation.Amount;
            updatedEntity.CategoryItem = updatedOperation.OperationCategory;
            updatedEntity.Type = updatedOperation.Type;
            updatedEntity.Note = updatedOperation.Note;
            updatedEntity.UserEntityId = int.Parse(updatedOperation.UserId);

            appContext.SaveChanges();
        }

<<<<<<< HEAD
=======
        public void Delete()
>>>>>>> origin/stage
        public void Delete(int operationId)
        {
            var deletedOperation = appContext.Operations.Find(operationId);
            appContext.Operations.Remove(deletedOperation);

            appContext.SaveChanges();
        }
    }
}
