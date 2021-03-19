using Part5.Data.Entities;

namespace Part5.Data.Repositories.EntityFramework.Abstract
{
    public interface IFoodRepository : IReadRepository<Food>, IWriteRepository<Food>
    {
    }
}