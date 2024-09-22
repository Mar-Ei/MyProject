
using DataAccess.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DataAccess.Wrapper;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace мед.журнал;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<MedicalContext>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: "Server=DESKTOP-3V67SLK;Database=medical;Integrated Security=True;TrustServerCertificate=True;"));
        builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        builder.Services.AddScoped<IUserService, UserService>();
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
