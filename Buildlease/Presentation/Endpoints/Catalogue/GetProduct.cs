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
    public class GetProduct : BaseEndpoint
        .WithRequest<int>
        .WithResponse<ProductFullView>
    {
        private readonly IServiceManager _serviceManager;
        public GetProduct(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetProduct/{productId}")]
        public override ActionResult<ProductFullView> Handle([FromRoute] int productId)
            => 
            _serviceManager.CatalogueService.GetProduct(productId, this.GetCurrentUserId());
    }
}
