using Backend.Src.Models;

namespace Backend.Src.Data
{
    public class Seed
    {
        public async static void SeedData(DataContext context)
        {
            await SeedRoles(context);
            await SeedUsers(context);
        }

        private async static Task SeedRoles(DataContext context)
        {
            if (context.Roles.Any()) return;

            var roles = new List<Role>(){
                new(){
                    Name = "admin"
                },
                new(){
                    Name = "client"
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        private async static Task SeedUsers(DataContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>(){
                new(){
                    Username = "dizk",
                    Name = "David",
                    Email = "dvd@gmail.com",
                    Password =  BCrypt.Net.BCrypt.HashPassword("123", BCrypt.Net.BCrypt.GenerateSalt(12)),
                    RoleId = 1
                },
                new(){
                    Username = "porter",
                    Name = "Marcelo",
                    Email = "maikel@porter.com",
                    Password =  BCrypt.Net.BCrypt.HashPassword("321", BCrypt.Net.BCrypt.GenerateSalt(12)),
                    RoleId = 2
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}