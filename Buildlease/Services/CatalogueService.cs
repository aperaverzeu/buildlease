using Contracts.Requests;
using Contracts.Views;
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
    internal sealed class CatalogueService : ICatalogueService
    {
        private readonly ApplicationDbContext _db;

        public CatalogueService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        public CategoryFullView[] GetAllCategories()
        {
            var categories = _db.Categories
                .OrderBy(e => e.Id)
                .ToArray();

            var categoriesProductCount = _db.Products
                .GroupBy(e => e.CategoryId)
                .Select(g => new { g.Key, Count = g.Count() })
                .ToDictionary(obj => obj.Key, obj => obj.Count);

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
            var path = _db.Categories
                .GetPathFromRoot(categoryId)
                .Select(e => e.Id);

            var atts = _db.Attributes
                .Where(e => path.Contains(e.CategoryId))
                .Select(e => new CategoryFilterView()
                {
                    Id = e.Id,
                    Name = e.Name,
                    UnitName = e.UnitName,
                })
                .ToArray();

            foreach (var att in atts)
            {
                att.Values = _db.ProductAttributes
                    .Where(e => e.AttributeId == att.Id)
                    .Where(e => e.ValueString != null)
                    .Select(e => e.ValueString)
                    .Distinct()
                    .ToArray();

                if (!att.Values.Any()) att.Values = null;

                att.MinValue = _db.ProductAttributes
                    .Where(e => e.AttributeId == att.Id)
                    .Where(e => e.ValueNumber != null)
                    .Min(e => e.ValueNumber)
                    ?? null;

                att.MaxValue = _db.ProductAttributes
                    .Where(e => e.AttributeId == att.Id)
                    .Where(e => e.ValueNumber != null)
                    .Max(e => e.ValueNumber)
                    ?? null;
            }

            var subtree = _db.Categories
                .GetSubtree(categoryId)
                .Select(e => e.Id)
                .ToArray();

            var priceAttribute = new CategoryFilterView()
            {
                Id = 0,
                Name = "Price",
                MaxValue =
                    _db.Products
                    .Where(e => subtree.Contains(e.CategoryId))
                    .Where(e => e.Price != null)
                    .Max(e => e.Price),
            };

            atts = atts
                .Where(att => att.Values is not null || att.MinValue.HasValue)
                .Where(att => att.Values is not null || att.MinValue != att.MaxValue)
                .Prepend(priceAttribute)
                .ToArray();

            return atts;
        }

        public ProductFullView GetProduct(int productId, string userId)
        {
            var product = _db.Products
                .IncludeProductAttributeView()
                .Include(p => p.ProductDescriptions).ThenInclude(pd => pd.Language)
                .Single(e => e.Id == productId);

            var view = new ProductFullView()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                TotalCount = product.TotalCount,
                ImagePath = product.ImagePath,
                Attributes = product.GetProductAttributeViews(),
                AvailableCount = _db.GetProductAvailableCount(productId),
                Descriptions = product.ProductDescriptions
                    .Select(pd => new ProductDescriptionView()
                    {
                        Language = pd.Language.Name,
                        Description = pd.Description,
                    })
                    .ToArray(),
            };

            view.CategoryPath = _db.Categories
                .GetPathFromRoot(product.CategoryId)
                .Select(e => new CategoryView() 
                {
                    Id = e.Id,
                    Name = e.Name,
                })
                .ToArray();

            var cart = _db.ValidateAndGetCart(userId);
            view.CountInCart = 
                cart?.ProductOrders
                .Where(e => e.ProductId == view.Id)
                .SingleOrDefault()
                ?.Count
                ?? 0;

            return view;
        }

        private IQueryable<Product> BuildMainQuery(GetProductsRequest request)
        {
            var subtree = _db.Categories
                .GetSubtree(request.CategoryId)
                .Select(e => e.Id)
                .ToArray();

            var query = _db.Products
                .Where(e => subtree.Contains(e.CategoryId));

            if (request.Keywords is not null)
            {
                foreach (var word in request.Keywords)
                    query = query
                        .Where(e =>
                            e.Name.Contains(word) ||
                            e.ProductDescriptions.Any(pd => pd.Description.Contains(word)));
            }

            if (request.MaxPrice.HasValue)
            {
                query = query
                    .Where(e => e.Price != null)
                    .Where(e => e.Price.Value <= request.MaxPrice);
            }

            foreach (var filter in request.Filters)
            {
                if (filter.ValueNumberLowerBound.HasValue)
                    query = query.Where(prod =>
                        prod.ProductAttributes.Any(attr => attr.AttributeId == filter.AttributeId) &&
                        prod.ProductAttributes.Single(attr => attr.AttributeId == filter.AttributeId)
                        .ValueNumber >= filter.ValueNumberLowerBound.Value);

                if (filter.ValueNumberUpperBound.HasValue)
                    query = query.Where(prod =>
                        prod.ProductAttributes.Any(attr => attr.AttributeId == filter.AttributeId) &&
                        prod.ProductAttributes.Single(attr => attr.AttributeId == filter.AttributeId)
                        .ValueNumber <= filter.ValueNumberUpperBound.Value);

                if (filter.ValueStringAllowed is not null && filter.ValueStringAllowed.Any())
                    query = query.Where(prod =>
                        filter.ValueStringAllowed.Contains(
                            prod.ProductAttributes
                            .Single(attr => attr.AttributeId == filter.AttributeId)
                            .ValueString));
            }

            return query;
        }

        public int GetProductsCount(GetProductsRequest request) => BuildMainQuery(request).Count();

        public ProductView[] GetProducts(GetProductsRequest request, string userId)
        {
            var query = BuildMainQuery(request);

            switch (request.OrderByRule)
            {
                case SortRule.PriceAscending:
                    query = query
                        .OrderByDescending(e => e.Price != null)
                        .ThenBy(e => e.Price)
                        .ThenBy(e => e.Id);
                    break;

                case SortRule.PriceDescending:
                    query = query
                        .OrderByDescending(e => e.Price != null)
                        .ThenByDescending(e => e.Price)
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
                .IncludeProductAttributeView()
                .Select(e => new ProductView()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    ImagePath = e.ImagePath,
                    TotalCount = e.TotalCount,
                    Attributes = e.GetProductAttributeViews(),
                })
                .ToArray();

            var cart = _db.ValidateAndGetCart(userId);

            foreach (var prod in productViews)
            {
                prod.AvailableCount = _db.GetProductAvailableCount(prod.Id);

                prod.AlreadyInCart = cart is not null &&
                    cart.ProductOrders
                    .Select(e => e.ProductId)
                    .Contains(prod.Id);
            }

            return productViews;
        }
    }
}
