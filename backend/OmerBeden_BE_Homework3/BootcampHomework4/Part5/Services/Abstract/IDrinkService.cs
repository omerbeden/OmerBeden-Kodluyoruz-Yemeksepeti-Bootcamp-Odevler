using System.Collections.Generic;
using Part5.Data.Entities;

namespace Part5.Services.Abstract
{
    public interface IDrinkService
    {
        List<Drink> GetAll();
        Drink GetById(int id);

        void Add(Drink drink);

        void Delete(Drink drink);

        void Update(int id,Drink drink);
    }
}