using Microsoft.EntityFrameworkCore;
using backendnet.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3001", "http://localhost:8080", "http://localhost:3000")
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT", "DELETE");
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.MapControllers();

app.Run();
