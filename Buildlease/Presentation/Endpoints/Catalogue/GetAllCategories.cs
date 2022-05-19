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
    public class GetAllCategories : EndpointBaseSync
        .WithoutRequest
        .WithActionResult<CategoryFullView[]>
    {
        private readonly IServiceManager _serviceManager;
        public GetAllCategories(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetAllCategories")]
        public override ActionResult<CategoryFullView[]> Handle()
            => 
            _serviceManager.CatalogueService.GetAllCategories();
    }
}
