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
    public class GetMyOrders : BaseEndpoint
        .WithoutRequest
        .WithResponse<OrderView[]>
    {
        private readonly IServiceManager _serviceManager;
        public GetMyOrders(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetMyOrders")]
        public override ActionResult<OrderView[]> Handle()
            => 
            _serviceManager.OrderService.GetMyOrders(this.GetCurrentUserId());
    }
}
