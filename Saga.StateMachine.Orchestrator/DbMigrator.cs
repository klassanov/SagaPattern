using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.StateMachine.Orchestrator.SagaDatabaseContext;

namespace Saga.StateMachine.Orchestrator
{
    public static class DbMigrator
    {
        public static void MigrateDb(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<OrderSagaDbContext>();
                //db.Database.EnsureCreated();
                db.Database.Migrate();
            }
        }
    }
}
