using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace Saga.StateMachine.Service.SagaDatabaseContext
{
    public class OrderSagaDbContext : SagaDbContext
    {
        public OrderSagaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get
            {
                yield return new OrderStateMap();
            }
        }
    }
}
