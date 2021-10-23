using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buildlease.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buildlease.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {
        [HttpPost("GetAllCategories")]
        public CaregoryView[] GetAllCategories()
        {
            return new CaregoryView[]
            {
                new()
                {
                    Id = 0,
                    ParentId = 0,
                    Name = "Все",
                    ProductCount = 600
                },
                new()
                {
                    Id = 2,
                    ParentId = 0,
                    Name = "Зубные щётки",
                    ProductCount = 500
                },
                new()
                {
                    Id = 42,
                    ParentId = 2,
                    Name = "Электрические",
                    ProductCount = 400
                },
                new()
                {
                    Id = 10,
                    ParentId = 0,
                    Name = "Отвёртки",
                    ProductCount = 300
                },
                new()
                {
                    Id = 3,
                    ParentId = 2,
                    Name = "Механические",
                    ProductCount = 200
                },
            };
        }

        [HttpPost("GetCategoryFilters/{categoryId}")]
        public CategoryFilterView[] GetCategoryFilters([FromRoute] int categoryId)
        {
            return new CategoryFilterView[]
            {
                new()
                {
                    Id = 0,
                    Name = "Все",
                    UnitName = ""
                },
                new()
                {
                    Id = 2,
                    Name = "Зубные щётки",
                },
                new()
                {
                    Id = 42,
                    Name = "Электрические",
                },
                new()
                {
                    Id = 10,
                    Name = "Отвёртки",
                },
                new()
                {
                    Id = 3,
                    Name = "Механические",
                },
            };
        }

        [HttpPost("GetProducts")]
        public ProductView[] GetProducts()
        {
            return new ProductView[]
            {
                new()
                {
                    Id = 69,
                    Name = "SCP-1876 - Личная зубная щётка",
                },
                new()
                {
                    Id = 2,
                    Name = "Tooth-Brush™ с алмазным напылением",
                },
                new()
                {
                    Id = 13,
                    Name = "Красная отвёртка",
                },
                new()
                {
                    Id = 42,
                    Name = "Синяя отвёртка",
                },
                new()
                {
                    Id = 1,
                    Name = "Зелёная отвёртка",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    ImagePath = "wwwroot/static/products/1.jpg",
                    AvalableCount = 42,
                    Price = 690.42M,
                    AlreadyInCart = true
                }
            };
        }

        [HttpPost("GetProduct/{productId}")]
        public ProductFullView GetProduct([FromRoute] int productId)
        {
            return new ProductFullView
            {
                Id = 1,
                Name = "Зелёная отвёртка",
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                ImagePath = "wwwroot/static/products/1.jpg",
                Count = 500,
                AvalableCount = 42,
                CountInCart = 500-42,
                Price = 220M,
                Attributes = new ProductAttributeView[]
                {
                    new()
                    {
                        Name = "Обороты",
                        Value = "5000"
                    },
                    new()
                    {
                        Name = "Длина",
                        Value = "27см"
                    },
                    new()
                    {
                        Name = "Металл",
                        Value = "Смесь Росомахи и Капитана Америки"
                    },
                }
            };
        }

        [HttpPost("GetMyOrders")]
        public OrderView[] GetMyOrders()
        {
            return new OrderView[]
            {
                new ()
                {
                    Id = 13,
                    Status = 1,
                    OrderAcceptDate = DateTime.Now,
                    ProductCount = 500,
                    Price = 123M
                },
                new ()
                {
                    Id = 23,
                    Status = 2,
                    OrderAcceptDate = DateTime.Now,
                    ProductCount = 500,
                    Price = 123M
                },
                new ()
                {
                    Id = 69,
                    Status = 3,
                    OrderAcceptDate = DateTime.Now,
                    ProductCount = 500,
                    Price = 123M
                },
            };
        }

        [HttpPost("GetOrder/{orderId}")]
        public OrderFullView GetOrder([FromRoute] int orderId)
        {
            return new OrderFullView
            {
                Id = 1,
                OrderAcceptDate = DateTime.Now,
                Status = 1,
                Price = 500M,
                ProductOrders = new ProductOrderView[]
                {
                    new()
                    {
                        Name = "Зубная щётка",
                        ImagePath = "wwwroot/static/products/1.jpg",
                        Count = 11,
                        Price = 220M,
                    },
                    new()
                    {
                        Name = "SMTHNGRND",
                        ImagePath = "wwwroot/static/products/2.jpg",
                        Count = 22,
                        Price = 280M,
                    }
                }
            };
        }

        [HttpPost("GetMyCart")]
        public CartFullView GetMyCart()
        {
            return new CartFullView()
            {
                Price = 500M,
                ProductOrders = new ProductOrderView[]
                {
                    new()
                    {
                        Name = "Зубная щётка",
                        ImagePath = "wwwroot/static/products/1.jpg",
                        Count = 11,
                        Price = 220M,
                    },
                    new()
                    {
                        Name = "SMTHNGRND",
                        ImagePath = "wwwroot/static/products/2.jpg",
                        Count = 22,
                        Price = 280M,
                    }
                }
            };
        }
    }
}
