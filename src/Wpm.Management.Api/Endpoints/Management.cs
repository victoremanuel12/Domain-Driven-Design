using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Endpoints.EndpointCollection;
using Wpm.Management.Api.EndpointsExtension;
using Wpm.Management.Application.Commands;
using Wpm.Management.Application.Handlers;
using Wpm.Management.Application.Services;

namespace Wpm.Management.Api.Endpoints
{
    public class Management : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.Generate(EndpointManagementConstantCollection.Management, "Management", "Endpoints");
            group.MapPost("/", async ([FromBody] CreatePetCommand command, ManagementApplicationService managementApplicationService) =>
            {
                await managementApplicationService.Handle(command);
                return Results.Ok();
            }).WithAutoName(EndpointManagementConstantCollection.Management, "CreatePet");
            group.MapPut("/", async (
                ICommandHandler<SetWeightCommand> commandHandler,
                ManagementApplicationService managementApplicationService,
                SetWeightCommand command) =>
            {
                await commandHandler.Handle(command);
                return Results.Ok();
            }).WithAutoName(EndpointManagementConstantCollection.Management, "SetWeight");
        }
    }
}
