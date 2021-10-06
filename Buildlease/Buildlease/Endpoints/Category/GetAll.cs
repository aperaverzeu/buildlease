using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Buildlease.Data;
using Buildlease.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Buildlease.Endpoints.Category
{
    [Route("api/Category")]
    public class GetAllHandler : BaseEndpoint
        .WithoutRequest
        .WithResponse<Models.Category[]>
    {
        private readonly ApplicationDbContext _db;
        public GetAllHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("GetAll")]
        public override ActionResult<Models.Category[]> Handle()
        {
            return TestDatabase.Categories
                .GetSubtree(0)
                .ToArray();
        }
    }
}
