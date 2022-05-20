using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Endpoints
{
    [Route("api")]
    public class ThrowException: EndpointBaseSync
        .WithoutRequest
        .WithActionResult
    {
        [HttpGet("ThrowException")]
        public override ActionResult Handle()
            => throw new NotImplementedException("It's not implemented yet!");
    }
}
