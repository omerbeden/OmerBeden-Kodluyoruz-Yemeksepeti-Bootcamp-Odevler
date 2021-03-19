using System.Collections.Generic;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Services.Abstract;

namespace Part5.Services.Concrete
{
    public class FoodService : IFoodService
    {
        private IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public List<Food> GetAll()
        {
            return _foodRepository.GetAll();
        }

        public Food GetById(int id)
        {
            return _foodRepository.GetById(id);
        }

        public void Add(Food food)
        {
            _foodRepository.Add(food);
        }

        public void Delete(Food food)
        {
            _foodRepository.Delete(food);
        }

        public void Update(int id,Food food)
        {
            _foodRepository.Update(id,food);
        }
    }
}