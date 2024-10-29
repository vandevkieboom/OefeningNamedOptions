
using Microsoft.Extensions.DependencyInjection;
using OefeningNamedOptions.Models;

namespace OefeningNamedOptions
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

            builder.Services.Configure<EmailOptions>(
                EmailOptions.GmailSectionName,
                builder.Configuration.GetSection($"EmailServices:{EmailOptions.GmailSectionName}")
            );

            builder.Services.Configure<EmailOptions>(
                EmailOptions.OutlookSectionName,
                builder.Configuration.GetSection($"EmailServices:{EmailOptions.OutlookSectionName}")
            );

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
