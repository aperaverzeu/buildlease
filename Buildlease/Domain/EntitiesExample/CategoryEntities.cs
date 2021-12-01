using Domain.Models;
using System.Collections.Generic;

namespace Domain.EntitiesExample
{
    public static class CategoryEntities
    {
        public static List<Category> Get()
        {
            return new List<Category>
            {
                new Category()
                {
                    Id = -1,
                    ParentId = -1,
                    Name = "All",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -2,
                    ParentId = -1,
                    Name = "ToothBrushes",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -3,
                    ParentId = -2,
                    Name = "Electric Toothbrushes",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -4,
                    ParentId = -2,
                    Name = "Simple Toothbrushes",
                },
                new Category()
                {
                    Id = -5,
                    ParentId = -1,
                    Name = "Tools",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -6,
                    ParentId = -5,
                    Name = "Carpentry tools",
                },
                new Category()
                {
                    Id = -7,
                    ParentId = -6,
                    Name = "Hacksaws",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -8,
                    ParentId = -6,
                    Name = "Planners",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -9,
                    ParentId = -6,
                    Name = "Chisels",
                },
                new Category()
                {
                    Id = -10,
                    ParentId = -1,
                    Name = "Building materials",
                },
                new Category()
                {
                    Id = -11,
                    ParentId = -10,
                    Name = "Rolled Metal",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -12,
                    ParentId = -10,
                    Name = "Industrial wood",
                },
                new Category()
                {
                    Id = -13,
                    ParentId = -11,
                    Name = "Fittings",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -14,
                    ParentId = -11,
                    Name = "Sheet Metal",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -15,
                    ParentId = -11,
                    Name = "Wire",
                    DefaultImagePath = "/wwwroot/somewhere"
                },
                new Category()
                {
                    Id = -16,
                    ParentId = -12,
                    Name = "Board",
                },
                new Category()
                {
                    Id = -17,
                    ParentId = -12,
                    Name = "Bar",
                },
                new Category()
                {
                    Id = -18,
                    ParentId = -12,
                    Name = "Corner",
                },
            };
        }
    }
}