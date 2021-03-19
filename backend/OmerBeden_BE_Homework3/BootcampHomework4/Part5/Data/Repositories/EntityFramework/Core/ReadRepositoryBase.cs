using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part5.Data.Contexts;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;

namespace Part5.Data.Repositories.EntityFramework.Core
{
    public class ReadRepositoryBase<T>:IReadRepository<T> where T : class, IEntity, new()
    {
        private DatabaseContext _databaseContext;

        public ReadRepositoryBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<T> GetAll()
        {
           return  _databaseContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _databaseContext.Set<T>().Find(id);
        }
    }
}
