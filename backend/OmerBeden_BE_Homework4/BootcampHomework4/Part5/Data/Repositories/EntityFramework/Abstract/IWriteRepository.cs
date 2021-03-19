using Part5.Data.Entities;

namespace Part5.Data.Repositories.EntityFramework.Abstract
{
    public interface IWriteRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(int id,T entity);
    }
}