using Part5.Data.Contexts;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Data.Repositories.EntityFramework.Core;

namespace Part5.Data.Repositories.EntityFramework.Concrete
{
    public class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}