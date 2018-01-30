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
    public class CategoryModel: ICategoryModel
    {
        private ApplicationDB appContext = new ApplicationDB();

        public void AddCategory(CategoryViewModel categoryViewModel, int userId)
        {
            if(categoryViewModel != null)
            {
                CategoryEntity categoryEntity = new CategoryEntity()
                {
                    Id = categoryViewModel.Id,
                    UserEntityId = userId,
                    Name = categoryViewModel.Name,
                    Categories = categoryViewModel.CategoryItems
                };
                appContext.Categories.Add(categoryEntity);
            }
            appContext.SaveChanges();
        }

        public void AddCategoryItem()
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategoryItem()
        {
            throw new NotImplementedException();
        }

        public void EditCategory(CategoryViewModel categoryViewModel)
        {
            throw new NotImplementedException();
        }

        public void ReadCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public void ReadCategoryItems(CategoryEntity category)
        {
            throw new NotImplementedException();
        }
    }
}
