using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yens.DataAccess.Data;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace Yens.DataAccess.Repository
{
    public class FootTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly AplicationDbContext _db;
        public FootTypeRepository(AplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(FoodType obj)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
        }
    }
}
