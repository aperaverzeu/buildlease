using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using DTOs = Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.CategoryInfo
{
    [Route("api")]
    public class GetCategoryInfo : EndpointBaseSync
        .WithRequest<int>
        .WithActionResult<DTOs.CategoryInfo>
    {
        private readonly IServiceManager _serviceManager;
        public GetCategoryInfo(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("GetCategoryInfo/{categoryId}")]
        public override ActionResult<DTOs.CategoryInfo> Handle([FromRoute] int categoryId)
        {
            try
            {
                _serviceManager.AdminService.EnsureUserIsAdmin(this.GetCurrentUserId());
                return new OkObjectResult(_serviceManager.CategoryInfoService.GetCategoryInfo(categoryId));
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
