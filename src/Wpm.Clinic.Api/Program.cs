using Wpm.Clinic.Infra.IoC;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
app.Run();
