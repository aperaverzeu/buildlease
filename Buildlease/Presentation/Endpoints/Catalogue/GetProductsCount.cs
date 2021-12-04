using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Contracts.Requests;
using Contracts.Views;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.Catalogue
{
    [Route("api")]
    public class GetProductsCount : BaseEndpoint
        .WithRequest<GetProductsRequest>
        .WithResponse<int>
    {
        private readonly IServiceManager _serviceManager;
        public GetProductsCount(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetProductsCount")]
        public override ActionResult<int> Handle([FromBody] GetProductsRequest request)
            => 
            _serviceManager.CatalogueService.GetProductsCount(request);
    }
}
