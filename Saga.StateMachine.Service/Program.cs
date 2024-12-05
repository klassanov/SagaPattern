using MassTransit;
using Microsoft.EntityFrameworkCore;
using Saga.StateMachine.Service.SagaDatabaseContext;
using Saga.StateMachine.Service.SagaStateMachine;

namespace Saga.StateMachine.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            builder.Services.AddDbContext<OrderSagaDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
            });

            builder.Services.AddMassTransit(x =>
            {
                x.AddSagaStateMachine<OrderStateMachine, OrderState>()
                   .EntityFrameworkRepository(r =>
                   {
                       //r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
                       r.AddDbContext<DbContext, OrderSagaDbContext>();
                       r.UsePostgres();
                   });

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"));
                    cfg.ConfigureEndpoints(context);
                });
            });

            var host = builder.Build();

            host.MigrateDb();

            host.Run();
        }
    }
}