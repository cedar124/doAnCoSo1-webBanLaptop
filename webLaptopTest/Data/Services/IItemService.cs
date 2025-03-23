using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webLaptopTest.Data.Base;
using webLaptopTest.Data.ViewModels;
using webLaptopTest.Models;

namespace webLaptopTest.Data.Services
{
    public interface IItemService:IEntityBaseRepository<Item>
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<NewItemDropdownsVM> GetNewItemDropdownsValues();
        Task AddNewItemAsync(NewItemVM data);
        Task UpdateItemAsync(NewItemVM data);
    }
}
