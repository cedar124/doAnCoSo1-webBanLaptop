using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webLaptopMKII.Models
{
    [Table("TableDetail")]
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
        public Item Item { get; set; }
        public  Order Order { get; set; }
    }
}
