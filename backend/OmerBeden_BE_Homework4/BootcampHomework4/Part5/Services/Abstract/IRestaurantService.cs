using System.Collections.Generic;
using Part5.Data.Entities;

namespace Part5.Services.Abstract
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAll();
        Restaurant GetById(int id);

        void Add(Restaurant restaurant);

        void Delete(Restaurant restaurant);

        void Update(int id,Restaurant restaurant);
    }
}