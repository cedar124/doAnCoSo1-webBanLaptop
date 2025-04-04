using System.Collections.Generic;

namespace webLaptopTest.Data.ViewModels
{
    public class EditOrderStatusVM
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public List<string> AvailableStatuses { get; set; } = new();
    }
}
