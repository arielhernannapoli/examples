using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WPFTest.Data.Interfaces;

namespace WPFTest.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;

        public BaseRepository()
        {
            _context = new WpfTestEntities();
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
