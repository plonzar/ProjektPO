using ProjektPO.Entity;
using ProjektPO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using ProjektPO.ViewModels;

namespace ProjektPO.Models
{
    public class CategoryModel: ICategoryModel
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
                    Categories = categoryViewModel.CategoryItems.ToList()
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
                };
                appContext.CategoryItems.Add(categoryItem);
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
                
            
        }

        {
            if (appContext.Categories.Where( c => c.UserEntityId == userId).Any( c => c.Id == categoryId))
            {
                var deletedCategoryItems = appContext.CategoryItems.Where(c => c.CategoryEntityId == categoryId).ToList();MessageBox.Show(deletedCategoryItems.Count().ToString());
                foreach(var item in deletedCategoryItems)
                {
                    
                    DeleteCategoryItem(item.Id, userId);
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

        public bool DeleteCategoryItem(int categoryItemId, int userId)
        {
            if(appContext.CategoryItems.Where( u => u.UserEntityId == userId).Any( i => i.Id == categoryItemId))
            {
                var deletedCategoryItem = appContext.CategoryItems.Find(categoryItemId);
                MessageBox.Show("test");
                appContext.CategoryItems.Remove(deletedCategoryItem);
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditCategory(CategoryViewModel categoryViewModel, int userId)
        {
               !string.IsNullOrEmpty(categoryViewModel.Name) &&
               appContext.Categories.Where(u => u.UserEntityId == userId).Any(i => i.Id == categoryViewModel.Id))
            {
                var editedCategory = appContext.Categories.Find(categoryViewModel.Id);
                editedCategory.Name = categoryViewModel.Name;
                appContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            return true;
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
