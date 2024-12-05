using Microsoft.EntityFrameworkCore;
using Saga.StateMachine.Service.SagaDatabaseContext;

namespace Saga.StateMachine.Service
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
