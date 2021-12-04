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
    public class DeleteProduct : BaseEndpoint
        .WithRequest<int>
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public DeleteProduct(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("DeleteProduct/{productId}")]
        public override ActionResult Handle([FromRoute] int productId)
        {
            try
            {
                // _serviceManager.AdminService.EnsureUserIsAdmin(this.GetCurrentUserId());
                _serviceManager.ProductInfoService.DeleteProduct(productId);
                return new OkResult();
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
