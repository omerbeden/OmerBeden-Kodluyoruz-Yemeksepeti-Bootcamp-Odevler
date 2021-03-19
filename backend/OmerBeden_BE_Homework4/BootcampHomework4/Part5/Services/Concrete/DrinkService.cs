using System.Collections.Generic;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Services.Abstract;

namespace Part5.Services.Concrete
{
    public class DrinkService : IDrinkService
    {
        private IDrinkRepository _drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public List<Drink> GetAll()
        {
            return _drinkRepository.GetAll();
        }

        public Drink GetById(int id)
        {
            return _drinkRepository.GetById(id);
        }

        public void Add(Drink drink)
        {
            _drinkRepository.Add(drink);
        }

        public void Delete(Drink drink)
        {
            _drinkRepository.Delete(drink);
        }

        public void Update(int id,Drink drink)
        {
            _drinkRepository.Update(id,drink);
        }
    }
}