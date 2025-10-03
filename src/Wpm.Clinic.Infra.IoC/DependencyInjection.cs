using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Application.Handlers;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Infra.Data.Repository;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "Data source=WpmClinic.db";

            services.AddDbContext<ClinicDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped<IRepository<Consultation>, ConsultationRepository>();
            services.AddScoped<ICommandHandler<StartConsultationCommand,Guid>, StartConsultationCommandHandler>();
            services.AddScoped<ICommandHandler<AdministerDrugCommand>, AdministerDrugCommandHandler>();
            services.AddScoped<ICommandHandler<RegisterVitalSignsCommand>, RegisterVitalSignsCommandHandler>();
            services.AddScoped<ICommandHandler<SetWeightCommand>, SetWeightCommandHandler>();
            services.AddScoped<ICommandHandler<SetTreatmentCommand>, SetTreatmentCommandHandler>();
            services.AddScoped<ICommandHandler<SetDiagnosisCommand>, SetDiagnosisCommandHandler>();
            services.AddScoped<ICommandHandler<SetDiagnosisCommand>, SetDiagnosisCommandHandler>();
            services.AddScoped<ICommandHandler<SetDiagnosisCommand>, SetDiagnosisCommandHandler>();
            services.AddScoped<ICommandHandler<EndConsultationCommand>, EndConsultationCommandHandler>();
            services.AddScoped<IEventStore, EventStoreRepository>();






            return services;
        }
    }
    public static class ClinicDbContextExtensions
    {
        public static void EnsureDatabaseIsCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ClinicDbContext>();
            dbContext.Database.EnsureCreated();
            dbContext.Database.CloseConnection();
        }
    }
}
