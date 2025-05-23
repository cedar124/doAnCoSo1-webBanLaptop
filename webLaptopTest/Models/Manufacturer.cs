﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webLaptopTest.Data.Base;

namespace webLaptopTest.Models
{
    public class Manufacturer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Manufacturer Name")]
        [Required(ErrorMessage = "Manufacturer Name is required")]
        public string Name { get; set; }
    }
}
