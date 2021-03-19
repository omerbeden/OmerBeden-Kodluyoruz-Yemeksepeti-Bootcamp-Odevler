using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part5.Data.Entities;
using Part5.Data.Repositories.EntityFramework.Abstract;
using Part5.Services.Abstract;

namespace Part5.Services.Concrete
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetById(id);
        }

        public void Add(Menu menu)
        {
            _menuRepository.Add(menu);
        }

        public void Delete(Menu menu)
        {
            _menuRepository.Delete(menu);
        }

        public void Update(int id,Menu menu)
        {
            _menuRepository.Update(id,menu);
        }
    }
}
