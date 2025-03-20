using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webLaptopMKII.Models
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }

        [Required, MaxLength(255)]
        public string CategoryName { get; set; }
        public List<Item> Items { get; set; }
    }
}
