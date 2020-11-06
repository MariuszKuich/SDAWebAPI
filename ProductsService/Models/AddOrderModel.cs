using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductsService.Models
{
    public class AddOrderModel
    {
        [Required(ErrorMessage = "Order: Field ClientID is required")]
        public int ClientID { get; set; }
        [Required(ErrorMessage = "Order: Field ProductsIDs is required")]
        public IList<int> PurchasedProductsIDs { get; set; }
    }
}
