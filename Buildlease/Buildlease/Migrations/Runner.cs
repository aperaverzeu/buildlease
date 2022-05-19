using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Buildlease.Migrations;

public class Runner
{
    public static void Run(IServiceCollection services)
    {
        using var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var scopedServices = scope.ServiceProvider;

        var db = scopedServices.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}
