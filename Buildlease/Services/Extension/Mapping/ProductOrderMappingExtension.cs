using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Extension.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension
{
    public static class ProductOrderMappingExtension
    {
        private static ProductOrderView MapToProductOrderView(this ProductOrder obj)
        {
            if (obj.SerializedProductFullView == null)
            {
                return new ProductOrderView()
                {
                    ProductId = obj.Product.Id,
                    Count = obj.Count,
                    Name = obj.Product.Name,
                    ImagePath = obj.Product.ImagePath,
                    Price = obj.Product.Price.Value,
                    Attributes = obj.Product.GetProductAttributeViews(),
                };
            }
            else
            {
                var product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductFullView>(obj.SerializedProductFullView);
                return new ProductOrderView()
                {
                    ProductId = product.Id,
                    Count = obj.Count,
                    Name = product.Name,
                    ImagePath = product.ImagePath,
                    Price = product.Price.Value,
                    Attributes = product.Attributes,
                };
            }
        }

        private static IEnumerable<ProductOrderView> MapToProductOrderView(this IEnumerable<ProductOrder> objs)
            => objs
                .Select(obj => obj.MapToProductOrderView());

        public static IQueryable<ProductOrderView> MapToProductOrderView(this IQueryable<ProductOrder> objs)
            => objs
                .Include(e => e.Product)
                    .ThenInclude(e => e.ProductAttributes)
                        .ThenInclude(e => e.Attribute)
                .Select(obj => obj.MapToProductOrderView());

        public static IQueryable<Order> IncludeProductOrderView(this IQueryable<Order> objs)
            => objs
                .Include(e => e.ProductOrders)
                    .ThenInclude(e => e.Product)
                        .ThenInclude(e => e.ProductAttributes)
                            .ThenInclude(e => e.Attribute);

        public static IEnumerable<ProductOrderView> ExtractProductOrderView(this Order obj)
            => obj
                .ProductOrders
                .MapToProductOrderView();
    }
}
