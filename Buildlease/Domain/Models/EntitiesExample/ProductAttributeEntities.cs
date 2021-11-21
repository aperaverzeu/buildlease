using System.Collections.Generic;

namespace Domain.Models.EntitiesExample
{
    public static class ProductAttributeEntities
    {
        public static List<ProductAttribute> ProductAttributes()
        {
            return new List<ProductAttribute>()
            {
                new ProductAttribute()
                {
                    Id = 0,
                    ProductId = 12,
                    AttributeId = 9,
                    ValueNumber = 100,
                },
                new ProductAttribute()
                {
                    Id = 1,
                    ProductId = 12,
                    AttributeId = 10,
                    ValueNumber = 500,
                },
                new ProductAttribute()
                {
                    Id = 2,
                    ProductId = 8,
                    AttributeId = 3,
                    ValueNumber = 50
                },
                new ProductAttribute()
                {
                    Id = 3,
                    ProductId = 3,
                    AttributeId = 11,
                    ValueNumber = 3
                },
                new ProductAttribute()
                {
                    Id = 4,
                    ProductId = 3,
                    AttributeId = 14,
                    ValueString = "Steel"
                },
                new ProductAttribute()
                {
                    Id = 5,
                    ProductId = 4,
                    AttributeId = 14,
                    ValueString = "Carbonised steel"
                },
                new ProductAttribute()
                {
                    Id = 6,
                    ProductId = 6,
                    AttributeId = 14,
                    ValueString = "Titan"
                },
                new ProductAttribute()
                {
                    Id = 7,
                    ProductId = 1,
                    AttributeId = 0,
                    ValueString = "Linden"
                },
                new ProductAttribute()
                {
                    Id = 7,
                    ProductId = 0,
                    AttributeId = 0,
                    ValueString = "Pine"
                },

                new ProductAttribute()
                {
                    Id = 8,
                    ProductId = 11,
                    AttributeId = 8,
                    ValueString = "Wood"
                },
                new ProductAttribute()
                {
                    Id = 9,
                    ProductId = 12,
                    AttributeId = 8,
                    ValueString = "Plastic"
                },
                new ProductAttribute()
                {
                    Id = 10,
                    ProductId = 11,
                    AttributeId = 13,
                    ValueNumber = 42
                },
                new ProductAttribute()
                {
                    Id = 11,
                    ProductId = 12,
                    AttributeId = 13,
                    ValueNumber = 42
                },
            };
        }
    }
}