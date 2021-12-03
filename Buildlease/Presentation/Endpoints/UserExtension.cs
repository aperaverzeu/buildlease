using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Endpoints
{
    public static class UserExtension
    {
        public static string GetCurrentUserId(this ControllerBase obj)
            => obj?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
