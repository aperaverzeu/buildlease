using System.Collections.Generic;

namespace Domain.Models.EntitiesExample
{
    public static class CategoryEntities
    {
        public static List<Category> Categories()
        {
            return new List<Category>
            {
                new Category()
                {
                    Id = 0,
                    ParentId = 0,
                    Name = "All",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 1,
                    ParentId = 0,
                    Name = "ToothBrushes",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 2,
                    ParentId = 1,
                    Name = "Electric Toothbrushes",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 3,
                    ParentId = 1,
                    Name = "Simple Toothbrushes",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 4,
                    ParentId = 0,
                    Name = "Tools",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 5,
                    ParentId = 4,
                    Name = "Carpentry tools",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 6,
                    ParentId = 5,
                    Name = "Hacksaws",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 7,
                    ParentId = 5,
                    Name = "Planners",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 8,
                    ParentId = 5,
                    Name = "Chisels",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 9,
                    ParentId = 0,
                    Name = "Building materials",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 10,
                    ParentId = 9,
                    Name = "Rolled Metal",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 11,
                    ParentId = 9,
                    Name = "Industrial wood",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 12,
                    ParentId = 10,
                    Name = "Fittings",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 13,
                    ParentId = 10,
                    Name = "Sheet Metal",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 14,
                    ParentId = 10,
                    Name = "Wire",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 15,
                    ParentId = 11,
                    Name = "Board",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 16,
                    ParentId = 11,
                    Name = "Bar",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = 17,
                    ParentId = 11,
                    Name = "Corner",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
            };
        }
    }
}