using firstapi.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace firstapi.Services
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal mi_app_xamarinContext context;
        internal DbSet<TEntity> dbset;
        public BaseRepository(mi_app_xamarinContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }
        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }
            dbset.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            TEntity entitytoDelete = dbset.Find(id);
            Delete(entitytoDelete);
        }

        public IEnumerable<TEntity> get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();

            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
            return dbset.Find(id);
        }

        public void insert(TEntity entityToInsert)
        {
            dbset.Add(entityToInsert);
        }

        public void update(TEntity entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;

        }
    }
}
