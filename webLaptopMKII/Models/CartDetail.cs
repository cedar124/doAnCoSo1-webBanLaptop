using System.ComponentModel.DataAnnotations;

namespace webLaptopMKII.Models
{

    public class CartDetail
    {
        public int CartDetailId { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }
        public Item Item { get; set; }
        public Cart Cart { get; set; }
    }
}
