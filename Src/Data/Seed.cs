using Backend.Src.Models;

namespace Backend.Src.Data
{
    public class Seed
    {
        public async static void SeedData(DataContext context)
        {
            await SeedRoles(context);
        }

        private async static Task SeedRoles(DataContext context)
        {
            if (context.Roles.Any()) return;

            var roles = new List<Role>(){
                new(){
                    Name = "admin"
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
    }
}