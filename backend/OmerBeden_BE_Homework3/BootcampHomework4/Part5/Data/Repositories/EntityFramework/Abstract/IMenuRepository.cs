using Part5.Data.Entities;

namespace Part5.Data.Repositories.EntityFramework.Abstract
{
    public interface IMenuRepository : IReadRepository<Menu>, IWriteRepository<Menu>
    {
    }
}