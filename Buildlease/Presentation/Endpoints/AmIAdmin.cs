using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;

namespace Presentation.Endpoints
{
    [Route("api")]
    public class AmIAdmin : BaseEndpoint
        .WithoutRequest
        .WithResponse<bool>
    {
        private readonly IServiceManager _serviceManager;
        public AmIAdmin(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("AmIAdmin")]
        public override ActionResult<bool> Handle()
            =>
            _serviceManager.AdminService.IsUserAdmin(this.GetCurrentUserId());
    }
}
