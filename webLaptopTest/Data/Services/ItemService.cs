using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using webLaptopTest.Data.Base;
using webLaptopTest.Data.ViewModels;
using webLaptopTest.Models;

namespace webLaptopTest.Data.Services
{
    public class ItemService : EntityBaseRepository<Item>, IItemService
    {
        private readonly ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewItemAsync(NewItemVM data)
        {
            var NewItem = new Item()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                imgUrl = data.imgUrl,
                imgUrl2 = data.imgUrl2,
                CategoryId = data.CategoryId,
                ManufacturerId = data.ManufacturerId
            };
            await _context.Item.AddAsync(NewItem);
            await _context.SaveChangesAsync();
        }
        public async Task<Item> GetItemByIdAsync(int Id)
        {
            var movieDetails = await _context.Item.Include(c => c.Category).Include(m => m.Manufacturer).FirstOrDefaultAsync(n => n.Id == Id);
            return movieDetails;
        }
        public async Task<NewItemDropdownsVM> GetNewItemDropdownsValues()
        {
            var response = new NewItemDropdownsVM()
            {
                Category = await _context.Category.OrderBy(n => n.Name).ToListAsync(),
                Manufacturer = await _context.Manufacturer.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }
        public async Task UpdateItemAsync(NewItemVM data)
        {
            var dbItem = await _context.Item.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbItem != null)
            {
                dbItem.Name = data.Name;
                dbItem.Description = data.Description;
                dbItem.Price = data.Price;
                dbItem.imgUrl = data.imgUrl;
                dbItem.imgUrl2 = data.imgUrl2;
                dbItem.CategoryId = data.CategoryId;
                dbItem.ManufacturerId = data.ManufacturerId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
