using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week1Homework1.Data;
using Week1Homework1.Entity;

namespace Week1Homework1.Data_Access
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
