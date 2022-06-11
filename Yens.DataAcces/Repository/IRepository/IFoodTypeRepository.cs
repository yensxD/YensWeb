using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yens.Models;

namespace Yens.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository:IRepository<FoodType>
    {
        void Update(FoodType obj);
    }
}
