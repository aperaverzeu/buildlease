using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints
{
    [Route("api")]
    public class DatabaseRestartHandler : BaseEndpoint
        .WithoutRequest
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public DatabaseRestartHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("DatabaseRestart")]
        public override ActionResult Handle()
        {
            _serviceManager.DatabaseTestService.RestartDatabase();
            return new OkResult();
        }
    }
}
