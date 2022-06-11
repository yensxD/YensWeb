using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yens.DataAccess.Data;
using Yens.DataAccess.Repository.IRepository;

namespace Yens.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AplicationDbContext _db;
        public UnitOfWork(AplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FootTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IFoodTypeRepository FoodType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }

        public void Disponse() {
            _db.Dispose();
        }
        public void Save(){
            _db.SaveChanges();
        }

    }
}
