using System.ComponentModel.DataAnnotations;

namespace ProductsService.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string IBAN { get; set; }
    }
}
