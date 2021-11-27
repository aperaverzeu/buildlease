using Contracts.Requests;
using Contracts.Views;
using Domain.Models;
using Persistence;
using Services.Abstractions;
using Services.Extension;
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
            var cats = _db.Categories
                .GetPathFromRoot(categoryId)
                .Select(e => e.Id);

            var atts = _db.Attributes
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

            return atts;
        }

        public ProductFullView GetProduct(int productId, string userId)
        {
            var product = _db.Products
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

            productView.CategoryPath = _db.Categories
                .GetPathFromRoot(product.CategoryId)
                .Select(e => new CategoryView() 
                {
                    Id = e.Id,
                    Name = e.Name,
                })
                .ToArray();

            productView.Attributes = _db.GetProductAttributeViews(productId);
            productView.AvailableCount = _db.GetProductAvailableCount(productId);

            var cart = _db.ValidateAndGetCart(userId);
            productView.CountInCart = cart is null ? 0 : (
                _db.ProductOrders
                .Where(e => e.OrderId == cart.Id)
                .Where(e => e.ProductId == productView.Id)
                .SingleOrDefault()
                ?.Count
                ?? 0);

            return productView;
        }

        public ProductView[] GetProducts(GetProductsRequest request, string userId)
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

            var cart = _db.ValidateAndGetCart(userId);

            foreach (var prod in productViews)
            {
                prod.AvailableCount = _db.GetProductAvailableCount(prod.Id);
                prod.Attributes = _db.GetProductAttributeViews(prod.Id);

                prod.AlreadyInCart = cart is not null &&
                    _db.ProductOrders
                    .Where(e => e.OrderId == cart.Id)
                    .Select(e => e.ProductId)
                    .Contains(prod.Id);
            }

            return productViews;
        }
    }
}
