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
    public class SaveCustomerInfo : EndpointBaseSync
        .WithRequest<DTOs.CustomerInfo>
        .WithActionResult
    {
        private readonly IServiceManager _serviceManager;
        public SaveCustomerInfo(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("SaveCustomerInfo")]
        public override ActionResult Handle([FromBody] DTOs.CustomerInfo info)
        {
            try
            {
                info.UserId = this.GetCurrentUserId();
                _serviceManager.CustomerInfoService.SaveCustomerInfo(info);
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
