using webLaptopTest.Data.Base;
using webLaptopTest.Models;

namespace webLaptopTest.Data.Services
{
    public class ManufacturerService: EntityBaseRepository<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
