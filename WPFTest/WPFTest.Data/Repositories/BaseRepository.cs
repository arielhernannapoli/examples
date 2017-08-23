using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using WPFTest.Data.Interfaces;
using WPFTest.Infraestructure.UoW;

namespace WPFTest.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;

        public BaseRepository(IUnitOfWork uow)
        {
            _context = uow.Context;
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return _context.Set<TEntity>().SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query)
        {
            return _context.Set<TEntity>().SqlQuery(query).ToList();
        }

        public virtual int ExecuteSqlCommand(string command)
        {
            object[] args = new object[0];
            return _context.Database.ExecuteSqlCommand(command, args);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
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

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entityToDelete);
            }
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public void Detach(TEntity entity)
        {
            var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
            objectContext.Detach(entity);
        }

        public TEntity GetByID(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _context.Set<TEntity>().Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
