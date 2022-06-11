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
    public class MenuItemRepository: Repository<MenuItem>, IMenuItemRepository
    {
        private readonly AplicationDbContext _db;
        public MenuItemRepository(AplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(MenuItem obj)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(x => x.Id == obj.Id);
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.FootTypeId = obj.FootTypeId;
            if (!string.IsNullOrEmpty(objFromDb.Image)) {
                objFromDb.Image = obj.Image;
            }
        }
    }
}
