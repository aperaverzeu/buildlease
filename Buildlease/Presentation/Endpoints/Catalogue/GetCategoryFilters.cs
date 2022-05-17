using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Contracts.Views;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.Catalogue
{
    [Route("api")]
    public class GetCategoryFilters : EndpointBaseSync
        .WithRequest<int>
        .WithActionResult<CategoryFilterView[]>
    {
        private readonly IServiceManager _serviceManager;
        public GetCategoryFilters(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetCategoryFilters/{categoryId}")]
        public override ActionResult<CategoryFilterView[]> Handle([FromRoute] int categoryId)
            => 
            _serviceManager.CatalogueService.GetCategoryFilters(categoryId);
    }
}
