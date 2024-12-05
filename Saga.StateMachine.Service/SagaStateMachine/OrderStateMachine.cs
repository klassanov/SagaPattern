using MassTransit;
using Saga.Contracts;

namespace Saga.StateMachine.Service.SagaStateMachine
{
    public class OrderStateMachine : MassTransitStateMachine<OrderState>
    {
        // Events
        public Event<OrderSubmitted> OrderSubmitted { get; private set; }
        public Event<PaymentFailed> PaymentFailed { get; private set; }
        public Event<PaymentProcessed> PaymentProcessed { get; private set; }


        // States
        public State Completed { get; private set; }
        public State Failed { get; private set; }
        public State ProcessingPayment { get; private set; }


        public OrderStateMachine()
        {
            //Events are correlated to the state machine instance by OrderId (=CorrelationId)
            Event(() => OrderSubmitted, x => x.CorrelateById(m => m.Message.OrderId));
            Event(() => PaymentFailed, x => x.CorrelateById(m => m.Message.OrderId));
            Event(() => PaymentProcessed, x => x.CorrelateById(m => m.Message.OrderId));

            //Property which contains the current state of the state machine
            InstanceState(x => x.CurrentState);

            //Behaviors

            //Initial State
            Initially(
                When(OrderSubmitted)

                    //Change state of the saga instance with the input data
                    .Then(context =>
                    {
                        context.Saga.OrderTotal = context.Message.Total;
                        context.Saga.OrderDate = DateTime.UtcNow;
                        context.Saga.CustomerEmail = context.Message.Email;
                    })

                    //Publish message to the message broker to trigger process payment
                    .PublishAsync(context => context.Init<ProcessPayment>(new
                    {
                        OrderId = context.Saga.CorrelationId,
                        Amount = context.Saga.OrderTotal
                    }))

                    //Change state machine stae
                    .TransitionTo(ProcessingPayment)
            );

            During(ProcessingPayment,
                When(PaymentProcessed)
                    .Then(context =>
                    {
                        context.Saga.PaymentIntentId = context.Message.PaymentIntentId;
                    })
                    .TransitionTo(Completed),
                    //.Finalize(),

                When(PaymentFailed)
                     .Then(context =>
                    {
                        context.Saga.PaymentIntentId = context.Message.PaymentIntentId;
                        context.Saga.FailureReason = context.Message.Reason;
                    })
                    .TransitionTo(Failed)
                    //.Finalize()
            );

            //SetCompletedWhenFinalized();

        }


    }
}
