using System.ComponentModel.DataAnnotations;

namespace webLaptopTest.Models
{
    public class NewItemVM
    {
        public int Id { get; set; }

        [Display(Name = "Item name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Item description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Required")]
        public int Stock { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Display(Name = "Item img URL")]
        [Required(ErrorMessage = "Required")]
        public string imgUrl { get; set; }
        public string imgUrl2 { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }

        [Display(Name = "Select a Manufacturer")]
        [Required(ErrorMessage = "Required")]
        public int ManufacturerId { get; set; }
    }
}
