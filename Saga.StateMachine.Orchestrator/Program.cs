using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.StateMachine.Orchestrator.SagaDatabaseContext;
using Saga.StateMachine.Orchestrator.SagaStateMachine;

namespace Saga.StateMachine.Orchestrator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

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
