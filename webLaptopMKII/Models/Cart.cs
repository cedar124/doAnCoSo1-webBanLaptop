using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webLaptopMKII.Models
{
    [Table("Cart")]
    public class Cart
    {
        public int CartId { get; set; }

        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
