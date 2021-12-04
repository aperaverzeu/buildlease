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
    public static class ProductAttributesExtension
    {
        public static ProductAttributeView[] GetProductAttributeViews(this Product obj)
            => obj
                .ProductAttributes
                .MapToProductAttributeView()
                .ToArray();
    }
}
