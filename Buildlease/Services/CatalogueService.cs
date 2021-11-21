﻿using Contracts.Requests;
using Contracts.Views;
using Domain.Models;
using Persistence;
using Services.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    internal sealed class CatalogueService : ICatalogueService
    {
        private readonly ApplicationDbContext _db;

        public CatalogueService(ApplicationDbContext dbContext) => _db = dbContext;

        public CategoryFullView[] GetAllCategories()
        {
            var categories = _db.Set<Category>().ToArray();

            var categoriesProductCount = _db.Set<Product>()
                .GroupBy(e => e.CategoryId)
                .ToDictionary(g => g.Key, g => g.Count());

            var categoriesView = categories
                .Select(e => new CategoryFullView()
                {
                    Id = e.Id,
                    ParentId = e.ParentId,
                    Name = e.Name,
                    DefaultImagePath = e.DefaultImagePath,
                })
                .ToArray();

            foreach (var cat in categoriesView)
            {
                var subtree = categories
                    .GetSubtree(cat.Id)
                    .Select(e => e.Id);

                cat.ProductCount = categories
                    .Where(e => subtree.Contains(e.Id))
                    .Where(e => categoriesProductCount.ContainsKey(e.Id))
                    .Select(e => categoriesProductCount[e.Id])
                    .Sum();
            }

            return categoriesView;
        }

        public CategoryFilterView[] GetCategoryFilters(int categoryId)
        {
            var cats = _db.Set<Category>()
                .GetPathFromRoot(categoryId)
                .Select(e => e.Id);

            var atts = _db.Set<Attribute>()
                .Where(e => cats.Contains(e.CategoryId))
                .Select(e => new CategoryFilterView()
                {
                    Id = e.Id,
                    Name = e.Name,
                    UnitName = e.UnitName,
                })
                .ToArray();

            foreach (var att in atts)
            {
                att.Values = _db.Set<ProductAttribute>()
                    .Where(e => e.AttributeId == att.Id)
                    .Where(e => e.ValueString != null)
                    .Select(e => e.ValueString)
                    .Distinct()
                    .ToArray();

                att.MinValue = _db.Set<ProductAttribute>()
                    .Where(e => e.AttributeId == att.Id)
                    .Where(e => e.ValueNumber != null)
                    .Min(e => e.ValueNumber);

                att.MaxValue = _db.Set<ProductAttribute>()
                    .Where(e => e.AttributeId == att.Id)
                    .Where(e => e.ValueNumber != null)
                    .Max(e => e.ValueNumber);
            }

            return atts;
        }

        public ProductFullView GetProduct(int productId)
        {
            var product = _db.Set<Product>()
                .Single(e => e.Id == productId);

            var productView = new ProductFullView()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                TotalCount = product.TotalCount,
                ImagePath = product.ImagePath,
            };

            productView.CategoryPath = _db.Set<Category>()
                .GetPathFromRoot(product.CategoryId)
                .Select(e => new CategoryView() 
                {
                    Id = e.Id,
                    Name = e.Name,
                })
                .ToArray();

            productView.Attributes = _db.Set<ProductAttribute>()
                .Where(e => e.ProductId == productId)
                .Join(_db.Set<Attribute>(),
                    pa => pa.AttributeId,
                    a => a.Id,
                    (pa, a) => new ProductAttributeView()
                    {
                        Name = a.Name,
                        Value = a.ValueType == AttributeType.String ? 
                            pa.ValueString : 
                            (pa.ValueNumber.HasValue ? $"{pa.ValueNumber.Value} {a.UnitName}" : null),
                    }
                )
                .ToArray();

            // TODO
            productView.ShortDescription = null; 
            productView.AvailableCount = -1;
            productView.CountInCart = -1;

            return productView;
        }

        public ProductView[] GetProducts(GetProductsRequest request)
        {
            var subtree = _db.Set<Category>()
                .GetSubtree(request.CategoryId)
                .Select(e => e.Id)
                .ToArray();

            var query = _db.Set<Product>()
                .Where(e => subtree.Contains(e.CategoryId));

            if (request.Keywords is not null)
            {
                foreach (var word in request.Keywords)
                    query = query
                        .Where(e =>
                            e.Name.Contains(word) ||
                            e.Description.Contains(word));
            }

            switch (request.OrderByRule)
            {
                case SortRule.PriceAscending:
                    query = query
                        .Where(e => e.Price != null)
                        .OrderBy(e => e.Price)
                        .ThenBy(e => e.Id);
                    break;

                case SortRule.PriceDescending:
                    query = query
                        .Where(e => e.Price != null)
                        .OrderByDescending(e => e.Price)
                        .ThenBy(e => e.Id);
                    break;

                case SortRule.NameAscending:
                    query = query
                        .OrderBy(e => e.Name)
                        .ThenBy(e => e.Id);
                    break;

                case SortRule.NameDescending:
                    query = query
                        .OrderByDescending(e => e.Name)
                        .ThenBy(e => e.Id);
                    break;

                // TODO or remove
                case SortRule.PopularityAscending:
                case SortRule.PopularityDescending:

                case SortRule.Default:
                    query = query
                        .OrderBy(e => e.Id);
                    break;

                default:
                    throw new System.ArgumentOutOfRangeException("Unknown SortRule");
            }

            query = query
                .Skip(request.SkipCount)
                .Take(request.TakeCount);

            var productViews = query
                .Select(e => new ProductView()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    ImagePath = e.ImagePath,
                    TotalCount = e.TotalCount,
                })
                .ToArray();

            foreach (var prod in productViews)
            {
                // TODO
                prod.AlreadyInCart = false;
                prod.AvailableCount = -1;
                prod.ShortDescription = null;
            }

            return productViews;
        }
    }
}
