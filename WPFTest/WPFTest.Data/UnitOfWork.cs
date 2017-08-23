using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using WPFTest.Infraestructure.UoW;

namespace WPFTest.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private bool disposed = false;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
        }

        public void SaveChanges(int? idUsuario)
        {
            if (_context != null)
            {
                try
                {
                    if (_context.GetType() == typeof(WpfTestEntities))
                    {
                        //((WpfTestEntities)_context).idUsuario = idUsuario;
                    }
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {

                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }

                    throw new DbEntityValidationException("", dbEx);

                }
                catch (System.Data.DataException ex)
                {
                    throw new DbEntityValidationException("", ex.InnerException);
                }

            }
        }

        public DbContext Context
        {
            get { return _context; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
