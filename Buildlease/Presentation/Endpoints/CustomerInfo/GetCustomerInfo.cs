using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using DTOs = Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.CustomerInfo
{
    [Route("api")]
    public class GetCustomerInfo : BaseEndpoint
        .WithoutRequest
        .WithResponse<DTOs.CustomerInfo>
    {
        private readonly IServiceManager _serviceManager;
        public GetCustomerInfo(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetCustomerInfo")]
        public override ActionResult<DTOs.CustomerInfo> Handle()
        {
            try
            {
                return new OkObjectResult(_serviceManager.CustomerInfoService.GetCustomerInfo(this.GetCurrentUserId()));
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
