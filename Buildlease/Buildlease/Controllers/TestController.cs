using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTOs;
using Contracts.Requests;
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
        public ProductView[] GetProducts([FromBody] GetProductsRequest request)
        {
            return new ProductView[]
            {
                new()
                {
                    Id = 69,
                    Name = "SCP-1876 - Личная зубная щётка",
                    TotalCount = 213,
                    AvailableCount = 1,
                    Price = 1123.89M,
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
                },
                new()
                {
                    Id = 2,
                    Name = "Tooth-Brush™ с алмазным напылением",
                    ImagePath = "wrong/link/jpg.jpg",
                    TotalCount = 22,
                    AvailableCount = 22,
                },
                new()
                {
                    Id = 13,
                    Name = "Красная отвёртка",
                    TotalCount = 0,
                    AvailableCount = 0,
                    Price = 144,
                    AlreadyInCart = true,
                },
                new()
                {
                    Id = 42,
                    Name = "Синяя отвёртка",
                    TotalCount = 39,
                    AvailableCount = 0,
                    Price = 95.40M,
                },
                new()
                {
                    Id = 1,
                    Name = "Зелёная отвёртка",
                    ImagePath = "https://i.pinimg.com/originals/43/a3/5a/43a35af2a33785c5be181b68073f0661.gif",
                    TotalCount = 48500,
                    AvailableCount = 4200,
                    Price = 690.42M,
                    AlreadyInCart = true,
                }
            };
        }

        private ProductFullView BuildProductFullView()
            => new()
            {
                Id = 42,
                Name = "Зелёная отвёртка",
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
                ImagePath = "https://i.pinimg.com/originals/43/a3/5a/43a35af2a33785c5be181b68073f0661.gif",
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

        [HttpPost("GetProduct/{productId}")]
        public ProductFullView GetProduct([FromRoute] int productId) => BuildProductFullView();

        [HttpPost("GetHistoryProduct/{productOrderId}")]
        public ProductFullView GetHistoryProduct([FromRoute] int productOrderId) => BuildProductFullView();

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
                            ImagePath = "https://i.pinimg.com/originals/43/a3/5a/43a35af2a33785c5be181b68073f0661.gif",
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
                        ProductId = null,
                        ProductOrderId = 12345,
                        Name = "Зубная щётка",
                        ImagePath = "https://genk.mediacdn.vn/k:thumb_w/640/2015/screen-shot-2015-07-30-at-2-31-57-pm-1438334096188/cau-chuyen-ve-nguoi-tao-ra-chu-ech-xanh-than-thanh.png",
                        Count = 11,
                        Price = 22.11M,
                    },
                    new()
                    {
                        ProductId = 13,
                        ProductOrderId = 54321,
                        Name = "Saint Tropez",
                        ImagePath = "https://i.ytimg.com/vi/vHMRq5a2zr4/hqdefault.jpg",
                        Count = 22,
                        Price = 280.00M,
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
                        ProductOrderId = -1,
                        Name = "Зубная щётка",
                        ImagePath = "https://genk.mediacdn.vn/k:thumb_w/640/2015/screen-shot-2015-07-30-at-2-31-57-pm-1438334096188/cau-chuyen-ve-nguoi-tao-ra-chu-ech-xanh-than-thanh.png",
                        Count = 11,
                        Price = 22.11M,
                    },
                    new()
                    {
                        ProductId = 13,
                        ProductOrderId = -1,
                        Name = "Saint Tropez",
                        ImagePath = "https://i.ytimg.com/vi/vHMRq5a2zr4/hqdefault.jpg",
                        Count = 22,
                        Price = 280.00M,
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
                    }
                }
            };
        }


        [HttpPost("SetProductOrderCount/{productId}/{count}")]
        public void SetProductOrderCount([FromRoute] int productId, [FromRoute] int count)
        {
            if (count < 0) throw new ArgumentException("count < 0");
            return;
        }

        [HttpPost("MakeOrderFromCart")]
        public void MakeOrderFromCart()
        {
            if (new Random().Next(2) == 1) throw new ArgumentException("*here will be explanation of error*");
            return;
        }

        [HttpPost("DeclineOrder/{orderId}")]
        public void DeclineOrder([FromRoute] int orderId)
        {
            if (orderId <= 0) throw new ArgumentException("*here will be explanation of error*");
            return;
        }


        [HttpPost("GetCustomerInfo")]
        public CustomerInfo GetCustomerInfo()
        {
            return new CustomerInfo()
            {
                CompanyName = "Never Zero INC.",
                CompanyImagePath = "data:image/jpeg;base64,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",
                RepresentativeName = "Jacque Fresco",
                RepresentativeImagePath = "data:image/jpeg;base64,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",
                ContactInfo = "Email: contact@nzinc.com\n" +
                              "Phone: 88005553535",
                JuridicalAddress = new AddressInfo()
                {
                    PostalCode = "69-420",
                    City = "New-York",
                    Street = "Central park st",
                    Building = "Skyscraper",
                    Office = "Overlooking central park",
                },
                DeliveryAddresses = new AddressInfo[]
                {
                    new AddressInfo()
                    {
                        PostalCode = "301-3322",
                        City = "Dortmund",
                        Street = "Karl strasse st",
                        Building = "Loft",
                        Office = "Single room apartment",
                    },
                    new AddressInfo()
                    {
                        PostalCode = "111-6666",
                        City = "Reykjavik",
                        Street = "Monderlstotrm underlstom St",
                        Building = "House",
                        Office = "Room overlooking the geyser",
                    },
                    new AddressInfo()
                    {
                        PostalCode = "4455-112",
                        City = "Lisbon",
                        Street = "Pedro Gonsales st",
                        Building = "Great house",
                        Office = "Near ocean",
                    },
                },
            };
        }

        [HttpPost("SaveCustomerInfo")]
        public void SaveCustomerInfo([FromBody] CustomerInfo info)
        {
            return;
        }
    }
}
