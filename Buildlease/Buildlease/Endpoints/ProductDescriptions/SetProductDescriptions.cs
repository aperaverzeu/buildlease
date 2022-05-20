using System;
using System.Linq;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Buildlease.Endpoints.ProductDescriptions
{
    [Route("api")]
    public class SetProductDescriptions : EndpointBaseSync
        .WithRequest<ProductDescription[]>
        .WithoutResult
    {
        private readonly ApplicationDbContext _db;

        public SetProductDescriptions(ApplicationDbContext db) => _db = db;

        [HttpPost("ProductDescriptions")]
        public override void Handle(ProductDescription[] descriptions)
        {
            var unknownProductIds = descriptions.Select(d => d.ProductId).Except(_db.Products.Select(p => p.Id)).ToArray();
            if (unknownProductIds.Any())
                throw new InvalidOperationException($"Unknown product ids: {string.Join(", ", unknownProductIds)}");

            var newLanguages = descriptions
                .Select(d => d.Language)
                .Where(dl => _db.Languages.All(l => l.Name != dl))
                .ToArray();

            _db.Languages.AddRange(newLanguages.Select(newLang => new Domain.Models.Language()
            {
                Name = newLang,
            }));
            _db.SaveChanges();

            _db.ProductDescriptions.RemoveRange(_db.ProductDescriptions.ToArray());
            _db.ProductDescriptions.AddRange(descriptions.Select(pd => new Domain.Models.ProductDescription()
            {
                ProductId = pd.ProductId,
                LanguageId = _db.Languages.Single(l => l.Name == pd.Language).Id,
                Description = pd.Description,
            }));
            _db.SaveChanges();
        }
    }
}
