using ProjektPO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektPO.Models;
using ProjektPO.Entity;

namespace ProjektPO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
            ApplicationDB db = new ApplicationDB();
            OperationModel operationModel = new OperationModel();

            
            OperationEntity operation1 = new OperationEntity();
            UserEntity user = new UserEntity();
            CategoryItemEntity categoryItem  = new CategoryItemEntity();
            CategoryEntity category = new CategoryEntity();

            operation1.Id = 6;

            user.Id = 10;
            user.Name = "piotreq";
            user.Password = "123";
            db.Users.Add(user);
            /*
                        categoryItem.Id = 0;
                        categoryItem.UserEntityId = user.Id;
                        categoryItem.UserEntity = user;
                        categoryItem.Name = "katIt";
                        categoryItem.CategoryEntityId = 0;
                        categoryItem.CategoryEntity = category;
                        categoryItem.IncludeInEstimates = true;
                        db.CategoryItems.Add(categoryItem);

                        category.Id = 0;
                        category.UserEntityId = user.Id;
                        category.UserEntity = user;
                        category.Name = "kat";
                        category.Categories[0] = categoryItem;
                        db.Categories.Add(category);


                        db.SaveChanges();

                        operation1.Id = 1;
                        operation1.UserEntityId = user.Id;
                        operation1.UserEntity = user;
                        operation1.Date = DateTime.Now;
                        operation1.Amount = 2.5M;
                        operation1.CategoryItemEntityId = 1;
                        operation1.CategoryItem = categoryItem;
                        operation1.Type = Enums.OperationType.Income;
                        operation1.Note = "heheszki";



                        operationModel.AddOperation(operation1);

                        var operation = operationModel.GetList(user);*/
            
            OperationEntity op = db.Operations.Find(operation1.Id);

            op.Note = "hewfbnwe";

            operationModel.Update(op);
            var operationList = operationModel.GetList(user);
            for(int i = 0; i<operationList.Count; ++i)MessageBox.Show(operationList[i].Note);
               // message += operationList[i].Id;

            
        }

       
    }
}
