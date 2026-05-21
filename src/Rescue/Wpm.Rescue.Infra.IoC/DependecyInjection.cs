using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wpm.Rescue.Infra.Data;

namespace Wpm.Rescue.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "Data source=WpmRescue.db";

            services.AddDbContext<RescueDbContext>(options =>
                options.UseSqlite(connectionString));
            //services.AddSingleton<IntegrationEventPublisher>(s =>
            //{
            //    var configuration = s.GetRequiredService<IConfiguration>();
            //    var connectionString = configuration["AzureServiceBus:ConnectionString"];
            //    return new AzureServiceBusPublisher(connectionString!);
            //});

            return services;
        }
    }
    public static class ManagementDbContextExtensions
    {
        public static void EnsureDatabaseIsCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<RescueDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.CloseConnection();
        }
    }
}
