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

namespace Presentation.Endpoints.Order
{
    [Route("api")]
    public class GetOrder : BaseEndpoint
        .WithRequest<int>
        .WithResponse<OrderFullView>
    {
        private readonly IServiceManager _serviceManager;
        public GetOrder(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetOrder/{orderId}")]
        public override ActionResult<OrderFullView> Handle([FromRoute] int orderId)
            => 
            _serviceManager.OrderService.GetOrder(this.GetCurrentUserId(), orderId);
    }
}
