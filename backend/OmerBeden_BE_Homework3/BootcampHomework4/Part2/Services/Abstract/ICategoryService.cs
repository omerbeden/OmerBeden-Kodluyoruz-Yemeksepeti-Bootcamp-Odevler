using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part2.Data.Responses;

namespace Part2.Services.Abstract
{
    public interface ICategoryService
    {
        List<CategoryResponse> GetCategories();
    }
}
