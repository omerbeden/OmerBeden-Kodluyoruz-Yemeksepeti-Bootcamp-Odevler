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
    public class WriteRepositoryBase <T>:IWriteRepository<T> where T : class, IEntity, new()
    {
        private DatabaseContext _databaseContext;

        public WriteRepositoryBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(T entity)
        {
            var addedEntity = _databaseContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            _databaseContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            var deletedEntity = _databaseContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _databaseContext.SaveChanges();
        }


        public void Update(int id,T entity)
        {
            var deletedEntity = _databaseContext.Set<T>().Find(id);
            deletedEntity = entity;
            _databaseContext.SaveChanges();
        }
    }
}
