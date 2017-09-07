using System.Data.Entity;

namespace WPFTest.Infraestructure.UoW
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
