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
                    ProductCount = 0
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
                    Name = "Цена",
                    UnitName = "Тенге",
                    MinValue = 155,
                    MaxValue = 10000
                },
                new()
                {
                    Id = 2,
                    Name = "Материал",
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
                    Name = "Мощность",
                    UnitName = "Вт",
                    MinValue = 1,
                    MaxValue =1000
                },
                new()
                {
                    Id = 10,
                    Name = "Модель",
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
                    Name = "Энергопотребление",
                    UnitName = "Вт/ч",
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
                    AvalableCount = 22
                },
                new()
                {
                    Id = 13,
                    Name = "Красная отвёртка",
                    Price = 144,
                    ShortDescription = "Её прапрапрапрадеду подарил Джеймс Кук",
                    AlreadyInCart = true
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
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n" + 
                              "Из колхозной молодёжи панковал один лишь я\n" +
                              "Я носил портки из кожи и был грязный, как свинья\n" + 
                              "Мой папанька на комбайне по три нормы делал в день\n" + 
                              "А маманька, там, на ферме, сиськи дергаеть весь день\n" + 
                              "Я ядрёный, как кабан\n\n" + 
                              "Я имею свой баян\n" + 
                              "Я на нём панк-рок пистоню\n" + 
                              "Не найти во мне изъян\n" + 
                              "Первый парень на весь край\n" + 
                              "На меня все бабки в лай\n" + 
                              "А-а-а-ай, ну и няхай!\n\n" + 
                              "Меня батька бьёть ухватом, а маманька бьёть метлой\n" + 
                              "Потому что на всю хату я мочу панк-рок в забой\n" + 
                              "Меня девки презирают за мой выщип шухерной\n" + 
                              "На меня в селе все лають, говорят: Панкрок долой!\n\n" + 
                              "Я ядрёный, как кабан\n" + 
                              "Я имею свой баян\n" + 
                              "Я на нём панк-рок пистоню\n" + 
                              "Не найти во мне изъян\n" + 
                              "Первый парень на весь край\n" + 
                              "На меня все бабки в лай\n" + 
                              "А-а-а-ай, ну и няхай! (Соло!)\n\n" + 
                              "Нахрен брошу всё хозяйство и поеду в город я\n" + 
                              "За свого меня там примуть, ведь в почёте там свинья\n" + 
                              "Я на гвоздь повешу лапти и надену свой пянджак\n" + 
                              "И уеду я от седа на Воронежский пятак\n\n" + 
                              "Я ядрёный, как кабан\n" + 
                              "Я имею свой баян\n" + 
                              "Я на нём панк-рок пистоню\n" + 
                              "Не найти во мне изъян\n" + 
                              "Первый парень на весь край\n" + 
                              "На меня все бабки в лай\n" + 
                              "А-а-а-ай, ну и няхай!",
                ImagePath = "wwwroot/static/products/1.jpg",
                Count = 500,
                AvalableCount = 42,
                CountInCart = new Random().Next(0,2) == 1 ? 0 : 223,
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
