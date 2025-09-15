using Wpm.Clinic.Api.ExceptionFilter;

namespace Wpm.Clinic.Api.EndpointsExtension
{
    public static class Minimal
    {
        public static RouteGroupBuilder Generate(this WebApplication app, string endpoint, string tag, string name)
        {
            var routeBuilder = app.MapGroup($"/api/v1/{endpoint}")
                .WithTags(tag)
                .AddEndpointFilter<ApiExceptionFilter>();
                 //.RequireAuthorization()

            return routeBuilder;
        }
        public static RouteHandlerBuilder WithAutoName(this RouteHandlerBuilder builder, string endpoint, string action)
        {
            return builder.WithName($"{endpoint}-{action}");
        }
    }
}
