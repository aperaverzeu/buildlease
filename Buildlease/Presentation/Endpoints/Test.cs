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
    public class TestHandler : BaseEndpoint
        .WithRequest<string>
        .WithResponse<string>
    {
        private readonly IServiceManager _serviceManager;
        public TestHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("Test/{name}")]
        [HttpPost("Test/{name}")]
        public override ActionResult<string> Handle([FromRoute] string name) =>
            _serviceManager.TestService.DoTest(name);
    }
}
