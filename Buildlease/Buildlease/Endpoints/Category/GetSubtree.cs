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
    public class GetSubtreeHandler : BaseEndpoint
        .WithRequest<int>
        .WithResponse<Models.Category[]>
    {
        private readonly ApplicationDbContext _db;
        public GetSubtreeHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("GetSubtree/{categoryId}")]
        public override ActionResult<Models.Category[]> Handle([FromRoute] int categoryId)
        {
            return TestDatabase.Categories
                .GetSubtree(categoryId)
                .ToArray();
        }
    }
}
