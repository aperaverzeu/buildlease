using System.Collections.Generic;

namespace Domain.Models.EntitiesExample
{
    public static class ProductAttributeEntities
    {
        public static List<ProductAttribute> Get()
        {
            return new List<ProductAttribute>()
            {
                new ProductAttribute()
                {
                    Id = 1,
                    ProductId = 13,
                    AttributeId = 10,
                    ValueNumber = 100,
                },
                new ProductAttribute()
                {
                    Id = 2,
                    ProductId = 13,
                    AttributeId = 11,
                    ValueNumber = 500,
                },
                new ProductAttribute()
                {
                    Id = 3,
                    ProductId = 9,
                    AttributeId = 4,
                    ValueNumber = 50
                },
                new ProductAttribute()
                {
                    Id = 4,
                    ProductId = 4,
                    AttributeId = 12,
                    ValueNumber = 3
                },
                new ProductAttribute()
                {
                    Id = 5,
                    ProductId = 4,
                    AttributeId = 15,
                    ValueString = "Steel"
                },
                new ProductAttribute()
                {
                    Id = 6,
                    ProductId = 5,
                    AttributeId = 15,
                    ValueString = "Carbonised steel"
                },
                new ProductAttribute()
                {
                    Id = 7,
                    ProductId = 7,
                    AttributeId = 15,
                    ValueString = "Titan"
                },
                new ProductAttribute()
                {
                    Id = 8,
                    ProductId = 2,
                    AttributeId = 1,
                    ValueString = "Linden"
                },
                new ProductAttribute()
                {
                    Id = 9,
                    ProductId = 1,
                    AttributeId = 1,
                    ValueString = "Pine"
                },

                new ProductAttribute()
                {
                    Id = 10,
                    ProductId = 12,
                    AttributeId = 9,
                    ValueString = "Wood"
                },
                new ProductAttribute()
                {
                    Id = 11,
                    ProductId = 13,
                    AttributeId = 9,
                    ValueString = "Plastic"
                },
                new ProductAttribute()
                {
                    Id = 12,
                    ProductId = 12,
                    AttributeId = 14,
                    ValueNumber = 42
                },
                new ProductAttribute()
                {
                    Id = 13,
                    ProductId = 13,
                    AttributeId = 14,
                    ValueNumber = 42
                },
            };
        }
    }
}