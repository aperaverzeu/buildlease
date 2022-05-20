using System.Linq;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Buildlease.Endpoints.ProductDescriptions
{
    [Route("api")]
    public class GetProductDescriptions : EndpointBaseSync
        .WithoutRequest
        .WithResult<ProductDescription[]>
    {
        private readonly ApplicationDbContext _db;

        public GetProductDescriptions(ApplicationDbContext db) => _db = db;

        [HttpGet("ProductDescriptions")]
        public override ProductDescription[] Handle()
        {
            return _db.ProductDescriptions
                .Select(pd => new ProductDescription()
                {
                    ProductId = pd.ProductId,
                    Language = pd.Language.Name,
                    Description = pd.Description,
                })
                .ToArray();
        }
    }
}
