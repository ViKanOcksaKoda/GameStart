using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameStart.Infrastructure.Data
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GameStartContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}
