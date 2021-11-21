using System.Collections.Generic;

namespace Domain.Models.EntitiesExample
{
    public static class ProductEntities
    {
        public static List<Product> Products()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 0,
                    CategoryId = 17,
                    Name = "Smooth corner No. 1",
                    TotalCount = 5000,
                    Price = 5
                },
                new Product()
                {
                    Id = 1,
                    CategoryId = 17,
                    Name = "Smooth corner No. 2",
                    TotalCount = 1000,
                    Price = null,
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 17,
                    Name = "Internal corner No. 1",
                    TotalCount = 10000,
                    Price = 10
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 6,
                    Name = "Hacksaw for wood",
                    TotalCount = 699,
                    Price = 17
                },
                new Product()
                {
                    Id = 4,
                    CategoryId = 6,
                    Name = "Aerated concrete hacksaw",
                    TotalCount = 0,
                    Price = null
                },
                new Product()
                {
                    Id = 5,
                    CategoryId = 8,
                    Name = "Regular chisel",
                    TotalCount = 310,
                    Price = null
                },
                new Product()
                {
                    Id = 6,
                    CategoryId = 8,
                    Name = "Impact chisel",
                    TotalCount = 33,
                    Price = null
                },
                new Product()
                {
                    Id = 7,
                    CategoryId = 14,
                    Name = "Aluminum wire No. 1",
                    TotalCount = 444,
                    Price = 2
                },
                new Product()
                {
                    Id = 8,
                    CategoryId = 14,
                    Name = "Aluminum wire No. 2",
                    TotalCount = 333,
                    Price = 3
                },
                new Product()
                {
                    Id = 9,
                    CategoryId = 14,
                    Name = "Aluminum wire No. 3",
                    TotalCount = 1962,
                    Price = 4
                },
                new Product()
                {
                    Id = 10,
                    CategoryId = 14,
                    Name = "Copper wire",
                    TotalCount = 1889,
                    Price = 10
                },
                new Product()
                {
                    Id = 11,
                    CategoryId = 1,
                    Name = "Wood toothbrush",
                    TotalCount = 100,
                    Price = 40
                },
                new Product()
                {
                    Id = 12,
                    CategoryId = 2,
                    Name = "ElectorToothBrush",
                    TotalCount = 1,
                    Price = 1000
                },
            };
        }
    }
}