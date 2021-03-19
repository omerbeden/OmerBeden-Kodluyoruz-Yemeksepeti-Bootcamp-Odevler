using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week1Homework1.Entity;

namespace Week1Homework1.Data
{
    public interface IEntityRepository<T> where T: class, IEntity ,new()
    {
        T Get(int id);
        List<T> GetList();
        void Add(T entity);
        void Update(int id,T entity);
        void Delete(int id);


    }
}
