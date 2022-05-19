using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Contracts.Views;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.Order
{
    [Route("api")]
    public class GetHistoryProduct : EndpointBaseSync
        .WithRequest<int>
        .WithActionResult<ProductFullView>
    {
        private readonly IServiceManager _serviceManager;
        public GetHistoryProduct(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetHistoryProduct/{productOrderId}")]
        public override ActionResult<ProductFullView> Handle([FromRoute] int productOrderId)
            => 
            _serviceManager.OrderService.GetHistoryProduct(this.GetCurrentUserId(), productOrderId);
    }
}
