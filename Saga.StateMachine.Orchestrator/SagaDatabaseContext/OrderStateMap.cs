using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saga.StateMachine.Orchestrator.SagaStateMachine;

namespace Saga.StateMachine.Orchestrator.SagaDatabaseContext
{
    public class OrderStateMap : SagaClassMap<OrderState>
    {
        protected override void Configure(EntityTypeBuilder<OrderState> entity, ModelBuilder model)
        {
            entity.Property(x => x.CorrelationId).HasColumnName("OrderId");
        }
    }
}
