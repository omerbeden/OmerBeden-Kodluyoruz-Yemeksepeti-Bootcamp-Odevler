using System.Collections.Generic;
using System.Data;
using Part5.Data.Entities;

namespace Part5.Services.Abstract
{
    public interface IFoodService
    {
        List<Food> GetAll();
        Food GetById(int id);

        void Add(Food food);

        void Delete(Food food);

        void Update(int id,Food food);
    }
}