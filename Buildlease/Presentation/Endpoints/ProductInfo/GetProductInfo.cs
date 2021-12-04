using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using DTOs = Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.ProductInfo
{
    [Route("api")]
    public class GetProductInfo : BaseEndpoint
        .WithRequest<int>
        .WithResponse<DTOs.ProductInfo>
    {
        private readonly IServiceManager _serviceManager;
        public GetProductInfo(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetProductInfo/{productId}")]
        public override ActionResult<DTOs.ProductInfo> Handle([FromRoute] int productId)
        {
            try
            {
                // _serviceManager.AdminService.EnsureUserIsAdmin(this.GetCurrentUserId());
                return new OkObjectResult(_serviceManager.ProductInfoService.GetProductInfo(productId));
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                return new UnauthorizedResult();
            }
        }
    }
}
