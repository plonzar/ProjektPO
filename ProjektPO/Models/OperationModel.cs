using ProjektPO.Entity;
using ProjektPO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Models
{
    public class OperationModel: IOperationModel
    {
        public void AddOperation(Action newOperation)
        {

        }

        public List<OperationEntity> GetList()
        {
            List<OperationEntity> temp = new List<OperationEntity>();

            return temp;
        }

        public void Update(Action newOperation)
        {

        }

        public void Delete()
        {

        }
    }
}
