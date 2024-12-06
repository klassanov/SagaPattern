using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Saga.StateMachine.Orchestrator.SagaStateMachine;

namespace Saga.StateMachine.Orchestrator.SagaDatabaseContext
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
