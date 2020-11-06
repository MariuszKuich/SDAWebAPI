using ProductsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsService.Helpers
{
    public class DataMock
    {
        public static List<ProductModel> MockProductsList()
        {
            return new List<ProductModel>()
            {
                new ProductModel()
                {
                    ID = 1,
                    Name = "Michelin Tyre",
                    Price = 450.0m,
                    Color = "Black",
                    IBAN = "SE3550000000054910000003"
                },
                new ProductModel()
                {
                    ID = 2,
                    Name = "Lego Bricks",
                    Price = 110.0m,
                    Color = "Yellow",
                    IBAN = "DK9520000123456789"
                },
                new ProductModel()
                {
                    ID = 3,
                    Name = "ANZIO Steel Rim",
                    Price = 270.0m,
                    Color = "Silver",
                    IBAN = "HU93116000060000000012345676"
                },
                new ProductModel()
                {
                    ID = 4,
                    Name = "Samsung TV",
                    Price = 1400.0m,
                    Color = "Gray",
                    IBAN = "GB33BUKB20201555555555"
                },
                new ProductModel()
                {
                    ID = 5,
                    Name = "Tea Cup",
                    Price = 15.0m,
                    Color = "Blue",
                    IBAN = "PL10105000997603123456789123"
                },
                new ProductModel()
                {
                    ID = 6,
                    Name = "Novox Microphone",
                    Price = 200.0m,
                    Color = "Green",
                    IBAN = "FI1410093000123458"
                }
            };
        }

        public static List<ClientModel> MockClientsList()
        {
            return new List<ClientModel>()
            {
                new ClientModel()
                {
                    ID = 1,
                    Name = "Jan Kowalski",
                    Address = new AddressModel()
                    {
                        City = "Bydgoszcz",
                        PostCode = "85-435",
                        StreetName = "Wielorybia"
                    },
                    NIP = "104392593"
                },
                new ClientModel()
                {
                    ID = 2,
                    Name = "Adam Nowak",
                    Address = new AddressModel()
                    {
                        City = "Gdańsk",
                        PostCode = "33-465",
                        StreetName = "Morska"
                    },
                    NIP = "782539912"
                },
                new ClientModel()
                {
                    ID = 3,
                    Name = "Piotr Adamczyk",
                    Address = new AddressModel()
                    {
                        City = "Wrocław",
                        PostCode = "75-174",
                        StreetName = "Górska"
                    },
                    NIP = "835184092"
                }
            };
        }

        public static string GenerateIBan()
        {
            string generatedIBAN = string.Empty;
            string[] contryCodes = new string[] { "PL", "GB", "DE", "UK", "CZ", "SK", "IT", "ES" };
            Random random = new Random();
            int randomIndex = random.Next(contryCodes.Length);
            generatedIBAN += contryCodes[randomIndex];
            for(int i = 0; i < 15; i++)
            {
                generatedIBAN += random.Next(10);
            }
            return generatedIBAN;
        }
    }
}
