using Scalar.AspNetCore;
using Wpm.Management.Api.EndpointsExtension;
using Wpm.Management.Infra.IoC;

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
