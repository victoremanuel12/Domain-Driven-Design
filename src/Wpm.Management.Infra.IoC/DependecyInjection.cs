using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wpm.Management.Application.Commands;
using Wpm.Management.Application.EventSubscribers;
using Wpm.Management.Application.Handlers;
using Wpm.Management.Application.Services;
using Wpm.Management.Domain.Repositories;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Infra.Data;
using Wpm.Management.Infra.Data.Repository;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.IntegrationEvent;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.Management.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "Data source=WpmManagement.db";

            services.AddDbContext<ManagementDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped<IRepository<Pet>, ManagementRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<ICommandHandler<SetWeightCommand>, SetWeightCommandHandler>();
            services.AddScoped<ICommandHandler<AdoptPetCommand>, AdoptCommandHandler>();
            services.AddScoped<IBreedService, BreedService>();
            services.AddSingleton<ServiceBusClient>(s =>
            {
                var configuration = s.GetRequiredService<IConfiguration>();
                return new ServiceBusClient(configuration["AzureServiceBus:ConnectionString"]!);
            });
            services.AddSingleton<IIntegrationEventPublisher, AzureServiceBusPublisher>();
            services.AddSingleton<PetDomainEventSubscriber>();
            services.AddScoped<ManagementApplicationService>();

            return services;
        }
    }

    public static class ManagementDbContextExtensions
    {
        public static void EnsureDatabaseIsCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ManagementDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.CloseConnection();
        }
    }
}
