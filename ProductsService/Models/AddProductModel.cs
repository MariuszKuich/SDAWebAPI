using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsService.Models
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Product: Field Name is required")]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Product: Field Price should be greater than 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product: Field Color is required")]
        public string Color { get; set; }
    }
}
