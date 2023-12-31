using Backend.Src.Data;
using Backend.Src.Repositories;
using Backend.Src.Repositories.Interfaces;
using Backend.Src.Services;
using Backend.Src.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Src.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            AddSwaggerGen(services);
            AddRepositories(services);
            AddServices(services);
            AddDbContext(services);
            AddAutoMapper(services);
        }

        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMapperService, MapperService>();
        }

        
        private static void AddDbContext(IServiceCollection services)
        {
            // DI Dependency Injection
            // Inyectamos la base de datos (DataContext) a  partes de la aplicación donde sea necesario
            services.AddDbContext<DataContext>(opt => opt.UseSqlite("Data Source=AyudantiaUno.db"));
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
        }
    }
}