using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class DbManager //Klasa, która jest dostępem do bazy danych i zawiera metody, które są uniwersalne (dodawanie, usuwanie, edycja) i się powtarzają
    {
        private ApplicationDB context = new ApplicationDB();

        public IEnumerable<Category> categories
        {
            get { return context.Categories; }
        }

        public IEnumerable<Operation> operations
        {
            get { return context.Operations; }
        }

        public IEnumerable<CategoryItem> categoryItems
        {
            get { return context.CategoryItems; }
        }

        public IEnumerable<User> users
        {
            get { return context.Users; }
        }

        //Category

        public void AddOrEditCategory(Category category)
        {
            if (category != null)
            {
                if (category.Id == 0)
                {
                    context.Categories.Add(category);
                }
                else
                {
                    var actual = context.Categories.Find(category.Id);

                    if(actual != null)
                    {
                        context.Entry(actual).CurrentValues.SetValues(category);
                    }
                }
                context.SaveChanges();
            }
        }

        public void DeleteCategory(Category category)
        {
            if(category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        //User

        public void AddOrEditUser(User user)
        {
            if (user != null)
            {
                if (user.Id == 0)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    var actual = context.Users.Find(user.Id);

                    if (actual != null)
                    {
                        context.Entry(actual).CurrentValues.SetValues(user);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void DeleteUser(User user)
        {
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        //Operation

        public void AddOrEditOperation(Operation operation)
        {
            if (operation != null)
            {
                if (operation.Id == 0)
                {
                    context.Operations.Add(operation);
                    context.SaveChanges();
                }
                else
                {
                    var actual = context.Operations.Find(operation.Id);

                    if (actual != null)
                    {
                        context.Entry(actual).CurrentValues.SetValues(operation);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void DeleteOperation(Operation operation)
        {
            if (operation != null)
            {
                context.Operations.Remove(operation);
                context.SaveChanges();
            }
        }


        //CategoryItems


        public void AddOrEditCategoryItems(CategoryItem categoryItem)
        {
            if (categoryItem != null)
            {
                if (categoryItem.CategoryId == 0)
                {
                    context.CategoryItems.Add(categoryItem);
                    context.SaveChanges();
                }
                else
                {
                    var actual = context.CategoryItems.Find(categoryItem.CategoryId);

                    if (actual != null)
                    {
                        context.Entry(actual).CurrentValues.SetValues(categoryItem);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void DeleteCategoryItem(CategoryItem categoryItem)
        {
            if (categoryItem != null)
            {
                context.CategoryItems.Remove(categoryItem);
                context.SaveChanges();
            }
        }
    }
}
