using Example.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Example.Data.Repositories {

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class {

        protected DbContext _context;        

        public BaseRepository(ExampleDbEntities context)
        {
            _context = context;
        }
    }
}