using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Part2.Data.Contexts;
using Part2.Data.Entities;
using Part2.Data.Responses;
using Part2.Services.Abstract;

namespace Part2.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private DatabaseContext _databaseContext;

        public CategoryService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<CategoryResponse> GetCategories()
        {
            var categories =  _databaseContext.Categories.ToList();
            var responses = categories.Adapt<List<CategoryResponse>>();
            return responses;
        }
    }
}
