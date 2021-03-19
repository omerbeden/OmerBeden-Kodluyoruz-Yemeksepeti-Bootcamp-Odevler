using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Part5.Data.Contexts;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Data.Repositories.EntityFramework.Core;

namespace Part5.Data.Repositories.EntityFramework.Concrete
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Add(Menu entity)
        {
            _databaseContext.Menus.Add(entity);
            _databaseContext.Drinks.AddRange(entity.Drinks);
            _databaseContext.Foods.AddRange(entity.Foods);
            _databaseContext.SaveChanges();
        }
        public override void Update(int id,Menu entity)
        {
            var updated = _databaseContext.Menus.Include(m=>m.Drinks)
                .Include(m=>m.Foods).FirstOrDefault(m=>m.Id==id);

            updated.Drinks = entity.Drinks;
            updated.Foods = entity.Foods;
            updated.Name = entity.Name;

            _databaseContext.Update(updated);
            _databaseContext.SaveChanges();
        }

        public override List<Menu> GetAll()
        {
            return _databaseContext.Menus.Include(m => m.Foods).Include(m => m.Drinks).ToList();
            
        }

        public override Menu GetById(int id)
        {
            return _databaseContext.Menus.Include(m => m.Foods).Include(m => m.Drinks)
                .FirstOrDefault(m => m.Id == id);
        }
    }
}