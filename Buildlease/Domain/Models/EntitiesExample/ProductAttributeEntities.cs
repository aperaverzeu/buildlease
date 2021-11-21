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
                }
            };
        }
    }
}