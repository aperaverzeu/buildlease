using Contracts.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services.Extension.Mapping
{
    public static class ProductMappingExtension
    {
        public static ProductInfo MapToProductInfo(this Product obj, ProductAttributeInfo[] attributes)
            => new()
            {
                Id = obj.Id,
                CategoryId = obj.CategoryId,
                Name = obj.Name,
                ImageLink = obj.ImagePath,
                TotalCount = obj.TotalCount,
                Price = obj.Price,
                Attributes = attributes,
                Descriptions = obj.ProductDescriptions
                    .OrderBy(e => e.LanguageId)
                    .Select(e => new ProductDescriptionInfo()
                    {
                        Language = e.Language.Name,
                        Description = e.Description,
                    })
                    .ToArray(),
            };

        public static Product MapToProduct(this ProductInfo info)
            => new()
            {
                Id = info.Id,
                CategoryId = info.CategoryId,
                Name = info.Name,
                ImagePath = info.ImageLink,
                TotalCount = info.TotalCount,
                Price = info.Price,
            };


        public static IQueryable<Product> IncludeProductAttributeInfo(this IQueryable<Product> objs)
            => objs
                .Include(e => e.ProductAttributes)
                    .ThenInclude(e => e.Attribute)
                        .ThenInclude(e => e.ProductAttributes);

        public static ProductAttributeInfo MapToProductAttributeInfo(this ProductAttribute obj)
            => new()
            {
                AttributeId = obj.AttributeId,
                Name = obj.Attribute.Name,
                ValueType = obj.Attribute.ValueType,
                UnitName = obj.Attribute.UnitName,
                Value = obj.ValueString ?? obj.ValueNumber?.ToString() ?? null,
                ExistingStringValues = obj.Attribute
                    .ProductAttributes
                    .Select(e => e.ValueString)
                    .Where(e => e != null)
                    .Distinct()
                    .ToArray(),
            };

        public static IEnumerable<ProductAttributeInfo> MapToProductAttributeInfo(this IEnumerable<ProductAttribute> objs)
            => objs
                .Select(e => e.MapToProductAttributeInfo());
    }
}
