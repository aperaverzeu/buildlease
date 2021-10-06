using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Buildlease.Data;
using Microsoft.AspNetCore.Mvc;

namespace Buildlease.Endpoints.Product
{
    [Route("api/Product")]
    public class GetHandler : BaseEndpoint
        .WithRequest<int>
        .WithResponse<Models.Product>
    {
        private readonly ApplicationDbContext _db;
        public GetHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("Get/{productId}")]
        public override ActionResult<Models.Product> Handle([FromRoute] int productId)
        {
            var result = TestDatabase.Products.SingleOrDefault(p => p.Id == productId);

            if (result is null) 
                return NotFound(productId);

            return result;
        }
    }
}
