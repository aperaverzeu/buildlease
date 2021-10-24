using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints
{
    [Route("api")]
    public class TestAsyncHandler : BaseAsyncEndpoint
        .WithRequest<string>
        .WithResponse<string>
    {
        private readonly IServiceManager _serviceManager;
        public TestAsyncHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("TestAsync/{name}")]
        [HttpPost("TestAsync/{name}")]
        public override async Task<ActionResult<string>> HandleAsync([FromRoute] string name, CancellationToken cancellationToken) =>
            await _serviceManager.TestService.DoTest(name, cancellationToken);
    }
}
