using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model.Abstract
{
    public interface ICategoryModel
    {
        void AddCategory();
        void AddCategoryItem();
        void DeleteCategory();
        void DeleteCategoryItem();
        void EditCategory();
        void ReadCategory();
        void ReadCategoryItems(CategoryEntity category);

    }
}
