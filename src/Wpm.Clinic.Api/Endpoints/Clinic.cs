using Wpm.Clinic.Api.Endpoints;
using Wpm.Clinic.Api.EndpointsExtension;
using Wpm.Management.Api.Endpoints.EndpointCollection;


namespace Wpm.Management.Api.Endpoints
{
    public class Clinic : IEndpoint
    {
        public void Map(WebApplication app)
        {
            var group = app.Generate(EndpointClinicConstantCollection.NewConsultation, "Management", "Endpoints");
            group.MapPost("/", async () =>
            {
                //await managementApplicationService.Handle(command);
                return Results.Ok();
            }).WithAutoName(EndpointClinicConstantCollection.NewConsultation, "CreatePet");
        }
    }
}
