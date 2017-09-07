namespace WPFTest.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        void Detach(TEntity entity);
    }
}
