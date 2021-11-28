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
                .Include(e => e.Attribute)
                .Select(e => new ProductAttributeView()
                {
                    Name = e.Attribute.Name,
                    Value = e.Attribute.ValueType == AttributeType.String ?
                            e.ValueString :
                            (e.ValueNumber.HasValue ? $"{e.ValueNumber.Value} {e.Attribute.UnitName}" : null),
                })
                .ToArray();
    }
}
