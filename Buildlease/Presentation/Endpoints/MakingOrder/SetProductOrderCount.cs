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
    public class SetProductOrderCount : BaseEndpoint
        .WithRequest<SetProductOrderCountRequest>
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public SetProductOrderCount(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("SetProductOrderCount/{productId}/{count}")]
        public override ActionResult Handle([FromRoute] SetProductOrderCountRequest request)
        {
            try
            {
                _serviceManager.MakingOrderService.SetProductOrderCount(this.GetCurrentUserId(), request.productId, request.count);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }

    public class SetProductOrderCountRequest
    {
        public int productId { get; set; }
        public int count { get; set; }
    }
}
