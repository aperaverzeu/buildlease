using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Persistence;
using System;
using System.Threading.Tasks;

namespace Buildlease
{
    public class ExceptionLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var db = context.RequestServices.GetRequiredService<ApplicationDbContext>();

                db.ExceptionLogs.Add(new Domain.Models.ExceptionLog()
                {
                    DateTime = DateTime.UtcNow,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    SerializedException = JsonConvert.SerializeObject(ex),
                });

                db.SaveChanges();

                throw;
            }
        }
    }
}
