using System.ComponentModel.DataAnnotations;

namespace ProductsService.Models
{
    public class AddressModel
    {
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Address: Field City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Address: Field PostCode is required")]
        public string PostCode { get; set; }
    }
}
