
using Microsoft.AspNetCore.Cors.Infrastructure;
using OneToOne.Repository.PassportRepository;
using OneToOne.Repository.PersonRepository;
using OneToOne.Server.Configurations;
using OneToOne.Service.PassportService;
using OneToOne.Service.PersonService;

namespace OneToOnePractise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Db configuration
            builder.ConfigureDatabase();

            // Dependecy injection
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPassportRepository, PassportRepository>();


            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPassportService, PassportService>();

            var app = builder.Build();

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
}
