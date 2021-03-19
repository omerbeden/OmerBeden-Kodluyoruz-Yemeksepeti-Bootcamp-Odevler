using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part5.Data.Contexts;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Data.Repositories.EntityFramework.Core;

namespace Part5.Data.Repositories.EntityFramework.Concrete
{
    public class RestaurantRepository: RepositoryBase<Restaurant>,IRestaurantRepository
    {
        public RestaurantRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(Restaurant entity)
        {
            _databaseContext.Restaurants.Add(entity);
            _databaseContext.AddRange(entity.Menus);
            _databaseContext.SaveChanges();
        }

        public override void Update(int id,Restaurant entity)
        {
            _databaseContext.Restaurants.Update(entity);
            _databaseContext.UpdateRange(entity.Menus);
            _databaseContext.SaveChanges();
        }

        public override Restaurant GetById(int id)
        {
            return _databaseContext.Restaurants.Include(r => r.Menus).SingleOrDefault(re => re.Id == id);
        }

        public override List<Restaurant> GetAll()
        {
            return _databaseContext.Restaurants.Include(r => r.Menus).ToList();
        }
    }
}
