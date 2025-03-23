using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webLaptopTest.Data.Base;

namespace webLaptopTest.Models
{
    public class Item:IEntityBase
    {
        [Required, Key, Display(Name = "Item Id")]
        public int Id { get; set; }

        [Required, Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string imgUrl { get; set; }

        [Display(Name = "Image2")]
        public string imgUrl2 { get; set; }

        [Required, Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required, Display(Name = "Stock")]
        public int Stock { get; set; }

        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
