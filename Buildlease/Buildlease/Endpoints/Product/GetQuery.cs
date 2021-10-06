using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Buildlease.Data;
using Microsoft.AspNetCore.Mvc;

namespace Buildlease.Endpoints.Product
{
    [Route("api/Product")]
    public class GetQueryHandler : BaseEndpoint
        .WithRequest<GetQueryRequest>
        .WithResponse<Models.Product[]>
    {
        private readonly ApplicationDbContext _db;
        public GetQueryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("GetQuery")]
        public override ActionResult<Models.Product[]> Handle([FromBody] GetQueryRequest request)
        {
            return TestDatabase.Products.ToArray();
        }
    }
}
