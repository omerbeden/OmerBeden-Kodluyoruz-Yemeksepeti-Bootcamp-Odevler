using System.Collections.Generic;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Services.Abstract;

namespace Part5.Services.Concrete
{
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }

        public Restaurant GetById(int id)
        {
            return _restaurantRepository.GetById(id);
        }

        public void Add(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

        public void Delete(Restaurant restaurant)
        {
            _restaurantRepository.Delete(restaurant);
        }

        public void Update(int id,Restaurant restaurant)
        {
            _restaurantRepository.Update(id,restaurant);
        }
    }
}