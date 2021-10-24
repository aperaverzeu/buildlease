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
                    ProductCount = 733
                },
                new()
                {
                    Id = 2,
                    ParentId = 0,
                    Name = "Зубные щётки",
                    ProductCount = 123
                },
                new()
                {
                    Id = 42,
                    ParentId = 2,
                    Name = "Электрические",
                    ProductCount = 93
                },
                new()
                {
                    Id = 10,
                    ParentId = 0,
                    Name = "Отвёртки",
                    ProductCount = 62
                },
                new()
                {
                    Id = 3,
                    ParentId = 2,
                    Name = "Механические",
                    ProductCount = 362
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
                },
                new()
                {
                    Id = 2,
                    Name = "Зубные щётки",
                    Values = new string[]
                    {
                        "Деревяныые",
                        "Оловянные",
                        "Стеклянные",
                        "Графеновые"
                    }
                },
                new()
                {
                    Id = 42,
                    Name = "Электрические",
                    UnitName = "Мощность",
                    MinValue = 1,
                    MaxValue =1000
                },
                new()
                {
                    Id = 10,
                    Name = "Отвёртки",
                    Values = new string[]
                    {
                        "Батина",
                        "Дедова",
                        "Прадедова",
                        "Эргономичная"
                    }
                },
                new()
                {
                    Id = 3,
                    Name = "Механические",
                    UnitName = "Энергопотребление",
                    MinValue = 100,
                    MaxValue = 10000,
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
                    ShortDescription = "Была замечена в Берлине",
                    AvalableCount = 213,
                    Price = 1123
                },
                new()
                {
                    Id = 2,
                    Name = "Tooth-Brush™ с алмазным напылением",
                    ImagePath = "wwwroot/static/products/22.jpg",
                    AlreadyInCart = false,
                },
                new()
                {
                    Id = 13,
                    Name = "Красная отвёртка",
                    Price = 144,
                    ShortDescription = "Её прапрапрапрадеду подарил Джеймс Кук"
                },
                new()
                {
                    Id = 42,
                    Name = "Синяя отвёртка",
                    Price = 144,
                    ShortDescription = "Её прапрапрапрадеду никто не дарил"
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
                Id = productId,
                Name = "Зелёная отвёртка",
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Description = "Из колхозной молодёжи панковал один лишь я" +
                " Я носил портки из кожи и был грязный, как свинья" + 
                " Мой папанька на комбайне по три нормы делал в день" + 
                " А маманька, там, на ферме, сиськи дергаеть весь день" + 
                " Я ядрёный, как кабан" + 
                " Я имею свой баян" + 
                " Я на нём панк-рок пистоню" + 
                " Не найти во мне изъян" + 
                " Первый парень на весь край" + 
                " На меня все бабки в лай" + 
                " А-а-а-ай, ну и няхай!" + 
                " Меня батька бьёть ухватом, а маманька бьёть метлой" + 
                " Потому что на всю хату я мочу панк-рок в забой" + 
                " Меня девки презирают за мой выщип шухерной" + 
                " На меня в селе все лають, говорят: Панкрок долой!" + 
                " Я ядрёный, как кабан" + 
                " Я имею свой баян" + 
                " Я на нём панк-рок пистоню" + 
                " Не найти во мне изъян" + 
                " Первый парень на весь край" + 
                " На меня все бабки в лай" + 
                " А-а-а-ай, ну и няхай! (Соло!)" + 
                " Нахрен брошу всё хозяйство и поеду в город я" + 
                " За свого меня там примуть, ведь в почёте там свинья" + 
                " Я на гвоздь повешу лапти и надену свой пянджак" + 
                " И уеду я от седа на Воронежский пятак" + 
                " Я ядрёный, как кабан" + 
                " Я имею свой баян" + 
                " Я на нём панк-рок пистоню" + 
                " Не найти во мне изъян" + 
                " Первый парень на весь край" + 
                " На меня все бабки в лай" + 
                " А-а-а-ай, ну и няхай!",
                ImagePath = "wwwroot/static/products/1.jpg",
                Count = 500,
                AvalableCount = 42,
                CountInCart = new Random().Next(0,1) == 1 ? 0 : 223,
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
                    OrderAcceptDate = new DateTime(1969, 4, 20),
                    ProductCount = 155,
                    Price = 11M
                },
                new ()
                {
                    Id = 23,
                    Status = 2,
                    OrderAcceptDate = new DateTime(2001, 11, 10),
                    ProductCount = 546,
                    Price = 155M
                },
                new ()
                {
                    Id = 69,
                    Status = 3,
                    OrderAcceptDate = DateTime.Now,
                    ProductCount = 10,
                    Price = 1334M
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
