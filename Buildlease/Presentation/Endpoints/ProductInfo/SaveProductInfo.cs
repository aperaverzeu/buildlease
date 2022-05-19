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
    public class SaveProductInfo : EndpointBaseSync
        .WithRequest<DTOs.ProductInfo>
        .WithActionResult<int>
    {
        private readonly IServiceManager _serviceManager;
        public SaveProductInfo(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("SaveProductInfo")]
        public override ActionResult<int> Handle([FromBody] DTOs.ProductInfo info)
        {
            try
            {
                _serviceManager.AdminService.EnsureUserIsAdmin(this.GetCurrentUserId());
                return new OkObjectResult(_serviceManager.ProductInfoService.SaveProductInfo(info));
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
