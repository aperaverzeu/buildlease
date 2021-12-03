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
    public class GetMyCart : BaseEndpoint
        .WithoutRequest
        .WithResponse<CartFullView>
    {
        private readonly IServiceManager _serviceManager;
        public GetMyCart(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetMyCart")]
        public override ActionResult<CartFullView> Handle()
            => 
            _serviceManager.OrderService.GetMyCart(this.GetCurrentUserId());
    }
}
