using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Buildlease.Data;
using Microsoft.AspNetCore.Mvc;

namespace Buildlease.Endpoints.Order
{
    [Route("api/Order")]
    public class GetAllHandler : BaseEndpoint
        .WithoutRequest
        .WithResponse<Models.Order[]>
    {
        private readonly ApplicationDbContext _db;
        public GetAllHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("GetAll")]
        public override ActionResult<Models.Order[]> Handle()
        {
            return TestDatabase.Orders.Where(o => o.Status != Models.CommonOrderStatus.Cart).ToArray();
        }
    }
}
