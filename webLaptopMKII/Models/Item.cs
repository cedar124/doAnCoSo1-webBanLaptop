using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webLaptopMKII.Models
{
    [Table("Item")]
    public class Item
    {
        public int ItemId { get; set; }

        [Required, MaxLength(255)]
        public string? ItemName { get; set; }
        public  string? ItemDescription { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }
        public string?  ImgUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
    }
}
