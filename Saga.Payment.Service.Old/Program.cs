
using MassTransit;

namespace Saga.Payment.Service.Old
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<ProcessPaymentConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"));
                    cfg.ConfigureEndpoints(context);
                });
            });

            var app = builder.Build();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();
            //app.MapControllers();

            app.Run();
        }
    }
}
