using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part5.Data.Entities;

namespace Part5.Data.Repositories.EntityFramework.Abstract
{
    public interface IRestaurantRepository:IReadRepository<Restaurant>,IWriteRepository<Restaurant>
    {
    }
}
