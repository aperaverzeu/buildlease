using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.Auth
{
    [Route("api")]
    public class ChangePassword : EndpointBaseSync
        .WithRequest<ChangePasswordRequest>
        .WithActionResult
    {
        private readonly IServiceManager _serviceManager;
        public ChangePassword(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("ChangePassword")]
        public override ActionResult Handle([FromBody] ChangePasswordRequest request)
        {
            try
            {
                _serviceManager.AuthService.ChangePassword(request.Login, request.RestoreCode, request.NewPassword);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }

    public class ChangePasswordRequest
    {
        public string Login { get; set; }
        public string RestoreCode { get; set; }
        public string NewPassword { get; set; }
    }
}
