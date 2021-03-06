﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductsService.Helpers;
using ProductsService.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController
    {
        static IList<ProductModel> _productsList = DataMock.MockProductsList();
        static IList<ClientModel> _clientsList = DataMock.MockClientsList();
        static IList<OrderModel> _ordersList = new List<OrderModel>()
        {
            new OrderModel()
            {
                ID = 1,
                Client = _clientsList.Single(x => x.ID == 1),
                PurchasedProductsList = new List<ProductModel>()
                {
                    _productsList.Single(x => x.ID == 1),
                    _productsList.Single(x => x.ID == 2)
                },
                OrderPrice = 0.0m
            },
            new OrderModel()
            {
                ID = 2,
                Client = _clientsList.Single(x => x.ID == 2),
                PurchasedProductsList = new List<ProductModel>()
                {
                    _productsList.Single(x => x.ID == 3),
                    _productsList.Single(x => x.ID == 4),
                    _productsList.Single(x => x.ID == 5),
                    _productsList.Single(x => x.ID == 6)
                },
                OrderPrice = 0.0m
            },
            new OrderModel()
            {
                ID = 3,
                Client = _clientsList.Single(x => x.ID == 3),
                PurchasedProductsList = new List<ProductModel>()
                {
                    _productsList.Single(x => x.ID == 1),
                    _productsList.Single(x => x.ID == 2),
                    _productsList.Single(x => x.ID == 3),
                    _productsList.Single(x => x.ID == 4),
                    _productsList.Single(x => x.ID == 5),
                    _productsList.Single(x => x.ID == 6)
                },
                OrderPrice = 0.0m
            }
        };

        public OrdersController()
        {
            foreach(OrderModel order in _ordersList)
            {
                CalculateFinalOrderPrice(order);
            }
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<OrderModel> GetAllOrders()
        {
            return _ordersList;
        }

        [HttpGet]
        [Route("list/{id}")]
        public IEnumerable<OrderModel> GetOrderByClientId(int id)
        {
            return _ordersList.Where(x => x.Client.ID == id);
        }
        
        [HttpPost]
        [Route("add")]
        public OrderModel AddOrderForClient(AddOrderModel order)
        {
            OrderModel addedOrder = new OrderModel()
            {
                ID = _ordersList.Max(x => x.ID) + 1,
                Client = _clientsList.Single(x => x.ID == order.ClientID),
                PurchasedProductsList = _productsList.Where(x => order.PurchasedProductsIDs.Contains(x.ID)).ToList(),
                OrderPrice = 0.0m
            };
            CalculateFinalOrderPrice(addedOrder);
            _ordersList.Add(addedOrder);
            return addedOrder;
        }

        private static void CalculateFinalOrderPrice(OrderModel order)
        {
            string url = "https://localhost:44341/api/price/calculate";
            string json = JsonConvert.SerializeObject(order.PurchasedProductsList);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync(url, data).GetAwaiter().GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string calculatedPrice = response.Content.ReadAsStringAsync().Result;
                try
                {
                    decimal finalPrice = Convert.ToDecimal(calculatedPrice, CultureInfo.InvariantCulture);
                    order.OrderPrice = finalPrice;
                }
                catch
                {
                    order.OrderPrice = 0.0m;
                }
            }
            else
            {
                order.OrderPrice = 0.0m;
            }
        }
    }
}
