using Microsoft.EntityFrameworkCore;

namespace TonRoadVoteApi.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            Console.WriteLine("--> Applying Migrations...");
            context.Database.Migrate();
        }
    }
}
