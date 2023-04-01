
using Microsoft.AspNetCore.Builder;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app){
           using (var serciveScope= app.ApplicationServices.CreateScope()){
                SeedData(serciveScope.ServiceProvider.GetService<AppDbContext>());
           } 
        }

        private static void SeedData(AppDbContext context){

            if(!context.Platforms.Any()){
                Console.WriteLine("--> Sending Data ... ");

                context.Platforms.AddRange(
                    new Platform() {Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() {Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() {Name = "Kubernetes", Publisher = "Microsoft", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }

    }
}