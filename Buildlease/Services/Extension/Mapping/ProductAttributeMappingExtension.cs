using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension.Mapping
{
    public static class ProductAttributeMappingExtension
    {
        public static ProductAttributeView MapToProductAttributeView(this ProductAttribute obj)
            => new()
            {
                Name = obj.Attribute.Name,
                Value = obj.Attribute.ValueType == AttributeType.String ?
                        obj.ValueString :
                        (obj.ValueNumber.HasValue ? $"{obj.ValueNumber.Value} {obj.Attribute.UnitName}" : null),
            };

        public static IQueryable<ProductAttributeView> MapToProductAttributeView(this IQueryable<ProductAttribute> objs)
            => objs
                .Include(obj => obj.Attribute)
                .Select(obj => obj.MapToProductAttributeView());

        public static IEnumerable<ProductAttributeView> MapToProductAttributeView(this IEnumerable<ProductAttribute> objs)
            => objs
                .Select(obj => obj.MapToProductAttributeView());

        public static IQueryable<Product> IncludeProductAttributeView(this IQueryable<Product> objs)
            => objs
                .Include(e => e.ProductAttributes)
                    .ThenInclude(e => e.Attribute);
    }
}
