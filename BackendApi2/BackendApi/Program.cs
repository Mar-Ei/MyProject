
using Domain.Interfaces;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using BackendApi.Models;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<MedicalContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionString"]));


            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Медицинские данные",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();
         //   using (var scope = app.Services.CreateScope())
         //   {
           //     var services = scope.ServiceProvider;

           //     var context = services.GetRequiredService<MedicalContext>();
          //      context.Database.Migrate();
          //  }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder.WithOrigins(new[] { "http://localhost:5191", })
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}