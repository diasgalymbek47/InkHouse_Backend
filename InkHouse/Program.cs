using System.Data;
using InkHouse.Interfaces;
using InkHouse.Middlewares;
using InkHouse.Repositories;
using InkHouse.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDbConnection>(_ =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("NpgsqlConnection")));
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("InkHouse", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseCors("InkHouse");
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.MapControllers();
app.UseStaticFiles();
app.Run();