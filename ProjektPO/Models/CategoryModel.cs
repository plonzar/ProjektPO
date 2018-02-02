using ProjektPO.Entity;
using ProjektPO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using ProjektPO.ViewModels;
using ProjektPO.Model;

namespace ProjektPO.Models
{
    public class CategoryModel//: ICategoryModel
    {
        private ApplicationDB appContext = new ApplicationDB();

        public bool AddCategory(CategoryViewModel categoryViewModel, int userId)
        {
            if (categoryViewModel != null && 
               !string.IsNullOrEmpty(categoryViewModel.Name)&&
               !appContext.Categories.Where( u => u.UserEntityId == userId).Any( n => n.Name == categoryViewModel.Name))
            {
                CategoryEntity categoryEntity = new CategoryEntity()
                {

                    Id = categoryViewModel.Id,
                    UserEntityId = userId,
                    Name = categoryViewModel.Name,
<<<<<<< HEAD
                    Categories = categoryViewModel.CategoryItems.ToList()

                    //UserEntityId = userId,
                    //Name = categoryViewModel.Name,
                    //Categories = categoryViewModel.CategoryItems

=======
                    Categories = new List<CategoryItemEntity>()
>>>>>>> origin/Wojciech_Skwarun
                };
                appContext.Categories.Add(categoryEntity);
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool AddCategoryItem(CategoryItemViewModel categoryItemViewModel, int categoryId, int userId)
        {
            if (categoryItemViewModel != null &&
                !string.IsNullOrEmpty(categoryItemViewModel.Name) &&
                !appContext.CategoryItems.Where(c => c.CategoryEntityId == categoryId).Any(ci => ci.Name == categoryItemViewModel.Name))
            {
                var categoryItem = new CategoryItemEntity()
                {
                    UserEntityId = userId,
                    Name = categoryItemViewModel.Name,
                    CategoryEntityId = categoryId,
                    IncludeInEstimates = true,
                };
                appContext.CategoryItems.Add(categoryItem);
                appContext.Categories.Find(categoryId).Categories.Add(categoryItem);
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
                
            
        }

        public bool DeleteCategory(int categoryId, int userId)//             /nie działa
        {

            if (appContext.Categories.Where( c => c.UserEntityId == userId).Any( c => c.Id == categoryId))
            {
                var deletedCategoryItems = appContext.CategoryItems.Where(c => c.CategoryEntityId == categoryId).ToList();
                foreach(var item in deletedCategoryItems)
<<<<<<< HEAD
                {
                    

                    DeleteCategoryItem(item.Id.ToString(), userId);

                    DeleteCategoryItem(item.Name, userId);

=======
                {                    
                    DeleteCategoryItem(item.Name, categoryId, userId);
>>>>>>> origin/Wojciech_Skwarun
                }
                appContext.SaveChanges();
                var deletedCategory = appContext.Categories.Where(c => c.UserEntityId == userId).FirstOrDefault( c => c.Id == categoryId);
                appContext.Categories.Remove(deletedCategory);
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
                
        }

<<<<<<< HEAD

        public bool DeleteCategoryItem(string categoryItemName, int userId)
        {
            if(appContext.CategoryItems.Where( u => u.UserEntityId == userId).Any( i => i.Name == categoryItemName))
            {
                var deletedCategoryItem = appContext.CategoryItems.FirstOrDefault(u => u.UserEntityId == userId && u.Name == categoryItemName);

=======
        public bool DeleteCategoryItem(string categoryItemName, int categoryId, int userId)
        {
            if(appContext.CategoryItems.Where( u => u.UserEntityId == userId).Any( i => i.Name == categoryItemName))
            {
                var deletedCategoryItem = appContext.CategoryItems.FirstOrDefault(u => (u.UserEntityId == userId) && (u.Name == categoryItemName) && (u.CategoryEntityId == categoryId));
                var operationsToDelete = appContext.Operations.Where(x => x.UserEntityId == userId && x.CategoryItemEntityId == deletedCategoryItem.Id).ToList();
                foreach (var operation in operationsToDelete)
                {
                    appContext.Operations.Remove(operation);
                }
>>>>>>> origin/Wojciech_Skwarun
                appContext.CategoryItems.Remove(deletedCategoryItem);
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditCategory(CategoryViewModel categoryViewModel, string newName, int userId)
        {
            if (categoryViewModel != null &&
               !string.IsNullOrEmpty(categoryViewModel.Name) &&
               appContext.Categories.FirstOrDefault(u => u.UserEntityId == userId && u.Name == newName) == null)
            {
                var editedCategory = appContext.Categories.FirstOrDefault(u => u.Name == categoryViewModel.Name);
                editedCategory.Name = newName;
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public CategoryViewModel ReadCategory(string categoryName, int userId)
        {
            var categoryEntity = appContext.Categories.Where(n => n.Name == categoryName).FirstOrDefault(u => u.UserEntityId == userId);
            if(categoryEntity != null)
            {
                var categoryViewModel = new CategoryViewModel()
                {
                    Id = categoryEntity.Id,
                    Name = categoryEntity.Name,
                    UserId = categoryEntity.UserEntityId.ToString(),
                    CategoryItems = appContext.CategoryItems
                                              .Where(c => c.CategoryEntityId == categoryEntity.Id)
                                              .Where(u => u.UserEntityId == userId)
                                              .ToList()
            };
                return categoryViewModel;
            }
            else
            {
                return null;
            }
            
        }

        public List<CategoryItemViewModel> ReadCategoryItems(int categoryId)
        {
            List<CategoryItemViewModel> viewModelsList = new List<CategoryItemViewModel>();
            var entitiesList = appContext.CategoryItems.Where(c => c.CategoryEntityId == categoryId).ToList();
            foreach(var entity in entitiesList)
            {
                var categoryViewModel = new CategoryItemViewModel()
                {
                    Id = entity.Id,
                    CategoryId = entity.CategoryEntityId,
                    Name = entity.Name,

                    IncludeInEstimates = entity.IncludeInEstimates

                    
                };
                viewModelsList.Add(categoryViewModel);
            }
            return viewModelsList;
        }
    }
}
