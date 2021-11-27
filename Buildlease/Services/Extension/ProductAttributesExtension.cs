using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension
{
    public static class ProductAttributesExtension
    {
        public static ProductAttributeView[] GetProductAttributeViews(
            this ApplicationDbContext db,
            int productId)
            =>
                db.ProductAttributes
                .Where(e => e.ProductId == productId)
                .ToProductAttributeViews(db)
                .ToArray();

        public static IQueryable<ProductAttributeView> ToProductAttributeViews(
            this IQueryable<ProductAttribute> ProductAttributes, 
            ApplicationDbContext db)
            => 
            ProductAttributes
                .Join(db.Attributes,
                    pa => pa.AttributeId,
                    a => a.Id,
                    (pa, a) => new ProductAttributeView()
                    {
                        Name = a.Name,
                        Value = a.ValueType == AttributeType.String ?
                            pa.ValueString :
                            (pa.ValueNumber.HasValue ? $"{pa.ValueNumber.Value} {a.UnitName}" : null),
                    }
                );
    }
}
