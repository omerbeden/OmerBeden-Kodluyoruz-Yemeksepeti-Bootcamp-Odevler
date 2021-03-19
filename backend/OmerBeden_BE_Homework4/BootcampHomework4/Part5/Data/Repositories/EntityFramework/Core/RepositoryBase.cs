using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part5.Data.Contexts;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;

namespace Part5.Data.Repositories.EntityFramework.Core
{
    public class RepositoryBase<T>:IReadRepository<T>, IWriteRepository<T> where T : class, IEntity, new()
    {
        protected DatabaseContext _databaseContext;

        public RepositoryBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual void Add(T entity)
        {
            var addedEntity = _databaseContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            _databaseContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            var deletedEntity = _databaseContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _databaseContext.SaveChanges();
        }


        public virtual void Update(int id,T entity)
        {
            var deletedEntity = _databaseContext.Set<T>().Find(id);
            deletedEntity = entity;
            _databaseContext.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public virtual T  GetById(int id)
        {
            return _databaseContext.Set<T>().Find(id);
        }

    }
}
