using Part5.Data.Entities;

namespace Part5.Data.Repositories.EntityFramework.Abstract
{
    public interface IDrinkRepository : IReadRepository<Drink>, IWriteRepository<Drink>
    {
    }
}