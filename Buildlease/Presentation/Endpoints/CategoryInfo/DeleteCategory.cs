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
    public class DeleteCategory : EndpointBaseSync
        .WithRequest<int>
        .WithActionResult
    {
        private readonly IServiceManager _serviceManager;
        public DeleteCategory(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("DeleteCategory/{categoryId}")]
        public override ActionResult Handle([FromRoute] int categoryId)
        {
            try
            {
                _serviceManager.AdminService.EnsureUserIsAdmin(this.GetCurrentUserId());
                _serviceManager.CategoryInfoService.DeleteCategory(categoryId);
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
