﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Views;
using Domain.Models;
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
        public CategoryFullView[] GetAllCategories()
        {
            return new CategoryFullView[]
            {
                new()
                {
                    Id = 0,
                    ParentId = 0,
                    Name = "Все",
                    ProductCount = 733,
                    DefaultImagePath = @"https://www.meme-arsenal.com/memes/d076c825ca4c7745b32e6fa9867ff806.jpg",
                },
                new()
                {
                    Id = 2,
                    ParentId = 0,
                    Name = "Зубные щётки",
                    ProductCount = 123,
                },
                new()
                {
                    Id = 42,
                    ParentId = 2,
                    Name = "Электрические",
                    ProductCount = 0,
                },
                new()
                {
                    Id = 10,
                    ParentId = 0,
                    Name = "Отвёртки",
                    ProductCount = 62,
                    DefaultImagePath = @"https://st4.depositphotos.com/5466018/40601/v/600/depositphotos_406018700-stock-illustration-icon-flat-slotted-screwdriver-vector.jpg",
                },
                new()
                {
                    Id = 3,
                    ParentId = 2,
                    Name = "Механические",
                    ProductCount = 11,
                    DefaultImagePath = @"https://st2.depositphotos.com/1742172/10150/v/600/depositphotos_101506426-stock-illustration-black-and-white-cartoon-toothbrush.jpg",
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
                    MinValue = 155.42M,
                    MaxValue = 10000.00M,
                },
                new()
                {
                    Id = 2,
                    Name = "Материал",
                    Values = new string[]
                    {
                        "Деревянные",
                        "Оловянные",
                        "Стеклянные",
                        "Графеновые",
                    }
                },
                new()
                {
                    Id = 42,
                    Name = "Мощность",
                    UnitName = "Вт",
                    MinValue = 1,
                    MaxValue = 1000,
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
                        "Эргономичная",
                    }
                },
                new()
                {
                    Id = 3,
                    Name = "Энергопотребление",
                    UnitName = "Вт/ч",
                    MinValue = 57,
                    MaxValue = 9673,
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
                    TotalCount = 213,
                    AvailableCount = 1,
                    Price = 1123.89M,
                },
                new()
                {
                    Id = 2,
                    Name = "Tooth-Brush™ с алмазным напылением",
                    ImagePath = "wwwroot/static/products/22.jpg",
                    TotalCount = 22,
                    AvailableCount = 22,
                },
                new()
                {
                    Id = 13,
                    Name = "Красная отвёртка",
                    ShortDescription = "Её прапрапрапрадеду подарил Джеймс Кук",
                    TotalCount = 0,
                    AvailableCount = 0,
                    Price = 144,
                    AlreadyInCart = true,
                },
                new()
                {
                    Id = 42,
                    Name = "Синяя отвёртка",
                    ShortDescription = "Её прапрапрапрадеду никто не дарил",
                    TotalCount = 39,
                    AvailableCount = 0,
                    Price = 95.40M,
                },
                new()
                {
                    Id = 1,
                    Name = "Зелёная отвёртка",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    ImagePath = "wwwroot/static/products/1.jpg",
                    TotalCount = 48500,
                    AvailableCount = 4200,
                    Price = 690.42M,
                    AlreadyInCart = true,
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
                TotalCount = 500,
                AvailableCount = 42,
                Price = 220.10M,
                CountInCart = new Random().Next(2) == 1 ? 0 : 223,
                Attributes = new ProductAttributeView[]
                {
                    new()
                    {
                        Name = "Скорость вращения",
                        Value = "5000 об/мин"
                    },
                    new()
                    {
                        Name = "Длина",
                        Value = "27 см"
                    },
                    new()
                    {
                        Name = "Металл",
                        Value = "Смесь Росомахи и Капитана Америки"
                    },
                },
                CategoryPath = new CategoryView[]
                {
                    new()
                    {
                        Id = 0,
                        Name = "Все",
                    },
                    new()
                    {
                        Id = 10,
                        Name = "Отвёртки",
                    },
                    new()
                    {
                        Id = 2021,
                        Name = "Колдунские",
                    },
                },
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
                    Status = OrderStatus.Finished,
                    OrderAcceptDate = new DateTime(1969, 4, 20),
                    ProductCount = 155,
                    Price = 11.68M,
                    ProductOrders = new ProductOrderView[]
                    {
                        new()
                        {
                            Name = "Зелёная отвёртка",
                            ImagePath = "wwwroot/static/products/1.jpg",
                        },
                    },
                },
                new ()
                {
                    Id = 23,
                    Status = OrderStatus.InProcess,
                    OrderAcceptDate = new DateTime(2001, 11, 10),
                    ProductCount = 546,
                    Price = 15548.40M,
                    ProductOrders = new ProductOrderView[]
                    {
                        new()
                        {
                            Name = "Красная отвёртка",
                            ImagePath = "https://galamart.ru/images_1000/343ZCH2.jpg",
                        },
                        new()
                        {
                            Name = "Зелёная отвёртка",
                            ImagePath = "https://akl.by/media/files/products/6960/882143.jpg",
                        },
                        new()
                        {
                            Name = "Синяя отвёртка",
                            ImagePath = "https://image.galacentre.ru/size/1000/3441CH2.jpg",
                        },
                    },
                },
                new ()
                {
                    Id = 69,
                    Status = OrderStatus.WaitingForApproval,
                    OrderAcceptDate = DateTime.Now.AddMinutes(-5),
                    ProductCount = 10,
                    Price = 100M,
                    ProductOrders = new ProductOrderView[]
                    {
                        new()
                        {
                            Name = "Трактор «Беларус»",
                            ImagePath = "https://amttraktor.ru/image/cache/catalog/123/kupit-traktor-mtz-belarus-82_edited-1000x1000.jpg",
                        },
                    },
                },
            };
        }

        [HttpPost("GetOrder/{orderId}")]
        public OrderFullView GetOrder([FromRoute] int orderId)
        {
            return new OrderFullView
            {
                Id = 1,
                StatusHistory = new StatusChangeView[]
                {
                    new()
                    {
                        Date = DateTime.Now.AddMonths(-1),
                        NewStatus = OrderStatus.WaitingForApproval,
                    },
                    new()
                    {
                        Date = DateTime.Now.AddDays(-1),
                        NewStatus = OrderStatus.Approved,
                    },
                    new()
                    {
                        Date = DateTime.Now.AddHours(-1),
                        NewStatus = OrderStatus.DocumentPending,
                    },
                    new()
                    {
                        Date = DateTime.Now.AddMinutes(-1),
                        NewStatus = OrderStatus.InProcess,
                    },
                    new()
                    {
                        Date = DateTime.Now,
                        NewStatus = OrderStatus.Finished,
                    },
                },
                Status = OrderStatus.Finished,
                Price = 2759.90M,
                ProductOrders = new ProductOrderView[]
                {
                    new()
                    {
                        ProductId = 42,
                        Name = "Зубная щётка",
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        ImagePath = "wwwroot/static/products/1.jpg",
                        Count = 11,
                        Price = 22.11M,
                    },
                    new()
                    {
                        ProductId = 13,
                        Name = "Saint Tropez",
                        ShortDescription = "Car à la plage de Saint Tropez / A summer day I meet you there / I take your hand I say mon cher / And we're in love",
                        ImagePath = "https://www.kursivom.ru/wp-content/uploads/2020/11/Army_of_Lovers_20.jpg",
                        Count = 22,
                        Price = 280.00M,
                    }
                }
            };
        }

        [HttpPost("GetMyCart")]
        public CartFullView GetMyCart()
        {
            return new CartFullView()
            {
                ProductOrders = new ProductOrderView[]
                {
                    new()
                    {
                        ProductId = 42,
                        Name = "Зубная щётка",
                        ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        ImagePath = "wwwroot/static/products/1.jpg",
                        Count = 11,
                        Price = 22.11M,
                    },
                    new()
                    {
                        ProductId = 13,
                        Name = "Saint Tropez",
                        ShortDescription = "Car à la plage de Saint Tropez / A summer day I meet you there / I take your hand I say mon cher / And we're in love",
                        ImagePath = "https://www.kursivom.ru/wp-content/uploads/2020/11/Army_of_Lovers_20.jpg",
                        Count = 22,
                        Price = 280.00M,
                    }
                }
            };
        }
    }
}