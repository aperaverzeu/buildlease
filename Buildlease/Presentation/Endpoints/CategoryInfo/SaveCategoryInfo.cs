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
    public class SaveCategoryInfo : BaseEndpoint
        .WithRequest<DTOs.CategoryInfo>
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public SaveCategoryInfo(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("SaveCategoryInfo")]
        public override ActionResult Handle([FromBody] DTOs.CategoryInfo info)
        {
            try
            {
                _serviceManager.AdminService.EnsureUserIsAdmin(this.GetCurrentUserId());
                _serviceManager.CategoryInfoService.SaveCategoryInfo(info);
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
