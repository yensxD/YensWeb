﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yens.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IFoodTypeRepository FoodType { get; }
        IMenuItemRepository MenuItem { get; }
        void Save();
    }
}
