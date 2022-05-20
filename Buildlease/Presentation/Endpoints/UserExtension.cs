using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Services.Abstractions;
using System;
using System.Linq;

namespace Presentation.Endpoints
{
    public static class UserExtension
    {
        public static string GetCurrentUserId(this ControllerBase obj)
        {
            var headers = obj.HttpContext.Request.Headers;
            var login = headers["Login"].SingleOrDefault();
            var password = headers["Password"].SingleOrDefault();

            var db = obj.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

            var user = db.Users.SingleOrDefault(u => u.Id == login);
            if (user is null) return null;

            if (user.PasswordHash != IAuthService.ComputeHash(password))
                throw new UnauthorizedAccessException("Wrong password");

            return user.Id;
        }
    }
}
