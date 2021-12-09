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
    public class MakeOrderFromCart : BaseEndpoint
        .WithRequest<MakeOrderFromCartRequest>
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public MakeOrderFromCart(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("MakeOrderFromCart")]
        public override ActionResult Handle([FromBody] MakeOrderFromCartRequest request)
        {
            try
            {
                _serviceManager.MakingOrderService.MakeOrderFromCart(this.GetCurrentUserId(), request.StartDate, request.FinishDate);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }
    public class MakeOrderFromCartRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
