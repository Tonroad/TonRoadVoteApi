using Microsoft.EntityFrameworkCore;

namespace TonRoadVoteApi.Data;

public static class PrepDb
{
    public static void PrepPopulation(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        Console.WriteLine("--> Applying Migrations...");
        context.Database.Migrate();
    }
}
