using webLaptopTest.Data.Base;
using webLaptopTest.Models;

namespace webLaptopTest.Data.Services
{
    public class CategoryService:EntityBaseRepository<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
