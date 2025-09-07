var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Enable git agit CORS for development: allow any origin, header, and method
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Use CORS middleware before controllers
app.UseCors();

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();

app.Run();