using System.Data.Entity;

namespace WPFTest.Infraestructure.UoW
{
    public interface IUnitOfWork
    {
        void SaveChanges(int? idUsuario);

        DbContext Context { get; }
    }
}
