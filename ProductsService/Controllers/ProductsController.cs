using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Helpers;
using ProductsService.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController
    {
        static IList<ProductModel> _productsList = DataMock.MockProductsList();

        [HttpGet]
        [Route("list")]
        [Authorize]
        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _productsList;
        }

        [HttpPost]
        [Route("add")]
        public ProductModel AddNewProduct(AddProductModel product)
        {
            ProductModel addedProduct = new ProductModel()
            {
                ID = _productsList.Max(x => x.ID) + 1,
                Name = product.Name,
                Price = product.Price,
                Color = product.Color,
                IBAN = DataMock.GenerateIBan()
            };
            _productsList.Add(addedProduct);
            return addedProduct;
        }
    }
}
