using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part5.Data.Entities;

namespace Part5.Data.Repositories.EntityFramework.Abstract
{
    public interface IReadRepository<T> where  T:class,IEntity,new()
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
