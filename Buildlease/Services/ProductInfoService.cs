using Contracts.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using Services.Extension;
using Services.Extension.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    internal sealed class ProductInfoService : IProductInfoService
    {
        private readonly ApplicationDbContext _db;

        public ProductInfoService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        public ProductInfo GetProductInfo(int productId)
        {
            var product = _db.Products
                .Include(e => e.ProductAttributes)
                .Include(e => e.ProductDescriptions).ThenInclude(e => e.Language)
                .Single(e => e.Id == productId);

            var attributes = _db.GetAllAvailableAttributes(product.CategoryId);

            var attributesInfo = attributes
                .Select(e => new ProductAttributeInfo()
                {
                    AttributeId = e.Id,
                    Name = e.Name,
                    ValueType = e.ValueType,
                    UnitName = e.ValueType == AttributeType.Number ? e.UnitName : null,
                    ExistingStringValues = e.ValueType == AttributeType.String ?
                            e.ProductAttributes
                            .Where(pa => pa.ValueString != null)
                            .Select(pa => pa.ValueString)
                            .Distinct()
                            .ToArray()
                        : null,
                    Value = e.ValueType switch
                    {
                        AttributeType.String =>
                            product.ProductAttributes
                            .SingleOrDefault(pa => pa.AttributeId == e.Id)
                            ?.ValueString,
                        AttributeType.Number =>
                            product.ProductAttributes
                            .SingleOrDefault(pa => pa.AttributeId == e.Id)
                            ?.ValueNumber?.ToString(),
                        _ => throw new System.ArgumentOutOfRangeException(),
                    }
                })
                .ToArray();

            var info = product.MapToProductInfo(attributesInfo);

            return info;
        }

        public int SaveProductInfo(ProductInfo info)
        {
            var product = info.MapToProduct();

            var availableAttributes = _db.GetAllAvailableAttributes(product.CategoryId).ToArray();
            var availableAttributesIds = availableAttributes.Select(e => e.Id).ToArray();

            var attributes = info.Attributes
                .Where(e => availableAttributesIds.Contains(e.AttributeId))
                .Where(e => !string.IsNullOrWhiteSpace(e.Value))
                .Select(e => new { 
                    e.AttributeId, 
                    e.Value,
                    Attribute = availableAttributes.Single(a => a.Id == e.AttributeId),
                })
                .Select(e => new ProductAttribute()
                {
                    AttributeId = e.AttributeId,
                    ProductId = product.Id,
                    ValueNumber = e.Attribute.ValueType == AttributeType.Number ?
                        decimal.Parse(e.Value, System.Globalization.CultureInfo.InvariantCulture) : null,
                    ValueString = e.Attribute.ValueType == AttributeType.String ?
                        e.Value : null,
                });
            
            var newLanguages = info.Descriptions
                .Select(d => d.Language)
                .Where(dl => !string.IsNullOrWhiteSpace(dl))
                .Where(dl => _db.Languages.All(l => l.Name != dl))
                .ToArray();

            _db.Languages.AddRange(newLanguages.Select(newLang => new Language() { Name = newLang, }));
            _db.SaveChanges();

            var descriptions = info.Descriptions
                .Where(e => !string.IsNullOrWhiteSpace(e.Description))
                .Select(e => new ProductDescription()
                {
                    ProductId = product.Id,
                    LanguageId = _db.Languages.Single(l => l.Name == e.Language).Id,
                    Description = e.Description,
                })
                .ToArray();

            _db.ChangeTracker.Clear();
            _db.Database.BeginTransaction();

            _db.Products.Update(product);

            _db.ProductAttributes.RemoveRange(_db.ProductAttributes.Where(e => e.ProductId == product.Id));
            _db.ProductAttributes.AddRange(attributes);

            _db.ProductDescriptions.RemoveRange(_db.ProductDescriptions.Where(e => e.ProductId == product.Id));
            _db.ProductDescriptions.AddRange(descriptions);

            _db.SaveChanges();
            _db.Database.CommitTransaction();
            
            return GetProductInfo(product.Id).Id;
        }

        public void DeleteProduct(int productId)
        {
            var product = _db.Products.Include(e => e.ProductAttributes).Single(e => e.Id == productId);

            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}
