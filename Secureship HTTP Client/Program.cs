using Microsoft.EntityFrameworkCore;
using Refit;
using Secureship_HTTP_Client.Data.Contexts;
using Secureship_HTTP_Client.Data.Repositories;
using Secureship_HTTP_Client.Interfaces;
using Secureship_HTTP_Client.Services;
using Swashbuckle.AspNetCore.Filters;

namespace Secureship_HTTP_Client
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.ExampleFilters(); // to support examples
            });
            builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

            // Sets up a Refit HTTP client for the Open Exchange Rates API,
            builder.Services.AddRefitClient<IOpenExchangeRatesAPI>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://openexchangerates.org/api"));

            //Auto-mapper
            builder.Services.AddAutoMapper(typeof(Program));

            //EF
            builder.Services.AddDbContext<EndPointContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            // Registers OpenExchangeRatesAPIService as a scoped dependency,
            builder.Services.AddScoped<IOpenExchangeRatesAPIService, OpenExchangeRatesAPIService>();
            builder.Services.AddScoped<IEndPointStatisticRepository, EndPointStatisticRepository>();
            builder.Services.AddScoped<IEndPointStatisticService, EndPointStatisticService>();

            builder.Services.AddLogging();

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