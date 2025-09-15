using System.Reflection;
using Wpm.Clinic.Api.Endpoints;

namespace Wpm.Clinic.Api.EndpointsExtension
{
    public static class EndpointsExtensions
    {
        public static WebApplication MapAllEndpoints(this WebApplication app)
        {
            var endpointType = typeof(IEndpoint);
            var assembly = Assembly.GetExecutingAssembly();
            var endpointTypes = assembly.GetExportedTypes().Where(t => t.IsAbstract == false && t.GetInterfaces().Contains(endpointType));
            using var scope = app.Services.CreateScope();
            var provider = scope.ServiceProvider;
            foreach (var type in endpointTypes)
            {
                if (Activator.CreateInstance(type) is IEndpoint instance)
                    instance.Map(app);
            }
            return app;
        }
    }
}
