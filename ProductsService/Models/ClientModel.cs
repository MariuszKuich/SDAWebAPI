using System.ComponentModel.DataAnnotations;

namespace ProductsService.Models
{
    public class ClientModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Client: Field Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Client: Field Address is required")]
        public AddressModel Address { get; set; }
        [Required(ErrorMessage = "Client: Field NIP is required")]
        public string NIP { get; set; }
    }
}
