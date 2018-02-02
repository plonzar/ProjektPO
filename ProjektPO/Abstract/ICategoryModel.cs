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
        bool AddCategory(CategoryViewModel categoryViewModel, int userId);        
        bool DeleteCategory(int categoryId, int userId);
        bool EditCategory(CategoryViewModel categoryViewModel, string newName, int userId);
        CategoryViewModel ReadCategory(string categoryName, int userId);
<<<<<<< HEAD

        bool DeleteCategoryItem(int categoryId, int userId);     

        bool DeleteCategoryItem(string categoryItemName, int userId);     

=======
        bool DeleteCategoryItem(string categoryItemName, int categoryId, int userId);     
>>>>>>> origin/Wojciech_Skwarun
        bool AddCategoryItem(CategoryItemViewModel categoryItemViewModel, int categoryId,int userId);
        List<CategoryItemViewModel> ReadCategoryItems(int categoryId);

    }
}
