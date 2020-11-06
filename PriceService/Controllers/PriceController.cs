using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceService.Controllers
{
    [ApiController]
    [Route("api/price")]
    public class PriceController
    {
        [HttpPost]
        [Route("calculate")]
        public decimal GetFinalOrderPrice([FromBody] IList<ProductModel> productsList)
        {
            decimal finalPrice = 0.0m;
            foreach(ProductModel product in productsList)
            {
                finalPrice += product.Price;
            }
            if(productsList.Count > 2)
            {
                finalPrice *= 0.9m;
            }
            return finalPrice;
        }
    }
}
