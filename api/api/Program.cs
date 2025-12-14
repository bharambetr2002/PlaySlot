using api.Data;
using api.Repositories;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // getting string from the appsettings.json
        var conn = builder.Configuration.GetConnectionString("DefaultConnection");

        // Connection to the database
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Add controller
        builder.Services.AddControllers();

        // DJ
        builder.Services.AddScoped<ITurfRepository, TurfRepository>();
        builder.Services.AddScoped<TurfService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<UserService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}