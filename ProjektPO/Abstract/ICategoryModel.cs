using ProjektPO.Entity;
using ProjektPO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Abstract
{
    public interface ICategoryModel
    {
        void AddCategory(CategoryViewModel categoryViewModel, int userId);        
        void DeleteCategory(int categoryId);
        void EditCategory(CategoryViewModel categoryViewModel);
        void ReadCategory(string categoryId);
        void DeleteCategoryItem();     
        void AddCategoryItem();
        void ReadCategoryItems(CategoryEntity category);

    }
}
