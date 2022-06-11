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
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        private readonly AplicationDbContext _db;
        public CategoryRepository(AplicationDbContext db): base(db)
        {
            _db = db;
        }
        
        public void Update(Category category)
        {
            var objFromdb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            objFromdb.Name = category.Name;
            objFromdb.DisplayOrder = category.DisplayOrder;
        }
    }
}
