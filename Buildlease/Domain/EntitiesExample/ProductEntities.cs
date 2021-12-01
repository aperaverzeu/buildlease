using Domain.Models;
using System.Collections.Generic;

namespace Domain.EntitiesExample
{
    public static class ProductEntities
    {
        public static List<Product> Get()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = -1,
                    CategoryId = -18,
                    Name = "Smooth corner No. 1",
                    TotalCount = 5000,
                    Price = 5
                },
                new Product()
                {
                    Id = -2,
                    CategoryId = -18,
                    Name = "Smooth corner No. 2",
                    TotalCount = 1000,
                    Price = null,
                },
                new Product()
                {
                    Id = -3,
                    CategoryId = -18,
                    Name = "Internal corner No. 1",
                    TotalCount = 10000,
                    Price = 10
                },
                new Product()
                {
                    Id = -4,
                    CategoryId = -7,
                    Name = "Hacksaw for wood",
                    TotalCount = 699,
                    Price = 17
                },
                new Product()
                {
                    Id = -5,
                    CategoryId = -7,
                    Name = "Aerated concrete hacksaw",
                    TotalCount = 0,
                    Price = null
                },
                new Product()
                {
                    Id = -6,
                    CategoryId = -9,
                    Name = "Regular chisel",
                    TotalCount = 310,
                    Price = null
                },
                new Product()
                {
                    Id = -7,
                    CategoryId = -9,
                    Name = "Impact chisel",
                    TotalCount = 33,
                    Price = null
                },
                new Product()
                {
                    Id = -8,
                    CategoryId = -15,
                    Name = "Aluminum wire No. 1",
                    TotalCount = 444,
                    Price = 2
                },
                new Product()
                {
                    Id = -9,
                    CategoryId = -15,
                    Name = "Aluminum wire No. 2",
                    TotalCount = 333,
                    Price = 3
                },
                new Product()
                {
                    Id = -10,
                    CategoryId = -15,
                    Name = "Aluminum wire No. 3",
                    TotalCount = 1962,
                    Price = 4
                },
                new Product()
                {
                    Id = -11,
                    CategoryId = -15,
                    Name = "Copper wire",
                    TotalCount = 1889,
                    Price = 10
                },
                new Product()
                {
                    Id = -12,
                    CategoryId = -2,
                    Name = "Wood toothbrush",
                    TotalCount = 100,
                    Price = 40.20m
                },
                new Product()
                {
                    Id = -13,
                    CategoryId = -3,
                    Name = "ElectorToothBrush",
                    TotalCount = 1,
                    Price = 1000.69m
                },
            };
        }
    }
}