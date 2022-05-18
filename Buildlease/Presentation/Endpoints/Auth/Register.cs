using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.Auth
{
    [Route("api")]
    public class Register : EndpointBaseSync
        .WithRequest<RegisterRequest>
        .WithActionResult
    {
        private readonly IServiceManager _serviceManager;
        public Register(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("Register")]
        public override ActionResult Handle([FromBody] RegisterRequest request)
        {
            try
            {
                _serviceManager.AuthService.Register(request.Login, request.Password);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }

    public class RegisterRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
