﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yens.DataAccess.Data;
using Yens.DataAccess.Repository.IRepository;
using System.Threading.Tasks;

namespace Yens.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(AplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) {
                query = query.Where(filter);
            }
            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(includeProperty);
                }
            }

            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) {
                query = query.Where(filter);
            }
            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
