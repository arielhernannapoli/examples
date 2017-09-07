using WPFTest.Data;
using WPFTest.Infraestructure.UoW;

namespace WPFTest.Services
{
    public abstract class GenericService
    {
        protected readonly IUnitOfWork _uow;

        public GenericService()
        {
            IDbContextFactory factory = new DbContextFactory();
            _uow = new UnitOfWork(factory);
        }

    }
}
