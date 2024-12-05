using MassTransit;

namespace Saga.StateMachine.Service.SagaStateMachine
{
    //Represents the processing of 1 order
    public class OrderState : SagaStateMachineInstance
    {
        // Unique identifier of the instance
        public Guid CorrelationId { get; set; }

        // Current state of the order processing
        public string? CurrentState { get; set; }



        // BusinessData
        public decimal OrderTotal { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? CustomerEmail { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? FailureReason { get; set; }
    }
}
