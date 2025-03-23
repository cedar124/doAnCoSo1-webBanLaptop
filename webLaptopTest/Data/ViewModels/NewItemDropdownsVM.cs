using System.Collections.Generic;
using webLaptopTest.Models;

namespace webLaptopTest.Data.ViewModels
{
    public class NewItemDropdownsVM
    {
        public NewItemDropdownsVM()
        {
            Manufacturer = new List<Manufacturer>();
            Category = new List<Category>();
        }

        public List<Manufacturer> Manufacturer { get; set; }
        public List<Category> Category { get; set; }
    }
}
