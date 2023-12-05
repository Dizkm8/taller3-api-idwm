using Backend.Src.Models;

namespace Backend.Src.Data
{
    public class Seed
    {
        public async static void SeedData(DataContext context)
        {
            await SeedRoles(context);
            await SeedClients(context);
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

        private async static Task SeedClients(DataContext context){
            if (context.Clients.Any()) return;

            var clients = new List<Client>();

            for (int i = 1; i < 21; i++)
            {
                clients.Add(new Client(){
                    Names = $"Name {i}",
                    LastNames = $"LastNames {i}",
                    RutOrDni = $"RutOrDni {i}",
                    Email = $"Email {i}",
                    Score = i*150
                });
            }

            await context.Clients.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }
    }
}