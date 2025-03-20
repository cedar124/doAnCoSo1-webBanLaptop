using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webLaptopMKII.Models
{
    [Table("Order")]
    public class Order
    {
        public int  OrderId { get; set; }

        [Required]
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int  OrderStatusId { get; set; }
        public  bool IsDeleted { get; set; } = false;
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

    }
}
