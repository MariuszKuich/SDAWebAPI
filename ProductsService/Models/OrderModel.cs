using System.Collections.Generic;

namespace ProductsService.Models
{
    public class OrderModel
    {
        public ClientModel Client { get; set; }
        public IList<ProductModel> PurchasedProductsList { get; set; }
        public decimal OrderPrice { get; set; }
    }
}
