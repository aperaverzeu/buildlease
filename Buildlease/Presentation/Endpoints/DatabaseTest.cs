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
    public class DatabaseTestHandler : BaseEndpoint
        .WithoutRequest
        .WithoutResponse
    {
        private readonly IServiceManager _serviceManager;
        public DatabaseTestHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("DatabaseTest")]
        public override ActionResult Handle()
        {
            _serviceManager.DatabaseTestService.DoTest();
            return new OkResult();
        }
    }
}
