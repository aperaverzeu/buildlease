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
    public class GetProducts : BaseEndpoint
        .WithRequest<GetProductsRequest>
        .WithResponse<ProductView[]>
    {
        private readonly IServiceManager _serviceManager;
        public GetProducts(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetProducts")]
        public override ActionResult<ProductView[]> Handle([FromBody] GetProductsRequest request)
            => 
            _serviceManager.CatalogueService.GetProducts(request, this.GetCurrentUserId());
    }
}
