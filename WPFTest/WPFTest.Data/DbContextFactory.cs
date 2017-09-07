using System.Data.Common;
using System.Data.Entity;
using WPFTest.Infraestructure.UoW;

namespace WPFTest.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            _context = new WpfTestEntities();
            _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbContextFactory(DbConnection db)
        {
            _context = new WpfTestEntities(db);
            _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }
}
