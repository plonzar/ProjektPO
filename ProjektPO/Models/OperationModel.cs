﻿using ProjektPO.Entity;
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
    public class OperationModel : IOperationModel//heheszki_1
    {
        private ApplicationDB appContext = new ApplicationDB();
        public void AddOperation(OperationViewModel newOperationViewModel, int userId)// 
        {
            if (newOperationViewModel != null)
            {
                OperationEntity newOperation = new OperationEntity()
                {
                    Id = newOperationViewModel.Id,
                    Date = newOperationViewModel.Date,
                    Amount = newOperationViewModel.Amount,
                    CategoryItemEntityId = newOperationViewModel.OperationCategory.Id,
                    CategoryItem = newOperationViewModel.OperationCategory,
                    Type = newOperationViewModel.Type,
                    Note = newOperationViewModel.Note,
                    UserEntityId = userId
                };
                appContext.Operations.Add(newOperation);
            }
            appContext.SaveChanges();
        }

        public List<OperationViewModel> GetList(int userId)//  -> zwraca list<operationviewmodel>
        {
            List<OperationViewModel> viewModelsList = new List<OperationViewModel>();
            var entitiesList = appContext.Operations
                                 .Where(o => o.UserEntityId == userId)
                                 .ToList();

            foreach(var entity in entitiesList)
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
                } );
            }

            return viewModelsList;
        }

        public void Update(OperationViewModel updatedOperation)//operation view model
        {
            var updatedEntity = appContext.Operations.Find(updatedOperation.Id);

            updatedEntity.Id = updatedOperation.Id;
            updatedEntity.Date = updatedOperation.Date;
            updatedEntity.Amount = updatedOperation.Amount;
            updatedEntity.CategoryItemEntityId = updatedOperation.OperationCategory.Id;
            updatedEntity.CategoryItem = updatedOperation.OperationCategory;
            updatedEntity.Type = updatedOperation.Type;
            updatedEntity.Note = updatedOperation.Note;
            updatedEntity.UserEntityId = int.Parse(updatedOperation.UserId);

            appContext.SaveChanges();
        }

        public void Delete(int operationId)
        {
            var deletedOperation = appContext.Operations.Find(operationId);
            appContext.Operations.Remove(deletedOperation);

            appContext.SaveChanges();
        }
    }
}
