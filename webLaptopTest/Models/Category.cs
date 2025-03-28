using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webLaptopTest.Data.Base;

namespace webLaptopTest.Models
{
    public class Category:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
    }
}
