using Microsoft.AspNetCore.Mvc;
using Wpm.Clinic.Api.Endpoints.Intefaces;
using Wpm.Clinic.Api.EndpointsExtension;
using Wpm.Clinic.Application.Commands;
using Wpm.SharedKerbel.CommandHandler;
using Wpm.Management.Api.Endpoints.EndpointCollection;

namespace Wpm.Management.Api.Endpoints
{
    public class Clinic : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.Generate(EndpointClinicConstantCollection.NewConsultation, "Clinic", "Endpoints");

            group.MapPost("/start", async (
                [FromServices] ICommandHandler<StartConsultationCommand, Guid> commandHandler,
                StartConsultationCommand command) =>
            {
                var id = await commandHandler.Handle(command);
                return Results.Ok(id);
            })
            .Produces<Guid>(StatusCodes.Status200OK)
            .WithAutoName(EndpointClinicConstantCollection.NewConsultation, "CreateConsultation");

            group.MapPut("/diagnosis", async (
                [FromServices] ICommandHandler<SetDiagnosisCommand> commandHandler,
                SetDiagnosisCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            });

            group.MapPut("/treatment", async (
                [FromServices] ICommandHandler<SetTreatmentCommand> commandHandler,
                SetTreatmentCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            });

            group.MapPut("/weight", async (
                [FromServices] ICommandHandler<SetWeightCommand> commandHandler,
                SetWeightCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            });

            group.MapPut("/administerDrug", async (
                [FromServices] ICommandHandler<AdministerDrugCommand> commandHandler,
                AdministerDrugCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            });

            group.MapPut("/registerVitalSigns", async (
                [FromServices] ICommandHandler<RegisterVitalSignsCommand> commandHandler,
                RegisterVitalSignsCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            });

            group.MapPost("/end", async (
                [FromServices] ICommandHandler<EndConsultationCommand> commandHandler,
                EndConsultationCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            });
        }
    }
}
