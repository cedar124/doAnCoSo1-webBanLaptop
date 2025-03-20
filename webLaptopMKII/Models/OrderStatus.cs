using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webLaptopMKII.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        [Required]
        public int StatusId { get; set; }

        [Required, MaxLength(255)]
        public string? StatusName { get; set; }
    }
}
