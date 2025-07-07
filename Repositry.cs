using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry.IRepositry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.DataAccess.Repositry
{
    public class Repositry<T> : IRepositry<T> where T : class
    {
        private readonly ApplicationDbContext _Context;
        internal DbSet<T> dbset;
        public Repositry(ApplicationDbContext context)
        {
            _Context = context;
            dbset = _Context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> Filter = null, string includeproperties = null)
        {
            IQueryable<T> query = dbset;
            if (Filter != null)
                query = query.Where(Filter);
            if(includeproperties!=null)
            {
                foreach(var includeProp in includeproperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string includeproperties = null)
        {
            IQueryable<T> query = dbset;
            if (Filter != null)
                query = query.Where(Filter);
            if (includeproperties!=null)
            {
                foreach(var includeProp in includeproperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (OrderBy != null)
                return OrderBy(query).ToList();
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void Remove(int id)
        {
            dbset.Remove(Get(id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _Context.ChangeTracker.Clear();
            dbset.Update(entity);
        }
    }
}
