using Wpm.Clinic.Infra.IoC;
using Scalar.AspNetCore;
using Wpm.Clinic.Api.EndpointsExtension;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
var app = builder.Build();
app.MapAllEndpoints();
app.EnsureDatabaseIsCreated();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/", context =>
    {
        context.Response.Redirect("/scalar", permanent: false);
        return Task.CompletedTask;
    });
}
app.UseHttpsRedirection();
app.Run();

