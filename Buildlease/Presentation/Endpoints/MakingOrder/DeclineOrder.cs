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

namespace Presentation.Endpoints.MakingOrder
{
    [Route("api")]
    public class DeclineOrder : BaseEndpoint
        .WithRequest<int>
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public DeclineOrder(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("DeclineOrder/{orderId}")]
        public override ActionResult Handle([FromRoute] int orderId)
        {
            try
            {
                _serviceManager.MakingOrderService.DeclineOrder(this.GetCurrentUserId(), orderId);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }
}
