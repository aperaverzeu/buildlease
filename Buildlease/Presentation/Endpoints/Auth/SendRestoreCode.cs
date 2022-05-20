using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Endpoints.Auth
{
    [Route("api")]
    public class SendRestoreCode : EndpointBaseSync
        .WithRequest<SendRestoreCodeRequest>
        .WithActionResult
    {
        private readonly IServiceManager _serviceManager;
        public SendRestoreCode(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("SendRestoreCode")]
        public override ActionResult Handle([FromBody] SendRestoreCodeRequest request)
        {
            try
            {
                _serviceManager.AuthService.SendRestoreCode(request.Login);
            }
            catch (InvalidOperationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }

    public class SendRestoreCodeRequest
    {
        public string Login { get; set; }
    }
}
