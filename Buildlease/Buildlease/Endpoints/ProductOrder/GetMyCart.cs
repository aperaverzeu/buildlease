using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Buildlease.Data;
using Microsoft.AspNetCore.Mvc;

namespace Buildlease.Endpoints.ProductOrder
{
    [Route("api/ProductOrder")]
    public class GetMyCartHandler : BaseEndpoint
        .WithoutRequest
        .WithResponse<Models.ProductOrder[]>
    {
        private readonly ApplicationDbContext _db;
        public GetMyCartHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("GetMyCart")]
        public override ActionResult<Models.ProductOrder[]> Handle()
        {
            if (new Random().Next(2) == 0)
                return Array.Empty<Models.ProductOrder>();

            return TestDatabase.ProductOrders.ToArray();
        }
    }
}
