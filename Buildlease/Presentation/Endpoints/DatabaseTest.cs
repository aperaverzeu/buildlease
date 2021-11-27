using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints
{
    [Route("api")]
    public class DatabaseTestHandler : BaseEndpoint
        .WithoutRequest
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public DatabaseTestHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("DatabaseTest")]
        public override ActionResult Handle()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _serviceManager.DatabaseTestService.DoTest(userId);
            return new OkResult();
        }
    }
}
