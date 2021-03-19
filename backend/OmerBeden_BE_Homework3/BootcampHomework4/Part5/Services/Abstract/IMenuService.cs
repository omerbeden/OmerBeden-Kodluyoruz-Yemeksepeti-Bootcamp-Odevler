using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part5.Data.Entities;

namespace Part5.Services.Abstract
{
    public interface IMenuService
    {
        List<Menu> GetAll();
        Menu GetById(int id);

        void Add(Menu Menu);

        void Delete(Menu menu);

        void Update(int id,Menu menu);
    }
}
